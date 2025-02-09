class Program
{

    interface IPerson {
        string name { get; set; }
        string surname { get; set; }

        public string getFullName();
    }

    class Person:IPerson{
        public string name { get; set; }
        public string surname { get; set; }

        public string getFullName() {
            return this.name + " " + this.surname;
        }
    }

    interface IStudent:IPerson { 
        string school { get; set; }
        string fieldOfStudy { get; set; }
        int year { get; set; }
        int semester { get; set; }

        string viewAllStudentInfo();
    }

    class Student : IStudent {
        public string name { get; set; }
        public string surname { get; set; }

        public string school { get; set; }
        public string fieldOfStudy { get; set; }
        public int year { get; set; }
        public int semester { get; set; }

        public string getFullName() { 
            return this.name + " " + this.surname;
        }

        public string viewAllStudentInfo() {
            return $"{this.getFullName()}-{this.semester}{this.fieldOfStudy} {this.year} {this.school}";
        }
    }

    class StudentWSIIZ:Student {
        public string viewAllStudentInfo() { 
            return $"To jest student WSIIIZ!" + base.viewAllStudentInfo();
        }
    }



    public static void Main(String[] args)
    {
        List<Person> list = new List<Person>();
        Person person1 = new Person();
        Person person2 = new Person();
        Person person3 = new Person();
        Person person4 = new Person();
        person1.name = "Zuzanna";
        person1.surname = "Blicharska";
        person2.name = "Cecylia";
        person2.surname = "Pacholec";
        person3.name = "Ernest";
        person3.surname = "Trojanowicz";
        person4.name = "Leopold";
        person4.surname = "Opolski";
        list.Add(person1);
        list.Add(person2);
        list.Add(person3);
        list.Add(person4);
        viewAllPersonsInList(list);
        sortPersonsByName(list);
        Console.WriteLine("Sorted list : ");
        viewAllPersonsInList(list);
        List<Student> students = new List<Student>();
        Student student1 = new Student();
        Student student2 = new Student();
        StudentWSIIZ studentWSIIZ = new StudentWSIIZ();
        student1.name = "Andrzej";
        student1.surname = "Duda";
        student2.name = "Bolesław";
        student2.surname = "Chrobry";
        studentWSIIZ.name = "Mieszko";
        studentWSIIZ.surname = "Pierwszy";
        student1.school = "Sp4";
        student2.school = "Sp6";
        studentWSIIZ.school = "WSIIZ";
        student1.semester = 4;
        student2.semester = 6;
        studentWSIIZ.semester = 7;
        student1.year = 2023;
        student2.year = 2022;
        studentWSIIZ.year = 2021;
        student1.fieldOfStudy = "podstawowa";
        student2.fieldOfStudy = "podstawowa";
        studentWSIIZ.fieldOfStudy = "informatyka";
        students.Add(student1);
        students.Add(student2);
        students.Add(studentWSIIZ);
        students.ForEach(s => Console.WriteLine(s.viewAllStudentInfo()));
    }

    static void viewAllPersonsInList(List<Person> list)
    {
        string result = "";
        list.ForEach(person => result += person.getFullName() + ",");
        Console.WriteLine(result);
    }

    static List<Person> sortPersonsByName(List<Person> list) {
        list.Sort(new FullNameComparer());
        return list;
    }

    public class FullNameComparer : IComparer<Person>
    {
        int IComparer<Person>.Compare(Person? x, Person? y)
        {
            return string.Compare(x.getFullName(), y.getFullName());
        }
    }


}
