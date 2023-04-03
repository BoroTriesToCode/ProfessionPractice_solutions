using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace OOP_fundamentals
{
    //15.	Create a new OrderNotificationEmail class,  similar to the RegistrationEmail class, add OrderNumber, OrderURL properties and the email body should be:
    internal class OrderNotificationEmail
    {
        public string CustomerName { get; set; }
        public int OrderNumber { get; set; }
        public string OrderURL { get; set; }
        public string WebsiteName { get; set; }

        public OrderNotificationEmail(string CustomerName, int OrderNumber, string OrderURL, string WebsiteName)
        {
            this.CustomerName = CustomerName;
            this.OrderNumber = OrderNumber;
            this.OrderURL = OrderURL;
            this.WebsiteName = WebsiteName;
        }

        public string Format()
        {
            string Message = $"Dear {CustomerName}, \nThank you for order {OrderNumber}\nTo track your order, click on the following  URL : {OrderURL}.\nSincerelly,\nThe {WebsiteName} team.";
            return Message;
        }
    }
}


