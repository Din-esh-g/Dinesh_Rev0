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
        /// <summary>
        /// This method will be load when program is load. 
        /// </summary>
        public static void welcom()
        {

            Console.WriteLine("Please Select from following option: ");


            Console.WriteLine("\tc - Do you want to continue with Registration ");
            Console.WriteLine("\ta - Already have Registered User ID. ");
            Console.WriteLine("\te - Exit from application. ");


            Console.Write("Your option? : => ");
            string optiono = Console.ReadLine();

            while (string.IsNullOrEmpty(optiono) && (!(optiono == "c") || !(optiono == "e") || !(optiono == "a")))
            {
                Console.WriteLine("Your Selection can't be empty! Input your selection once more");
                optiono = Console.ReadLine();
            }
            if (optiono == "c")
            {
                userRegistration();
            }
            else if (optiono == "a")
            {
                selectionList();

            }
            else if (optiono == "e")
            {
                Console.WriteLine("\n\n Thank you For Using . ");
                Environment.Exit(0);

            }

        }

        #endregion
        #region New User Registration
        /// <summary>
        /// This method will be called when user sucuessfully select the option from welecome method. 
        /// this method will create new RegisteruserId.
        /// this Id will be reqired to open the account and use the other option.
        /// </summary>
        public static void userRegistration()
        {
            Console.WriteLine("==================================================\n");
            Console.WriteLine("\n\nWelcome to Registration Page:\n ");
            Console.WriteLine("===================================================\n");
            Console.Write("Please enter your First Name: \t\t\t=>");
            string fname = Console.ReadLine();
            while (string.IsNullOrEmpty(fname))
            {
                Console.WriteLine("Umm It's Look Empty First name. Please Enter again : ");
                fname = Console.ReadLine();
            }

            Console.Write("Please enter your Last Name: \t\t\t =>");
            string lname = Console.ReadLine();
            while (string.IsNullOrEmpty(lname))
            {
                Console.WriteLine("Umm It's Look Empty Last name. Please Enter again . ");
                lname = Console.ReadLine();
            }

            Console.Write("Please enter your Email Address: \t\t=>");
            string email = Validation.validEmail();
            while (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Umm It's Look Empty ..????. Please Enter again. : ");
                email = Console.ReadLine();
            }

            Console.Write("Please enter your Phone Number (Without Area Code and Space: 0123456789) :=>");

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
        /// <summary>
        /// This is the regular menu for the customer who have valid account. 
        /// </summary>
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


            while (string.IsNullOrEmpty(userChoice) && (((userChoice == "1") || (userChoice == "2") || (userChoice == "3") || (userChoice == "4"))))
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
                    // int custId = Convert.ToInt32(Console.ReadLine());
                    int custId = Validation.validUserId();
                    //Providing the Option to the valid userID
                    Console.Write("\nWhat type of account would you like to open? \n \n =============================\n"

                                 + "1. Checking Account \n\n"
                                 + "2. Business Account \n\n"
                                 + "3. Term Account\n\n"
                                 + "4. Loan Account \n\n"
                                 );

                    Console.Write("\n Enter selection: :=> ");
                    string type = Console.ReadLine();
                    //Checking the input ..........up correct input. 
                    while (string.IsNullOrEmpty(type) && (((type == "1") || (type == "2") || (type == "3") || (type == "4"))))
                    {
                        Console.WriteLine("Your Selection can't be empty! Input your selection once more");
                        type = Console.ReadLine();
                    }
                    //Setting default to creat checking account. 
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
                        // to incerment the account number. 
                        ListEnums.accntNumberChk++;

                        NewAccount newAcc = new NewAccount();
                        newAcc.CreateAccount(accountNew);



                    }
                    //Creating Business Account. 
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
                    //Creating Term Account. 
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
                    //Creating Loan Account. 
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

                    //Defining index for account

                    int Index = ListEnums.AccountList.FindIndex(a => a.accountNumber.Equals(accountId));
                    //Validating user input 
                    Console.WriteLine("What is your Customer Id?");
                    int userInpuId = Validation.validUserId();
                    if (userInpuId != ListEnums.AccountList[Index].CustomerId)
                    {
                        Console.WriteLine($"\n Customer Id does not Match with this account number {accountId} . ");
                        Validation.displaySelection();
                    }

                    //chking types here
                    var toAccountTypeofMainAccount = ListEnums.AccountList[Index].type;

                    //Display the menu with valid user and valid account. 
                    Console.Write("\nWhat type of transaction would you like to make? \n \n"
                                    + "1. Deposit \n"
                                    + "2. Withdrawl \n"
                                    + "3. Transfer Funds \n"
                                    + "4. Look up Account Balance\n"
                                    + "5. Look up  the transaction\n"
                                    + "6. Closed account\n"
                                    + "7. Return to Previouse Menu \n"
                                    + "8. Look up interest.\n\n"
                                    + "Enter selection: ");


                    Console.Write("\nYour Selection  : => ");

                    string transType = Console.ReadLine();


                    //This else if part will be called when user want's to deposit
                    if (transType == "1")
                    {

                        Console.WriteLine("Deposit Amount: ");
                        //Cheking types
                        var accountType = ListEnums.AccountList[Index].type;
                        // amt validation
                        double amount = Validation.validAmtInput();

                        //Deposit for Checking. 
                        if (accountType == "Checking")
                        {
                            Checking accountNew = new Checking();
                            //Find the account
                            accountNew = (Checking)ListEnums.AccountList[Index];
                            //Perform the action
                            Console.WriteLine(accountNew.deposit(amount));
                            //back to main menu
                            Validation.displaySelection();

                        }
                        //Deposit for Business
                        else if (accountType == "Business")
                        {
                            Business accountNew = new Business();
                            accountNew = (Business)ListEnums.AccountList[Index];
                            Console.WriteLine(accountNew.deposit(amount));
                            Validation.displaySelection();


                        }
                        //Deposit for Term Account
                        else if (accountType == "Term")
                        {
                            TermDeposit accountNew = new TermDeposit();
                            accountNew = (TermDeposit)ListEnums.AccountList[Index];
                            Console.WriteLine(accountNew.deposit(amount));
                            Validation.displaySelection();

                        }
                        //Deposit for Loan
                        else if (accountType == "Loan")
                        {
                            Loan accountNew = new Loan();
                            accountNew = (Loan)ListEnums.AccountList[Index];
                            Console.WriteLine(accountNew.deposit(amount));
                            Validation.displaySelection();
                        }
                    }


                    //Withdrawl Part
                    else if (transType == "2")
                    {
                        //Taking amt
                        Console.Write("Withdraw Amount: => $ ");
                        //validate the amt
                        double amt = Validation.validAmtInput();
                        //Taking the types 
                        var accountType = ListEnums.AccountList[Index].type;

                        //Withdrawl from checking 
                        if (accountType == "Checking")
                        {
                            Checking accountNew = new Checking();
                            //Find the account first
                            accountNew = (Checking)ListEnums.AccountList[Index];
                            //Action performed and dispaly the message 
                            Console.WriteLine(accountNew.withdraw(amt));
                            //Back to the menue
                            Validation.displaySelection();


                        }

                        //Withdrawl from Business

                        else if (accountType == "Business")
                        {
                            Business accountNew = new Business();
                            //Find the account first and
                            accountNew = (Business)ListEnums.AccountList[Index];
                            // Withdraw is happend.
                            Console.WriteLine(accountNew.withdraw(amt));
                            Validation.displaySelection();


                        }

                        //Withdrawl from Term Account

                        else if (accountType == "Term")
                        {
                            //check the date
                            foreach (IAccount item in ListEnums.AccountList)
                            {
                                //Maturity test
                                if ((Validation.MonthDifference(DateTime.Now, item.dateAndTime) > item.period))
                                {

                                    TermDeposit accountNew = new TermDeposit();
                                    accountNew = (TermDeposit)ListEnums.AccountList[Index];
                                    Console.WriteLine(accountNew.withdraw(amt));
                                    Validation.displaySelection();
                                }
                                else
                                {
                                    Console.WriteLine("Opertaion is not sucess. ");
                                }
                            }
                        }
                        //
                        //Withdrawl from Loan

                        else if (accountType == "Loan")
                        {
                            Loan accountNew = new Loan();
                            accountNew = (Loan)ListEnums.AccountList[Index];
                            Console.WriteLine(accountNew.withdraw(amt));
                            Validation.displaySelection();
                        }
                    }


                    //This else if will work with Transfer. 
                    else if (transType == "3")
                    {

                        Console.Write("In which Account would like to transfer: ");

                        int toAccount = Validation.validAccountNumber();
                        // int toAccount =Convert.ToInt32( Console.ReadLine());// Checking
                        // to verify the account is exit i am looking serching the index.
                        //toAccount is the passed account number 

                        int IndexLocal = ListEnums.AccountList.FindIndex(a => a.accountNumber.Equals(toAccount));


                        var toAccountType = ListEnums.AccountList[IndexLocal].type;

                        Console.WriteLine("Checking the Types: " + toAccountType);//Testing 



                        Console.Write("\nTransfer Amount : => $ \n");
                        double amount = Validation.validAmtInput();
                        // From Cheking 

                        if (toAccountTypeofMainAccount == "Checking")
                        {
                            Checking accountNew = new Checking();
                            // now we are looking the account 
                            accountNew = (Checking)ListEnums.AccountList[Index];
                            //founded then withdraw
                            Console.WriteLine(accountNew.withdraw(amount));
                            //checking
                            if (toAccountType == "Checking")
                            {
                                Checking toAccountNew = new Checking();
                                toAccountNew = (Checking)ListEnums.AccountList[IndexLocal];
                                Console.WriteLine(toAccountNew.deposit(amount));
                                SelectionList.selectionList();

                            }
                            //Business
                            else if (toAccountType == "Business")
                            {
                                Business toAccountNew = new Business();
                                toAccountNew = (Business)ListEnums.AccountList[IndexLocal];
                                Console.WriteLine(toAccountNew.deposit(amount));
                                SelectionList.selectionList();
                            }
                            //Loan
                            else if (toAccountType == "Loan")
                            {
                                Loan toAccountNew = new Loan();
                                toAccountNew = (Loan)ListEnums.AccountList[IndexLocal];
                                Console.WriteLine(toAccountNew.deposit(amount));
                                SelectionList.selectionList();
                            }
                            else
                            {
                                Console.WriteLine("You can only trasfer between Checking ,Buisness accounts, and Loan. ");
                                SelectionList.selectionList();
                            }

                        }
                        //From Business. 
                        else if (toAccountTypeofMainAccount == "Business")
                        {
                            Business accountNew = new Business();
                            accountNew = (Business)ListEnums.AccountList[Index];
                            Console.WriteLine(accountNew.withdraw(amount));
                            // TO checking
                            if (toAccountType == "Checking")
                            {
                                Checking toAccountNew = new Checking();
                                toAccountNew = (Checking)ListEnums.AccountList[IndexLocal];
                                Console.WriteLine(toAccountNew.deposit(amount));
                                SelectionList.selectionList();
                            }
                            //To Business
                            else if (toAccountType == "Business")
                            {
                                Business toAccountNew = new Business();
                                toAccountNew = (Business)ListEnums.AccountList[IndexLocal];
                                Console.WriteLine(toAccountNew.deposit(amount));
                                SelectionList.selectionList();
                            }
                            //To Loan
                            else if (toAccountType == "Loan")
                            {
                                Loan toAccountNew = new Loan();
                                toAccountNew = (Loan)ListEnums.AccountList[IndexLocal];
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
                            accountNew = (Loan)ListEnums.AccountList[Index];
                            Console.WriteLine(accountNew.withdraw(amount));

                            if (toAccountType == "Checking")
                            {
                                Checking toAccountNew = new Checking();
                                toAccountNew = (Checking)ListEnums.AccountList[IndexLocal];
                                Console.WriteLine(toAccountNew.deposit(amount));
                                SelectionList.selectionList();
                            }
                            else if (toAccountType == "Business")
                            {
                                Business toAccountNew = new Business();
                                toAccountNew = (Business)ListEnums.AccountList[IndexLocal];
                                Console.WriteLine(toAccountNew.deposit(amount));
                                SelectionList.selectionList();
                            }
                            else if (toAccountType == "Loan")
                            {
                                Loan toAccountNew = new Loan();
                                toAccountNew = (Loan)ListEnums.AccountList[IndexLocal];
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
                                    accountNew = (TermDeposit)ListEnums.AccountList[Index];
                                    Console.WriteLine(accountNew.withdraw(amount));

                                    if (toAccountType == "Checking")
                                    {
                                        Checking toAccountNew = new Checking();
                                        toAccountNew = (Checking)ListEnums.AccountList[IndexLocal];
                                        Console.WriteLine(toAccountNew.deposit(amount));
                                        SelectionList.selectionList();
                                    }
                                    else if (toAccountType == "Business")
                                    {
                                        Business toAccountNew = new Business();
                                        toAccountNew = (Business)ListEnums.AccountList[IndexLocal];
                                        Console.WriteLine(toAccountNew.deposit(amount));
                                        SelectionList.selectionList();
                                    }
                                    else if (toAccountType == "Loan")
                                    {
                                        Loan toAccountNew = new Loan();
                                        toAccountNew = (Loan)ListEnums.AccountList[IndexLocal];
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
                    //Display the balance
                    else if (transType == "4")
                    {

                        var currentBalance = ListEnums.AccountList[Index].Balance;
                        Console.WriteLine($"Your account balance is:  $ {currentBalance}");
                        SelectionList.selectionList();

                    }
                    //Look up  the transaction
                    else if (transType == "5")
                    {
                        var accountType = ListEnums.AccountList[Index].type;
                        if (accountType == "Checking")
                        {
                            Checking accountNew = new Checking();
                            accountNew = (Checking)ListEnums.AccountList[Index];
                            foreach (Activities item in accountNew.getLog())
                            {
                                Console.WriteLine(item.info);
                            }
                            Validation.displaySelection();

                        }
                        else if (accountType == "Business")
                        {
                            Business accountNew = new Business();
                            accountNew = (Business)ListEnums.AccountList[Index];
                            foreach (Activities item in accountNew.getLog())
                            {
                                Console.WriteLine(item.info);
                            }
                            Validation.displaySelection();


                        }
                        else if (accountType == "Term")
                        {
                            TermDeposit accountNew = new TermDeposit();
                            accountNew = (TermDeposit)ListEnums.AccountList[Index];
                            foreach (Activities item in accountNew.getLog())
                            {
                                Console.WriteLine(item.info);
                            }
                            Validation.displaySelection();

                        }
                        else if (accountType == "Loan")
                        {
                            Loan accountNew = new Loan();
                            accountNew = (Loan)ListEnums.AccountList[Index];
                            foreach (Activities item in accountNew.getLog())
                            {
                                Console.WriteLine(item.info);
                            }
                            Validation.displaySelection();
                        }

                    }
                    //Closed Account
                    else if (transType == "6")
                    {
                        foreach (IAccount item in ListEnums.AccountList)
                        {

                            if (!Validation.checkBalance((Index)))
                            {
                                ListEnums.AccountList.RemoveAt(Index);
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
                        var accountType = ListEnums.AccountList[Index].type;

                        if (accountType == "Checking")
                        {
                            Checking accountNew = new Checking();
                            accountNew = (Checking)ListEnums.AccountList[Index];
                            Console.WriteLine(accountNew.intrest(DateTime.Now));

                            Validation.displaySelection();


                        }
                        else if (accountType == "Business")
                        {
                            Business accountNew = new Business();
                            accountNew = (Business)ListEnums.AccountList[Index];
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
                                    accountNew = (TermDeposit)ListEnums.AccountList[Index];
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
                            accountNew = (Loan)ListEnums.AccountList[Index];
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

                                Console.WriteLine("\n " + item.type + " Account: \n");
                                var table = new ConsoleTable("Account Number", "Types", "Balance ", "Date");
                                table.AddRow(item.accountNumber, item.type, item.Balance, item.dateAndTime);
                                table.Write();


                            }
                        }
                        Validation.displaySelection();
                    }

                    //Exit From program
                    break;
                case "5":
                    Console.WriteLine(" \n\n\n Thank you For Using ! .......................\n");
                    Environment.Exit(0);

                    break;
                default:

                    Validation.notAvilable();
                    break;
            }
        }

        #endregion





    }
}


