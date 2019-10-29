using System;
using System.Collections.Generic;
using System.Text;

namespace DInesh_Rav0
{
    public class TermDeposit: IAccount
    {
        public string type { get; set; }
        public int accountNumber { get; set; }
        public int CustomerId { get; set; }
        public double InterestRate { get; set; }
        public double Balance { get; set; }

        public DateTime createdAt { get; set; }
        public bool status { get; set; }
        public int period { get; set; }
        public DateTime dateAndTime { get; set; }


        public List<Activities> transactionList = new List<Activities>();

        public void addTransaction(Activities transactionNew)
        {
            this.transactionList.Add(transactionNew);
        }

        public string withdraw(double amount)
        {
            
            this.Balance = this.Balance - amount;
            Activities transactionNew = new Activities()
            {
                info = $"${amount} has been withdrawn at {DateTime.Now} balance is now ${this.Balance}."
            };
            this.addTransaction(transactionNew);

            return $"You withdrew ${amount} from account number {this.accountNumber}. Your balance is now ${this.Balance}.";

        }

        public string deposit(double amount)
        {

            this.Balance = this.Balance + amount;
            Activities transactionNew = new Activities()
            {
                info = $"${amount} has been deposited at {DateTime.Now} balance is now ${this.Balance}."
            };
            this.addTransaction(transactionNew);


            return $"You have deposited ${amount} into account number {this.accountNumber}. Your balance is now ${this.Balance}.";
        }

        public string intrest(DateTime date)

        {
            date = DateTime.Now;
            if (this.status == true)
            {
                double interestAmt = (this.Balance * (Validation.MonthDifference(date, this.dateAndTime)) * this.InterestRate);
                this.Balance = this.Balance + (this.Balance * (Validation.MonthDifference(DateTime.Now, this.dateAndTime)*30) * (this.InterestRate/(365*100)));
                Activities transactionNew = new Activities()
                {
                    info = $" Your Accured $ {interestAmt} has been added at {DateTime.Now} balance is now $ {this.Balance} in your  {this.type} account. "
                };
                this.addTransaction(transactionNew);

                return $" Your Accured $ {interestAmt} has been added at {DateTime.Now} balance is now $ {this.Balance} in your  {this.type} account. ";
        }
            else
            {
                return $"There is no interest for Dormant account. ";
            }

        }


        public List<Activities> getLog()
        {
            return this.transactionList;
        }

    }
}
