using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BuzzFizz
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 1; i < 101; i++)
            //{
            //    var r = "";

            //    if (i%3 == 0)
            //    {
            //        r = "Fizz";
            //    }
            //    if (i%7 == 0)
            //    {
            //        r += "Buzz";
            //    }
            //    if (r == "")
            //    {
            //        Console.WriteLine(i);
            //    }
            //    else
            //    {
            //        Console.WriteLine(i + r);
            //    }
            //}
            //Console.WriteLine("Done with loop");
            //Console.ReadLine();


            //int[] a = new int[(int)char.MaxValue];

            //string b = "FFFFuckwertyuiuytrewrtyuytretytrertyt";
            //foreach (char c in b)
            //{
            //    a[(int) c]++;
            //}
            //for (int i = 0; i < (int)char.MaxValue; i++)
            //{
            //    if (a[i] > 0 && char.IsLetterOrDigit((char)i))
            //    {
            //        Console.WriteLine("letter: {0} Frequency: {1}",(char)i,a[i]);
            //    }
            //}

            //Console
            //    .ReadLine();

            //int[] array = {1,1,1,1,2,2,3,4,};
            //var dict = new Dictionary<int, int>();

            //foreach (var value in array)
            //{
            //    if (!dict.ContainsKey(value))
            //        dict[value] = 1;
            //}
            //foreach (var pair in dict)
            //    Console.WriteLine( "{0}", pair.Key);
            //Console.ReadKey();




            Console.WriteLine("Enter Numbers to sort");
            int[] array = new int[5];
            string input = "";
            for (int i = 0; i < 5; i++)
            {
                input = Console.ReadLine();
                array[i] = Convert.ToInt32(input);
            }

            int a, b, c = 0;
            Console.WriteLine();
            for (a = 0; a < array.Length; a++)
            {
                for (b = a + 1; b < array.Length; b++)
                {
                    if (array[a] > array[b])
                    {
                        c = array[a];
                        array[a] = array[b];
                        array[b] = c;
                    }
                }
                Console.WriteLine(array[a]);
            }
            Console.ReadLine();

        }
    }
}
