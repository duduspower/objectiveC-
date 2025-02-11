class Program {
    public static void Main(String[] args)
    {
        string sufix = "w69775";
        Console.WriteLine("Podaj nazwę pliku : ");
        string fileName = Console.ReadLine();
        Console.WriteLine("Podaj co ma być wpisane do pliku : ");
        string fileValue = Console.ReadLine();
        File.WriteAllText(fileName + "_" + sufix, fileValue);
    }
}
