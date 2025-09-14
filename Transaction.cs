using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Sary
{
    internal class Transaction
    {
        public int TransactionId { get; private set; }
        public int FromAccountId { get; private set; }
        public int ToAccountId { get; private set; }
        public decimal Amount {  get; private set; }
        public DateTime TransactionDate { get; private set; }
        public TransactionType Type { get; private set; }
        public Transaction(int transactionId, int fromAccountId, int toAccountId, decimal amount, TransactionType type,DateTime dataTime)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero");
            TransactionId = transactionId;
            FromAccountId = fromAccountId;
            ToAccountId = toAccountId;
            Amount = amount;
            TransactionDate = dataTime;
            Type = type;
        }
        public Transaction(int transactionId, int fromAccountId, int toAccountId, decimal amount, TransactionType type)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero");
            TransactionId = transactionId;
            FromAccountId = fromAccountId;
            ToAccountId = toAccountId;
            Amount = amount;
            TransactionDate = DateTime.Now;
            Type = type;
        }
        
        //public void Execute(Account fromAccount, Account toAccount)
        //{
        //    if (fromAccount.Id != FromAccountId || toAccount.Id != ToAccountId)
        //    {
        //        throw new ArgumentException("Account IDs do not match the transaction details.");
        //    }
        //    fromAccount.Withdraw(Amount);
        //    toAccount.Deposit(Amount);
        //    Console.WriteLine("Transaction executed successfully.");
        //}
        //public void Transfer(Account fromAccount, Account toAccount)
        //{
        //    try
        //    {
        //        Execute(fromAccount, toAccount);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Transaction failed: {ex.Message}");
        //    }        الكودالتاني افضل بكتير
        //}     
        public void Excute(AccountRepository ar) 
        {
            switch(Type)
            {
                case TransactionType.Deposit:
                    var deposit = ar.GetAccountById(ToAccountId);
                    if (deposit == null)
                        throw new Exception("Account Not Found");
                    deposit.Deposit(Amount); 
                break;
                case TransactionType.Withdraw:
                    var withdraw = ar.GetAccountById(FromAccountId);
                    if (withdraw == null) throw new Exception("Account Not Found");
                    withdraw.Withdraw(Amount); 
                    break;
                case TransactionType.Transfer:
                    var from = ar.GetAccountById(FromAccountId);
                    var to = ar.GetAccountById(ToAccountId);
                    if (from == null || to == null)
                        throw new Exception("Account Not Found");
                    from.Withdraw(Amount);
                    to.Deposit(Amount);
                    break;


            }
            Console.WriteLine("Transaction Executed Successfully.");
        }

        public override string ToString()
        {
            return $"[{Type}] Transaction ID:{TransactionId},From Account: {FromAccountId},To Account: {ToAccountId}, Amount: {Amount:C}, Date:{TransactionDate}";
        }
    }
}
