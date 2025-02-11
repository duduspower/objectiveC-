using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Transactions;

class Program
{

    class PopulationDiff
    {

        public PopulationDiff(long from, long to)
        {
            this.from = from; this.to = to;
        }

        public long from { get; }
        public long to { get; }


    }

    class JsonRecord
    {
        [JsonPropertyName("indicator")]
        public Indicator Indicator { get; set; }

        [JsonPropertyName("country")]
        public Country Country { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("decimal")]
        public string Decimal { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }
    }

    class Indicator
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    class Country
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }


    private static string getFileStringValue()
    {
        string basePath = "C:\\Users\\Admin\\source\\repos\\objectiveCRepo";
        string fileName = "db.json";
        string filePath = Path.Join(basePath, fileName);
        string text = File.ReadAllText(filePath);
        return text;
    }

    private static List<JsonRecord> getJsons(string fileValue)
    {
        List<JsonRecord> jsonRecord = JsonSerializer.Deserialize<List<JsonRecord>>(fileValue);
        return jsonRecord; //todo fix json deserialization
    }

    private static long getPopulationForInYear(string place, int year, List<JsonRecord> jsons)
    {
        string record = jsons.Find(j => j.Country.Value.Equals(place) && Convert.ToInt16(j.Date) == year).Value;
        return Convert.ToInt32(record);
    }

    private static PopulationDiff getPopulationDiffForWithYearsBetween(string place, int yearFrom, int yearTo, List<JsonRecord> jsons)
    {
        long from = getPopulationForInYear(place, yearFrom, jsons);
        long to = getPopulationForInYear(place, yearTo, jsons);
        return new PopulationDiff(from, to);
    }

    private static double getPercentage(PopulationDiff diff)
    {
        return ((double)diff.to / (double)diff.from) * 100;
    }

    private static PopulationDiff getPopulationDiffForIndia(List<JsonRecord> jsons)
    {
        return getPopulationDiffForWithYearsBetween("India", 1970, 2000, jsons);
    }

    private static PopulationDiff getPopulationDiffForUSA(List<JsonRecord> jsons)
    {
        return getPopulationDiffForWithYearsBetween("United States", 1965, 2010, jsons);
    }

    private static PopulationDiff getPopulationDiffForChina(List<JsonRecord> jsons)
    {
        return getPopulationDiffForWithYearsBetween("China", 1980, 2018, jsons);
    }

    private static double getPercentageForYearBefore(string place, int year, List<JsonRecord> jsons)
    {
        PopulationDiff diff = getPopulationDiffForWithYearsBetween(place, year - 1, year, jsons);
        return getPercentage(diff);
    }

    public static void Main(String[] args)
    {
        string jsonText = getFileStringValue();
        List<JsonRecord> records = getJsons(jsonText);
        PopulationDiff diffForIndia = getPopulationDiffForIndia(records);
        Console.WriteLine("diff For India: from : " + diffForIndia.from + " to: " + diffForIndia.to);
        PopulationDiff diffForUSA = getPopulationDiffForUSA(records);
        Console.WriteLine("diff For USA: from : " + diffForUSA.from + " to : " + diffForUSA.to);
        PopulationDiff diffForChina = getPopulationDiffForChina(records);
        Console.WriteLine("diff For China: from : " + diffForChina.from + " to : " + diffForChina.to);
        PopulationDiff customDiffForUser = getPopulationDiffForWithYearsBetween("India", 1960, 2018, records);
        Console.WriteLine("diff for India Custom: from : " + customDiffForUser.from + " to: " + customDiffForUser.to);
        double percentageDiff = getPercentageForYearBefore("India", 2017, records); //tak wiem nie jest to najbardziej optymalny sposób na wyciągnięcie tych danych(lepiej by było dodać tablicę elementów to wyszukiwania i iterować jeden do n elementów tablicy ale to rozwiązanie które zrobiłem jest dużo szybsze w implementacji)
        Console.WriteLine("percentage diff for custom : " + percentageDiff + "%");
    }
}


//Pozwalający sprawdzić ile wynosi różnica populacji pomiędzy rokiem 1970 a 2000 dla Indii
//• Pozwalający sprawdzić ile wynosi różnica populacji pomiędzy rokiem 1965 a 2010 dla USA
//• Pozwalający sprawdzić ile wynosi różnica populacji pomiędzy rokiem 1980 a 2018 dla Chin
//• Pozwalający użytkownikowi na wybranie roku i kraju, z którego populację chciałby wyświetlić.
//• Pozwalający użytkownikowi na sprawdzenie różnicy populacji dla wskazanego zakresu lat i
//kraju,
//• Pozwalający użytkownikowi na sprawdzenie procentowego wzrostu populacji dla każdego kraju
//względem roku poprzedniego do wskazanego,

