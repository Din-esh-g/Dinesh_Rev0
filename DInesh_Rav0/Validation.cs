using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DInesh_Rav0
{
    public static class Validation
    {



        #region Validation and verification
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toAccount"></param>
        /// <returns></returns>

        public static int MonthDifference(this DateTime lValue, DateTime rValue)
        {
            return Math.Abs((lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year));
        }

        public static bool accountIdValidation(int toAccount)
        {
            bool found = false;

            foreach (IAccount item in ListEnums.AccountList)
            {
                if (item.accountNumber == toAccount)
                {
                    found = true;
                }
            }

            return found;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sts"></param>
        /// <returns>Status True or False</returns>
        public static bool statusCheck()
        {

            bool found = false;

            foreach (IAccount item in ListEnums.AccountList)
            {
                if (item.status == true)
                {
                    found = true;
                }
            }

            return found;
        }

        //public static void transferInfo()
        //{
        //     try
        //        {
        //           if (SelectionList.checkBalance()
        //        }
        //        catch
        //        {

        //        }


        //}


        public static bool checkBalance(int account)
        {
            bool found = false;

            foreach (IAccount item in ListEnums.AccountList)
            {
                if (item.Balance > 0)
                {
                    found = true;
                }
            }

            return found;

        }

        /// <summary>
        /// This will show the selection list to the users. 
        /// </summary>

        public static void displaySelection()
        {
            Console.WriteLine("Please press enter to return to the main menu");
            Console.ReadLine();
            SelectionList.selectionList();
        }
        /// <summary>
        /// This Method is print the user friendly Message to where to procede. 
        /// </summary>
        public static void notAvilable()
        {
            Console.WriteLine("\n\n***********Selection is not Found************\n");
            Console.WriteLine("Please press enter to return to the main menu");
            SelectionList.selectionList();

        }
        /// <summary>
        /// /
        /// </summary>
        /// <returns>Valid Amount . Amount in Double.  </returns>
        public static double validAmtInput()
        {

            try
            {
                double amount = Convert.ToInt32(Console.ReadLine());

                return amount;
            }
            catch
            {
                Validation.notAvilable();
                return 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Valid Account Number</returns>
        public static int validAccountNumber()
        {
            try
            {
                int accountId = Convert.ToInt32(Console.ReadLine());
                if (!Validation.validAccountNumbers(accountId))
                {
                    Console.WriteLine("\n\n *************No Account Found***********\n.");
                    Console.WriteLine("Please press enter to return to the main menu");
                    Console.ReadLine();
                    SelectionList.selectionList();
                }
                return accountId;
            }
            catch
            {
                notAvilable();
                return 0;
            }
        }
        /// <summary>
        /// /
        /// </summary>
        /// <returns>Valid User ID</returns>
        public static int validUserId()
        {
            try
            {
                string custId = (Console.ReadLine());
                int intCust = Convert.ToInt32(custId);

                while (string.IsNullOrEmpty(custId))
                {
                    Console.WriteLine("Your Selection can't be empty! Input your selection once more");
                    custId = (Console.ReadLine());
                }


                if (!Validation.customerIdValidation(intCust))
                {
                    Console.WriteLine("\n\n***********No User Found.*************\n");
                    displaySelection();
                }
                return intCust;
            }
            catch
            {
                Console.WriteLine("That was not a valid customer Id");

                SelectionList.selectionList();
                return 0;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="telNo"></param>
        /// <returns></returns>
        public static bool validTelephoneNo(string telNo)
        {

            Regex r = new Regex("^[0-9]{9}$");
            if (r.IsMatch(telNo))
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name=" registerUserId"></param>
        /// <returns></returns>
        public static bool customerIdValidation(int registerUserId)
        {
            bool found = false;

            foreach (RegisterUser item in ListEnums.CustomerList)
            {
                if (item.Id == registerUserId)
                {
                    found = true;
                }
            }

            return found;
        }


        //
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toAccount"></param>
        /// <returns></returns>
        public static bool validAccountNumbers(int toAccount)
        {
            bool found = false;

            foreach (IAccount item in ListEnums.AccountList)
            {
                if (item.accountNumber == toAccount)
                {
                    found = true;
                }
            }

            return found;
        }










        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string validEmail()
        {
            string email = Console.ReadLine();
            try
            {
                if (!IsEmailSyntaxValid(email))
                {
                    Console.WriteLine("\n\n******That was not a valid Email*********** \n");
                    SelectionList.userRegistration();
                }
                return email;

            }
            catch
            {
                Console.WriteLine("\n\n******That was not a valid Email*********** \n");
                SelectionList.userRegistration();
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static long validPhone()
        {
            var phone = (Console.ReadLine());
            try
            {
                if (!validTelephoneNo(phone))
                {
                    Console.WriteLine("\n\n******* Ummm Phone Number doesnot look correct.  !!******** \n ");
                    SelectionList.userRegistration();
                }
                return long.Parse(phone);

            }
            catch
            {
                Console.WriteLine("\n\n******* Ummm Phone Number doesnot look correct.  !! \n ");
                SelectionList.userRegistration();
                return 0;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailToValidate"></param>
        /// <returns></returns>
        public static bool IsEmailSyntaxValid(string emailToValidate)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(emailToValidate,
                @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        public static double interestCalulation()
        {
            double interest = 0;
            foreach (IAccount item in ListEnums.AccountList)
            {

                interest = item.Balance * item.InterestRate * item.period;
            }
            return interest;
        }
        public static double interestForOtherAccount()
        {
            double interest = 0;
            foreach (IAccount item in ListEnums.AccountList)
            {
                interest = (item.Balance * (MonthDifference(DateTime.Now, item.dateAndTime) / 12) * item.InterestRate) / 100;
            }
            return interest;
        }



        #endregion










    }
}
