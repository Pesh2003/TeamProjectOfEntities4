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
        public int CommandParse(int ExistingRowsInDB, string type)
        {
            var numChosen = 0;
            bool check = true;
            while (!int.TryParse(Console.ReadLine(), out numChosen))
            {
                Console.WriteLine("It is not a valid number!");
            }
            if (numChosen > ExistingRowsInDB)
            {
                while (numChosen > ExistingRowsInDB || check)
                {
                    Console.WriteLine("{0} with this number does not exist \n Please enter a correct number", type);
                    check = !int.TryParse(Console.ReadLine(), out numChosen);
                }
            }

            return numChosen;
        }
    }    
}
