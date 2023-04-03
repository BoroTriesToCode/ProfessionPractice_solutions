using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes_and_reflection
{
    //1.	Create 2 classes: DbField, and DbTable, both classes inherit the Attribute class.
    [AttributeUsage(AttributeTargets.Class)]  //DbTable is a class level attribute
    public class DbTable:Attribute
    {
        //DbTable has a string “TableName” property.
        public String TableName { get; set; }
        public DbTable(String TableName)
        {
            this.TableName = TableName;
        }
         
    }
}
