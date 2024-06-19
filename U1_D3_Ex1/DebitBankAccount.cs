using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_D3_Ex1
{
    internal class DebitBankAccount : BankAccount
    {
        public DebitBankAccount(string owner, decimal initialAmount) : base(owner, initialAmount)
        {
        }

        public override void Withdraw(decimal amount)
        {
            base.Withdraw(1); // addebito 1€ per ogni operazione di prelievo
            base.Withdraw(amount);
        }
    }
}
