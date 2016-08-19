using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SGFlooring.BLL;
using SGFlooring.Models;
using SGFlooring.Data;

namespace SGFlooring.UI.Workflows
{
    public class EditOrderWorkflow : WorkFlows
    {
        private Order _currentOrder;


        public override void Execute()
        {
            DateTime orderDate = GetOrderDate();
            int orderId = GetOrderId();
            ProccessEditOrder(orderDate,orderId);
        }


        private void ProccessEditOrder(DateTime orderDate, int orderId)
        {
            var ops = new OrderOperations();
            var orderToEdit = ops.GetOrder(orderDate, orderId);//pass date and id to get order in bll get back order
            if (orderToEdit != null)//if order to edit gets order back
            {
                Order order = ModifyOrder(orderToEdit); // pass intire order to modify order method get back edited order
                ops.EditOrder(order);// passes edited order to edit order in bll
            }
            else
            {
                Console.WriteLine("Order not found");
                Thread.Sleep(1000);
            }
        }

        private Order ModifyOrder(Order orderToEdit)
        {
            bool isWorked = false;
            bool isValid = false;
            bool isParsed = false;
            string input = "";

            int productIndex = 0;
            decimal Area = 0;
            List<string> PossibleProductTypes;
            var ops = new OrderOperations();
            PossibleProductTypes = ops.GetAllProductTypes(); // gets list of just product types ffrom bll

            int stateIndex = 0;
            List<string> possibleStates;
            possibleStates = _operations.GetAllStates(); // gets list of just state names from bll

            do
            {
                Console.Clear();
                Console.WriteLine("Enter name for the order to edit the current name is {0}", orderToEdit.Customer);
                orderToEdit.Customer = Console.ReadLine();
            } while (orderToEdit.Customer == "");


            do
            {
                Console.Clear();
                foreach (string product in PossibleProductTypes)//displays all options from list of products
                {
                    int index = PossibleProductTypes.IndexOf(product);
                    Console.WriteLine("{0}. {1}", index, PossibleProductTypes[index]);//writes an index then product type
                }
                Console.WriteLine("Enter product type current product type is {0}",orderToEdit.Product.ProductType);
                isValid = int.TryParse(Console.ReadLine(), out productIndex);
                if (isValid == false)
                {
                    Console.WriteLine("Thats not an option");
                    Thread.Sleep(1000);
                    isValid = false;
                }
            } while (!isValid);
            orderToEdit.Product.ProductType = PossibleProductTypes[productIndex];


            do
            {
                Console.Clear();
                Console.WriteLine("Enter area current area is {0}", orderToEdit.Area);
                isWorked = decimal.TryParse(Console.ReadLine(), out Area);
                if (isWorked == false)
                {
                    Console.WriteLine("Thats not an option");
                    Thread.Sleep(1000);
                    isWorked = false;
                }
            } while (!isWorked);


            do
            {
                Console.Clear();
                foreach (string s in possibleStates)
                {
                    int index = possibleStates.IndexOf(s);
                    Console.WriteLine("{0}. {1}", index, possibleStates[index]);
                }
                Console.WriteLine("Enter state name current state is {0}", orderToEdit.Tax.StateAbbreviation);
                isParsed = int.TryParse(Console.ReadLine(),out stateIndex);
            } while (!isParsed);
            orderToEdit.Tax.StateAbbreviation = possibleStates[stateIndex];


            Console.Clear();
            Console.WriteLine($"Your modified order is as follows\n" +
                              "*********************************\n" +
                              "                                 \n" +
                              $"orderId = {orderToEdit.OrderId}\n" +
                              $"Customer = {orderToEdit.Customer}\n" +
                              $"State: = {orderToEdit.Tax.StateAbbreviation}\n" +
                              $"Product = {orderToEdit.Product.ProductType}\n" +
                              $"Total = {orderToEdit.Total}\n");

            Console.WriteLine("Would you like to modify this order (Y)es or (N)o?");
            string answer = Console.ReadLine().ToUpper();
            if (answer == "Y")
            {
                return orderToEdit;
            }
            Console.WriteLine("Your order wont be updated");
            Thread.Sleep(1000);
            return null;
        }
    }
}
