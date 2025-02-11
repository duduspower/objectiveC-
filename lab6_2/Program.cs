class Program
{
    public static void Main(String[] args)
    {
        string basePath = "C:\\Users\\Admin\\source\\repos\\objectiveCRepo";
        string fileName = "plikTekstowy.txt";
        string filePath = Path.Join(basePath, fileName);
        string text = File.ReadAllText(filePath);
        Console.WriteLine($"Zawartość pliku : {text}");
    }
}