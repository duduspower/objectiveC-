class Zadanie7
{
    static void Main(string[] args)
    {
        int n = getN();
        int[] table = getNumbers(n);
        int[] sorted = sort(table);
        print(sorted);
    }

    private static int getN()
    {
        Console.WriteLine("Podaj ile liczb ma zawierać lista : ");
        int n = Convert.ToInt16(Console.ReadLine());
        return n;
    }

    private static int[] getNumbers(int n)
    {
        int[] table = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Podaj liczbę : ");
            int temp = Convert.ToInt16(Console.ReadLine());
            table[i] = temp;
        }
        return table;
    }

    private static int[] sort(int[] table)
    {
        int[] result = new int[table.Length];
        int min = table[0];
        int minIndex = 0;
        int length = table.Length;
        for (int i = 0; i < length; i++)
        {
            min = table[0];
            minIndex = 0;
            for (int j = 0; j < table.Length; j++)
            {
                if (min > table[j])
                {
                    min = table[j];
                    minIndex = j;
                }
            }
            result[i] = min;
            table = deleteIndex(table, minIndex);
        }
        return result;
    }

    private static int[] deleteIndex(int[] table, int index)
    {
        int[] result = new int[table.Length - 1];
        int counter = 0;
        for (int i = 0; i < table.Length; i++)
        {
            if (i == index)
            {
                continue;
            }
            result[counter] = table[i];
            counter++;
        }
        return result;
    }


    private static void print(int[] table)
    {
        Console.WriteLine("Posortowana tablica : ");
        for (int i = 0; i < table.Length; i++)
        {
            Console.WriteLine(table[i]);
        }

    }
}

