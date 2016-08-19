using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.iterateString();
            prog.DeclareImplicitArrays();
            prog.rectangularmultidimensionalarray();
            prog.jaggedmultidemincialarray();

            Console.ReadLine();

        }

        public void iterateString()
        {
            string s1 = "This is a string of characters.";

            foreach (char c in s1)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine(s1.Length);
        }

        public static void splitString()
        {
            Console.Clear();
            string[] words = "This is a sentence.".Split(' ');
            foreach (string word in words)
            {
                Console.WriteLine(word);   
            }
        }

        public void simpleArray()
        {
            Console.Clear();
            int[] myint = new int[3];
            myint[0] = 100;
            myint[1] = 200;

            foreach (int i in myint)
            {
                Console.WriteLine(i);
            }
        }

        public void ReverseString()
        {
            //NEED TO KNOW THIS!!!
            string mystring = "string too reverse";

            for (int i = 0; i < mystring.Length; i++)
            {
                Console.WriteLine(mystring[mystring.Length-i-1]);
            }
            Console.ReadLine();

            for (int i = mystring.Length; i >= 0; i--)
            {
                Console.WriteLine(mystring[i]-1);
            }
        }

        public void DeclareImplicitArrays()
        {
            Console.Clear();
            var a = new[] {1, 10, 100, 1000};
            Console.WriteLine("a is a: {0}", a.ToString());

            var b = new[] {1, 1.5, 2, 2.5};
            Console.WriteLine("b is b:{0}",b.ToString());


            var c = new[] {"hello", null, "world"};
            Console.WriteLine("c is a : {0}",c.ToString());
        }

        public void rectangularmultidimensionalarray()
        {
            Console.Clear();
            int[,] mygrid = new int[5,6];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    mygrid[i, j] = i*j;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write(mygrid[i,j]+"\t");
                }
            }
        }

        public void jaggedmultidemincialarray()
        {
            Console.Clear();
            int[][] myjaggedarray = new int [5][];

            for (int i = 0; i < myjaggedarray.Length; i++)
            {
                myjaggedarray[i] = new int[i+3];
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < myjaggedarray[i].Length; j++)
                {
                    Console.WriteLine(myjaggedarray[i][j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
