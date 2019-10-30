using System;
using System.Collections.Generic;
using System.Text;

namespace DInesh_Rav0
{
    /// <summary>
    /// This class will implement the interface of IAccount 
    /// </summary>
    public class Business:IAccount
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
        /// Creating a list which will be adeed all the transaction.
        /// </summary>
        public List<Activities> transactionList = new List<Activities>();
        /// <summary>
        /// This method will added the transaction in to transaction list. 
        /// </summary>
        /// <param name="transactionNew"></param>
        public void addTransaction(Activities transactionNew)
        {
            this.transactionList.Add(transactionNew);
        }
        /// <summary>
        /// /it will returns message of withdraw sucess and new balance.
        /// There is limit of $ 5000 can be withdraw. 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>new balnce </returns>
        public string withdraw(double amount)
        {
            if (this.Balance + 5000 > amount)//Hard coded 5000
            {
                //Cheecking this.Balance -=amount;
                this.Balance = this.Balance - amount;
                //This will be the new Activities Activites has info  will String get and set 
                Activities transactionNew = new Activities()
                {
                    info = $"$ WithDraw AMt : {amount}  at {DateTime.Now} balance is now ${this.Balance}."
                };
                this.addTransaction(transactionNew);

                return $"WithDraw AMt ${amount} from Account Number:  {this.accountNumber}. Your balance is now ${this.Balance}."; return $"You withdrew ${amount} from account number {this.accountNumber}. Your balance is now ${this.Balance}. (Note: You have $5000 Credit Limits.)";
            }
            else
            {
                return $"You can not withdrawl ${amount} because you only have ${this.Balance} in you account.";
            }

        }

        /// <summary>
        /// This method will deposited in Business account and return the message with new balance. 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>new balance after deposit. </returns>
        public string deposit(double amount)
        {


            this.Balance = this.Balance + amount;
            Activities transactionNew = new Activities()
            {
                info = $"${amount} has been deposited at {DateTime.Now} balance is now ${this.Balance}."
            };
            this.addTransaction(transactionNew);


            return $"You have deposited:  $ {amount}  into account number {this.accountNumber}. Your balance is now ${this.Balance}.";

        }
        /// <summary>
        /// This method will calculate a interest based on date and return new balance message. 
        /// </summary>
        /// <param name="date"></param>
        /// <returns>New Balnce with after interest added. </returns>
        public string intrest(DateTime date)
        {
            if (this.status == true)// Checking the status
            {
                 date = DateTime.Now;
                double interestAmt = (this.Balance * (Validation.MonthDifference(date, this.dateAndTime)) * this.InterestRate);
                this.Balance = this.Balance + (this.Balance * (Validation.MonthDifference(DateTime.Now, this.dateAndTime) * 30) * (this.InterestRate / (365 * 100)));
                Activities transactionNew = new Activities()
                {
                    info = $" Your Accured ${interestAmt} has been added at {DateTime.Now} balance is now ${this.Balance} in your  {this.type} account. "
                };
                this.addTransaction(transactionNew);

                return $" Your Accured $ {interestAmt} has been added at {DateTime.Now} balance is now $ {this.Balance} in your  {this.type} account. ";
            }
            else
            {
                return $"There is no interest for Dormant account. ";
            }

        }


        //This is the create log. Which we passed as a info will loged here then we can retrived later

        public List<Activities> getLog()
        {
            return this.transactionList;
        }


    }
}
