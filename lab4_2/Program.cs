class Program
{

    class Person
    {
        private string name;
        private string surname;
        private long pesel;
        private byte age;
        private bool gender;//true is women false is men
        private string educationInfo;

        public Person(byte age, bool gender, string educationInfo)
        {
            this.age = age;
            this.gender = gender;
            this.educationInfo = educationInfo;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setSurname(string surname)
        {
            this.surname = surname;
        }

        public void setPesel(long pesel)
        {
            this.pesel = pesel;
        }

        public byte getAge()
        {
            return this.age;
        }

        public string getGender()
        {
            return this.gender ? "woman" : "men";
        }

        public string getEducationInfo()
        {
            return this.educationInfo;
        }

        public string getFullName()
        {
            return this.name + this.surname;
        }

        public virtual bool canGoHomeAlone()
        {
            if (age > 12)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Student:Person
    {

        private string school;
        private bool canGoAlone;

        public Student(byte age, bool gender, string educationInfo) : base(age, gender, educationInfo)
        {
        }

        public void setSchool(string school)
        { // nie widzę tutaj sensu 2 metod do ustawiania szkół. Moim zdaniem ogólnie to zadanie jest źle poskładane i powinno być poprawione :(
            this.school = school;
        }

        public void setCanGoHomeAlone(bool can)
        {
            this.canGoAlone = can;
        }

        public override bool canGoHomeAlone()
        {
            if (canGoAlone != null) {
                return canGoAlone;
            }
            return base.canGoHomeAlone();
        }

        public string info() {
            return "Can go home alone if kid has more than 12 yo or if canGoHomeAlone is set to true";
        }
    }


    class Teacher:Person
    {
        private string academicTitle;
        List<Student> studentsInClass;

        public Teacher(byte age, bool gender, string educationInfo, string academicTitle, List<Student> studentsInClass):base(age,gender,educationInfo)
        {
            this.academicTitle = academicTitle;
            this.studentsInClass = studentsInClass;
        }

        public string whichStudentsCanGoHomeALone() {
            string result = "";
            this.studentsInClass.ForEach(s => result += $"Student with fullname : {s.getFullName} can go home alone : {s.canGoHomeAlone}");
            return result;
        }
    }

    public static void Main(String[] args)
    {

    }
}
