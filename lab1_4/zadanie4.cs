class Zadanie4
{
    static void Main(string[] args)
    {
        int n = 10;
        Console.WriteLine("Program do wykonywania operacji na liście");
        Console.WriteLine($"Program zapyta Cię o podanie {n} liczb");
        int[] table = getTable(n);
        int sum = sumTable(table);
        int multiply = multiplyTable(table);
        int avg = calculateAvg(table, sum);
        int max = findMax(table);
        int min = findMin(table);
        Console.WriteLine($"Suma : {sum}");
        Console.WriteLine($"Iloczyn : {multiply}");
        Console.WriteLine($"Średnia : {avg}");
        Console.WriteLine($"Maksimum : {max}");
        Console.WriteLine($"Minimum : {min}");
    }

    private static int[] getTable(int n)
    {
        int[] table = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Podaj {i} liczbę");
            table[i] = Convert.ToInt16(Console.ReadLine());
        }
        return table;
    }

    private static int sumTable(int[] table) {
        int sum = 0;

        for (int i = 0; i < table.Length; i++)
        {
            sum += table[i];
        }
        return sum;
    }

    private static int multiplyTable(int[] table)
    {
        int multiply = 1;

        for (int i = 0; i < table.Length; i++)
        {
            multiply = multiply * table[i];
        }
        return multiply;
    }

    private static int calculateAvg(int[] table, int sum) {
        return sum / table.Length;
    }

    private static int findMax(int[] table) {
        int max = table[0];
        for (int i = 0; i < table.Length; i++) {
            if (max < table[i]) {
                max = table[i];
            }
        }
        return max;
    }

    private static int findMin(int[] table)
    {
        int min = table[0];
        for (int i = 0; i < table.Length; i++)
        {
            if (min > table[i])
            {
                min = table[i];
            }
        }
        return min;
    }
}