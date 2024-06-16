using System;
using System.Collections.Generic;

namespace PlayerDetailsSpace
{

    public class PlayerDetailsClass
    {
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

        static public void PlayerDetailsEnter()
        {
            Console.WriteLine("**WELCOME**");
            Console.WriteLine("Please enter Players name");
            strPlayerName = Console.ReadLine();

            if (strPlayerName.Length >= 1)
            {
                Console.Clear();
                Console.WriteLine("**HAS CHARACTERS**");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("**NO CHARACTERS**");
                //after repeating it will write multiple copies of the details
                //PlayerDetailsEnter();
            }

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
                    // IF NO FILE FOUND. MAKE ONE
                    File.AppendAllText(strPlayerName + ".txt",
                        "PLAYER NAME = " + strPlayerName + "\n" +
                        "PLAYER PASSWORD = " + strPlayerPassword + "\n" +
                        "PLAYER LEVEL = " + intPlayerLevel + "\n" +
                        "PLAYER MONEY = " + intPlayerMoney + "\n" +
                        "PLAYER XP = " + intPlayerXp);
                    //ADD EXTRA FILE INFO TO BE SAVED AT FILE MAKE
                    Console.WriteLine("**PLAYER FILE CREATED**");
                }
                else
                {
                    
                    Console.WriteLine("Password does not match");
                    //make it restart password enter
                }

            }
            else if (File.Exists(strPlayerName + ".txt"))
            {
                Console.Clear();
                // IF FILE FOUND GET THE DETAILS
                var dic = File.ReadAllLines(strPlayerName + ".txt")
                        .Select(l => l.Split(new[] { '=' }))
                        .ToDictionary(s => s[0].Trim(), s => s[1].Trim());

                strPlayerSavedPassword = dic["PLAYER PASSWORD"];
                Console.WriteLine("**ACCOUNT FOUND**");
                Console.WriteLine("Please enter your password");
                strPlayerPassword = Console.ReadLine();

                if (strPlayerPassword == strPlayerSavedPassword)
                {
                    Console.Clear();
                    Console.WriteLine("**LOGGED IN**");
                    strPlayerLevel = dic["PLAYER LEVEL"];
                    strPlayerName = dic["PLAYER NAME"];
                    strPlayerMoney = dic["PLAYER MONEY"];
                    strPlayerXp = dic["PLAYER XP"];
                    Console.WriteLine("Player name is: " + strPlayerName);
                    Console.WriteLine("level is: " + strPlayerLevel);
                    Console.WriteLine("money is: " + strPlayerMoney);
                    Console.WriteLine("xp is: " + strPlayerXp);
                    //Gets player level and converts string to int
                    intPlayerLevel = Convert.ToInt32(strPlayerLevel);
                    intPlayerMoney = Convert.ToInt32(strPlayerMoney);
                    intPlayerXp = Convert.ToInt32(strPlayerXp);
                    SavePlayerDetails();
                }
                else
                {
                    Console.WriteLine("Wrong Password");
                }
            }
        }

        static void CreateNewPlayer()
        {
            //NEW FILE CREATING HERE FOR NEW PLAYER
        }

        static void LoadPlayerDetails()
        {
            //IF ACCOUNT. LOAD ACCOUNT HERE 
        }

        static void SavePlayerDetails()
        {
            //WRITE OVER OLD FILE WITH NEW PLAYER STATS
            intPlayerLevel = 30;
            //ADDS EXTRA LINE AT THE END OF THE FILE
            //ADD ALL PLAYER DATA
            File.AppendAllText(strPlayerName + ".txt",
                        "\nPOINTS = " + intPlayerLevel + "\n");
        }
    }
}
