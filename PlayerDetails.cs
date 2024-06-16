using System;
using System.Collections.Generic;

namespace PlayerDetailsSpace
{

    public class PlayerDetailsClass
    {
        static public bool boolPlayerLoggedIn = false;
        static public string strPlayerName;
        static public string strPlayerPassword;
        static public string strPlayerSavedPassword;
        static public string strPlayerNewPassword;
        static public string strPlayerNewPasswordRepeat;
        static public string strPlayerLevel;
        static public string strPlayerMoney;
        static public string strPlayerXp;
        static public int intPlayerLevel = 0;
        static public int intPlayerMoney = 0;
        static public int intPlayerXp = 0;

        static public void PlayerWelcome()
        {
            Console.WriteLine("**WELCOME**");
            Console.WriteLine("Please enter Players name");
            strPlayerName = Console.ReadLine();

            if (!File.Exists(strPlayerName + ".txt"))
            {
                Console.WriteLine("**NO EXISTING ACCOUNT**");
                Console.WriteLine("Please enter a password");
                strPlayerNewPassword = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Please retype password");
                strPlayerNewPasswordRepeat = Console.ReadLine();

                if (strPlayerNewPassword == strPlayerNewPasswordRepeat)
                {
                    strPlayerPassword = strPlayerNewPassword;
                    Console.WriteLine("Passwords match");
                    Console.Clear();
                    CreateNewPlayerFile();
                }
                else
                {
                    Console.WriteLine("Password does not match");
                    PlayerWelcome();
                }
            }
            else if (File.Exists(strPlayerName + ".txt"))
            {
                Console.Clear();
                // IF FILE FOUND GET THE DETAILS
                LoadPlayerDetails();
                Console.WriteLine("**ACCOUNT FOUND**");
                Console.WriteLine("Please enter your password");
                strPlayerPassword = Console.ReadLine();
                LoadPlayerDetails();
                if (boolPlayerLoggedIn)
                {
                    Console.Clear();
                    Console.WriteLine("**LOGGED IN**");
                    Console.WriteLine("Player name is: " + strPlayerName);
                    Console.WriteLine("level is: " + strPlayerLevel);
                    Console.WriteLine("money is: " + strPlayerMoney);
                    Console.WriteLine("xp is: " + strPlayerXp);
                    //Gets player level and converts string to int
                    intPlayerLevel = Convert.ToInt32(strPlayerLevel);
                    intPlayerMoney = Convert.ToInt32(strPlayerMoney);
                    intPlayerXp = Convert.ToInt32(strPlayerXp);
                    Console.ReadLine();
                    SavePlayerDetails();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong Password");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    PlayerWelcome();
                }
            }

            static void LoadPlayerDetails()
            {
                var dic = File.ReadAllLines(strPlayerName + ".txt")
                        .Select(l => l.Split(new[] { '=' }))
                        .ToDictionary(s => s[0].Trim(), s => s[1].Trim());
                strPlayerSavedPassword = dic["PLAYER PASSWORD"];
                if (strPlayerPassword == strPlayerSavedPassword)
                {
                    boolPlayerLoggedIn = true;
                    strPlayerLevel = dic["PLAYER LEVEL"];
                    strPlayerName = dic["PLAYER NAME"];
                    strPlayerMoney = dic["PLAYER MONEY"];
                    strPlayerXp = dic["PLAYER XP"];
                }
                else
                {
                    boolPlayerLoggedIn = false;
                }
            }

            static void CreateNewPlayerFile()
            {
                File.AppendAllText(strPlayerName + ".txt",
                    "PLAYER NAME = " + strPlayerName + "\n" +
                    "PLAYER PASSWORD = " + strPlayerPassword + "\n" +
                    "PLAYER LEVEL = " + intPlayerLevel + "\n" +
                    "PLAYER MONEY = " + intPlayerMoney + "\n" +
                    "PLAYER XP = " + intPlayerXp);
                //ADD EXTRA FILE INFO TO BE SAVED AT FILE MAKE
                Console.WriteLine("**PLAYER FILE CREATED**");
            }
            static void SavePlayerDetails()
            {
                //ADDED CHANGE TO SEE RESULTS
                intPlayerLevel = 3;
                intPlayerMoney = 2000;
                intPlayerXp = 400;
                System.IO.File.WriteAllText(strPlayerName + ".txt", string.Empty);
                File.AppendAllText(strPlayerName + ".txt",
                        "PLAYER NAME = " + strPlayerName + "\n" +
                        "PLAYER PASSWORD = " + strPlayerPassword + "\n" +
                        "PLAYER LEVEL = " + intPlayerLevel + "\n" +
                        "PLAYER MONEY = " + intPlayerMoney + "\n" +
                        "PLAYER XP = " + intPlayerXp + "\n" +
                        "PLAYER FILE = UPDATED");
                //ADD EXTRA FILE INFO TO BE SAVED AT FILE MAKE
                Console.Clear();
                Console.WriteLine("**PLAYER DATA UPDATED**");
                Console.WriteLine("Player name is: " + strPlayerName);
                Console.WriteLine("level is: " + strPlayerLevel);
                Console.WriteLine("money is: " + strPlayerMoney);
                Console.WriteLine("xp is: " + strPlayerXp);
                //ADD EXTRA SAVE DETAILS
            }
        }
    }
}
