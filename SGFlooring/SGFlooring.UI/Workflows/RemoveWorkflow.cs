using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SGFlooring.BLL;
using SGFlooring.Data;

namespace SGFlooring.UI.Workflows
{
    public class RemoveWorkflow : WorkFlows
    {

        public override void Execute()
        {
            DateTime orderDate = GetOrderDate();
            int orderId = GetOrderId();
            ProcessRemoveing(orderDate, orderId);
        }


        private static void ProcessRemoveing(DateTime orderDate, int orderId)
        {
            bool isRemoved = false;
            do
            {
                Console.WriteLine($"Would you like to remove order {orderId} placed on {orderDate}?");
                Console.WriteLine("(Y)es or (N)o");
                string input = Console.ReadLine();
                if (input.ToUpper() == "Y")
                {
                    var ops = new OrderOperations();
                    ops.RemoveOrder(orderDate, orderId);  //Passes date and ID to RemoveOrder method in BLL
                    Console.WriteLine("Your order has been removed");
                    Thread.Sleep(1000);
                    isRemoved = true;
                }
                if (input.ToUpper() != "Y")
                {
                    Console.WriteLine("Your order will not be removed");
                    isRemoved = true;
                }
            } while (!isRemoved);
        }
    }
}
