using System;
using System.Collections.Generic;
using System.Text;

namespace DInesh_Rav0
{
    /// <summary>
    /// This is the implementation of the IAccounts as per loan account e
    /// </summary>
    public class Loan : IAccount
    {
        public DateTime dateAndTime { get; set; }
        public int period { get; set; }
        public string type { get; set; }
        public int accountNumber { get; set; }
        public int CustomerId { get; set; }
        public double InterestRate { get; set; }
        public double Balance { get; set; }
        public DateTime createdAt { get; set; }
        public bool status { get; set; }
        /// <summary>
        /// List to hold all the relvent activities of Loan account 
        /// </summary>

        public List<Activities> transactionList = new List<Activities>();
        /// <summary>
        /// This method will add the all the transaction in the transactionList
        /// </summary>
        /// <param name="transactionNew"></param>
        public void addTransaction(Activities transactionNew)
        {
            this.transactionList.Add(transactionNew);
        }
        /// <summary>
        /// This method will call when user try to withdraw the amount from loan account.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>newBalance </returns>
        public string withdraw(double amount)
        {
            if (this.Balance > amount)
            {
                this.Balance = this.Balance - amount;
                Activities transactionNew = new Activities()
                {
                    info = $"${amount} has been withdrawn at {DateTime.Now} balance is now ${this.Balance}."
                };
                this.addTransaction(transactionNew);

                return $"You withdrew ${amount} from account number {this.accountNumber}. Your balance is now ${this.Balance}.";
            }
            else
            {
                return $"You can not withdrawl ${amount} because you only have ${this.Balance} in you account.";
            }

        }
        /// <summary>
        /// This method will call when user try to deposited. the amount from loan account.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>newbalance w</returns>
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
        /// <summary>
        /// This method will call when the interest need to calculate. 
        /// </summary>
        /// <param name="date"></param>
        /// <returns>new balance after interst. </returns>
        public string intrest(DateTime date)
        {
                 date = DateTime.Now;
            if (this.status == true)
            {
           

                double interestAmt = (this.Balance * (Validation.MonthDifference(date, this.dateAndTime)) * this.InterestRate);
                this.Balance = this.Balance - (this.Balance * (Validation.MonthDifference(date, this.dateAndTime)*30) * (this.InterestRate / (365 * 100)));
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

        /// <summary>
        /// This is the method to getLog.
        /// </summary>
        /// <returns></returns>
        public List<Activities> getLog()
        {
            return this.transactionList;
        }

    }
}
