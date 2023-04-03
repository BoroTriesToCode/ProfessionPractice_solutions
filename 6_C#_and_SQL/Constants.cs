using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace program
{
    public class Constants
    {
        const string myConnectionString = "server=192.168.10.10;database=training_nb;port=3306;uid=nagyb;pwd=training;";
        public static string getConnection() { return myConnectionString; }
    }
}
