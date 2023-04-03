using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_fundamentals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //7.Declare and instantiate a variable of type Customer.Populate the fields with data.
            Customer firstCustomer = new Customer("Andie Jones",Genders.Male, DateTime.ParseExact(19820422.ToString(), "yyyyMMdd", null), "tankoi@enetix.ro");

            //8.	Display the customer.
            Console.WriteLine(firstCustomer.ToString());

            //10.	Send an email to yourself using this code.
            EmailSender.Send("tankoi@enetix.ro", "tankoi@enetix.ro", "First Mail", "This is my first email.");

            //13.
            RegistrationEmail myRegistrationEmail = new RegistrationEmail("Andie Jones", "Andie", "andie123", "Enetix", "https://enetix.ro/ro/");
            EmailSender.Send("tankoi@enetix.ro", "tankoi@enetix.ro", "Registration Email", myRegistrationEmail.Format());

            //15.
            OrderNotificationEmail myOrderNotificationEmail = new OrderNotificationEmail("Andie Jones", 3456, "https://enetix.ro/ro/", "Enetix");
            EmailSender.Send("tankoi@enetix.ro", "tankoi@enetix.ro", "Order notification email", myOrderNotificationEmail.Format());

            Console.ReadKey();
        }
    }
}
