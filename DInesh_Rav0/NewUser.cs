using System;
using System.Collections.Generic;
using System.Text;
//using ConsoleTables;

namespace DInesh_Rav0
{
    public class NewUser
    {
        public string Create(RegisterUser newCustomer)
        {
            string custInfo = $"\n\nThank you for Registration {newCustomer.firstName} {newCustomer.lastName}. You Have Following Registration Details .\nYour Registration ID:  {newCustomer.Id} || Email Id: {newCustomer.email} || Phone Number: {newCustomer.phoneNumber} || Address: {newCustomer.address}";
            ListEnums.CustomerList.Add(newCustomer);                        
            return custInfo;

        }
        //public static void table()
        //{
        //    var table = new ConsoleTable ("First Name", "Last Name", "Email", "PhoneNumbers", "CustomerId");

        //    table.AddRow(newCustomer.firstName, newCustomer.lastName, newCustomer.email, newCustomer.phoneNumber, newCustomer.Id);
        //    table.Write();
        //}

    }
}
