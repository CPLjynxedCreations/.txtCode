using System;

namespace PlayerNavSpace
{

    public class PlayerNavClass
    {
        static public string strPlayerInput;
        static List<string> strExit = new List<string> { "exit", "Exit", "EXIT" };
        static List<string> strConfirmYes = new List<string> { "yes", "Yes", "YES" };
        static List<string> strConfirmNo = new List<string> { "no", "No", "NO" };
        static bool boolIsExit = false;

        static public void PlayerNav()
        {
            strPlayerInput = Console.ReadLine();
            if (strExit.Contains(strPlayerInput))
            {
                End();
            }
        }

        static void End()
        {
            Console.WriteLine("Are you sure you would like to Exit\n" +
                "Type YES or NO to continue");
            strPlayerInput = Console.ReadLine();
            if (strConfirmYes.Contains(strPlayerInput))
            {
                Console.Clear();
                Environment.Exit(0);
            }
            else if (strConfirmNo.Contains(strPlayerInput))
            {
                Console.WriteLine("Please try your task again or\ntype Exit to leave");
                PlayerNav();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid response");
                End();
            }
        }
    }
}
