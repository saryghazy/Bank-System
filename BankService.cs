using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Sary
{
    internal class BankService 
    {
        private AccountRepository accountRepository;
        private TransactionRepoistroy transactionRepoistroy;
        private int transactionCounter = 744020;
        private int nextAccountId = 744626;
        protected const string Password = "saryghazy@gm";
        public BankService()
        {
            accountRepository = new AccountRepository();
            transactionRepoistroy = new TransactionRepoistroy();
            accountRepository.LoadFromFile();
            transactionRepoistroy.LoadFromFile();
            var allTransactions = transactionRepoistroy.GetAllTransactions();
            if (allTransactions.Count > 0)
            {
                transactionCounter = allTransactions.Max(t => t.TransactionId) + 1;
            }
            var allAccounts = accountRepository.GetAllAccounts();
            if (allAccounts.Count > 0)
            {
                nextAccountId = allAccounts.Max(a => a.Id) + 1;
            }
        }
        public void CreateAccount(string ownerName, decimal initialBalance)
        {
            var account = new Account(nextAccountId, ownerName, initialBalance);
            accountRepository.AddAccount(account);
            nextAccountId++;
        }
        public void Deposit( decimal amount, int to)
        {
            var account = accountRepository.GetAccountById(to);
            if (account != null)
            {
                try 
                { 
                    account.Deposit(amount);
                    var transaction = new Transaction( transactionCounter++, 0, to, 
                        amount, TransactionType.Deposit, DateTime.Now);
                    transactionRepoistroy.AddTransaction(transaction);
                    accountRepository.SaveToFile();
                    Console.WriteLine("Deposit Successful");
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
        }
        public void Withdraw( decimal amount, int from)
        {
            var account = accountRepository.GetAccountById(from);
            if (account != null)
            {
                try
                {
                    account.Withdraw(amount);
                    var transaction = new Transaction(transactionCounter++, from, 0, 
                        amount, TransactionType.Withdraw, DateTime.Now);
                    transactionRepoistroy.AddTransaction(transaction);
                    accountRepository.SaveToFile();

                    Console.WriteLine("Withdrawal Successful");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            transactionRepoistroy.SaveToFile();
        }
        public void Transfer( decimal amount, int from , int to )
        {
            var fromAccount = accountRepository.GetAccountById(from);
            var toAccount = accountRepository.GetAccountById(to);
            if (fromAccount != null && toAccount != null)
            {
                try
                {
                    fromAccount.Withdraw(amount);
                    toAccount.Deposit(amount);
                    var transaction = new Transaction(transactionCounter++, from, to, amount, TransactionType.Transfer, DateTime.Now);
                    transactionRepoistroy.AddTransaction(transaction);
                    accountRepository.SaveToFile();
                    Console.WriteLine("Transfer Successful");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            transactionRepoistroy.SaveToFile();
        }
        public Account GetAccountById(int id)
        {
            return accountRepository.GetAccountById(id);
        }
        public List<Account> GetAllAccounts() 
        {
            return accountRepository.GetAllAccounts(); 
        }
        public List<Transaction> GetAllTransactions()
        {
            return transactionRepoistroy.GetAllTransactions();
        }
        public void Remove(int id)
        {
            accountRepository.RemoveAccount(id);
        }
        public void PrintAllAccounts()
        {
            var accounts = accountRepository.GetAllAccounts();
            foreach (var account in accounts)
            {
                Console.WriteLine(account);
            }
        }
        public void PrintAllTransactions()
        {
            var transactions = transactionRepoistroy.GetAllTransactions();
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}
