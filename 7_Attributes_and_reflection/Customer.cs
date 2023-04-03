using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Attributes_and_reflection
{
    [DbTable("customers")]
    public class Customer
    {
        MySqlConnection connection = new MySqlConnection("server=192.168.10.10;database=training_nb;port=3306;uid=nagyb;pwd=training;");

        [DbField("ID")]
        public int ID { get; set; }

        [DbField("Name")]
        public String Name { get; set; }

        [DbField("Email")]
        public String Email { get; set; }

        [DbField("User_Name")]
        public String User_Name { get; set; }

        [DbField("Password")]
        public String Password { get; set; }

        [DbField("Is_Active")]
        public bool Is_Active { get; set; }

        public Customer(int ID, String Name, String Email, String User_Name, String Password, bool Is_Active)
        {
            this.ID = ID;
            this.Name = Name;
            this.Email = Email;
            this.User_Name = User_Name;
            this.Password = Password;
            this.Is_Active = Is_Active;
        }


    }
}
