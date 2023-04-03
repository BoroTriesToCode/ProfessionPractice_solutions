using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace OOP_fundamentals
{
    public class RegistrationEmail : Email
    {
        //12.	Create a new RegistrationEmail  class, this should inherit the Email class, and add new properties for the following: CustomerName, UserName, Password, WebsiteName, WebsiteURL.
        public string CustomerName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string WebsiteName { get; set; }
        public string WebsiteURL { get; set; }

        public RegistrationEmail(string CustomerName, string UserName, string Password,string WebsiteName,string WebsiteURL)
        {
            this.CustomerName = CustomerName;
            this.UserName = UserName;
            this.Password = Password;
            this.WebsiteName = WebsiteName;
            this.WebsiteURL = WebsiteURL;
        }
        public override void ServerCredentials(string WebsiteURL)
        {
            SmtpClient SmtpServer = new SmtpClient("smtp-pulse.com");
            SmtpServer.Port = 2525;
            SmtpServer.Credentials = new System.Net.NetworkCredential("tankoi@enetix.ro", "9SqCLkdP87DE");
            SmtpServer.EnableSsl = false;
            this.WebsiteURL = WebsiteURL;
        }

        public override void Validate(string From, string To, string Subject)
        {
            this.From= From;
            this.To= To;
            this.Subject= Subject;
        }

        //13.	This type of email will be sent to newly registered customers, so it should have a specific format:
        public override string Format()
        {
            string Message= $"Dear {CustomerName}, \nThank you for registering on {WebsiteName} website.\nYour user information is the following :\nUser name : {UserName}\nPassword : {Password}\nPlease visit our website on the following  URL : {WebsiteURL}.\nSincerelly,\nThe {WebsiteName} team.";
            return Message;
        }
    }
}




