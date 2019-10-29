using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Twilio.Types;
using ConsoleTables;

namespace DInesh_Rav0
{
    public static class SelectionList
    {
        #region Welcome 
        public static void welcom()
        {

            Console.WriteLine("Please Select from following option: ");


            Console.WriteLine("\tc - Do you want to continue with Registration ");

            Console.WriteLine("\te - Exit from application. ");

            Console.Write("Your option? : => ");
            string optiono = Console.ReadLine();

            while (string.IsNullOrEmpty(optiono) && (!(optiono == "c") || !(optiono == "e")))
            {
                Console.WriteLine("Your Selection can't be empty! Input your selection once more");
                optiono = Console.ReadLine();
            }
            if (optiono == "c")
            {
                userRegistration();
            }
            else if (optiono == "e")
            {
                Console.WriteLine("\n\n Thank you For Using . ");
                Environment.Exit(0);

            }

        }

        #endregion
        #region New User Registration
        public static void userRegistration()
        {
            Console.WriteLine("==================================================\n");
            Console.WriteLine("\n\nWelcome to Registration Page:\n ");
            Console.WriteLine("===================================================\n");
            Console.Write("Please enter your First Name: \t\t\t=>");
            string fname = Console.ReadLine();
            while (string.IsNullOrEmpty(fname) )
            {
                Console.WriteLine("Umm It's Look Empty First name. ");
                fname = Console.ReadLine();
            }

            Console.Write("Please enter your Last Name: \t\t\t =>");
            string lname = Console.ReadLine();
            while (string.IsNullOrEmpty(lname))
            {
                Console.WriteLine("Umm It's Look Empty First name. ");
                lname = Console.ReadLine();
            }

            Console.Write("Please enter your Email Address: \t\t=>");
            string email = Validation.validEmail();
            while (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Umm It's Look Empty ..????. ");
                email = Console.ReadLine();
            }

            Console.Write("Please enter your Phone Number (Without Area Code and Space: 123456789) :=>");

            //long phone = long.Parse(Console.ReadLine());
            long phone = Validation.validPhone();
                       
            Console.Write("Please enter your Mailing Address:     \t=>");
            string address = Console.ReadLine();

            while (string.IsNullOrEmpty(address))
            {
                Console.WriteLine("Umm It's Look Empty First name. ");
                address = Console.ReadLine();
            }

            RegisterUser customerNew = new RegisterUser()
            {
                Id = ListEnums.custNumber,
                firstName = fname,
                lastName = lname,
                email = email,
                phoneNumber = phone,
                address = address
            };
            ListEnums.custNumber++;
            NewUser newUser = new NewUser();
            newUser.Create(customerNew);
           // Console.WriteLine(newUser.Create(customerNew));
          
                Console.WriteLine("Please press enter to continue ........");
                Console.ReadLine();
                
          selectionList();

        }
        #endregion
        #region Avilablae selection option
        public static void selectionList()
        {

            Console.Write("\nWelcome to the XXXXXXX Bank. What would you like to do today ? \n \n ================================\n\n"

                                    + "1. Return to Register Page \n"
                                    + "2. Open New Account. \n"
                                    + "3. Transaction \n"
                                    + "4. View Account \n"
                                    + "5. Close the Application \n"
                                    );

            Console.Write("\n Enter selection: => ");
            string userChoice = Console.ReadLine();


            while (string.IsNullOrEmpty(userChoice) && (((userChoice == "1") || (userChoice == "2") || (userChoice == "3") || (userChoice == "4") )))
            {
                Console.WriteLine("Your Selection can't be empty! Input your selection once more");
                userChoice = Console.ReadLine();
            }

            switch (userChoice)
            {
                case "1":
                    userRegistration();

                    break;
                case "2":

                    Console.WriteLine("\nPlease enter your Customer ID");
                    Console.Write("\n Your option? :=> ");
                    int custId = Convert.ToInt32(Console.ReadLine());
                    //int custId = getCustomerId();

                    Console.Write("\nWhat type of account would you like to open? \n \n =============================\n"

                                 + "1. Checking Account \n\n"
                                 + "2. Business Account \n\n"
                                 + "3. Term Account\n\n"
                                 + "4. Loan Account \n\n"
                                 );

                    Console.Write("\n Enter selection: :=> ");
                    string type = Console.ReadLine();

                    while (string.IsNullOrEmpty(type) && (((type == "1") || (type == "2") || (type == "3") || (type == "4"))))
                    {
                        Console.WriteLine("Your Selection can't be empty! Input your selection once more");
                        type = Console.ReadLine();
                    }

                    double rate = 0.00;
                    double balance = 0.00;
                    int period = 0;
                    DateTime dateAndTime;
                    // DateTime? period = null;
                    if (type == "1")
                    {
                        type = "Checking";
                        rate = 0.00;
                        dateAndTime = DateTime.Now;

                        IAccount accountNew = new Checking()
                        {
                            type = type,
                            accountNumber = ListEnums.accntNumberChk,
                            CustomerId = custId,
                            InterestRate = rate,
                            status = true,
                            Balance = balance,
                            dateAndTime = dateAndTime
                        };

                        ListEnums.accntNumberChk++;

                        NewAccount newAcc = new NewAccount();
                        newAcc.CreateAccount(accountNew);



                    }
                    else if (type == "2")
                    {
                        type = "Business";
                        rate = 1.99;
                        dateAndTime = DateTime.Now;
                        IAccount accountNew = new Business()
                        {
                            type = type,
                            accountNumber = ListEnums.accntNumberBs,
                            CustomerId = custId,
                            InterestRate = rate,
                            status = true,
                            Balance = balance,
                            dateAndTime = dateAndTime
                        };
                        ListEnums.accntNumberBs++;

                        NewAccount newBusinessAcc = new NewAccount();
                        newBusinessAcc.CreateAccount(accountNew);
                    }
                    else if (type == "3")
                    {
                        type = "Term";
                        rate = 4.0;
                        dateAndTime = DateTime.Now;
                        Console.WriteLine("\n Please Enter the period for your CD ?\n ");
                        Console.Write("\n Month   :=> ");
                        period = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\n How much would you like to deposit in your term account?\n ");
                        Console.Write("\n Your Amount : =>$");
                        balance = Convert.ToInt32(Console.ReadLine());

                        IAccount newTerm = new TermDeposit()
                        {
                            type = type,
                            accountNumber = ListEnums.accntNumberCD,
                            CustomerId = custId,
                            InterestRate = rate,
                            Balance = balance,
                            status = true,
                            period = period,
                            dateAndTime = dateAndTime


                        };

                        ListEnums.accntNumberCD++;

                        NewAccount newTermAccount = new NewAccount();
                        newTermAccount.CreateAccountTerm(newTerm);


                    }
                    else if (type == "4")
                    {
                        type = "Loan";
                        rate = 6.99;
                        dateAndTime = DateTime.Now;
                        Console.Write("The Loan Amount: $");

                        balance = 0 - Convert.ToInt32(Console.ReadLine());

                        IAccount newLoan = new Loan()
                        {
                            type = type,
                            accountNumber = ListEnums.accntNumberLn,
                            CustomerId = custId,
                            InterestRate = rate,
                            status = true,
                            Balance = balance,
                            dateAndTime = dateAndTime

                        };
                        ListEnums.accntNumberLn++;

                        NewAccount accountBL = new NewAccount();
                        accountBL.CreateAccount(newLoan);
                    }
                    else
                    {
                        Validation.notAvilable();
                    }

                    SelectionList.selectionList();

                    break;


                case "3":

                    Console.WriteLine("What is your account number?");
                    int accountId = Validation.validAccountNumber();



                    int accountIndex = ListEnums.AccountList.FindIndex(a => a.accountNumber.Equals(accountId));

                    Console.WriteLine("What is your Customer Id?");
                    int userInpuId = Validation.validUserId();
                    if (userInpuId != ListEnums.AccountList[accountIndex].CustomerId)
                    {
                        Console.WriteLine($"\n Customer Id does not Match with this account number {accountId} . ");
                        Validation.displaySelection();
                    }

                    //chking types here
                    var toAccountTypeofMainAccount = ListEnums.AccountList[accountIndex].type;

                    Console.Write("\nWhat type of transaction would you like to make? \n \n"
                                    + "1. Withdrawl \n"
                                    + "2. Deposit \n"
                                    + "3. Transfer Funds \n"
                                    + "4. Look up Account Balance\n"
                                    + "5. Look up  the transaction\n"
                                    + "6. Closed account\n"
                                    + "7. Return to Previouse Menu \n"
                                    + "8. Look up interest.\n\n"
                                    + "Enter selection: ");


                    Console.Write("\nYour Selection  : => ");

                    string transType = Console.ReadLine();

                    if (transType == "1")
                    {

                        Console.Write("Withdraw Amount: => $ ");
                        double amt = Validation.validAmtInput();

                        var accountType = ListEnums.AccountList[accountIndex].type;
                        if (accountType == "Checking")
                        {
                            Checking accountNew = new Checking();
                            accountNew = (Checking)ListEnums.AccountList[accountIndex];
                            Console.WriteLine(accountNew.withdraw(amt));
                            Validation.displaySelection();


                        }
                        else if (accountType == "Business")
                        {
                            Business accountNew = new Business();
                            accountNew = (Business)ListEnums.AccountList[accountIndex];
                            Console.WriteLine(accountNew.withdraw(amt));
                            Validation.displaySelection();


                        }
                        else if (accountType == "Term")
                        {
                            //check the date
                            foreach (IAccount item in ListEnums.AccountList)
                            {

                                if ((Validation.MonthDifference(DateTime.Now, item.dateAndTime) > item.period)) {

                                    TermDeposit accountNew = new TermDeposit();
                                    accountNew = (TermDeposit)ListEnums.AccountList[accountIndex];
                                    Console.WriteLine(accountNew.withdraw(amt));
                                    Validation.displaySelection();
                                }
                                else
                                {
                                    Console.WriteLine("Opertaion is not sucess. ");
                                }
                            }
                        }
                        else if (accountType == "Loan")
                        {
                            Loan accountNew = new Loan();
                            accountNew = (Loan)ListEnums.AccountList[accountIndex];
                            Console.WriteLine(accountNew.withdraw(amt));
                            Validation.displaySelection();
                        }
                    }


                    else if (transType == "2")
                    {

                        Console.WriteLine("Deposit Amount: ");
                        var accountType = ListEnums.AccountList[accountIndex].type;
                        double amount = Validation.validAmtInput();
                        if (accountType == "Checking")
                        {
                            Checking accountNew = new Checking();
                            accountNew = (Checking)ListEnums.AccountList[accountIndex];
                            Console.WriteLine(accountNew.deposit(amount));
                            Validation.displaySelection();

                        }
                        else if (accountType == "Business")
                        {
                            Business accountNew = new Business();
                            accountNew = (Business)ListEnums.AccountList[accountIndex];
                            Console.WriteLine(accountNew.deposit(amount));
                            Validation.displaySelection();


                        }
                        else if (accountType == "Term")
                        {
                            TermDeposit accountNew = new TermDeposit();
                            accountNew = (TermDeposit)ListEnums.AccountList[accountIndex];
                            Console.WriteLine(accountNew.deposit(amount));
                            Validation.displaySelection();

                        }
                        else if (accountType == "Loan")
                        {
                            Loan accountNew = new Loan();
                            accountNew = (Loan)ListEnums.AccountList[accountIndex];
                            Console.WriteLine(accountNew.deposit(amount));
                            Validation.displaySelection();
                        }
                    }
                    else if (transType == "3")
                    {

                        Console.Write("In which Account would like to transfer: ");
                        int toAccount = Validation.validAccountNumber();
                        // int toAccount =Convert.ToInt32( Console.ReadLine());

                        int toAccountIndex = ListEnums.AccountList.FindIndex(a => a.accountNumber.Equals(toAccount));


                        var toAccountType = ListEnums.AccountList[toAccountIndex].type;
                        Console.WriteLine("Checking the Types: " + toAccountType);



                        Console.Write("\nTransfer Amount : => $ \n");
                        double amount = Validation.validAmtInput();

                        if (toAccountTypeofMainAccount == "Checking")
                        {
                            Checking accountNew = new Checking();
                            accountNew = (Checking)ListEnums.AccountList[accountIndex];
                            Console.WriteLine(accountNew.withdraw(amount));

                            if (toAccountType == "Checking")
                            {
                                Checking toAccountNew = new Checking();
                                toAccountNew = (Checking)ListEnums.AccountList[toAccountIndex];
                                Console.WriteLine(toAccountNew.deposit(amount));
                                SelectionList.selectionList();

                            }
                            else if (toAccountType == "Business")
                            {
                                Business toAccountNew = new Business();
                                toAccountNew = (Business)ListEnums.AccountList[toAccountIndex];
                                Console.WriteLine(toAccountNew.deposit(amount));
                                SelectionList.selectionList();
                            }
                            else if (toAccountType == "Loan")
                            {
                                Loan toAccountNew = new Loan();
                                toAccountNew = (Loan)ListEnums.AccountList[toAccountIndex];
                                Console.WriteLine(toAccountNew.deposit(amount));
                                SelectionList.selectionList();
                            }
                            else
                            {
                                Console.WriteLine("You can only trasfer between Checking ,Buisness accounts, and Loan. ");
                                SelectionList.selectionList();
                            }

                        }
                        else if (toAccountTypeofMainAccount == "Business")
                        {
                            Business accountNew = new Business();
                            accountNew = (Business)ListEnums.AccountList[accountIndex];
                            Console.WriteLine(accountNew.withdraw(amount));

                            if (toAccountType == "Checking")
                            {
                                Checking toAccountNew = new Checking();
                                toAccountNew = (Checking)ListEnums.AccountList[toAccountIndex];
                                Console.WriteLine(toAccountNew.deposit(amount));
                                SelectionList.selectionList();
                            }
                            else if (toAccountType == "Business")
                            {
                                Business toAccountNew = new Business();
                                toAccountNew = (Business)ListEnums.AccountList[toAccountIndex];
                                Console.WriteLine(toAccountNew.deposit(amount));
                                SelectionList.selectionList();
                            }
                            else if (toAccountType == "Loan")
                            {
                                Loan toAccountNew = new Loan();
                                toAccountNew = (Loan)ListEnums.AccountList[toAccountIndex];
                                Console.WriteLine(toAccountNew.deposit(amount));
                                SelectionList.selectionList();
                            }
                            else
                            {
                                Console.WriteLine("You can only trasfer between Checking, Buisness, and Loan accounts. ");
                                SelectionList.selectionList();
                            }

                        }
                        //Transfer From Loan
                        else if (toAccountTypeofMainAccount == "Loan")
                        {
                            Loan accountNew = new Loan();
                            accountNew = (Loan)ListEnums.AccountList[accountIndex];
                            Console.WriteLine(accountNew.withdraw(amount));

                            if (toAccountType == "Checking")
                            {
                                Checking toAccountNew = new Checking();
                                toAccountNew = (Checking)ListEnums.AccountList[toAccountIndex];
                                Console.WriteLine(toAccountNew.deposit(amount));
                                SelectionList.selectionList();
                            }
                            else if (toAccountType == "Business")
                            {
                                Business toAccountNew = new Business();
                                toAccountNew = (Business)ListEnums.AccountList[toAccountIndex];
                                Console.WriteLine(toAccountNew.deposit(amount));
                                SelectionList.selectionList();
                            }
                            else if (toAccountType == "Loan")
                            {
                                Loan toAccountNew = new Loan();
                                toAccountNew = (Loan)ListEnums.AccountList[toAccountIndex];
                                Console.WriteLine(toAccountNew.deposit(amount));
                                SelectionList.selectionList();
                            }
                            else
                            {
                                Console.WriteLine("You can only trasfer between Checking, Buisness, and Loan accounts. ");
                                SelectionList.selectionList();
                            }

                        }


                        //Transfer from CD

                        else if (toAccountTypeofMainAccount == "Term")
                        {
                            //chek the maturity date here

                            foreach (IAccount item in ListEnums.AccountList)
                            {

                                if ((Validation.MonthDifference(DateTime.Now, item.dateAndTime) > item.period))
                                {

                                    TermDeposit accountNew = new TermDeposit();
                                    accountNew = (TermDeposit)ListEnums.AccountList[accountIndex];
                                    Console.WriteLine(accountNew.withdraw(amount));

                                    if (toAccountType == "Checking")
                                    {
                                        Checking toAccountNew = new Checking();
                                        toAccountNew = (Checking)ListEnums.AccountList[toAccountIndex];
                                        Console.WriteLine(toAccountNew.deposit(amount));
                                        SelectionList.selectionList();
                                    }
                                    else if (toAccountType == "Business")
                                    {
                                        Business toAccountNew = new Business();
                                        toAccountNew = (Business)ListEnums.AccountList[toAccountIndex];
                                        Console.WriteLine(toAccountNew.deposit(amount));
                                        SelectionList.selectionList();
                                    }
                                    else if (toAccountType == "Loan")
                                    {
                                        Loan toAccountNew = new Loan();
                                        toAccountNew = (Loan)ListEnums.AccountList[toAccountIndex];
                                        Console.WriteLine(toAccountNew.deposit(amount));
                                        SelectionList.selectionList();
                                    }
                                    else
                                    {
                                        Console.WriteLine("You can only trasfer between Checking, Buisness, and Loan accounts. ");
                                        SelectionList.selectionList();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nYour CD is not mature yet. \n\n ");
                                    SelectionList.selectionList();
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("You can only trasfer between Checking and Buisness accounts. ");
                            SelectionList.selectionList();
                        }


                    }
                    else if (transType == "4")
                    {

                        var currentBalance = ListEnums.AccountList[accountIndex].Balance;
                        Console.WriteLine($"Your account balance is:  $ {currentBalance}");
                        SelectionList.selectionList();

                    }
                    else if (transType == "5")
                    {
                        var accountType = ListEnums.AccountList[accountIndex].type;
                        if (accountType == "Checking")
                        {
                            Checking accountNew = new Checking();
                            accountNew = (Checking)ListEnums.AccountList[accountIndex];
                            foreach (Activities item in accountNew.getLog())
                            {
                                Console.WriteLine(item.info);
                            }
                            Validation.displaySelection();

                        }
                        else if (accountType == "Business")
                        {
                            Business accountNew = new Business();
                            accountNew = (Business)ListEnums.AccountList[accountIndex];
                            foreach (Activities item in accountNew.getLog())
                            {
                                Console.WriteLine(item.info);
                            }
                            Validation.displaySelection();


                        }
                        else if (accountType == "Term")
                        {
                            TermDeposit accountNew = new TermDeposit();
                            accountNew = (TermDeposit)ListEnums.AccountList[accountIndex];
                            foreach (Activities item in accountNew.getLog())
                            {
                                Console.WriteLine(item.info);
                            }
                            Validation.displaySelection();

                        }
                        else if (accountType == "Loan")
                        {
                            Loan accountNew = new Loan();
                            accountNew = (Loan)ListEnums.AccountList[accountIndex];
                            foreach (Activities item in accountNew.getLog())
                            {
                                Console.WriteLine(item.info);
                            }
                            Validation.displaySelection();
                        }

                    }
                    else if (transType == "6")
                    {
                        foreach (IAccount item in ListEnums.AccountList)
                        {

                            if (!Validation.checkBalance((accountIndex)))
                            {
                                ListEnums.AccountList.RemoveAt(accountIndex);
                                Console.WriteLine($"\nYou're account {item.accountNumber} has been deleted Sucessfully.\n ");
                                SelectionList.selectionList();
                            }
                            else
                            {
                                Console.WriteLine($"\n\nPlease Transfer/repay your balance $ {item.Balance}  first and try again.\n ");
                                SelectionList.selectionList();
                            }
                        }


                    }
                    // Back to main menu
                    else if (transType == "7")
                    {
                        Validation.notAvilable();
                        SelectionList.selectionList();
                    }
                    //Interest Look up is not 
            
                    else if (transType == "8")
                    {
                        var accountType = ListEnums.AccountList[accountIndex].type;

                        if (accountType == "Checking")
                        {
                            Checking accountNew = new Checking();
                            accountNew = (Checking)ListEnums.AccountList[accountIndex];
                            Console.WriteLine(accountNew.intrest(DateTime.Now));
                            
                            Validation.displaySelection();


                        }
                        else if (accountType == "Business")
                        {
                            Business accountNew = new Business();
                            accountNew = (Business)ListEnums.AccountList[accountIndex];
                            Console.WriteLine(accountNew.intrest(DateTime.Now));
                             Validation.displaySelection();


                        }
                        else if (accountType == "Term")
                        {
                            //check the date
                            foreach (IAccount item in ListEnums.AccountList)
                            {

                                if ((Validation.MonthDifference(DateTime.Now, item.dateAndTime) > item.period))
                                {

                                    TermDeposit accountNew = new TermDeposit();
                                    accountNew = (TermDeposit)ListEnums.AccountList[accountIndex];
                                    Console.WriteLine(accountNew.intrest(DateTime.Now));
                                    Validation.displaySelection();
                                }
                                else
                                {
                                    Console.WriteLine("Opertaion is not sucess. ");
                                }
                            }
                        }
                        else if (accountType == "Loan")
                        {
                            Loan accountNew = new Loan();
                            accountNew = (Loan)ListEnums.AccountList[accountIndex];
                            Console.WriteLine(accountNew.intrest(DateTime.Now));
                            Validation.displaySelection();
                        }
                    }



                                       

                        break;
                case "4":

                    Console.WriteLine("Please enter your customer ID");
                    int CustId = Validation.validUserId();
                    if (!Validation.customerIdValidation(CustId))
                    {
                        Console.WriteLine("There is no customer under that number.");
                        Validation.displaySelection();
                    }
                    else
                    {
                        Console.WriteLine("The Id  has following accounts...");
                        foreach (IAccount item in ListEnums.AccountList)
                        {
                            if (item.CustomerId == CustId)
                            {

                                Console.WriteLine("\n " + item.type +" Account: \n");
                                var table = new ConsoleTable("Account Number", "Types","Balance ",  "Date");
                                table.AddRow(item.accountNumber, item.type, item.Balance, item.dateAndTime);
                                table.Write();

                           
                            }
                        }
                        Validation.displaySelection();
                    }
                    

                    break;
                case "5":
                    Console.WriteLine(  " \n\n\n Thank you For Using ! .......................\n");
                    Environment.Exit(0);

                    break;
                default:

                    Validation.notAvilable();
                    break;
            }
        }

        #endregion

       // #region Validation and verification
       // /// <summary>
       // /// 
       // /// </summary>
       // /// <param name="toAccount"></param>
       // /// <returns></returns>

       // public static int MonthDifference(this DateTime lValue, DateTime rValue)
       // {
       //     return Math.Abs((lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year));
       // }

       // private static bool accountIdValidation(int toAccount)
       //     {
       //         bool found = false;

       //         foreach (IAccount item in ListEnums.AccountList)
       //         {
       //             if (item.accountNumber == toAccount)
       //             {
       //                 found = true;
       //             }
       //         }

       //         return found;
       //     }
       // /// <summary>
       // /// 
       // /// </summary>
       // /// <param name="sts"></param>
       // /// <returns>Status True or False</returns>
       // private static bool statusCheck()
       // {
            
       //     bool found = false;

       //     foreach (IAccount item in ListEnums.AccountList)
       //     {
       //         if (item.status == true)
       //         {
       //             found = true;
       //         }
       //     }

       //     return found;
       // }

       // //public static void transferInfo()
       // //{
       // //     try
       // //        {
       // //           if (SelectionList.checkBalance()
       // //        }
       // //        catch
       // //        {
                   
       // //        }
                     

       // //}

        
       // private static bool checkBalance(int account)
       // {
       //     bool found = false;

       //     foreach (IAccount item in ListEnums.AccountList)
       //     {
       //         if (item.Balance > 0)
       //         {
       //             found = true;
       //         }
       //     }

       //     return found;

       // }

       //     /// <summary>
       //     /// This will show the selection list to the users. 
       //     /// </summary>

       //     private static void displaySelection()
       //     {
       //         Console.WriteLine("Please press enter to return to the main menu");
       //         Console.ReadLine();
       //         SelectionList.selectionList();
       //     }
       //     /// <summary>
       //     /// This Method is print the user friendly Message to where to procede. 
       //     /// </summary>
       //     public static void notAvilable()
       //     {
       //         Console.WriteLine("\n\n***********Selection is not Found************\n");
       //         Console.WriteLine("Please press enter to return to the main menu");
       //         SelectionList.selectionList();

       //     }
       //     /// <summary>
       //     /// /
       //     /// </summary>
       //     /// <returns>Valid Amount . Amount in Double.  </returns>
       //    public static double validAmtInput()
       //     {

       //         try
       //         {
       //             double amount = Convert.ToInt32(Console.ReadLine());

       //             return amount;
       //         }
       //         catch
       //         {
       //             SelectionList.notAvilable();
       //             return 0;
       //         }
       //     }
       //     /// <summary>
       //     /// 
       //     /// </summary>
       //     /// <returns>Valid Account Number</returns>
       //     public static int validAccountNumber()
       //     {
       //         try
       //         {
       //             int accountId = Convert.ToInt32(Console.ReadLine());
       //             if (!SelectionList.validAccountNumbers(accountId))
       //             {
       //                 Console.WriteLine("\n\n *************No Account Found***********\n.");
       //                 Console.WriteLine("Please press enter to return to the main menu");
       //                 Console.ReadLine();
       //                 SelectionList.selectionList();
       //             }
       //             return accountId;
       //         }
       //         catch
       //         {
       //             notAvilable();
       //             return 0;
       //         }
       //     }
       //     /// <summary>
       //     /// /
       //     /// </summary>
       //     /// <returns>Valid User ID</returns>
       //     public static int validUserId()
       //     {
       //         try
       //         {
       //          string custId = (Console.ReadLine());
       //         int intCust = Convert.ToInt32(custId);

       //         while (string.IsNullOrEmpty(custId))
       //         {
       //             Console.WriteLine("Your Selection can't be empty! Input your selection once more");
       //             custId =(Console.ReadLine());
       //         }


       //         if (!SelectionList.customerIdValidation(intCust))
       //             {
       //                 Console.WriteLine("\n\n***********No User Found.*************\n");
       //                 displaySelection();
       //             }
       //             return intCust;
       //         }
       //         catch
       //         {
       //             Console.WriteLine("That was not a valid customer Id");

       //             SelectionList.selectionList();
       //             return 0;
       //         }
       //     }


       //     /// <summary>
       //     /// 
       //     /// </summary>
       //     /// <param name="telNo"></param>
       //     /// <returns></returns>
       //     public static bool validTelephoneNo(string telNo)
       //     {

       //         Regex r = new Regex("^[0-9]{9}$");
       //         if (r.IsMatch(telNo))
       //         {
       //             return false;
       //         }

       //         return true;
       //     }
       //     /// <summary>
       //     /// 
       //     /// </summary>
       //     /// <param name=" registerUserId"></param>
       //     /// <returns></returns>
       //     public static bool customerIdValidation(int registerUserId)
       //     {
       //         bool found = false;

       //         foreach (RegisterUser item in ListEnums.CustomerList)
       //         {
       //             if (item.Id == registerUserId)
       //             {
       //                 found = true;
       //             }
       //         }

       //         return found;
       //     }


       //     //
       //     /// <summary>
       //     /// 
       //     /// </summary>
       //     /// <param name="toAccount"></param>
       //     /// <returns></returns>
       //     private static bool validAccountNumbers(int toAccount)
       //     {
       //         bool found = false;

       //         foreach (IAccount item in ListEnums.AccountList)
       //         {
       //             if (item.accountNumber == toAccount)
       //             {
       //                 found = true;
       //             }
       //         }

       //         return found;
       //     }










       //     /// <summary>
       //     /// 
       //     /// </summary>
       //     /// <returns></returns>
       //     public static string validEmail()
       //     {
       //         string email = Console.ReadLine();
       //         try
       //         {
       //             if (!IsEmailSyntaxValid(email))
       //             {
       //                 Console.WriteLine("\n\n******That was not a valid Email*********** \n");
       //                 SelectionList.userRegistration();
       //             }
       //             return email;

       //         }
       //         catch
       //         {
       //             Console.WriteLine("\n\n******That was not a valid Email*********** \n");
       //             SelectionList.userRegistration();
       //             return null;
       //         }
       //     }

       //     /// <summary>
       //     /// 
       //     /// </summary>
       //     /// <returns></returns>
       //    public static long validPhone()
       //     {
       //         var phone = (Console.ReadLine());
       //         try
       //         {
       //             if (!validTelephoneNo(phone))
       //             {
       //                 Console.WriteLine("\n\n******* Ummm Phone Number doesnot look correct.  !!******** \n ");
       //                 SelectionList.userRegistration();
       //             }
       //             return long.Parse(phone);

       //         }
       //         catch
       //         {
       //             Console.WriteLine("\n\n******* Ummm Phone Number doesnot look correct.  !! \n ");
       //             SelectionList.userRegistration();
       //             return 0;
       //         }
       //     }


       //     /// <summary>
       //     /// 
       //     /// </summary>
       //     /// <param name="emailToValidate"></param>
       //     /// <returns></returns>
       //     public  static bool IsEmailSyntaxValid(string emailToValidate)
       //     {
       //         return System.Text.RegularExpressions.Regex.IsMatch(emailToValidate,
       //             @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
       //     }
       //public  static double interestCalulation()
       // {
       //     double interest = 0;
       //      foreach (IAccount item in ListEnums.AccountList)
       //         {

       //         interest = item.Balance * item.InterestRate * item.period;
       //     }
       //     return interest;
       // }
       // public static double interestForOtherAccount()
       // {
       //     double interest = 0;
       //     foreach (IAccount item in ListEnums.AccountList)
       //     {
       //         interest = (item.Balance * (MonthDifference(DateTime.Now,item.dateAndTime)/12) * item.InterestRate) / 100;
       //     }
       //     return interest;
       // }
            


       //     #endregion





        }
    }


