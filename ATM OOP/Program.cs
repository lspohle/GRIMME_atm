using System;
using System.Collections.Generic; // using namespace because of generic lists
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ATM
{
    public class Program
    {
        static void Main(string[] args)
        {
            Output console = new Output();
            CashMachine atm = new CashMachine ();

            // Welcoming the user
            console.PrintWelcomeStatement();
            // The atual program
            atm.Initialization();
            atm.Execution();
        }
    }
}
