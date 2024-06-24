namespace U1_D3_Ex1
{
    internal class BankAccount
    {
        private static int LastAccountNumber = 0;
        public string Owner { get; set; }
        public int Number { get; private set; }
        public DateTime LastOperation { get; private set; }
        public decimal Amount { get; private set; }

        public BankAccount(string owner, decimal initialAmount) {
            if (initialAmount < 1000)
                throw new ArgumentException("Per aprire il conto occorre versare almeno 1000 euro");
            Owner = owner;
            Number = ++LastAccountNumber;
            Deposit(initialAmount);
        }

        public virtual void Deposit(decimal amount) {
            LastOperation = DateTime.Now;
            Amount += amount;
            Console.WriteLine($"Deposito di {amount} euro effettuato");
            Console.WriteLine(Describe());
        }
        public virtual void Withdraw(decimal amount) {
            if (Amount < amount)
                throw new ArgumentException("Fondi non sufficienti");
            LastOperation = DateTime.Now;
            Amount -= amount;
            Console.WriteLine($"Prelievo di {amount} euro effettuato");
            Console.WriteLine(Describe());
        }

        public string Describe() {
            return $"Conto corrente n. {Number:08} intestato a {Owner}\n\tUltima operazione effettuata il {LastOperation}\n\tSaldo: {Amount} euro";
        }
    }
}
