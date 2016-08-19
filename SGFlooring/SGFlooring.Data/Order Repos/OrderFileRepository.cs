using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Tax_Repos;
using SGFlooring.Models;

namespace SGFlooring.Data
{
    public class OrderFileRepository : IOrderRepository
    {

        private List<Order> _orders;
        private const string _folderName = @"DataFiles/Orders_";


        public List<Order> Read(DateTime orderDate)// gets date from bll which gets date from ui
        {
            string fileName = _folderName + FormatOrderDate(orderDate) + ".txt";
            _orders = new List<Order>();
 
            if (File.Exists(fileName))
            {
                using (StreamReader sr = File.OpenText(fileName)) //opens file
                {
                    string inputLine = "";
                    string[] inputParts;

                    string dateOfFile = fileName.Substring(fileName.Length - 12, 8); // makes substring from filename
                    dateOfFile = dateOfFile.Substring(0, 2) + "/" + dateOfFile.Substring(2, 2) + "/" + //adds / into date frome filename
                                 dateOfFile.Substring(4);
                    var date = Convert.ToDateTime(dateOfFile);

                    while ((inputLine = sr.ReadLine()) != null)  //while line in file isnt empty
                    {
                        inputParts = inputLine.Split(',');

                        Product productInfoFromFile = new Product()
                        {
                            ProductType = inputParts[4],
                            CostPerSquareFoot = decimal.Parse(inputParts[6]),
                            LaborCostPerSquareFoot = decimal.Parse(inputParts[7])
                        };

                        Tax taxFromFile = new Tax()
                        {
                            StateName = inputParts[2],
                            StateAbbreviation = TaxFileRepository._stateTranslation[inputParts[2]],
                            TaxRate = decimal.Parse(inputParts[3])
                        };

                        Order orderFromFile = new Order()
                        {
                            OrderId = int.Parse(inputParts[0]),
                            Customer = inputParts[1],
                            Area = decimal.Parse(inputParts[5]),
                            OrderDate = date,
                            Product = productInfoFromFile,
                            Tax = taxFromFile
                        };

                        _orders.Add(orderFromFile); //adds to list
                    }
                }
            }

            else//if file doesnt exist
            {
                _orders = new List<Order>();
            }
            return _orders;//returns orders from file  in a list

        }

        public Order Create(Order order)// gets order from order operations
        {
            string fileName = _folderName + FormatOrderDate(order.OrderDate) + ".txt";//formats filename
            order.OrderId = GetNextNumberForOrder(order);//gets next number 

            if (File.Exists(fileName))
            {
                _orders = new List<Order>();
                _orders = Read(order.OrderDate);//gets list orders on specified date from read method 
                _orders.Add(order);//adds the order we got from the bll to the list of orders for that date

                using (StreamWriter sw = new StreamWriter(fileName))//rewrites all orders to file 
                {
                    foreach (var o in _orders)
                    {
                        sw.WriteLine($"{o.OrderId},{o.Customer},{o.Tax.StateName}," +
                                     $"{o.Tax.TaxRate},{o.Product.ProductType},{o.Area}," +
                                     $"{o.Product.CostPerSquareFoot},{o.Product.LaborCostPerSquareFoot}," +
                                     $"{o.Product.CostOfMaterial},{o.Total}");
                    }
                }
            }

            else//if file doesnt exist 
            {
                using (StreamWriter sw = new StreamWriter(fileName,true))
                {
                    sw.WriteLine($"{order.OrderId},{order.Customer},{order.Tax.StateName}," +
                                   $"{order.Tax.TaxRate},{order.Product.ProductType},{order.Area}," +
                                   $"{order.Product.CostPerSquareFoot},{order.Product.LaborCostPerSquareFoot}," +
                                   $"{order.Product.CostOfMaterial},{order.Total}");
                }
            }

            return order;
        }

        public List<Order> ReadAll()
        {
            throw new NotImplementedException();
        }//not used


        public bool Update(Order order, int orderId)//gets edited order and date from edit order  method in bll
        {
            string filename = _folderName + FormatOrderDate(order.OrderDate) + ".txt";// gets file name 
            List<Order> orders = Read(order.OrderDate);//gets list orders for speccific date from read method
            int index = 0;
            if (orders.Count == 0)// if theres no orders on specified date return false
            {
                return false;
            }
            if (orders.Any(x => x.OrderId == orderId))// if any of the order ids in the list of orders == the inputed order id to edite
            {
                index = orders.FindIndex(x => x.OrderId == orderId);// find index ==to the user inputed index
                orders[index] = order;//set edited order to the corresponding index in the list of orders 

                using (StreamWriter sw = new StreamWriter(filename))//rewrite all the orders 
                {
                    foreach (var o in orders)
                    {
                        sw.WriteLine($"{o.OrderId},{o.Customer},{o.Tax.StateName}," +
                                  $"{o.Tax.TaxRate},{o.Product.ProductType},{o.Area}," +
                                  $"{o.Product.CostPerSquareFoot},{o.Product.LaborCostPerSquareFoot}," +
                                  $"{o.Product.CostOfMaterial},{o.Total}");
                    }
                }
            }
            return true;
        }


        public bool Delete(DateTime orderDate, int orderId)//gets datte and id from BLL
        {
            List<Order> ordersFromList = Read(orderDate);//reads all orders for this date and puts in list
            string filename = _folderName + FormatOrderDate(orderDate) + ".txt";

            int index = 0;
            if (ordersFromList.Count == 0)
            {
                return false;
            }

            if (ordersFromList.Any(x => x.OrderId == orderId))// order id from list = order id inputed
            {
                index = ordersFromList.FindIndex(x => x.OrderId == orderId);
                ordersFromList.RemoveAt(index);//remove order at index from list

                using (StreamWriter sw = new StreamWriter(filename, false))
                {
                    foreach (var order in ordersFromList) //writes remaining orders in file
                    {
                        sw.WriteLine($"{order.OrderId},{order.Customer},{order.Tax.StateName}," +
                                  $"{order.Tax.TaxRate},{order.Product.ProductType},{order.Area}," +
                                  $"{order.Product.CostPerSquareFoot},{order.Product.LaborCostPerSquareFoot}," +
                                  $"{order.Product.CostOfMaterial},{order.Total}");
                    }
                }
            }
            return true;
        }


        public string FormatOrderDate(DateTime orderDate)
        {
            string formatdate = "";
            string[] dateParts = new string[3];// string array for 3 parts of date
            DateTime date = orderDate;
            dateParts = date.ToShortDateString().Split('/');//gets numbers from string date
            if (int.Parse(dateParts[0]) < 10)  //if month is before october adds a 0 
            {
                dateParts[0] = "0" + dateParts[0];
            }
            if (int.Parse(dateParts[1]) < 10)  // if day is less than 10 adds 0 in front of day number
            {
                dateParts[1] = "0" + dateParts[1];
            }
            formatdate =  dateParts[0] + dateParts[1] + dateParts[2];  // adds all pieces of date together
            return formatdate; // returns string of date numbers without /
        }


        public int GetNextNumberForOrder(Order order)
        {
            int number = 0;
            List < Order > orders = Read(order.OrderDate);//gets list of order on that date from read method 
            if (orders.Count == 0)
            {
                number = 1;//if theres no orders in the list the order number is one
                return number;
            }
            else
            {
                number = orders.Max(x => x.OrderId);//if there is orders in the list this finds the maximum order id 
            }
            return ++number;
        }
    }
}
