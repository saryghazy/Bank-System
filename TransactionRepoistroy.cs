using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Sary
{
    internal class TransactionRepoistroy
    {
        private Dictionary<int, Transaction> transactions = new Dictionary<int, Transaction>();
        private string filePath = ("transaction.txt");

        public void AddTransaction(Transaction transaction)
        {
            if (!transactions.ContainsKey(transaction.TransactionId))
            {
                transactions[transaction.TransactionId] = transaction;
                SaveToFile();
                Console.WriteLine("Your Add Transaction Successfully");
            }
            else
            {
                Console.WriteLine("Transaction with this ID already exists.");
            }

        }
        public Transaction GetTransactionId(int transactionId)
        {
            if (transactions.ContainsKey(transactionId))
            {
                return transactions[transactionId];
            }
            Console.WriteLine("Transaction Not Found");
            return null;
        }

        public List<Transaction> GetAllTransactions()
        {
            return transactions.Values.ToList();
        }

        public void LoadFromFile()
        {
            if (File.Exists(filePath))
            {
                var line = File.ReadAllLines(filePath);
                foreach (var item in line)
                {
                    var parts = item.Split(",");
                    TransactionType type = (TransactionType)Enum.Parse(typeof(TransactionType), parts[0]);
                    int id = int.Parse(parts[1]);
                    int from = int.Parse(parts[2]);
                    int to = int.Parse(parts[3]);
                    decimal amount = decimal.Parse(parts[4]);
                    DateTime dateTime = DateTime.Parse(parts[5]);
                    transactions[id] = new Transaction(id,from, to, amount,type,dateTime);
                }
            }
            
        }
        public void SaveToFile()
        {
            var line = transactions.Values.Select(a => $"{a.Type},{a.TransactionId}," +
            $"{a.FromAccountId},{a.ToAccountId},{a.Amount},{a.TransactionDate}");
            File.WriteAllLines( filePath, line );
            
        }
    }
}
