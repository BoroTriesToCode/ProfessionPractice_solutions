using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Reflection;


namespace Attributes_and_reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection connection = new MySqlConnection("server=192.168.10.10;database=training_nb;port=3306;uid=nagyb;pwd=training;");
            try
            {
                Console.WriteLine("Opening Connection ...");

                connection.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Type type = typeof(Customer);
            Console.WriteLine("Class:"+type.Name);
            Console.WriteLine("Namespace: " + type.Namespace);

            Customer firstCustomer = new Customer(51, "Luke Hemmings", "lukehemmo@gmail.com", "luke5sos", "l729715sos", true);
            GenericDAL<Customer>.insertCustomer(firstCustomer);


            /*PropertyInfo[] propertiesInfo = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertiesInfo)
            {
                Console.WriteLine(propertyInfo.Name+"  "+propertyInfo.GetValue(firstCustomer));
            }
            */

            Console.WriteLine("---------------------------------------------------------------------------------------");

            String str1 = "g";
            str1 = str1 + "haha";
            Console.WriteLine(str1);
 
            


            Console.ReadKey();
        }
    }
}
