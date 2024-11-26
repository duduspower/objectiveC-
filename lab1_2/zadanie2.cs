class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running) {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("(1)Dodawanie");
            Console.WriteLine("(2)Odejmowanie");
            Console.WriteLine("(3)Mnożenie");
            Console.WriteLine("(4)Dzielenie");
            Console.WriteLine("(5)Potęgowanie");
            Console.WriteLine("(6)Pierwiastkowanie");
            Console.WriteLine("(7)Wartości sin i cos");
            Console.WriteLine("(0)Wyjście z aplikacji :( ");
            Console.WriteLine("");
            Console.WriteLine("Wybierz opcję : ");
            int option = Convert.ToInt16(Console.ReadLine());
            switch (option) {
                case 0:
                    Console.WriteLine("Zatrzymywanie aplikacji...");
                    running = false;
                    break;
                case 1:
                    Console.WriteLine("Wybrano operację : Dodawanie");
                    dodawanie();
                    break;
                case 2:
                    Console.WriteLine("Wybrano operację : Odejmowanie");
                    odejmowanie();
                    break;
                case 3:
                    Console.WriteLine("Wybrano operację : Mnożenie");
                    mnozenie();
                    break;
                case 4:
                    Console.WriteLine("Wybrano operację : Dzielenie");
                    dzielenie();
                    break;
                case 5:
                    Console.WriteLine("Wybrano operację : Potęgowanie");
                    potegowanie();
                    break;
                case 6:
                    Console.WriteLine("Wybrano operację : Pierwiastkowanie");
                    pierwiastkowanie();
                    break;
                case 7:
                    Console.WriteLine("Wybrano operację : Wartości funkcji trygonometrycznych");
                    wartoscitrygonometryczne();
                    break;
            }
            
        }
    }
    private static void printAnswer(double wynik) {
        Console.WriteLine($"Wynik : {wynik}");
    }

    private static double podajLiczbe(char letter) { 
        Console.WriteLine($"Podaj {letter} : ");
        return Convert.ToDouble(Console.ReadLine());
    }

    private static void dodawanie() {
        double a = podajLiczbe('a');
        double b = podajLiczbe('b');
        double wynik = a + b;
        printAnswer(wynik);
         
    }

    private static void odejmowanie()
    {
        double a = podajLiczbe('a');
        double b = podajLiczbe('b');
        double wynik = a - b;
        printAnswer(wynik);
    }

    private static void mnozenie()
    {
        double a = podajLiczbe('a');
        double b = podajLiczbe('b');
        double wynik = a * b;
        printAnswer(wynik);
    }

    private static void dzielenie()
    {
        double a = podajLiczbe('a');
        double b = podajLiczbe('b');
        double wynik = a / b;
        printAnswer(wynik);
    }
    private static void potegowanie()
    {
        double a = podajLiczbe('a');
        double wynik = a * a;
        printAnswer(wynik);
    }

    private static void pierwiastkowanie()
    {
        double a = podajLiczbe('a');
        double wynik = Math.Sqrt(a);
        printAnswer(wynik);
    }

    private static void wartoscitrygonometryczne()
    {
        Console.WriteLine("Podaj kąt w stopniach");
        double degrees = Convert.ToDouble(Console.ReadLine());
        double radians = degrees * Math.PI / 180;
        double sinValue = Math.Sin(radians);
        double cosValue = Math.Cos(radians);

        Console.WriteLine($"Dla kąta {degrees}°:");
        Console.WriteLine($"Sinus: {sinValue}");
        Console.WriteLine($"Cosinus: {cosValue}");
    }
}