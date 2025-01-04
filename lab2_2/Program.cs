class Program {

    class BankAccount { 
        private decimal saldo;

        public BankAccount(decimal saldo)
        {
            this.saldo = saldo;
        }

        public decimal getSaldo() {
            return saldo;
        }

        public void deposit(decimal amount) {
            Console.WriteLine($"Depositing money : {amount}");
            saldo = saldo + amount;
        }

        public void withdraw(decimal amount) {
            if ((saldo - amount) < 0) {
                Console.WriteLine($"You cannot withdraw {amount} of money because saldo is to low");
                return;
            }
            Console.WriteLine($"There you go! Here are your {amount}");
            saldo = saldo - amount;
        }
    }

    static void Main(string[] args)
    {
        BankAccount bankAccount = new BankAccount(1000);
        bankAccount.deposit(200);
        bankAccount.withdraw(600);
        bankAccount.withdraw(2000);
    }
}
