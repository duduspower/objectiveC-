namespace Program
{
    class Person
    {
        private string name;
        private string surname;
        private int age;

        public Person(string name, string surname, int age)
        {
            if (name.Length <= 2)
            {
                throw new Exception("Invalid name length exception");
            }
            if (surname.Length <= 2)
            {
                throw new Exception("Invalid surname length exception");
            }
            if (age < 0)
            {
                throw new Exception("Age cannot be lower then zero");
            }
            this.name = name;
            this.surname = surname;
            this.age = age;
        }

        public void showInfo()
        {
            Console.WriteLine($"Showing info about person : \n Name : {name} \n Surname : {surname} \n Age : {age}");
        }
    }

}