using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    public class Customer
    {
        private int customerID;
        private string customerName;
        private string customerEmail;
        private string customerUsername;
        private string customerPassword;
        private bool isActive;

        public Customer(int customerID)
        {
            this.customerID = customerID;
        }

        public Customer(int customerID, string customerName, string cutomerEmail, string customerUsername, string customerPassword, bool isActive)
        {
            this.customerID = customerID;
            this.customerName = customerName;
            this.customerEmail = cutomerEmail;
            this.customerUsername = customerUsername;
            this.customerPassword = customerPassword;
            this.isActive = isActive;

        }

        public int getCustomerID()
        {
            return customerID;
        }

        public void setCustomerID(int customerID)
        {
            this.customerID = customerID;
        }

        public string getCustomerName()
        {
            return customerName;
        }

        public void setCustomerName(string customerName)
        {
            this.customerName = customerName;
        }

        public string getCustomerEmail()
        {
            return customerEmail;
        }

        public void setCustomerEmail(string customerEmail)
        {
            this.customerEmail = customerEmail;
        }

        public string getCustomerUsername()
        {
            return customerUsername;
        }

        public void setCustomerUsername(string customerUsername)
        {
            this.customerUsername = customerUsername;
        }

        public string getCustomerPassword()
        {
            return customerPassword;
        }

        public void setCustomerPassword(string customerPassword)
        {
            this.customerPassword = customerPassword;
        }

        public bool getIsActive()
        {
            return isActive;
        }

        public void setIsActive(bool isActive){
            this.isActive = isActive;
        }

        public String ToString()
        {
            return "ID: " + this.customerID + " | Name: " + this.customerName + " | Email: " + this.customerEmail + " | Username: " + this.customerUsername + " | Password: " + this.customerPassword + " | Active: " + this.isActive;
        } 
    }
}
