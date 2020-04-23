using System;

namespace MyProject
{
    public static class ConsoleShow
    {
        public static void Red(string Text){
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write(Text);
            Console.ForegroundColor = ConsoleColor.White; 
        }     
        public static void Green(string Text){
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write(Text);
            Console.ForegroundColor = ConsoleColor.White; 
        }
    }
}