using System;
using TextColorSpace;
using PlayerDetailsSpace;

namespace MainSpace
{

    class MainClass
    {
        //static int intPlayerLevel;

        static void Main()
        {
            Console.Clear();

            PlayerDetailsClass.PlayerWelcome();
            //MAIN TO BECOME CORE FILE FOR NAVIGATION
            //REST IS RANDOM

            
            
            
            //COLOR SHIT
            TextColorClass.ChangeTextColorBlue();
            Console.WriteLine("-------------------");
            TextColorClass.ChangeTextColorYellow();
            Console.WriteLine("Reading first file \n" + TextColorClass.secondString);
            TextColorClass.ChangeTextColorBlue();
            Console.WriteLine("-------------------\n");
            //TextColorClass.ChangeTextColorReset();

            TextColorClass.ChangeTextColorGreen();
            Console.WriteLine("=========================");
            Console.WriteLine("Files opened successfully");
            Console.WriteLine("=========================\n");
            //TextColorClass.ChangeTextColorReset();

            TextColorClass.ChangeTextColorCyan();
            Console.WriteLine("Press enter to end");
            Console.WriteLine("//////////////////\n");
            TextColorClass.ChangeTextColorReset();
            Console.ReadLine();
            Console.Clear();

        }
    }
}