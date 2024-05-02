using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmMachine
{
    internal class Account(double balance)
    {
        private double Balance { get; set; } = balance;

        public double CheckBalance()
        {
            return Balance;
        }

        public void Deposit(double amount) 
        {
            if (amount > 0)
            {
                Balance += amount;
            }
        }
        
        public double withdraw(double amount)
        {
            if(Balance-amount > 0)
            {
                Balance = Balance - amount;
            }
            return amount;
        }
    }
}
