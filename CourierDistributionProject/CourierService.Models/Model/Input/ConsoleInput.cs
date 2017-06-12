using System;

namespace ApplicationModels.Model.Input
{
    public static class ConsoleInput
    {
        public static string ReadLine()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            return Console.ReadLine().Trim();
        }
    }
}
