enum Color
{
    RED, BLUE, YELLOW, ORANGE, VIOLET, WHITE, BLACK, GREEN
}

class Program
{


    public static void Main(String[] args)
    {
        Array arrayOfColors = Enum.GetValues(typeof(Color));
        List<Color> colorsAvailable = new List<Color>((IEnumerable<Color>)arrayOfColors);
        Console.WriteLine(colorsAvailable.ToString());
        Console.WriteLine("Gra w zgadywanie kolorów");
        Color randomColor = getRandomColor(colorsAvailable);
        bool incorrectAnswer = true;
        while (incorrectAnswer)
        {
            Console.WriteLine("Wybierz kolor z wypisanych i wpisz jego nazwę do konsoli");
            printListOfColors(colorsAvailable);
            string colorFromConsole = Console.ReadLine();
            try
            {
                Color choosedColor = (Color)Enum.Parse(typeof(Color), colorFromConsole);
                if (checkColorMatch(choosedColor, randomColor))
                {
                    incorrectAnswer = false;
                    Console.WriteLine($"Brawo zgadłeś kolor! Twoja odpowiedź to : {choosedColor.ToString()}");
                    break;
                }
                else
                {
                    Console.WriteLine("Nie trafiłeś koloru. Przykro mi :( ...");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Wybrano nie prawidłowy kolor. Wpisz ponownie!");
            }
        }
    }

    private static void printListOfColors(List<Color> colors)
    {
        colors.ForEach(color => Console.Write(color + ","));
    }

    private static Color getRandomColor(List<Color> availableColors)
    {
        Random random = new Random();
        int numberOfColor = random.Next(availableColors.Count);
        return availableColors[numberOfColor];
    }

    private static bool checkColorMatch(Color toCheck, Color generated)
    {
        return toCheck.Equals(generated);
    }
}
