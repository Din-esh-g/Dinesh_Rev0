using System;
using System.Collections.Generic;
using System.Text;

namespace DInesh_Rav0
{
    /// <summary>
    /// This is the interface which will be implemented by all the accounts we have. 
    /// </summary>
    public interface IAccount
    {
        string type { get; set; }
        int accountNumber { get; set; }
        int CustomerId { get; set; }
        double InterestRate { get; set; }
        double Balance { get; set; }
        bool status { get; set; }
        int period { get; set; }
        DateTime dateAndTime { get; set; }


        //This method will add the new transaction in list

        void addTransaction(Activities transactionNew);
        // withdraw transaction
        string withdraw(double amount);
        //deposit transaction
        string deposit(double amount);
        //for interest 
        string intrest(DateTime date);





    }
}


