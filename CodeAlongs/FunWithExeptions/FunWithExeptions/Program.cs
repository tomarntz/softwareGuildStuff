using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FunWithExeptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //CauseExeption();
            //HandleExeption();
            //HandleSpecificExeption();
            //FiniallyExample();
            //CallStackExample();
            ThrowCustomExeption();

            Console.ReadLine();
        }

        static void CauseExeption()
        {
            int x = 17;
            int y = 0;

            Console.WriteLine(x/y);
        }

        static void HandleExeption()
        {
            try
            {
                CauseExeption();
            }
            catch (Exception)
            {
            Console.WriteLine("You did something bad,  but  im going to keep running");
            }
            Console.WriteLine("I'm still here!!!");
        }

        static void HandleSpecificExeption()
        {
            try
            {
                int[] ints = new[] {5, 4};
                ints[2] = 20;

                ints[1] = 21;
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Your index is out of reange...");

            }
            catch (Exception)
            {
                Console.WriteLine("An exeption occurred!");
            }
        }

        static void FiniallyExample()
        {
            try
            {
                int x = 3;
                int y = 7;

                Console.WriteLine(x/y);
            }
            catch (DivideByZeroException dex)
            {
                Console.WriteLine("You can not divide by 0");
            }
            finally
            {
                Console.WriteLine("Finially I get  to execute");
            }
        }

        static void CallStackExample()
        {
            try
            {
                Method1();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("catch clause in callstackexample for dividebbyzero");
            }
            finally
            {
                Console.WriteLine("Finially clause in call stack");
            }
            Console.WriteLine("Still running");
        }

        static void Method1()
        {
            try
            {
                Method2();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Catch clause in method 1 for null referance exeption");
            }
            finally
            {
                Console.WriteLine("Finially clause in method1");
            }
            Console.WriteLine("method1!");
        }

        static void Method2()
        {
            try
            {
                CauseExeption();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Catch clause in method 1 forindexoutofrangeexeption");
            }
            finally
            {
                Console.WriteLine("Finially clause in method2");
            }
            Console.WriteLine("method2!");
        }

        static void ThrowCustomExeption()
        {
            try
            {
                throw new MySpecificExeption("Not a chance!");
            }
            catch (MySpecificExeption nex)
            {
                Console.WriteLine(nex.Message);
                Console.WriteLine(nex.StackTrace);
                Console.WriteLine(nex.HelpLink);
            }
        }
    }
}
