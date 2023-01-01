using System;
using System.Collections.Generic; // using namespace because of generic lists
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ATM
{
    // Class Transactions
    public class Transactions : CashMachine
    {
        string _name;
        decimal _amount;

        // Default Constructor 
        public Transactions()
        {
            _name = "Unbekannt";
            _amount = 0;
        }

        // Parametisierter Konstruktor -> Properties
        public Transactions(string _name, decimal _amount)
        {
            this.Name = _name;
            this.Amount = _amount;
        }

        // Property Action
        public string Name
        {
            get;
            set;
        }

        // Property Amount
        public decimal Amount
        {
            get;
            set;
        }

        // Method to insert an amount of money
        public void InsertMoney(List<Transactions> statement, BankAccount userAccount)
        {
            Console.WriteLine("\nPlease enter the amount you would like to insert:");
            decimal _inputInsert = method.GetInput();

            if (_inputInsert > 0)
            {
                statement.Add(new Transactions() {Name = "Deposit        ", Amount = _inputInsert});
                userAccount.AccountBalance += _inputInsert;
                console.ActionSuccessful(userAccount);
            }
            else
            {
                console.ActionFailed(userAccount);
            }
        }

        // Method to withdraw an amount of money (smaller/equal to the current balance)
        public void WithdrawMoney(List<Transactions> statement, BankAccount userAccount)
        {
            Console.WriteLine("\nPlease enter the amount you would like to withdraw:");
            decimal _inputWithdraw = method.GetInput();

            if (_inputWithdraw > 0 && _inputWithdraw < userAccount.AccountBalance)
            {
                statement.Add(new Transactions() {Name = "Withdrawal     ", Amount = -1 *_inputWithdraw});
                userAccount.AccountBalance -= _inputWithdraw;
                console.ActionSuccessful(userAccount);
            }
            else
            {
                console.ActionFailed(userAccount);
            }
        }

        // Method to transfer an amount money (smaller/equal to the current balance) to a different account
        public void TransferMoney(List<Transactions> statement, BankAccount userAccount)
        {
            Console.WriteLine("\nPlease enter the owner of the account to which you wish to transfer:");
            string _inputName = Console.ReadLine();

            Console.WriteLine("\nPlease enter the amount you would like to transfer to the account from {0}:", _inputName);
            decimal _inputTrans = method.GetInput();

            if (_inputTrans > 0 && _inputTrans < userAccount.AccountBalance)
            {
                statement.Add(new Transactions() {Name = "Transfer       ", Amount = -1 *_inputTrans});
                userAccount.AccountBalance -= _inputTrans;
                console.ActionSuccessful(userAccount);
            }
            else
            {
                console.ActionFailed(userAccount);
            }
        }
    }
}
