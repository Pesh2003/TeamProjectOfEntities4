using ApplicationModels.Model.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationModels.Constant
{
    internal static class ConstantInformation
    {
        internal static void PrintAvailableKeyCodes()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1. Get Users");
            sb.Append("2. Exit Application");
            ConsoleOutput.PrintLine(sb.ToString());
        }
    }
}
