using System;
using System.Collections.Generic;
using System.Text;

namespace DInesh_Rav0
{
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


        public List<Activities> getLog()
        {
            return this.transactionList;
        }

    }
}
