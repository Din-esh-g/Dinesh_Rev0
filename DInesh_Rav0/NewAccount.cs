using System;
using System.Collections.Generic;
using System.Text;

namespace DInesh_Rav0
{
   public class NewAccount
    {
        public string CreateAccount(IAccount accountNew)

        {

            string accntInfo = $"\n\nCongratulations you have created a new {accountNew.type} account.\n";
            accntInfo += $"Your new account number :  {accountNew.accountNumber}. ||";
            accntInfo += $"Account Balance: $ {accountNew.Balance} ||Interest Rate:  {accountNew.InterestRate}% || Satatus : { accountNew.status}  Date: {DateTime.Now}";
            ListEnums.AccountList.Add(accountNew);

            return accntInfo;
        }

        public string CreateAccountTerm(IAccount accountNew)

        {

            string accntInfo = $"\n\nCongratulations you have created a new {accountNew.type} account with Following details: \n" ;
            accntInfo += $"Account Number:  {accountNew.accountNumber}. ||";
            accntInfo += $"Balance : $  {accountNew.Balance} || Interest Rate:  {accountNew.InterestRate} %|| Duration: {accountNew.period} Month|| Satatus : {accountNew.status}  Date: {DateTime.Now} ";
            ListEnums.AccountList.Add(accountNew);

            return accntInfo;
        }

    }

}

