class Program {

    private static int howManyFemalesInPesels(string[] pesels)
    {
        int result = 0;
        for (int i = 0; i < pesels.Length; i++) {
            if (pesels[i][9] % 2 == 0) {
                result++;
            }
        }
        return result;
    }

    public static void Main(String[] args) {
        string basePath = "C:\\Users\\Admin\\source\\repos\\objectiveCRepo";
        string fileName = "pesele.txt";
        string filePath = Path.Join(basePath, fileName);
        string pesels = File.ReadAllText(filePath);
        string[] tableOf = pesels.Split("\n");
        int numberOfFemales = howManyFemalesInPesels(tableOf);
        Console.WriteLine($"Number of females pesels are : {numberOfFemales}");
    }
}