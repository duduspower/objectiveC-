//most of code is reused from previous task
using CsvHelper;
using System.Globalization;
using System.Text.RegularExpressions;
using static Project;

class Project() // There is an sql file that creates everything in db side
{

    public class Client
    {
        public Client(int id, string name, string surname, string email, string phone)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.phone = phone;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

        public static Client getOtherRequiredDataForClientCreation(int id)
        {
            Console.WriteLine("Give name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Give surname : ");
            string surname = Console.ReadLine();
            Console.WriteLine("Give email : ");
            string email = Console.ReadLine();
            Console.WriteLine("Give phone : ");
            string phone = Console.ReadLine();

            Client result = new Client(id, name, surname, email, phone);
            validateClient(result);
            return result;
        }

        private static void validateClient(Client client)
        {
            validateEmail(client.email);
            validatePhone(client.phone);
        }

        private static void validateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(email, pattern))
            {
                throw new ArgumentException("Email doesn't match given pattern");
            }
        }

        private static void validatePhone(string phone)
        {
            string pattern = @"^\+?\d{1,3}?[-.\s]?\(?\d{1,4}?\)?[-.\s]?\d{1,4}[-.\s]?\d{1,4}[-.\s]?\d{1,9}$";
            if (!Regex.IsMatch(phone, pattern))
            {
                throw new ArgumentException("Phone doesn't match given pattern");
            }
        }

        public static void printClient(Client client) // maybe should be another class Client Helper for all these helping methods?
        {
            if (client != null)
            {
                Console.WriteLine("Printing client : {");
                Console.WriteLine($"Id : {client.id}");
                Console.WriteLine($"Name : {client.name}");
                Console.WriteLine($"Surname : {client.surname}");
                Console.WriteLine($"Email : {client.email}");
                Console.WriteLine($"Phone : {client.phone}");
                Console.WriteLine("}");
            }
            else
            {
                Console.WriteLine("Empty result...");
            }
        }
    }

    class Repository // there should be entity classes and infrastructure abstraction level but i propably wouldn't change database here so i think it is waste of time...
    {
        private string FILE_PATH = "C:\\Users\\Admin\\source\\repos\\objectiveCRepo\\clients.csv";

        public void insert(Client client)
        {
            using (var writer = new StreamWriter(FILE_PATH, append: true))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecord(client);
                csv.NextRecord();
            }
        }

        public List<Client> findAll()
        {
            using (var reader = new StreamReader(FILE_PATH))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Client>();
                return records.ToList();
            }
        }

        public Client findById(int id)
        {
            return findAll().Find(c => c.id == id);
        }


        public void delete(int id)
        {
            List<Client> all = findAll();//redundant findAll call can be optimize in future
            int index = all.FindIndex(c => c.id == id);
            if (index == -1) {
                throw new ArgumentException("Entity with given id not exist");
            }
            all.RemoveAt(index);
            string headers = File.ReadLines(FILE_PATH).First();
            File.Delete(FILE_PATH);
            File.WriteAllText(FILE_PATH, headers + "\r\n");
            using (var writer = new StreamWriter(FILE_PATH, append: true))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                all.ForEach(c =>
                {
                    csv.WriteRecord(c);
                    csv.NextRecord();
                });

            }
        }
    }

    interface Operation
    {
        public string getName();
        public void execute();

    }

    class UserInterface // global error handling is good option to implement here but it isn't part of exercise soo...
    {
        List<string> operations = new List<string>() {
            "Show all clients       (0)",
            "Show client by id      (1)",
            "Add client             (2)",
            "Update client          (3)",
            "Delete client          (4)",
            "EXIT                   (-1)"
        };
        Repository repository;

        public UserInterface(Repository repository)
        {
            this.repository = repository;
        }

        public void printOperations()
        {
            Console.WriteLine("\n\n\nChoose operation : ");
            operations.ForEach(o => Console.WriteLine(o));
        }
        public int getIntInputFromUser()
        {
            string answear = Console.ReadLine();
            return Convert.ToInt32(answear);
        }


        public void handleOperationChoose()
        {
            printOperations();
            int answear = getIntInputFromUser();
            if (answear > 0)
            {
                Console.WriteLine($"Operation Choosed : {operations[answear]}");
            }
            switch (answear)
            {
                case 0:
                    handleShowAll();
                    break;
                case 1:
                    handleShowById();
                    break;
                case 2:
                    handleAdd();
                    break;
                case 3:
                    handleUpdate();
                    break;
                case 4:
                    handleDelete();
                    break;
                case -1:
                    handleExit();
                    break;
            }
        }

        public void handleShowAll()
        {
            repository.findAll().ForEach(c => Client.printClient(c));
        }

        public void handleShowById()
        {
            Client client = repository.findById(getId());
            Client.printClient(client);
        }

        public void handleAdd()
        {
            int id = getId();
            Client client = repository.findById(id);
            if (client != null)
            {
                throw new ArgumentException("Client with that id already exist");
            }
            Client toSave = Client.getOtherRequiredDataForClientCreation(id);
            repository.insert(toSave);
        }

        public void handleUpdate()
        {
            int id = getId();
            Client client = repository.findById(id);
            if (client == null)
            {
                throw new ArgumentException("Client with that id not exist");//there should be other type of exception(Entity not found)(for future refactoring)(if any will ocurr)
            }
            Client toSave = Client.getOtherRequiredDataForClientCreation(id);
            repository.delete(id);
            repository.insert(toSave); // in future can be changed to update query but for now it is ok
        }

        public void handleDelete()
        {
            repository.delete(getId());
        }

        public void handleExit()
        {
            Console.WriteLine("Exiting wit code 0");
            Environment.Exit(0);
        }


        private int getId()
        {
            Console.WriteLine("Give id : ");
            int id = getIntInputFromUser();
            return id;
        }
    }

    public static void Main(String[] args)
    {
        Repository repository = new Repository();
        UserInterface userInterface = new UserInterface(repository);
        bool keepAlive = true;
        while (keepAlive)
        {
            userInterface.handleOperationChoose();
        }
    }
}
