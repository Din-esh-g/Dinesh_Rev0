using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DInesh_Rav0
{
   public class NewAccount
    {
        public void CreateAccount(IAccount accountNew)

        {
            Console.WriteLine("\n\nCongratulation !!!\n\n Following is details of your new Account: \n \n");
            ListEnums.AccountList.Add(accountNew);           
            var table = new ConsoleTable("Account Number", "Balance ", "Interest Rate","Types", "Status", "Date");
            table.AddRow(accountNew.accountNumber,  "$ "+accountNew.Balance, accountNew.InterestRate +"%", accountNew.type, accountNew.status, accountNew.dateAndTime);
            table.Write();

           
        }

        public void CreateAccountTerm(IAccount accountNew)

        {
            Console.WriteLine("\n\nCongratulation !!!\n\n Following is details of your new Account: \n \n");
            ListEnums.AccountList.Add(accountNew);
            var table = new ConsoleTable("Account Number", "Balance ", "Interest Rate", "Period","Types", "Status", "Date");
            table.AddRow(accountNew.accountNumber, "$ " + accountNew.Balance, accountNew.InterestRate +" %", accountNew.period +" Month",accountNew.type, accountNew.status, accountNew.dateAndTime);
            table.Write();


        }



    }

}

