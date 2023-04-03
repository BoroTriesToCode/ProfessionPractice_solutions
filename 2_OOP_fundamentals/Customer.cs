using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_fundamentals
{
    //5.	Create a new class: Customer. This will inherit the Person class, and will also have an Email property. Add a constructor that populates all the fields (including Person fields).
    public class Customer:Person
    {
        public String Email;
        public Customer(String Name, Genders Gender, DateTime DateOfBirth, String Email)
        :base(Name,Gender,DateOfBirth)
        {
            this.Email = Email;
        }


        // 6.	Override the ToString() method for Person, so that it displays data in the following form:Name: <name> Gender: <gender> Date of birth: <year>-<month>-<day>Email: <email>

        public override string ToString()
        {
            return $"Name: {this.Name} \nGender: {this.Gender.ToString()} \nDate of birth: {this.DateOfBirth.Year}-{this.DateOfBirth.Month}-{this.DateOfBirth.Day} \nEmail: {this.Email}";
        }


    }
}
