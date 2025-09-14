using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Sary
{
    internal class AccountRepository
    {
        private Dictionary<int, Account> accounts = new Dictionary<int, Account>();
        private string filePath = ("accounts.txt");
        public void AddAccount(Account account)
        {
            if (!accounts.ContainsKey(account.Id))
            {
                accounts[account.Id] = account;
                SaveToFile();
                Console.WriteLine("Account Added Successfully");
            }
            else
            {
                Console.WriteLine("Account with this ID already exists.");
            }
        }
        public Account GetAccountById(int id)
        {
            if (accounts.ContainsKey(id))
            {
                return accounts[id];
            }
            Console.WriteLine("Account Not Found");
            return null;
        }
        public List<Account> GetAllAccounts()
        {
            return accounts.Values.ToList();
        }
        public void RemoveAccount(int id)
        {
            if(accounts.ContainsKey(id))
            {
                accounts.Remove(id);
                SaveToFile();
                Console.WriteLine("Account Removed Successfully");
            }
            else
            {
                Console.WriteLine("Account With This ID Not Found.");
            }

        }
        public void LoadFromFile()
        {
            if (File.Exists(filePath))
            {
                var Line = File.ReadAllLines(filePath);
                foreach(var line in Line)
                {
                    var parts = line.Split(",");
                    int id = int.Parse(parts[0]);
                    string account = parts[1];
                    decimal blance = decimal.Parse(parts[2]);
                    accounts[id] = new Account(id, account,blance);
                }
            }
        }
        public void SaveToFile()
        {
            var line = accounts.Values.Select(a => $"{a.Id},{a.OwnerName},{a.Balance}");
            File.WriteAllLines(filePath, line);
        }

    }
}
