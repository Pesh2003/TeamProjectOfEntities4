using ApplicationModels.Model.Output;
using System.Text;


namespace ApplicationModels.Constant
{
    public static class ConstantInformation
    {
        public static void PrintAvailableKeyCodes()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1. Register");
            sb.AppendLine("2. Login");
            sb.Append("3. Exit Application");
            ConsoleOutput.PrintLine(sb.ToString());
        }
    }
}
