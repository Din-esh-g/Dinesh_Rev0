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
        public void Create(RegisterUser newCustomer)
        {
            ListEnums.CustomerList.Add(newCustomer);
            Console.WriteLine($"\n\nConguralation !!!\n\n Following information is saved for {newCustomer.firstName}.\n");
            var table = new ConsoleTable("First Name", "Last Name", "User ID", "Email Address", "Phone ", "Address");
            table.AddRow(newCustomer.firstName, newCustomer.lastName, newCustomer.Id, newCustomer.email, newCustomer.phoneNumber, newCustomer.address);
            table.Write();

    

        }
        

    }
}
