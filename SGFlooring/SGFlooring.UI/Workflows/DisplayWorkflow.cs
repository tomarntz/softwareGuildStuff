using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SGFlooring.BLL;
using SGFlooring.Data;
using SGFlooring.Models;

namespace SGFlooring.UI.Workflows
{
    public class DisplayWorkflow : WorkFlows
    {

        public override void Execute()
        {
            DateTime orderdate = GetOrderDate();
            int orderId = GetOrderId();
            Order order = GetOrder(orderdate,orderId);
            PrintOrder(order);
          
        }


        private Order GetOrder(DateTime orderdate, int orderId)//get date and id from user
        {
            var ops = new OrderOperations();
            Order order = ops.GetOrder(orderdate, orderId); //passes date and id to get order method in bll gets back order
            return order;
        }


        private void PrintOrder(Order order)
        {
            if (order == null)
            {
                Console.WriteLine("Order not found");
                Thread.Sleep(1000);
                return;
            }
            Console.Clear();
            Console.WriteLine($"Date: {order.OrderDate}\n" +
                              $"Order Id: {order.OrderId}\n" +
                              $"Customer Name: {order.Customer}\n" +
                              $"Product Type: {order.Product.ProductType}\n" +
                              $"State: {order.Tax.StateName}\n" +
                              $"Area: {order.Area}\n" +
                              $"Total: {order.Total}\n");
            Console.WriteLine("\n\nHit enter to return to main menu");
            Console.ReadLine();
        }
    }
}
