using System;
using System.Collections.Generic; // using namespace because of generic lists
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ATM
{
    public class CashMachine : BankAccount
    {
        private const int _max_attempts = 3;
        private static int _attempts;


        private static List<BankAccount> listOfAccounts;
        private static List<Transactions> statement;
        private static BankAccount userAccount;


        public static Output console = new Output();
        public static Utility method = new Utility();
        public static Actions action = new Actions();

        // Method to declare and initialize the generic list 'listOfAccounts'
        public void Initialization()
        {
            listOfAccounts = new List<BankAccount>
            {
                new BankAccount () {AccountNumber = 1, Pin = 1234, Name = "Paul Nord", AccountBalance = 100.45m},
                new BankAccount () {AccountNumber = 2, Pin = 5678, Name = "Lisa Ost", AccountBalance = 250.98m},
                new BankAccount () {AccountNumber = 3, Pin = 4321, Name = "Lena Süd", AccountBalance = 500.45m},
                new BankAccount () {AccountNumber = 4, Pin = 8765, Name = "Kleo West", AccountBalance = 1020.98m}
            };
        }

        public void InitializationOfStatement()
        {
            statement = new List<Transactions>
            {
                new Transactions () {Name = "Initial Balance", Amount = userAccount.AccountBalance}
            };
        }

        // Method to check the 'AccountNumber' which was entered by the user
        public bool CheckAccountNumber()
        {
            userAccount = new BankAccount();

            Console.WriteLine("\nPlease refer to the account you would like to access:");

            decimal _login = method.GetInput();
            foreach (BankAccount account in listOfAccounts)
            {
                if (_login == account.AccountNumber)
                {
                    console.WriteInGreen("\nValid account!");
                    userAccount = account;
                    return (true);
                }
            }
            console.WriteInRed("\nNo valid account!");
            return (false);
        }

        // Method to check the 'Pin' which was entered by the user
        public bool CheckPin()
        {
            Console.WriteLine("\nPlease enter your pin:", userAccount.Name);

            decimal _pin = method.GetInput();
            if (_pin == userAccount.Pin)
            {
                console.WriteInGreen("\nAccess allowed!");
                Console.WriteLine("Your current balance: {0} €", userAccount.AccountBalance);
                return (true);
            }
            else if (_attempts < _max_attempts)
            {
                console.WriteInRed("\nAccess denied!");
                _attempts++;
                return (CheckPin());
            }
            else
            {
                console.WriteInRed("\nAccess denied multiple times!\n");
                console.WriteInRed("For security reasons the debit card has been retained and blocked.");
            }
            return (false);
        }

        // Method to call various methods - the heart of the program
        public int Execution()
        {
            _attempts = 1;
            if (CheckAccountNumber() == true)
            {
                if (CheckPin() == true)
                {
                    InitializationOfStatement();

                    action.CheckAction(statement, userAccount);
                    while (action.Continue("with your transactions") == true)
                        action.CheckAction(statement, userAccount);
                }
                else 
                {
                    if (action.Continue("with another account") == true)
                        Execution();
                    else 
                        return (0);
                }
            }
            if (action.Continue("with another account") == true)
                Execution();
            return (0);
        }
    }
}
