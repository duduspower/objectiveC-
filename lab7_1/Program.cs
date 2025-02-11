using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;

class Project() // There is an sql file that creates everything in db side
{

    public class Client
    {
        public Client(int id, string name, string surname, string email, string phone, DateTime registerTime)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.phone = phone;
            this.registerTime = registerTime;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime registerTime { get; set; }

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
            DateTime registerAt = getRegisterTime();

            Client result = new Client(id, name, surname, email, phone, registerAt);
            validateClient(result);
            return result;
        }

        private static DateTime getRegisterTime()
        {
            string format = "dd-MM-yyyy HH:mm";
            Console.WriteLine($"Give register time (format {format}): ");
            string registerTimeStringValue = Console.ReadLine();
            DateTime dateTime = DateTime.ParseExact(registerTimeStringValue, format, CultureInfo.InvariantCulture);
            return dateTime;
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
                Console.WriteLine($"Registered Time : {client.registerTime}");
                Console.WriteLine("}");
            }
            else {
                Console.WriteLine("Empty result...");
            }
        }
    }

    class DatabaseManager
    {
        private static string CONNECTION_STRING = "Server=localhost;Database=lab7_1;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;"; // change for used db

        public Object executeQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))//vulnuleable with sql injection!!!
                {
                    return command.ExecuteNonQuery();
                }
            }
        }

        public List<Client> executeSelectAllQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Client> clients = new List<Client>();
                        while (reader.Read())
                        {
                            Client client = new Client(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetDateTime(5));
                            clients.Add(client);
                        }
                        return clients;
                    }
                }

            }
        }

        public Client executeSelectQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Client client = new Client(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetDateTime(5));
                            return client;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }

            }
        }
    }

    class Repository // there should be entity classes and infrastructure abstraction level but i propably wouldn't change database here so i think it is waste of time...
    {


        private DatabaseManager manager;

        public Repository(DatabaseManager manager)
        {
            this.manager = manager;
        }

        public void insert(Client client)
        {
            string query = $"INSERT into client (id,name,surname,email,phone,registerTime) VALUES ({client.id}, '{client.name}', '{client.surname}', '{client.email}', '{client.phone}', '{client.registerTime}')";
            manager.executeQuery(query);
        }

        public List<Client> findAll()//throws error if db is empty
        {
            string query = "SELECT * from client";
            List<Client> clients = manager.executeSelectAllQuery(query);
            return clients;
        }

        public Client findById(int id)
        {
            string query = $"SELECT * from client where id = {id}";
            Client client = (Client)manager.executeSelectQuery(query);
            return client;
        }


        public void delete(int id)
        {
            string query = $"DELETE from client where id = {id}";
            manager.executeQuery(query);
        }

        public Client findBySurname(string surname)
        {
            string query = $"SELECT * from client where surname = '{surname}'";
            Client client = (Client)manager.executeSelectQuery(query);
            return client;
        }

        public List<Client> getPage(int pageSize, int pageNumber)
        {
            //can be implemented that way it is making longer query but for result size < 1000 records it will be small diference if we process it in this way or in database(also records are small and without dependencies)
            List<Client> allClients = findAll();
            int skipCount = (pageNumber - 1) * pageSize;

            // Pobierz stronę wyników
            List<Client> page = allClients.Skip(skipCount).Take(pageSize).ToList();
            return page;
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
            "Find client by surname (5)",
            "Get page of clients    (6)" };
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
            Console.WriteLine($"Operation Choosed : {operations[answear]}");
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
                case 5:
                    handleFindBySurname();
                    break;
                case 6:
                    handleGetPage();
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

        public void handleFindBySurname()
        {
            Console.WriteLine("Give surame : ");
            string surname = Console.ReadLine();
            Client client = repository.findBySurname(surname);
            Client.printClient(client);
        }

        public void handleGetPage()
        {
            Console.WriteLine("Give page size");
            int pageSize = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Give page number");
            int pageNumber = Convert.ToInt16(Console.ReadLine());
            List<Client> page = repository.getPage(pageSize, pageNumber);
            page.ForEach(c => Client.printClient(c));
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
        Repository repository = new Repository(new DatabaseManager());
        UserInterface userInterface = new UserInterface(repository);
        bool keepAlive = true;
        while (keepAlive)
        {
            userInterface.handleOperationChoose();
        }
    }
}
