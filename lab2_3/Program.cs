class Program {

    class Student {
        private string name;
        private string surname;
        private int[] grades = [];

        public Student(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

        public decimal avg() {
            decimal result = 0;
            for (int i = 0; i < grades.Length; i++) { 
                result = result + grades[i];
            }
            result = result / grades.Length;
            Console.WriteLine($"Avg of grades is {result}");
            return result;
        }

        public void addGrade(int grade) {
            if (grade > 6 || grade < 1) {
                Console.WriteLine("Grade should be between 1 and 6");
                return;
            }
            grades = addElementToArray(grades, grade);
            Console.WriteLine($"Grade : {grade} added to grades!");
        }

        private int[] addElementToArray(int[] array, int number) {
            int[] result = new int[array.Length + 1];
            for (int i = 0; i < array.Length; i++) {
                result[i] = array[i];
            }
            result[array.Length] = number;
            return result;
        }

    }

    static void Main(string[] args)
    {
        Student student = new Student("Dominik", "Duda");
        student.addGrade(7);
        student.addGrade(0);
        student.addGrade(5);
        student.addGrade(2);
        student.addGrade(3);
        student.avg();
    }
}