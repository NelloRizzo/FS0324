namespace U1_D3_Ex1
{
    internal class Program
    {
        static void Main(string[] args) {
            BankAccount a1 = new DebitBankAccount("Nello", 1200);
            try {
                BankAccount a2 = new BankAccount("Nello", 0);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            try {
                a1.Deposit(500);
                a1.Withdraw(1000);
                a1.Withdraw(1000);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
