using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_fundamentals
{
    //2.	Add a new class, call it Person.
    //3.	Add the following attributes, encapsulated (private field + public property or just use auto properties): Name (string), Gender(enum type “Genders”), DateOfBirth(datetime).

    public enum Genders
    {
        Male,
        Female
    };
    public class Person
    {

        public string Name { get; set; }
        public Genders Gender { get; set; }
        public DateTime DateOfBirth = new DateTime();

        //4.	Create a constructor that can populate all the fields from parameters and also create a separate copy constructor.

        public Person(string Name, Genders Gender, DateTime DateOfBirth)
        {
            this.Name = Name;
            this.DateOfBirth = DateOfBirth;
            this.Gender= Gender;
        }

        //copy constructor
        public Person(Person person)
        {
            if (person != null) { 
            this.Name = person.Name;
            this.DateOfBirth = person.DateOfBirth;
            }
        }



    }
}
