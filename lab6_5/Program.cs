using System.Text.Json;
using System.Text.Json.Serialization;

class Program
{


    class Person
    {
        public Person(int id, string name, string surname, byte age, string phone)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.phone = phone;
        }

        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("surname")]
        public string surname { get; set; }
        [JsonPropertyName("age")]
        public byte age { get; set; }
        [JsonPropertyName("phone")]
        public string phone { get; set; }
    }

    interface IPersonRepository
    {

        public void create(Person person);

        public Person findById(int id);

        public void update(Person person);

        public void delete(int id);

        public List<Person> findAll();

        public void clearDb();
    }

    class FilePersonRepository : IPersonRepository
    {
        private static string DB_FILENAME = "dbPerson.json";
        private static string BASE_PATH = "C:\\Users\\Admin\\source\\repos\\objectiveCRepo";
        public FilePersonRepository()
        {

        }

        public void create(Person person)
        {
            List<Person> persons = findAll();
            if (persons.Find(p => person.id == p.id)!=null)
            {
                throw new ArgumentException("Person with that id already exist");
            }
            persons.Add(person);
            var serializedPersons = JsonSerializer.Serialize(persons);
            File.WriteAllText(getPath(),serializedPersons);
        }

        public void delete(int id)
        {
            string filePath = getPath();
            List<Person> persons = findAll();
            Person personToDelete = persons.Find(p => p.id == id);
            persons.Remove(personToDelete);
            var serialized = JsonSerializer.Serialize(persons);
            File.Delete(filePath);
            File.WriteAllText(filePath,serialized);
        }

        public List<Person> findAll()
        {
            string fileValue = File.ReadAllText(getPath());
            List<Person> persons = JsonSerializer.Deserialize<List<Person>>(fileValue);
            return persons;
        }

        public Person findById(int id)
        {
            List<Person>  persons = findAll();
            Person person = persons.Find(p => p.id == id);
            return person;
        }

        public void update(Person person)
        {
            Person foundPerson = findById(person.id);
            if (foundPerson == null)
            {
                throw new KeyNotFoundException($"Cannot find entity for given id : {person.id}");
            }
            delete(foundPerson.id);
            create(person);
        }

        private string getPath() {
            return Path.Join(BASE_PATH, DB_FILENAME);
        }

        public void clearDb() {
            string filePath = getPath();
            File.Delete(filePath);
            File.WriteAllText(filePath, "[]"); //must be [] otherwise will cause error on first deserialization
        }
    }

    public static void Main(String[] args)
    {
        IPersonRepository repository = new FilePersonRepository();
        Person person1 = new Person(1,"Mietek", "Bodzio",32, "111 111 111");
        Person person2 = new Person(2,"Piotr", "Brzęczeszczykiewicz",42, "222 222 222");
        Person person3 = new Person(3,"Andrzej", "Wiercipięta",56, "333 333 333");
        repository.create(person1);
        repository.create(person2);
        repository.create(person3);
        Person personFromRepository = repository.findById(person1.id);
        repository.delete(person1.id);
        List<Person> allPersons = repository.findAll();
        //for tesitng best to use is debugger in this case ;)
        repository.clearDb(); // for testing purpouses. Without that records will be overrided and problems will occur. It is only one of 5 tasks in this lab and it is preatty late to implement all of this(I need more free time in my life(working 10+hr daily in programming :))
    }
}
