using System;
using System.Collections.Generic;
using System.Text;

namespace DInesh_Rav0
{
    public class ListEnums
    {
        public static int custNumber = 1001000;

        public static int accntNumberChk = 5005000;
        public static int accntNumberLn = 6006000;
        public static int accntNumberCD = 7007000;
        public static int accntNumberBs = 4004000;


        public static List<RegisterUser> CustomerList = new List<RegisterUser>();

        public static List<IAccount> AccountList = new List<IAccount>();

        public enum accountType
        {
            checking,
            buisness,
            term,
            loan
        };
    }
}

