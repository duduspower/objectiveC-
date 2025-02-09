class Program
{

    class Car
    {
        private string make;
        private string model;
        private string body;
        private int year;
        private long milage;

        public Car()
        {
            Console.WriteLine("Making car : \n Give make : ");
            this.make = Console.ReadLine();
            Console.WriteLine("Give model :");
            this.model = Console.ReadLine();
            Console.WriteLine("Give body :");
            this.body = Console.ReadLine();
            this.year = getYear();
            this.milage = getMilage();
        }

        private int getYear()
        {
            Console.WriteLine("Give year :");
            int year = Convert.ToInt16(Console.ReadLine());
            int currentYear = DateTime.Now.Year;
            if (year < 1900)
            {
                Console.WriteLine("There are no such a old cars. Give valid year");
                getYear();
            }
            else if (year > currentYear)
            {
                Console.WriteLine("You cannot have car that is released in next years");
                getYear();
            }
            return year;
        }

        private long getMilage()
        {
            Console.WriteLine("Give milage :");
            long milage = Convert.ToInt64(Console.ReadLine());
            if (milage < 0)
            {
                Console.WriteLine("You cannot have milage lower then zero");
                getMilage();
            }
            return milage;
        }

        virtual public string view(bool show)
        {
            string result = $"Showing car info : \n make : {make}, model : {model}, body : {body}, year : {year}, milage : {milage}";
            if (show)
            {
                Console.WriteLine(result);
            }
            return result;
        }

    }

    class PassengerCar : Car
    {
        private decimal weight;
        private float capacity;
        private decimal numberOfSeats;

        public PassengerCar() : base()
        {
            this.weight = getWeight();
            this.capacity = getCapacity();
            this.numberOfSeats = getSeats();
        }

        public override string view(bool show)
        {
            string result = base.view(false);
            result += $" weight : {weight}, capacity : {capacity}, number of seats : {numberOfSeats}";

            if (show)
            {
                Console.WriteLine(result);
            }
            return result;
        }

        private decimal getSeats()
        {
            Console.WriteLine("Give number of seats");
            decimal seats = Convert.ToDecimal(Console.ReadLine());
            if (seats > 7 || seats < 2)
            {
                Console.WriteLine("Invalid number of seats");
                getSeats();
            }
            return seats;
        }

        private decimal getWeight()
        {
            Console.WriteLine("Give weight in kilograms");
            decimal weight = Convert.ToDecimal(Console.ReadLine());
            if (weight < 2000 || weight > 4500)
            {
                Console.WriteLine("Invalid weight of vehicle. Should be between 2000-4500kg");
                getCapacity();
            }
            return weight;
        }

        private float getCapacity()
        {
            Console.WriteLine("Give capacity of vehicle's engine");
            float capacity = float.Parse(Console.ReadLine());
            if (capacity < 0.8 || capacity > 3.0)
            {
                Console.WriteLine("Invalid engine capacity. Should be between 0.8 - 3.0l");
                getCapacity();
            }
            return capacity;
        }

    }


    public static void Main(String[] args)
    {
        PassengerCar passengerCar = new PassengerCar();
        Car car1 = new Car();
        Car car2 = new Car();
        passengerCar.view(true);
        car1.view(true);
        car2.view(true);
    }
}
