class Program {

    class Car {
        private string make;
        private string model;
        private string body;
        private int year;
        private int milage;

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

        private int getYear() {
            Console.WriteLine("Give year :");
            int year = Convert.ToInt16(Console.ReadLine());
            int currentYear = DateTime.Now.Year;
            if (year < 1900)
            {
                Console.WriteLine("There are no such a old cars. Give valid year");
            }
            else if (year > currentYear) {
                Console.WriteLine("You cannot have car that is released in next years");
            }
            else
            {
                getYear();
            }
            return year;
        }

        private int getMilage() {
            Console.WriteLine("Give milage :");
            int milage = Convert.ToInt16(Console.ReadLine());
            if (milage < 0)
            {
                Console.WriteLine("You cannot have milage lower then zero");
            }
            else {
                getMilage();
            }
            return milage;
        }

        virtual public string view(bool show) {
            string result = $"Showing car info : \n make : {make}, model : {model}, body : {body}, year : {year}, milage : {milage}";
            if (show) {
                Console.WriteLine(result);
            }
            return result ;
        } 

    }

    class PassengerCar : Car {
        private decimal weight;
        private decimal capacity;
        private decimal numberOfSeats;

        public PassengerCar() : base()
        {
            Console.WriteLine("Give weight :");
            this.weight = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Give capacity :");
            this.capacity = Convert.ToDecimal(Console.ReadLine());
            this.numberOfSeats = getSeats();
        }

        public override string view(bool show)
        {
            string result = base.view(show);
            result += $"weight : {weight}, capacity : {capacity}";

            if (show)
            {
                Console.WriteLine(result);
            }
            return result;
        }

        private decimal getSeats() {
            Console.WriteLine("Give number of seats");
            decimal seats = Convert.ToDecimal(Console.ReadLine());
            return seats;
        }

        private decimal getWeight() { 
        
        }

    }


    public static void Main(String[] args) {

    }
