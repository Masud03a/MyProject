using System;

namespace MyProject
{
    class Log
    {
        public static void Error(string _exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Fatal error was occured: " + _exception);
        }
    }
}        