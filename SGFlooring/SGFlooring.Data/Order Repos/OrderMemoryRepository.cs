using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using SGFlooring.Data.Product_Repos;
using SGFlooring.Data.Tax_Repos;
using SGFlooring.Models;

namespace SGFlooring.Data
{
    public class OrderMemoryRepository : IOrderRepository
    {
        protected static Dictionary<DateTime, List<Order>> OrderDictionary { get; private set; }//dictionary with date as key and list of orders as value


        public OrderMemoryRepository()
        {
            if (OrderDictionary == null)
            {
                ProductMemoryRepository pmp = new ProductMemoryRepository();
                TaxMemoryRepository tmp = new TaxMemoryRepository();

                OrderDictionary = new Dictionary<DateTime, List<Order>>();

                #region orderlist

                OrderDictionary
                    .Add(DateTime.Today,new List<Order>()
                            {
                                new Order
                                {
                                    OrderId = 1,
                                    Customer = "Apple, Inc",
                                    OrderDate = DateTime.Today,
                                    Area = 50.5m,
                                    Product = pmp.Read("Carpet"),
                                    Tax = tmp.Read("OH")
                                },
                                new Order
                                {
                                    OrderId = 2,
                                    Customer = "Google, LLC",
                                    OrderDate = DateTime.Today,
                                    Area = 40.4m,
                                    Product = pmp.Read("Tile"),
                                    Tax = tmp.Read("PA")
                                },
                                new Order
                                {
                                    OrderId = 3,
                                    Customer = "Microsoft, Inc",
                                    OrderDate = DateTime.Today,
                                    Area = 100.5m,
                                    Product = pmp.Read("Wood"),
                                    Tax = tmp.Read("MI")
                                }
                            });

                OrderDictionary
                    .Add(
                        DateTime.Today.Subtract(TimeSpan.FromDays(1)),
                        new List<Order>()
                        {
                            new Order()
                            {
                                OrderId = 1,
                                Customer = "Billy Joe",
                                OrderDate = DateTime.Today.Subtract(TimeSpan.FromDays(1)),
                                Area = 10m,
                                Product = pmp.Read("Wood"),
                                Tax = tmp.Read("OH")
                            },
                            new Order()
                            {
                                OrderId = 2,
                                Customer = "Bob Tanner",
                                OrderDate = DateTime.Today.Subtract(TimeSpan.FromDays(1)),
                                Area = 5m,
                                Product = pmp.Read("Tile"),
                                Tax = tmp.Read("OH")
                            },
                            new Order()
                            {
                                OrderId = 3,
                                Customer = "Craig Mabbit",
                                OrderDate = DateTime.Today.Subtract(TimeSpan.FromDays(1)),
                                Area = 3,
                                Product = pmp.Read("Wood"),
                                Tax = tmp.Read("PA")
                            }
                        });
                #endregion
            }
        }


        public Order Create(Order order)
        {
            int orderId = GetNextOrderNumber(order.OrderDate);//gets next order number
            order.OrderId = orderId;//sets order id to the next order number
            List<Order> orderList;
            if (OrderDictionary.ContainsKey(order.OrderDate))//if thers orders on specified date
            {
                OrderDictionary[order.OrderDate].Add(order);//add the order to it
            }
            else
            {
                orderList = new List<Order>();
                orderList.Add(order);//add new order to list
                OrderDictionary.Add(order.OrderDate, orderList);//add new list to dictionary
            }
            return order;
        }


        public List<Order> Read(DateTime orderDate)//makes list of orders on specified date
        {
            List<Order> orderlist = null;
            if (OrderDictionary.ContainsKey(orderDate))
            {
                orderlist = OrderDictionary[orderDate];
            }
            return orderlist;
        }


        public List<Order> ReadAll()//gets all orders from dictionary
        {
            var stupidList = OrderDictionary.Values.SelectMany(x => x).ToList();
            return stupidList;
        }


        //public Order OneOrder(DateTime date, int id)
        //{
        //    if (OrderDictionary.ContainsKey(date))
        //    {
        //        List<Order> orderList = OrderDictionary[date];
        //        if (orderList.Any(o=>o.OrderId == id))
        //        {
        //            int index = orderList.FindIndex(o => o.OrderId == id);
        //            Order order = orderList.Select(index)
        //        }
        //    }
        //}


        public bool Delete(DateTime orderDate, int orderId)
        {
            bool isDeleted = false;
            if (OrderDictionary.ContainsKey(orderDate))
            {
                var orderList = OrderDictionary[orderDate];//list of orders for specified date
                if (orderList.Any(x => x.OrderId == orderId))//out of this list if  any of the id mathch the user inputed id
                {
                    int index = orderList.FindIndex(x => x.OrderId == orderId);//set the index to that order id and return it
                    orderList.RemoveAt(index);//remove the order at that index
                    //  OrderDictionary.Remove(orderDate);//remove that date
                    // OrderDictionary.Add(orderDate,orderList);//add remaining order list to dictionary
                    isDeleted = true;
                }
            }
            else
            {
                isDeleted = false;
            }
            return isDeleted;
        }

        public bool Update(Order order, int orderId)
        {
            bool isUpdated = false;
            if (OrderDictionary.ContainsKey(order.OrderDate))
            {
                var orderList = OrderDictionary[order.OrderDate];//set orderlist to all order on specified date
                if (orderList.Any(o => o.OrderId == orderId))//if any orders in list == user inputed order id
                {
                    orderList.RemoveAt(CheckOrderIndex(order.OrderDate,orderId));//removes old order
                    orderList.Add(order);//adds updated one
                    OrderDictionary.Remove(order.OrderDate);
                    OrderDictionary.Add(order.OrderDate, orderList);//add updated list to dictionary
                    isUpdated = true;
                }
            }
            else
            {
                isUpdated = false;
            }
            return isUpdated;
        }


        public int CheckOrderIndex(DateTime orderDate, int orderId)//checks for order id in specified date
        {
            int index = 0;
            if (OrderDictionary.ContainsKey(orderDate))
            {
                var orderlist = OrderDictionary[orderDate];// list of orders for specified date 
                if (orderlist.Any(x => x.OrderId == orderId))//out of this list if  any of the id mathch the user inputed id
                {
                    index = orderlist.FindIndex(x => x.OrderId == orderId);//set the index to that order id and return it
                }
            }
            return index;
        }


        public int GetNextOrderNumber(DateTime orderDate)//gets next order number just like in file
        {
            int number = 0;
            List<Order> orderList = null;
            if (OrderDictionary.ContainsKey(orderDate))
            {
                orderList = OrderDictionary[orderDate];
                number = orderList.Max(t => t.OrderId);
            }
            else
            {
                number = 0;
            }
            return ++number;
        }
    }
}
