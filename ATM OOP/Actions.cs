using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ATM
{
    public class Actions : CashMachine
    {
        private static Transactions transaction = new Transactions();

        // Method to enabl the user to choose a transaction
        public void CheckAction(List<Transactions> statement, BankAccount userAccount)
        {

            console.PrintVarietyOfActions();

            decimal _inputChoice = method.GetInput();
            switch (_inputChoice)
            {
                case 1: // Inserting money
                    transaction.InsertMoney(statement, userAccount);
                    break;
                case 2: // Withdrawing money
                    transaction.WithdrawMoney(statement, userAccount);
                    break;
                case 3: // Transferring money
                    transaction.TransferMoney(statement, userAccount);
                    break;
                case 4: // Printing statement
                    console.PrintStatement(statement, userAccount);
                    break;
            }
        }

        // Method to continue with a different account
        public bool Continue(string str)
        {
            Console.WriteLine("\nWould you like to continue {0}?", str);
            Console.WriteLine("(y/n)");
            string _input = Console.ReadLine();

            if (_input == "y")
                return (true);
            else
                return (false);
        }
    }
}