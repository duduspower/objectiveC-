enum Operation{ ADD, SUBSTRACT, MULTIPLY, DIVIDE }

class Program {

    class Calculator {

        public static double performOperation(double a, double b, Operation operation) {
            switch(operation){ 
                case Operation.ADD:
                    return add(a, b);
                case Operation.SUBSTRACT:
                    return substract(a, b);
                case Operation.MULTIPLY:
                    return multiply(a, b);
                case Operation.DIVIDE:
                    return divide(a, b);
                default:
                    throw new InvalidOperationException("This method not support this type of operation...");
            }
        }

        private static double add(double a, double b) {
            double result = a + b;
            Console.WriteLine($"Adding : {result}");
            return result;
        }

        private static double substract(double a, double b) {
            double result = a - b;
            Console.WriteLine($"Substraction {result}");
            return result;
        }

        private static double multiply(double a, double b) {
            double result = a * b;
            Console.WriteLine($"Multiplication {result}");
            return result;
        }

        private static double divide(double a, double b) {
            if (b == 0) {
                throw new DivideByZeroException("You cannot divide by 0");
            }
            double result = 0;
            result = a / b;
            Console.WriteLine($"Division {result}");
            return result;
        }
    }

    class SafeNumberReader {
        public static double getNumberSafe()
        {
            Console.WriteLine("Podaj liczbę : ");
            double number = 0;
            bool flag = true;
            while (flag)
            {
                try
                {
                    string numberString = Console.ReadLine();
                    number = Convert.ToDouble(numberString);
                    flag = false;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid number format...");
                }
            }
            return number;
        }
    }

    public static void Main(String[] args)
    {
        double a = SafeNumberReader.getNumberSafe();
        double b = SafeNumberReader.getNumberSafe();
        double result1 = Calculator.performOperation(a, b, Operation.ADD);
        double result2 = Calculator.performOperation(a, b, Operation.SUBSTRACT);
        double result3 = Calculator.performOperation(a, b, Operation.MULTIPLY);
        double result4 = Calculator.performOperation(a, b, Operation.DIVIDE);
        List<double> results = new List<double>() { result1, result2, result3, result4};
        Console.WriteLine("List of results :");
        results.ForEach(Console.WriteLine);
    }

}