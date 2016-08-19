using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;
using SGFlooring.BLL;
using SGFlooring.Models;
using SGFlooring.Data;

namespace SGFlooring.UI.Workflows
{
    public class AddOrderWorkflow : WorkFlows
    {
        public override void Execute()
        {
            string name = GetNameOfCustomer();
            DateTime orderDate = GetOrderDate();
            decimal totalArea = GetArea();
            string ProductType = GetProductType();
            string stateAbb = GetStateFromCustomer();
            VerifyAddOrder(name, orderDate, ProductType, stateAbb, totalArea);

           // ProcessNewOrder(name, orderDate, ProductType, stateAbb, totalArea);
        }


        private string GetNameOfCustomer()// gets name from user
        {
            string name = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Enter name for order");
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.Clear();
                    Console.WriteLine("Must enter name for order\n " +
                                      "Hit enter to continue");
                    Console.ReadLine();
                }
            } while (string.IsNullOrEmpty(name));
            return name;
        }


        private decimal GetArea()//gets area from user
        {
            decimal total = 0;
            bool isValid = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter area in sqr ft");
                isValid = decimal.TryParse(Console.ReadLine(),out total);
                if (isValid == false)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input");
                    Thread.Sleep(1000);
                }
            } while (!isValid);
            return total;
        }


        private string GetProductType()//gets product type from user
        {
            bool isValid = false;
            string productType = "";
            int productIndex = 0;
            List<string> PossibleProductTypes;

            var ops = new OrderOperations();
            PossibleProductTypes = ops.GetAllProductTypes();
           
            do
            {
                Console.Clear();
                foreach (string type in PossibleProductTypes)
                {
                    int index = PossibleProductTypes.IndexOf(type);
                    Console.WriteLine("{0}. {1}", index, PossibleProductTypes[index]);
                }
                Console.WriteLine("Enter product type for order");
                isValid = int.TryParse(Console.ReadLine(), out productIndex);
                if (isValid == false)
                {
                    Console.WriteLine("Must enter valid number");
                    Console.ReadLine();
                }
               
            } while (!isValid);
            productType = PossibleProductTypes[productIndex];
            return productType;
        }


        private string GetStateFromCustomer()//gets state from user
        {
            bool isValid = false;
            string state = "";
            int stateIndex = 0;
            List<string> possibleStates;
            possibleStates = _operations.GetAllStates();
            do
            {
                Console.Clear();
                foreach (string s in possibleStates)
                {
                    int index = possibleStates.IndexOf(s);
                    Console.WriteLine("{0}. {1}", index, possibleStates[index]);
                }
                Console.WriteLine("Enter your states corresponding number and hit enter");
                isValid = int.TryParse(Console.ReadLine(),out stateIndex);
                if (isValid == false)
                {
                    Console.WriteLine("Must enter state vaild number");
                    Thread.Sleep(1000);
                    Console.Clear();
                    isValid = false;
                }
            } while (!isValid);
            state = possibleStates[stateIndex];
            return state;
        }


        private void VerifyAddOrder(string name, DateTime orderDate, string productType, string stateAbb, decimal totalArea)
        {
            Console.Clear();
           
            Console.WriteLine($"Here is the summary for your order\n" +
                              $"----------------------------------\n" +
                              $"Date: {orderDate.ToShortDateString()}\n" +//would like to write order id here but to get the next order number
                              $"Name: {name}\n" +                         //from the file i have to pass it the entire orders first
                              $"Product type: {productType}\n" +
                              $"State: {stateAbb}\n" +
                              $"Area: {totalArea}\n" +
                              $"-----------------------------------\n" +
                              $"Would you like to place this order?\n" +
                              $"(Y)es or (N)o");
            string input = Console.ReadLine().ToUpper();
            if (input == "Y")
            {
                ProcessNewOrder(name, orderDate, productType, stateAbb, totalArea);
            }
            if (input != "Y")
            {
                Console.WriteLine("Your order will mot be placed");
                Thread.Sleep(1000);
            }
        }


        private void ProcessNewOrder(string name, DateTime orderDate,string productType, string stateAbb, decimal totalArea)//takes all input from user and passes it to add order method in bll
        {
            var ops = new OrderOperations();
            ops.AddOrder(name, orderDate, productType, stateAbb, totalArea);
        }
    }
}
