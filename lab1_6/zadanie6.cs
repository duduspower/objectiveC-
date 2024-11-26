class Zadanie6
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Podaj liczbę całkowitą");
            int number = Convert.ToInt16(Console.ReadLine());
            if (number < 0) {
                Console.WriteLine("Podano liczbę mniejszą od 0 kończenie programu");
                break;
            } 
        }
    }
}