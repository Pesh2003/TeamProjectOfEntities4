using System;

namespace ApplicationModels.Model.Output
{
    public static class ConsoleOutput
    {
        public static void PrintLine(string line)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine(line);
        }
    }
}
