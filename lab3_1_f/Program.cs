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

        virtual public string view()
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

        public string getTitle()
        {
            return title;
        }

    }

    class Reader : Person
    {

        protected Book[] books;

        public Reader(string name, string surname, int age, Book[] books) : base(name, surname, age)
        {
            this.books = books;
        }

        public string viewReadedBooks()
        {
            string result = "Showing titles of readed books : {";
            //Console.WriteLine(result);

            for (int i = 0; i < books.Length; i++)
            {
                string temp = books[i].getTitle();
                //Console.WriteLine(temp);
                result += temp + ",";
            }

            string temp2 = "}";
            result += temp2;
            //Console.WriteLine(temp2);
            return result;
        }

        override public string view()
        {
            string result = "\nDisplaying info about reader : { \n" + base.view() + '\n';
            result += viewReadedBooks() + "}";
            Console.WriteLine(result);
            return result;
        }
    }

    class Reviewer(string name, string surname, int age, Program.Book[] books) : Reader(name, surname, age, books) {

        override public string view() {
            Random random = new Random();
            string result = "Showing information about reviews : {\n";

            for (int i = 0; i < books.Length; i++) { 
                result += books[i].getTitle() + ", wynik : " + random.Next(0, 100) + "\n";
            }

            result += "}";
            Console.WriteLine(result);
            return result;
        }

    }



    public static void Main(String[] args)
    {
        Person author1 = new Person("Dominik", "Duda", 21);
        Person author2 = new Person("Jakub", "Kowalski", 34);
        Person author3 = new Person("Andrzej", "Nowak", 69);

        string title1 = "Nad niemnem";
        string title2 = "Pod piecem lub nad piecem";
        string title3 = "Magiczna podróż przez życie";

        DateTime releasedAt1 = DateTime.Now;
        DateTime releasedAt2 = DateTime.Now;
        DateTime releasedAt3 = DateTime.Now;

        Book book1 = new Book(title1, author1, releasedAt1);
        Book book2 = new Book(title2, author2, releasedAt2);
        Book book3 = new Book(title3, author3, releasedAt3);

        Book[] books1 = new Book[2];
        books1[0] = book1;
        books1[1] = book2;

        Book[] books2 = new Book[2];
        books2[0] = book2;
        books2[1] = book3;

        Reader reader1 = new Reviewer("Andrzej", "Duda", 42, books1);
        Reader reader2 = new Reviewer("Jerzy", "Aksamit", 69, books2);

        reader1.view();
        reader2.view();
    }
}
