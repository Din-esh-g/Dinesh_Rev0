using System;
using System.Collections.Generic;
using System.Text;

namespace DInesh_Rav0
{
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




        void addTransaction(Activities transactionNew);

        string withdraw(double amount);

        string deposit(double amount);





    }
}


