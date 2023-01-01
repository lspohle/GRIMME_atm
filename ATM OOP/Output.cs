using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ATM
{
    // Class Output
    public class Output : CashMachine
    {
        // Method to welcome the user
        public void PrintWelcomeStatement()
        {
            WriteInCyan("\n------------------------------------------------------");
            Console.WriteLine("               Welcome to the ATM");
            WriteInCyan  ("------------------------------------------------------");
        }

        // Method to display variety of actions
        public void PrintVarietyOfActions()
        {
            WriteInCyan("\n------------------------------------------------------");
            Console.WriteLine("Please choose one of the displayed transactions:");
            Console.WriteLine("1) Insert money");
            Console.WriteLine("2) Withdraw money");
            Console.WriteLine("3) Transfer money to a different account");
            Console.WriteLine("4) Print statement");
            WriteInCyan  ("------------------------------------------------------");
        }

        // Method to print the statement
        public void PrintStatement(List<Transactions> statement, BankAccount userAccount)
        {
            statement.Add(new Transactions() {Name = "Final Balance  ", Amount = userAccount.AccountBalance});

            WriteInMagenta ("\n------------------------------------------------------");
            Console.WriteLine("                                            {0}", DateOnly.FromDateTime(DateTime.Now));
            WriteInCyan      ("                   BANK STATEMENT                    ");
            Console.WriteLine("                on behalf of {0}", userAccount.Name);
            WriteInMagenta   ("------------------------------------------------------");
            foreach (Transactions action in statement)
            {
                Console.WriteLine("     {0}                  {1} €", action.Name, action.Amount);
            }
            WriteInMagenta   ("------------------------------------------------------");
            statement.Remove(new Transactions() {Name = "Final Balance  ", Amount = userAccount.AccountBalance});
            statement.RemoveAt(statement.Count - 1);
        }

        // Method to display success because action was successfully performed
        public void ActionSuccessful(BankAccount userAccount)
        {
            WriteInGreen("\nYour balance has been successfully updated!");
            Console.WriteLine("Your current balance: {0} €", userAccount.AccountBalance);
        }

        // Method to display failure because action was not performed
        public void ActionFailed(BankAccount userAccount)
        {
            WriteInRed("\nYour desired amount is not valid!\nNo money has been transferred from your account.");
            Console.WriteLine("Your balance has not been changed: {0} €", userAccount.AccountBalance);
        }

        // Methods to change the color of output and write it on the console
        public void WriteInGreen(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void WriteInRed(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void WriteInCyan(string str)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteInMagenta(string str)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}