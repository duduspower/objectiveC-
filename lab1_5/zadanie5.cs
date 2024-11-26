class Zadanie5
{
    static void Main(string[] args)
    {
        for (int i = 20; i >= 0; i--)
        {
            if (isEqualForeginNumbers(i)) {
                continue;
            }
            Console.WriteLine(i);
        } 
    }

    private static bool isEqualForeginNumbers(int number) {
        return number == 2 || number == 6 || number == 9 || number == 15 || number == 19;
    }
}