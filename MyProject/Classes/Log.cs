using System;

namespace MyProject
{
    public static class ConsoleShow
    {
        public static void Error(string Text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write(Text);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public static void Green(string Text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write(Text);
            Console.ForegroundColor = ConsoleColor.Yellow;

        }
    }
}       