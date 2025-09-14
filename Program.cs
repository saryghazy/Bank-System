using System.Diagnostics;

namespace Bank_Sary
{
    internal class Program:BankService
    {
        static void Main(string[] args)
        {
            BankService bank = new BankService();
            bool running = true;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            while (running)
            {
                Console.WriteLine("\n========== Welcome To Bank Sary ===========");
                Console.WriteLine("\n1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. View Account Details");
                Console.WriteLine("6. View All Accounts");
                Console.WriteLine("7. View All Transactions");
                Console.WriteLine("8. Exit");
                Console.WriteLine("9. Remove Account");
                Console.Write("Please select an option (1-9): ");
                if (!int.TryParse(Console.ReadLine(), out int input) || input < 1 || input > 9)
                {
                    Console.Write("Invalid Input, Please Select A Valid Option (1-9): ");
                    
                    input =int.Parse(Console.ReadLine());
                    
                }
               
                
                Console.Clear();
                switch(input)
                {
                    case 1:
                        Console.Write("Please Enter Name Acount: ");
                        string name = Console.ReadLine();
                        Console.Write("Please Enter Initial Balance: ");
                        decimal initialBalance = decimal.Parse(Console.ReadLine());
                        bank.CreateAccount(name, initialBalance);
                        break;
                    case 2:
                        Console.Write("Please Enter Amount Deposit: ");
                        decimal amountDeposit = decimal.Parse(Console.ReadLine());
                        Console.Write("Please Enter Account ID To Deposit: ");
                        int toDeposit = int.Parse(Console.ReadLine());
                        bank.Deposit(amountDeposit, toDeposit);
                        break;
                    case 3:
                        Console.Write("Please Enter Amount Withdraw: ");
                        decimal amountWithdraw = decimal.Parse(Console.ReadLine());
                        Console.Write("Please Enter Account ID From Withdraw: ");
                        int FromWithdraw = int.Parse(Console.ReadLine());
                        bank.Withdraw(amountWithdraw, FromWithdraw);
                        break;
                    case 4:
                        Console.Write("Please Enter Amount Transfer: ");
                        decimal amountTransfer = decimal.Parse(Console.ReadLine());
                        Console.Write("Please Enter Account ID From Transfer: ");
                        int fromTransfer = int.Parse(Console.ReadLine());
                        Console.Write("Please Enter Account ID To Transfer: ");
                        int toTransfer = int.Parse(Console.ReadLine());
                        bank.Transfer(amountTransfer, fromTransfer, toTransfer);
                        break;
                    case 5:
                        Console.Write("Please Enter Account ID To View Details: ");
                        int idDetails = int.Parse(Console.ReadLine());
                        var account = bank.GetAccountById(idDetails);
                        if (account != null)
                        {
                            Console.WriteLine(account);
                        }
                        break;
                    case 6:
                        Console.Write("Please enter password: ");
                        string password = Console.ReadLine();
                        if (password == Password)
                        {
                            var allAccounts = bank.GetAllAccounts();
                            foreach (var acc in allAccounts)
                            {
                                Console.WriteLine(acc);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Incorrect password. Access denied.");
                        }
                        break;
                    case 7:
                        Console.Write("Please enter password: ");
                        string pass = Console.ReadLine();
                        if (pass == Password)
                        {
                            var allTransactions = bank.GetAllTransactions();
                            foreach (var item in allTransactions)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Incorrect password. Access denied.");
                        }
                        break;
                    case 8:
                        running = false;
                        Console.WriteLine("Thank you Use Bank Sary. Goodbye!");
                        break;
                    case 9:
                        Console.Write("Please Enter Account ID To Remove: ");
                        int idRemove = int.Parse(Console.ReadLine());
                        bank.Remove(idRemove);
                        break;
                    default:
                        Console.WriteLine("Invalid Option, Please Select A Valid Option (1-9).");
                        break;

                }
                Console.Write("Do You want Repeat Excute Press Yes, if you won't press No: ");
                string repeat = Console.ReadLine().ToLower();
                while(repeat != "yes" && repeat != "no")
                {
                    Console.Write("Invalid Input, Please Enter Yes or No: ");
                    repeat = Console.ReadLine().ToLower();
                }
                if (repeat == "no")
                {
                    running = false;
                    Console.WriteLine("Thank you Use Bank Sary. Goodbye!");
                }
                else 
                {
                    Console.Clear();
                    continue;
                }
               


            }

        }
    }
}
