class Zadanie3
{
    static void Main(string[] args)
    {
        int n = 10;
        Console.WriteLine("Program do wykonywania operacji na liście");
        Console.WriteLine($"Program zapyta Cię o podanie {n} liczb");
        int[] table = getTable(n);
        displayFromFirstToLast(table);
        displayFromLastToFirst(table);
        displayEvenIndexes(table);
        displayUnEvenIndexes(table);
    }

    private static int [] getTable(int n) {
        int[] table = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Podaj {i} liczbę");
            table[i] = Convert.ToInt16(Console.ReadLine());
        }
        return table;
    }

    private static void displayFromFirstToLast(int[] table) {
        Console.WriteLine("\n Wypisywanie listy od pierwszego do ostatniego indeksu");
        for (int i = 0; i < table.Length; i++) {
            Console.WriteLine(table[i]);
        }
    }

    private static void displayFromLastToFirst(int[] table) {
        Console.WriteLine("\n Wypisywanie listy od ostatniego do pierwszego indeksu");
        for (int i = table.Length - 1; i >= 0 ; i--)
        {
            Console.WriteLine(table[i]);
        }
    }

    private static void displayEvenIndexes(int[] table) {
        Console.WriteLine("\n Wypisywanie listy zawierającej parzyste indeksy");
        for (int i = 0; i < table.Length; i+=2)
        {
            Console.WriteLine(table[i]);
        }
    }

    private static void displayUnEvenIndexes(int[] table) {
        Console.WriteLine("\n Wypisywanie listy zawierającej nie parzyste indeksy");
        for (int i = 1; i < table.Length; i+=2)
        {
            Console.WriteLine(table[i]);
        }
    }
}