using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Basics2
{
    internal class Program
    {
        static void Main(string[] args)     
        {
            //2.	Using System.Console print “Hello world!” :)
            Console.WriteLine("Hello world!");
            //3.	Declare 2 integer variables, assign values and print their sum.
            int first = 3;
            int second = 5;
            Console.Write(first + second + Environment.NewLine); 
            //  4.Declare a string variable, display the same string in 3 different ways: all letters uppercase, all letters lowercase, capitalize the first letter.
            const string sentence="this is a sentence";       
        
            Console.WriteLine(sentence.ToUpper() + Environment.NewLine + sentence.ToLower()+ Environment.NewLine + char.ToUpper(sentence[0]) + sentence.Substring(1));

            // 5.Create a file(input.txt), containing several numbers(1 / line), write code to display their sum, largest value and smallest value.
            string[] numbers=File.ReadAllLines("input.txt");
            int[] numbers_int = new int[numbers.Length];
            for(int i = 0; i < numbers.Length; i++)
            {
                numbers_int[i] = Int32.Parse(numbers[i]);
            }
            int sum = 0, min = numbers_int[0], max;
            max = min;
            for(int i = 0; i < numbers.Length; i++)
            {
                if (numbers_int[i] < min)
                {
                    min = numbers_int[i];
                }
                if (numbers_int[i] > max)
                {
                    max = numbers_int[i];
                }
                sum += numbers_int[i];
            }
            Console.WriteLine(sum+Environment.NewLine+max+Environment.NewLine+min);
            //6.Write their sum to the last line of the file(“sum = < sum >”), the program shouldn't add a sum line with each execution – consider updating the last line.
            File.AppendAllText("input.txt", Environment.NewLine+ sum + Environment.NewLine);

            //7.Change your existing code so that all the file operations are handled within a single read.
            //8.Place all the numbers read into an array, sort the numbers in the array, display the sorted list.


            void Sort_And_Display(int[] array, int length)
            {
                int var_help, i;
                for (int j = 1; j < length; j++)
                {
                    var_help = array[j];
                    i = j - 1;
                    while (i >= 0 && array[i] >= var_help)
                    {
                        array[i + 1] = array[i];
                        i -= 1;
                    }
                    array[i + 1] = var_help;
                }
                for (int p = 0; p < length; p++)
                {
                    Console.Write(array[p] + " ");
                }
                Console.WriteLine(Environment.NewLine);
            }
            Sort_And_Display(numbers_int, numbers.Length);



            //9.	Declare a few string variables and combine these using string interpolation.

            string string1 = "first";
            string string2 = "second";
            string string3 = "third";
            string string_interloration =$"{string1} and { string2} and {string3}";
            Console.WriteLine(string_interloration+Environment.NewLine);

            //10.	Declare a large number variable as decimal, and write out the value of this formatting it like so: I.e. decimal val = 1233682 should become 1,233,682.00
            decimal val = 1233682;
            Console.WriteLine($"{val:N2}");

            //11.	Change a string variable to title case using CultureInfo.CurrentCulture.TextInfo
            
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            Console.WriteLine(textInfo.ToTitleCase("this is a text"));


            //12.	Declare a datetime variable setting its value to the current datetime, and display its value formatting it to look like this (24h format): Friday, 29 May 2015 05:50:06
            DateTime current_time= DateTime.Now;
            Console.WriteLine((DateTime.Today.DayOfWeek + ", " + current_time.ToString("F")) + Environment.NewLine);
            Console.Write(DateTime.Now.ToString("ddd,d MMM yyy HH:mm:ss"));


            Console.ReadKey();
        }
    }
}
