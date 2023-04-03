using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection connection = new MySqlConnection(Constants.getConnection());
            try
            {
                Console.WriteLine("Opening Connection ...");

                connection.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            //------------CUSTOMERS-------------------------------------- -

            //Customers > Insert
            Customer firstCustomer = new Customer(0, "David Carls", "davidcarl@gmail.com", "carl3", "carl32", true);
            CustomerDAL.CustomerInsert(firstCustomer);

            //Customer>     Update
            firstCustomer.setCustomerPassword("carl222");
            CustomerDAL.CustomerUpdate(firstCustomer);

            //Customer>     Delete
            CustomerDAL.CustomerDelete(13);

            //Customer>     GetByID
            Customer newCustomer = new Customer(15, "", "", "", "", true);
            CustomerDAL.CustomerGetByID(newCustomer);
            Console.WriteLine(newCustomer.ToString());

            //Customer>     Browse
            DataSet resultOfBrowse = CustomerDAL.CustomerBrowse("es");
            foreach (DataRow row in resultOfBrowse.Tables["customers"].Rows)
            {
                Console.WriteLine(row["ID"] + " " + row["Name"] + " " + row["Email"] + " " + row["User_Name"] + " " + row["Password"] + " " + row["Is_Active"]);
            }

            //Customer>     Collection
            foreach (Customer customer in CustomerDAL.CustomerCollection("es"))
            {
                Console.WriteLine(customer.ToString());
            };


            //------------CUSTOMER SENT EMAILS----------------------------

            //CustomerSentEmails>   Insert
            CustomerSentEmails firstEmail = new CustomerSentEmails(43, 6, "importantmessage@yahoo.com", " ", " ", "Important", "This is an other important message", "2022-04-15 14:23:02");
            CustomerSentEmailDAL.EmailInsert(firstEmail);


            //CustomerSentEmail>    Update
            firstEmail.setSentWhen("2022-04-22 14:26:00");
            CustomerSentEmailDAL.EmailUpdate(firstEmail);

            //CustomerSentEmail>    Delete
            CustomerSentEmailDAL.EmailDelete(26);

            //CustomerSentEmails>   GetByID
            CustomerSentEmails thirdEmail = new CustomerSentEmails(32, 0, "", "", "", "", "", "");
            CustomerSentEmailDAL.EmailGetByID(thirdEmail);
            Console.WriteLine(thirdEmail.ToString());


            //CustomerSentEmails>   Browse
            DataSet resultOfEmailBrowse = CustomerSentEmailDAL.EmailBrowse("other");
            if (resultOfEmailBrowse != null)
            {
                foreach (DataRow row in resultOfEmailBrowse.Tables["customer_sent_emails"].Rows)
                {
                    Console.WriteLine(row["ID"] + " " + row["Customer_ID"] + " " + row["From_Address"] + " " + row["CC_Address"] + " " + row["BCC_Address"] + " " + row["Subject"] + " " + row["Message"] + " " + row["Sent_When"]);
                }
            }
            else
            {
                Console.WriteLine("DataTable is empty");
            }



            //CustomerSentEmails>	Collection
            foreach (CustomerSentEmails email in CustomerSentEmailDAL.EmailCollection("other"))
            {
                Console.WriteLine(email.ToString());
            };


            Console.ReadLine();
            connection.Close(); 
        }


    }    
}
