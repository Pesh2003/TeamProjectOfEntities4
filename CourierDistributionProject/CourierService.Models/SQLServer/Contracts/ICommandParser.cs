using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Models.SQLServer.Contracts
{
    public interface ICommandParser
    {
        int CommandParse(IList<int> ExistingRowsInDB, string type);

        int CommandParse(string type);
    }
}
