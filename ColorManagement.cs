using System;
using System.Collections.Generic;

namespace TextColorSpace
{

    public class TextColorClass
    {
        public static string secondString = "Reading second file";

        static public void ChangeTextColorBlue()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        static public void ChangeTextColorGreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        static public void ChangeTextColorCyan()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        static public void ChangeTextColorYellow()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        static public void ChangeTextColorReset()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}