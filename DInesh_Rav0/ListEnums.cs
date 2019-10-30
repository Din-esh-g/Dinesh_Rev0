﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DInesh_Rav0
{
    /// <summary>
    /// This is the class where all the enmus, list, and account number is defined.   
    /// </summary>
    public class ListEnums
    {
        public static int custNumber = 1000;

        public static int accntNumberChk = 5000;
        public static int accntNumberLn = 6000;
        public static int accntNumberCD = 7000;
        public static int accntNumberBs = 4000;

        /// <summary>
        /// This is the list of customer
        /// </summary>
        public static List<RegisterUser> CustomerList = new List<RegisterUser>();
        /// <summary>
        /// This the list of Account and it's associated elements. 
        /// </summary>
        public static List<IAccount> AccountList = new List<IAccount>();
       
        /// <summary>
        /// This the list of enums which will used by this application. 
        /// </summary>
        public enum accountType
        {
            checking,
            buisness,
            term,
            loan
        };
    }
}

