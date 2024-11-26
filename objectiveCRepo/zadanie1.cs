class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Program do obliczania funkcji kwadratowej");
        Console.WriteLine("Pobieranie funkcji w postaci kanonicznej");

        Console.WriteLine("Podaj a : ");
        int a = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Podaj b : ");
        int b = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Podaj c : ");
        int c = Convert.ToInt16(Console.ReadLine());

        int delta = (b * b) - (4 * a * c);
        double sqrtDelta = Math.Sqrt(delta);
        double aDouble = Convert.ToDouble(a);
        double bDouble = Convert.ToDouble(b);
        Console.WriteLine($"Delta wynosi {delta}");

        if (delta > 0)
        {
            Console.WriteLine("funkcja ma 2 miejsca zerowe");
            double x1 = calculateX1(aDouble, bDouble, sqrtDelta);
            double x2 = calculateX2(aDouble, bDouble, sqrtDelta);
            Console.WriteLine($"Miejsca zerowe to : {x1} i {x2}");
            return;
        }
        else if (delta == 0)
        {
            Console.WriteLine("funkcja ma 1 miejsce zerowe");
            double x1 = calculateX1(aDouble, bDouble, sqrtDelta);
            Console.WriteLine($"Miejsce zerowe to : {x1}");
            return;
        }
        else {
            Console.WriteLine("funkcja nie ma miejsc zerowych");
            return;
        }
    }

    private static double calculateX1(double a, double b, double sqrtDelta) {
        return (-b - sqrtDelta) / (2 * a);
    }

    private static double calculateX2(double a, double b, double sqrtDelta) { 
        return (-b + sqrtDelta) / (2 * a);
    }
}