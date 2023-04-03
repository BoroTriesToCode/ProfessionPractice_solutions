using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Text.RegularExpressions;



namespace OOP_fundamentals
{
    public static class EmailSender
    {
        //9.	Create a static EmailSender class, this class should have a Send method. The method receives From, To, Subject, Message as parameters and using SmtpClient and MailMessage classes sends the email (research on how to send mail using these classes).
        public static void Send(string From, string To, string Subject, string Message)
        {
            SmtpClient SmtpServer = new SmtpClient("smtp-pulse.com");
            MailMessage myMail = new System.Net.Mail.MailMessage(From, To);
            myMail.Subject = Subject;
            myMail.Body = Message;


            SmtpServer.Port = 2525;
            SmtpServer.Credentials = new System.Net.NetworkCredential("tankoi@enetix.ro", "9SqCLkdP87DE");
            SmtpServer.EnableSsl = false;

            //14.	Change the EmailSender (static class) so that from now on it works with Email types, before sending an email it will validate it, and also call the Format method. Exception handling should be added.
            string pattern = null;
            pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            try
            {
                if (From == "tankoi@enetix.ro" && (Regex.IsMatch(To, pattern)) && Subject != null)
                {
                    SmtpServer.Send(myMail);
                    Console.WriteLine("Succesfully send");
                }

            }
            catch (Exception ex)
            {
                
                string errorMessage = string.Empty;
                while (ex != null)
                {
                    errorMessage += ex.ToString();
                    ex = ex.InnerException;
                }
                Console.WriteLine("Error:" + errorMessage);
            }
        }

    }

}

