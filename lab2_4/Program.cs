class Program {

    class Count {

        public decimal value;

        public Count(decimal value)
        {
            this.value = value;
        }

        public decimal add(decimal valueToAdd) { 
            value += valueToAdd;
            return value;
        }

        public decimal substract(decimal valueToSubstract) { 
            value -= valueToSubstract;
            return value;
        }

    }

    static void Main(String[] args) {
        Count count1 = new Count(1);
        Count count2 = new Count(2);
        Count count3 = new Count(3);

        decimal valueOfCount1 = count1.add(1);
        decimal valueOfCount2 = count2.add(6);
        decimal valueOfCount3 = count3.substract(12);

        Console.WriteLine(valueOfCount1);
        Console.WriteLine(valueOfCount2);
        Console.WriteLine(valueOfCount3);
    }
}