using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    public static class Methods<T>
    {
        //5.	Write a generic boolean method that tests if two values are equal.
        public static bool areTheyEqual(T first, T second)
        {
            if (first.Equals(second))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static void result(bool result)
        {
            if (result == true)
            {

                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("Not equal");

            }

        }
    }
}

