using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Sary
{
    internal class Account
    {
        public int Id { get; }
        public string OwnerName { get; }
        public decimal Balance { get; private set; }
        public Account(int id, string ownerName, decimal initialBalance)
        {
            this.Id = id;
            this.OwnerName = ownerName;
            this.Balance = initialBalance;
        }
       public virtual void Deposit(decimal amount)
       {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }
            Balance += amount;
       }
        public virtual void Withdraw(decimal amount)
        {
                if (amount <= 0)
                { 
                    throw new ArgumentException("Withdraw amount must be positive.");
                }
                if (amount > Balance)
                {
                    throw new InvalidOperationException("Insufficient funds for this withdrawal.");
                }
                Balance -= amount;
        }
        public override string ToString()
        {
            return($"Account ID: {Id}, Owner: {OwnerName}, Balance: {Balance:C}");
        }
    }
}
