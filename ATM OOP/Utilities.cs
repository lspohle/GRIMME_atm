using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ATM
{
    // Class Utility
    public class Utility
    {
        // Method to check the user's input and convert it into decimal
        public decimal GetInput()
        {
            string _input = Console.ReadLine();

            Regex regex = new Regex(@"^\d{1,}[,]\d{1,2}$|^\d{1,}$");
            bool _result = regex.IsMatch(_input);

            if (_result && decimal.TryParse(_input, out decimal _output))
                return _output;
            else
                return 0;
        }     
    }
}