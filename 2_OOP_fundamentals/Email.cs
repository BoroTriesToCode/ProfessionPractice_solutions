using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_fundamentals
{
    //11.	Create an abstract class Email that will store all the infos needed to send an email, it will have a separate method to set the stmp server credentials and url, a method to validate From, To, Subject, and also a virtual method to Format the message body (will set the Message to the formatted message, by default it can be empty).
    public abstract class Email
    {
        public string From;
        public string To;
        public string Subject;

        public abstract void ServerCredentials(string URL);
        public abstract void Validate(string From,string To, string Subject);
        public virtual string Format()
        {
            return string.Empty;
        }
    }
}
