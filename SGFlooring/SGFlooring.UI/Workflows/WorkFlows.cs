using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SGFlooring.BLL;
using SGFlooring.Models;

namespace SGFlooring.UI.Workflows
{
    public abstract class WorkFlows
    {
        protected OrderOperations _operations;

        protected WorkFlows()
        {
            _operations = new OrderOperations();
        }

        public abstract void Execute();

        public static int IntPrompt(string message)
        {
            bool isvalid = false;
            string input = "";
            int i = 0;
            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
                isvalid = Int32.TryParse(input, out i);
                if (!isvalid)
                {
                    Console.WriteLine("    Not a valid option");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            } while (!isvalid);
            Console.Clear();
            return i;
        }


        public int GetOrderId()
        {

            bool isParsed = false;
            int orderId = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter order Id");
                isParsed = int.TryParse(Console.ReadLine(),out orderId);
                if (!isParsed)
                {
                    Console.WriteLine("Enter valid order Id");
                    Thread.Sleep(1000);
                    
                }

            } while (!isParsed);
            return orderId;
        }


        public DateTime GetOrderDate()
        {
            DateTime orderDate;
            bool isParsed = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter date for order MM/DD/YYYY");
                isParsed = DateTime.TryParse(Console.ReadLine(), out orderDate);
                if (!isParsed)
                {
                    Console.WriteLine("Enter Valid Date");
                    Thread.Sleep(1000);

                }
            } while (!isParsed);
            return orderDate;
        }


       
    }
}
