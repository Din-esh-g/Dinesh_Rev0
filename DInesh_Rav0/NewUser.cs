using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ConsoleTables;
using DocumentFormat.OpenXml.Drawing;

namespace DInesh_Rav0
{
    public class NewUser
    {
        /// <summary>
        /// This will create new customer and displayed in Table.
        /// </summary>
        /// <param name="newCustomer"></param>
        public void Create(RegisterUser newCustomer)
        {
            //Adding the new custmer in the Customer list
            ListEnums.CustomerList.Add(newCustomer);
            //This will print out the message in Table form.
            Console.WriteLine($"\n\nConguralation !!!\n\n Following information is saved for {newCustomer.firstName}.\n");
            var table = new ConsoleTable("First Name", "Last Name", "User ID", "Email Address", "Phone ", "Address");
            table.AddRow(newCustomer.firstName, newCustomer.lastName, newCustomer.Id, newCustomer.email, newCustomer.phoneNumber, newCustomer.address);
            table.Write();

    

        }
        

    }
}
