using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace program
{
    public class Program
    {
        static void Main(string[] args)
        {
            //1.Declare an ArrayList(add a few numeric values to it).
            //Print out the sum of it's items.What happens if you 'accidentally' add another type to it? Is it still possible to calculate it's sum?

            ArrayList arrayList = new ArrayList(3) { 3, 6, 7 };
            arrayList.Add(7);
            int sum1 = 0;
            foreach (int i in arrayList)
            {
                sum1 += i;
            }
            Console.WriteLine(sum1);
            arrayList.Add("hello");
            for (int i = 0; i < arrayList.Count; i++)
            {
                Console.Write(arrayList[i] + " ");
            }
            //int sum2=0
            //foreach (int i=0; i<arrayList.Count; i++)
            //{
            //    sum2 += arrayList[i];

            //}
            //Console.WriteLine(sum2);



            //2.	Declare a List<int>, in the same way, add values to it and calculate it's sum.Is it possible to add a different type to it?
            List<int> newList = new List<int>(new int[] { 2, 3, 7 });
            int sum3 = 0;
            foreach (int j in newList)
            {
                sum3 += j;
            }
            Console.WriteLine(sum3);

            //newList.Add("hello");



            GenericList<int> list1 = new GenericList<int>();
            list1.addItem(1);
            list1.addItem(2);
            list1.addItem(3);
            list1.addItem(4);
            list1.deleteItem(1);
            list1.printList();

            GenericList<string> list2 = new GenericList<string>();
            list2.addItem("cat");
            list2.addItem("dog");
            list2.addItem("hamster");
            list2.printList();
            list2.deleteItem(2);
            list2.printList();


            //5.	Write a generic boolean method that tests if two values are equal.
            Methods<int>.result(Methods<int>.areTheyEqual(7, 8));
            Methods<int>.result(Methods<string>.areTheyEqual("apple", "apple"));


            IntegerList list3 = new IntegerList();  
            list3.addItem(92);
            list3.addItem(93);
            list3.printList();
            list3.deleteItem(0);
            list3.printList();

            Console.ReadLine();
        }


    }
}

