class Program {

    class Adder {

        private decimal[] numbers = [];

        public Adder(decimal[] numbers)
        {
            this.numbers = numbers;
        }

        public decimal add() {
            decimal result = 0;
            for (int i = 0; i < numbers.Length; i++) {
                result += numbers[i];
            }
            Console.WriteLine($"Addition result is : {result}");
            return result;
        }

        public decimal addAndDivideByTwo() {
            decimal result = add() / 2;
            Console.WriteLine($"Divided by two is : {result}");
            return result;
        }

        public int numberOfElements() { 
            return numbers.Length;
        }

        public void printElements() {
            Console.WriteLine("Numbers is : {");
            for (int i = 0; i < numbers.Length; i++) { 
                Console.WriteLine( numbers[i] );
            }
            Console.WriteLine("}");
        }

        public decimal [] getSlice(int lowIndex, int highIndex) {
            if (lowIndex < 0) {
                Console.WriteLine("lowIndex is lower then zero... You must give number higher then zero as lowIndex. I will do that for you");
                lowIndex = 0;
            }
            if (highIndex >= numbers.Length) {
                Console.WriteLine("You gave highIndex that is higher than table length. I will correct that adt truncate result to last item in table");
                highIndex = numbers.Length;
            }

            Console.WriteLine("Printing slice : {");
            decimal[] slice = new decimal[highIndex - lowIndex + 1];

            for (int i = lowIndex; i < highIndex; i++) {
                Console.WriteLine(numbers[i]);
                slice[i] = numbers[i];
            }

            Console.WriteLine("}");

            return slice;
        }

    }
    
    public static void Main(String[] args) {
        decimal[] numbers = [12, 53, 265, 753, 22, 54, 123, 546, 346, 734, 87, 54, 72];
        Adder adder = new Adder(numbers);
        adder.addAndDivideByTwo();
        adder.numberOfElements();
        adder.getSlice(1, 8);
    }
}