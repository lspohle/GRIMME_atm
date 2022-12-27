using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ATM
{
    internal class Program
    {
        // Main method - the heart of the program
        static void Main(string[] args)
        {
            decimal _accountNumberPaul = 1;
            decimal _accountNumberLisa = 2;

            Console.WriteLine("\nPlease refer to the account, you would like to access:");

            decimal _login = GetInput();
            if (_login == _accountNumberPaul) // Paul's account details
            {
                decimal _pinPaul = 1234;
                string _namePaul = "Paul Nord";
                decimal _accountPaul = 500.30M;
                string[] _transactionsPaul = { $"Initial balance: {_accountPaul} €" };

                Console.WriteLine("\nWelcome, {0}!\nPlease enter your PIN:", _namePaul);
                if (CheckPin(_pinPaul, _accountPaul))
                {
                    CheckAction(_transactionsPaul, _accountPaul);
                }
            }
            else if (_login == _accountNumberLisa) // Lisa's account details
            {
                decimal _pinLisa = 4567;
                string _nameLisa = "Lisa Otto";
                decimal _accountLisa = 600.55M;
                string[] _transactionsLisa = { $"Initial balance: {_accountLisa} €" };

                Console.WriteLine("\nWelcome, {0}!\nPlease enter your PIN:", _nameLisa);
                if (CheckPin(_pinLisa, _accountLisa))
                {
                    CheckAction(_transactionsLisa, _accountLisa);
                }
            }
            else // No matching account
            {
                Console.WriteLine("\nThere is no account belonging to your reference!\nPlease try again.");
                Main(args);
            }

            // Continue with a different account
            Console.WriteLine("\nDo you wish to continue with a different account?");
            string _inputDifferentAccount = Console.ReadLine();
            if (_inputDifferentAccount == "Yes")
            {
                Main(args);
            }
            else
            {
                Console.WriteLine("\nSee you soon!");
            }
            Console.ReadLine();
        }

        // Method which compares the entered PIN with the actual PIN
        public static bool CheckPin(decimal pin, decimal account)
        {
            return CheckPin(pin, account, 1);
        }

        private static bool CheckPin(decimal pin, decimal account, int counter)
        {
            decimal _inputPin = GetInput();
            if (_inputPin == pin)
            {
                Console.WriteLine("\nAccess allowed!\nYour current balance: {0} €", account);
                return true;
            }

            if (counter == 3)
            {
                Console.WriteLine("\nAccess denied multiple times!\nFor security reasons the debit card has been retained and blocked.");
                return false;
            }

            Console.WriteLine("\nAccess denied!\nPlease try again.");
            
            counter++;
            return CheckPin(pin, account, counter);
        }

        // Method which enables the user to choose a transaction
        public static void CheckAction(string[] transactions, decimal account)
        {
            Console.WriteLine("\nPlease choose one of the displayed transactions:");
            Console.WriteLine("1) Insert money");
            Console.WriteLine("2) Withdraw money");
            Console.WriteLine("3) Transfer money to a different account");
            Console.WriteLine("4) Print statement\n");

            decimal _inputChoice = GetInput();
            switch (_inputChoice)
            {
                case 1: // Inserting money
                    Console.WriteLine("\nPlease enter the amount you wish to insert:");
                    decimal _inputInsert = GetInput();
                    if (_inputInsert != 0)
                    {
                        transactions = InsertMoney(transactions, _inputInsert);
                        account += _inputInsert;
                        Console.WriteLine("\nYour balance has been updated: {0} €", account);
                    }
                    else
                    {
                        Console.WriteLine("\nYour desired amount is not valid! No money has been transferred from your account.\nYour balance has not been changed: {0} €", account);
                    }
                    break;
                case 2: // Withdrawing money
                    Console.WriteLine("\nPlease enter the amount you would like to withdraw:");
                    decimal _inputWithdraw = GetInput();
                    if (_inputWithdraw != 0 && _inputWithdraw <= account)
                    {
                        transactions = WithdrawMoney(transactions, _inputWithdraw);
                        account -= _inputWithdraw;
                        Console.WriteLine("\nYour balance has been updated: {0} €", account);
                    }
                    else
                    {
                        Console.WriteLine("\nYour desired amount is not valid! No money has been transferred from your account.\nYour balance has not been changed: {0} €", account);
                    }
                    break;
                case 3: // Transferring money
                    Console.WriteLine("\nPlease enter the owner of the account to which you wish to transfer:");
                    string inputName = Console.ReadLine();
                    Console.WriteLine("\nPlease enter the amount you would like to transfer to the account of {0}:", inputName);
                    decimal _inputTrans = GetInput();
                    if (_inputTrans != 0 && _inputTrans <= account)
                    {
                        transactions = TransferMoney(transactions, _inputTrans, inputName);
                        account -= _inputTrans;
                        Console.WriteLine("\nYour balance has been updated: {0} €", account);
                    }
                    else
                    {
                        Console.WriteLine("\nYour desired amount is not valid! No money has been transferred from your account.\nYour balance has not been changed: {0} €", account);
                    }
                    break;
                case 4: // Printing statement
                    Console.WriteLine("");
                    PrintStatement(transactions, account);
                    break;
            }

            ContinueTransactions(transactions, account);
        }

        // Method to continue or finish with transactions
        public static void ContinueTransactions(string[] transactions, decimal account)
        {
            Console.WriteLine("\nDo you wish to continue your transactions?\nPlease enter 'Yes' in order to contiue. You will be automatically logged out otherwise!");

            string _input = Console.ReadLine();
            if (_input == "Yes")
            {
                CheckAction(transactions, account);
            }
            else
            {
                Console.WriteLine("\nYou are logged out of your account!");  
            }
        }

        // Method which converts the user's input from string to decimal
        public static decimal GetInput()
        {
            string _input = Console.ReadLine();

            // Using regular expressions to check if input is valid (with two decimal places)
            Regex regex = new Regex(@"^\d{1,}[,]\d{1,2}$|^\d{1,}$");

            bool _result = regex.IsMatch(_input);

            if (_result && decimal.TryParse(_input, out decimal _output))
            {
                return _output;
            }
            else
            {
                return 0;
            }
        }

        // Methode which inserts an amount of money
        public static string[] InsertMoney(string[] transactions, decimal inputAmount)
        {
            string[] _tmp = new string[transactions.Length + 1];

            int _i = 0;
            while (_i < transactions.Length)
            {
                _tmp[_i] = transactions[_i];
                _i++;
            }
            _tmp[_i] = "Deposit: " + inputAmount.ToString() + " €";

            return _tmp;
        }

        // Method which withdraws an amount of money (smaaller/equal to the current balance)
        public static string[] WithdrawMoney(string[] transactions, decimal inputAmount)
        {
            string[] _tmp = new string[transactions.Length + 1];

            int _i = 0;
            while (_i < transactions.Length)
            {
                _tmp[_i] = transactions[_i];
                _i++;
            }
            _tmp[_i] = "Withdrawal: - " + inputAmount.ToString() + " €";

            return _tmp;
        }

        // Method which transfers an amount of money (smaaller/equal to the current balance) to a different account
        public static string[] TransferMoney(string[] transactions, decimal inputAmount, string inputName)
        {
            string[] _tmp = new string[transactions.Length + 1];

            int _i = 0;
            while (_i < transactions.Length)
            {
                _tmp[_i] = transactions[_i];
                _i++;
            }
            _tmp[_i] = "Transfer to " + inputName + ": - " + inputAmount.ToString() + " €";

            return _tmp;
        }

        // Method which prints the statement
        public static void PrintStatement(string[] transactions, decimal account)
        {
            string[] _tmp = new string[transactions.Length + 1];

            int _i = 0;
            while (_i < transactions.Length)
            {
                _tmp[_i] = transactions[_i];
                _i++;
            }
            _tmp[_i] = "Final balance: " + account.ToString() + " €";

            for (int _j = 0; _j <= transactions.Length; _j++)
            {
                Console.WriteLine("{0}", _tmp[_j]);
            }
        }
    }
}

// Note_Regex
//     -> Links: https://www.c-sharpcorner.com/article/c-sharp-regex-examples/ (gives you an understanding of Regex)
//               https://regex101.com (displayes an explanation of your regular expression)