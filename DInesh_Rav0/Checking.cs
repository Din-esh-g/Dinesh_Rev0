﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DInesh_Rav0
{
    public class Checking:IAccount
    {
        public int period { get; set; }
       public DateTime dateAndTime { get; set; }
        public string type { get; set; }
        public int accountNumber { get; set; }
        public int CustomerId { get; set; }
        public double InterestRate { get; set; }
        public double Balance { get; set; }
        public DateTime createdAt { get; set; }
        public bool status { get; set; }

        public List<Activities> transactionList = new List<Activities>();

        public void addTransaction(Activities transactionNew)
        {
            this.transactionList.Add(transactionNew);
        }

        public string withdraw(double amount)
        {
            if (this.Balance > amount)
            {
                this.Balance = this.Balance - amount;
                Activities transactionNew = new Activities()
                {
                    info = $"$Withdraw Amt:  {amount}  || Date: {DateTime.Now} || Current Balance:  ${this.Balance}."
                };
                this.addTransaction(transactionNew);

                return $"Withdraw Amt: \t ${amount}|| Account Number: \t {this.accountNumber}. New Balance: \t ${this.Balance}.";
            }
            else
            {
                return $"You can not withdrawl ${amount} because you dont have sufficent funds. Your have $ {this.Balance} in you account.";
            }

        }

        public string deposit(double amount)
        {

            this.Balance = this.Balance + amount;
            Activities transactionNew = new Activities()
            {
                info = $" \nDeposied Amount: ${amount} || Date:  {DateTime.Now} || Current Balance: $ {this.Balance}."
            };
            this.addTransaction(transactionNew);


            return $" \nDeposied Amount: ${amount} || Date:  {DateTime.Now} || Current Balance: $ {this.Balance}.";

        }


        public List<Activities> getLog()
        {
            return this.transactionList;
        }


    }
}
