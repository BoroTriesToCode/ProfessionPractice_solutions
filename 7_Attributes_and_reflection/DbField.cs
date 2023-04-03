using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace Attributes_and_reflection
{
    [AttributeUsage(AttributeTargets.Property)]  //DbField is property level
    public class DbField: Attribute
    //1.	Create 2 classes: DbField, and DbTable, both classes inherit the Attribute class.
    {
        //DbField has a string “FieldName” property.
        public String FieldName { get; set; }
        public DbField(String FieldName)
        {
            this.FieldName = FieldName;
        }


    }
}
