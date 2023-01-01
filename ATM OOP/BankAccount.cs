using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ATM
{
    // Class BankAccount
    public class BankAccount
    {
        decimal _accountNumber;
        decimal _pin;
        string _name;
        decimal _accountBalance;

        // Default Constructor 
        public BankAccount()
        {
            _accountNumber = 0;
            _pin = 0;
            _name = "Unbekannt";
            _accountBalance = 0;
        }

        // Parametisierter Konstruktor -> Properties
        public BankAccount(decimal _accountNumber, decimal _pin, string _name, decimal _accountBalance)
        {
            this.AccountNumber = _accountNumber;
            this.Pin = _pin;
            this.Name = _name;
            this.AccountBalance = _accountBalance;
        }

        // Property AccountNumber
        public decimal AccountNumber
        {
            get;
            set;
        }

        // Property Pin
        public decimal Pin
        {
            get;
            set;
        }

        // Property Name
        public string Name
        {
            get;
            set;
        }

        // Property Account
        public decimal AccountBalance
        {
            get;
            set;
        }
    }
}
