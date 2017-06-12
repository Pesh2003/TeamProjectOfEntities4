using CourierService.Models.SQLServer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Models.SQLServer
{
    public class CommandParser : ICommandParser
    {
        public int CommandParse(IList<int> ExistingRowsInDB, string type)
        {
            var numChosen = 0;
            bool check = true;

            string input = null;
            while (!int.TryParse(input = Console.ReadLine(), out numChosen))
            {
                if (input.ToLower() == "exit")
                {
                    numChosen = 0;
                    return numChosen;
                }
                Console.WriteLine(" It is not a valid number!\n  (type a valid numbar or \" EXIT \")");
            }

            if (ExistingRowsInDB.FirstOrDefault<int>(n => n.Equals(numChosen)) == 0)
            {
                while (ExistingRowsInDB.FirstOrDefault<int>(n => n.Equals(numChosen)) == 0 || check)
                {
                    Console.WriteLine("{0} with this number does not exist \n Please enter a correct number  or \" EXIT \"", type);
                    check = !int.TryParse(input = Console.ReadLine(), out numChosen);

                    if (input.ToLower() == "exit")
                    {
                        numChosen = 0;
                        return numChosen;
                    }
                }
            }

            return numChosen;
        }

        public int CommandParse(string type)
        {
            var numChosen = 0;
            bool check = true;
            string input = null;
            while (!int.TryParse(input = Console.ReadLine(), out numChosen))
            {
                if (input.ToLower() == "exit")
                {
                    numChosen = 0;
                    return numChosen;
                }
                Console.WriteLine(" It is not a valid number!\n  (type a valid numbar or \" EXIT \")");                
            }

            if ((numChosen != 1) && (numChosen != 2))
            {
                Console.WriteLine("Please enter a number from the list above or \" EXIT \"");
                while (!((numChosen == 1) || (numChosen == 2))|| check)
                {
                    Console.WriteLine("{0} with this number does not exist \n Please enter a correct number or \" EXIT \"", type);                     
                    check = !int.TryParse(input = Console.ReadLine(), out numChosen);

                    if (input.ToLower() == "exit")
                    {
                        numChosen = 0;
                        return numChosen;
                    }
                }
            }

            return numChosen;
        }
    }    
}
