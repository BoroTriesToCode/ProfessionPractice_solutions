using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    //3.	Implement a generic class that will work the way List<T> works.Implement the following methods: clear, add, remove.
    public class GenericList<T>
    {
        private T[] myList = new T[0];


        public void addItem(T item)
        {
            T[] tempList = new T[myList.Length+ 1];
            for(int i=0;i< myList.Length; i++)
            {
                tempList[i] = myList[i];
            }
            tempList[tempList.Length-1] = item;
            myList=tempList;

        }

        public void deleteItem(int index)
        {
            if(index < 0 || index >= myList.Length)
            {
                Console.WriteLine("No such index in list");
            }
            else
            {
                if (myList.Length == 0)
                {
                    Console.WriteLine("The list is empty");
                }
                else
                {
                    for (int i = index; i < myList.Length- 1; i++)
                    {
                        myList[i] = myList[i + 1];
                    }
                    Array.Resize(ref myList, myList.Length - 1);

                }
            }

        }


        public void  clearList()
        {
            myList = null;
        }

        public void printList()
        {
            if (myList == null)
            {
                Console.WriteLine("The list is empty");
            }
            else
            {

                for (int i = 0; i < myList.Length; i++)
                {
                    Console.Write(myList[i] + " ");
                }
                Console.WriteLine("");
            }
        }
    }
}
