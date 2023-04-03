using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    public class CustomerSentEmails
    {
        private int customerEmailID;
        private int customerID;
        private string fromAddress;
        private string ccAddress;
        private string bccAddress;
        private string subject;
        private string message;
        private string sentWhen;

        public CustomerSentEmails(int customerEmailID, int customerID, string fromAddress, string ccAddress, string bccAddress, string subject, string message, string sentWhen)
        {
            this.customerEmailID = customerEmailID;     
            this.customerID = customerID;   
            this.fromAddress = fromAddress;
            this.ccAddress = ccAddress;
            this.bccAddress = bccAddress;
            this.subject = subject;
            this.message = message;
            this.sentWhen = sentWhen;

        }

        public int getCustomerEmailID()
        {
            return customerEmailID;
        }

        public void setCustomerEmailID(int customerEmailID)
        {
            this.customerEmailID = customerEmailID; 
        }

        public int getCustomerID()
        {
            return customerID;
        }

        public void setCustomerID(int customerID)
        {
            this.customerID = customerID;
        }

        public string getFromAddress()
        {
            return fromAddress;
        }

        public void setFromAddress(string fromAddress)
        {
            this.fromAddress = fromAddress;
        }

        public string getCcAddress()
        {
            return ccAddress;
        }

        public void setCcAddress(string ccAddress)
        {
            this.ccAddress = ccAddress;
        }

        public string getBccAddress()
        {
            return bccAddress;
        }

        public void setBccAddress(string bccAddress)
        {
            this.bccAddress = bccAddress;
        }

        public string getSubject()
        {
            return subject;
        }

        public void setSubject(string subject)
        {
            this.subject = subject;
        }
        public string getMessage()
        {
            return message;
        }

        public void setMessage(string message)
        {
            this.message = message;
        }

        public string getSentWhen()
        {
            return sentWhen;
        }

        public void setSentWhen(string sentWhen)
        {
            this.sentWhen = sentWhen;
        }

        public String ToString()
        {
            return "ID: " + this.customerEmailID + " | CustomerID: " + this.customerID + " | From Address: " + this.fromAddress + " | CC Address: " + this.ccAddress + " | BCC Address: " + this.bccAddress + " | Subject: " + this.subject + " | Message: " + this.message + " | Date: " + this.sentWhen;
        }
    }
}
