using System.Xml.Linq;

class Program
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

        public string view()
        {
            string info = $"Showing info about person : \n Name : {name} \n Surname : {surname} \n Age : {age}";
            return info;
        }

    }

    class Book
    {

        private string title;
        private Person author;
        private DateTime releasedAt;

        public Book(string title, Person author, DateTime releasedAt)
        {
            this.title = title;
            this.author = author;
            this.releasedAt = releasedAt;
        }

        public void view()
        {
            Console.WriteLine($"Showing info about book : \n Title : {title} \n Author : {author.view()} \n releasedAt : {releasedAt.ToString()}");
        }
    }

    public static void Main(String[] args)
    {
        Person author1 = new Person("Dominik", "Duda", 21);
        Person author2 = new Person("Jakub", "Kowalski", 34);
        Person author3 = new Person("Andrzej", "Nowak", 68);

        string title1 = "Nad niemnem";
        string title2 = "Pod piecem lub nad piecem";
        string title3 = "Magiczna podróż przez życie";

        DateTime releasedAt1 = DateTime.Now;
        DateTime releasedAt2 = DateTime.Now;
        DateTime releasedAt3 = DateTime.Now;

        Book book1 = new Book(title1, author1, releasedAt1);
        Book book2 = new Book(title2, author2, releasedAt2);
        Book book3 = new Book(title3, author3, releasedAt3);

        book1.view();
        book2.view();
        book3.view();
    }
}
