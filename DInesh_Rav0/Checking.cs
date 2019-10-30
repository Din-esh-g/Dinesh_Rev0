using System;
using System.Collections.Generic;
using System.Text;

namespace DInesh_Rav0
{
    /// <summary>
    /// This class will implement the interface of IAccount 
    /// </summary>
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
        //Defining the list for the tansaction which will be in this account.

        public List<Activities> transactionList = new List<Activities>();
        /// <summary>
        /// This will add the every new transaction in our transactionList.
        /// </summary>
        /// <param name="transactionNew"></param>
        public void addTransaction(Activities transactionNew)
        {
            this.transactionList.Add(transactionNew);
        }
        /// <summary>
        /// Implementing withdraw
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>it will returns message of withdraw secuess and new balance. </returns>

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
        /// <summary>
        /// This method is depositing the amount we passed and it will return the new balance.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>new balance of with deposited amt</returns>

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
        /// <summary>
        /// This method will calculate interst and added to the balance
        /// </summary>
        /// <param name="date"></param>
        /// <returns> new balance after adding the interest. </returns>

        public string intrest(DateTime date)
        {
            date = DateTime.Now;
            if (this.status == true)
            {
                double interestAmt = (this.Balance * (Validation.MonthDifference(date, this.dateAndTime)) * this.InterestRate);
                this.Balance = this.Balance + (this.Balance * (Validation.MonthDifference(DateTime.Now, this.dateAndTime)*30) * (this.InterestRate / (365 * 100)));
                Activities transactionNew = new Activities()
                {
                    info = $" Your Accured $ {interestAmt} has been added at {DateTime.Now} balance is now $ {this.Balance} in your  {this.type} account. "
            };
                this.addTransaction(transactionNew);

                return $" Your Accured $ {interestAmt} has been added at {DateTime.Now} balance is now $ {this.Balance} in your  {this.type} account. ";
            }
            else
            {
                return $"There is no interest for inactive account. ";
            }

        }

        //This will getlog 
        public List<Activities> getLog()
        {
            return this.transactionList;
        }


    }
}
