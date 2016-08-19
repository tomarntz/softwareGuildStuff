using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SGFlooring.Data;
using SGFlooring.Data.Product_Repos;
using SGFlooring.Data.Tax_Repos;
using SGFlooring.Models;

namespace SGFlooring.BLL
{
    public class OrderOperations
    {
        private readonly IOrderRepository _repo;
        private readonly IProductRepository _productRepo;
        private readonly ITaxRepository _taxRepo;

        public OrderOperations()
        {
            _repo = RepositoryFactory.CreateOrderRepository();
            _productRepo = RepositoryFactory.CreateProductRepository();
            _taxRepo = RepositoryFactory.CreateTaxRepository();
        }


        public List<string> GetAllProductTypes()//gets list of just product types from read all method in product file repo and return it
        {
            List<string> allProductTypes;
            allProductTypes = _productRepo.ReadAll();
            return allProductTypes;
        }


        public List<Order> GetAllOrders()
        {
            var orders = _repo.ReadAll();
            return orders;
        }


        public Order AddOrder(string name, DateTime orderDate, string productType, string stateAbb, decimal totalArea)// gets input from user in ui
        {
            Product product = _productRepo.Read(productType);//passes product type to read method in product file repo and gets back list of that products info
            Tax tax = _taxRepo.Read(stateAbb);// passes state abb to read method in tax file repo and gets back list of specifed state info

            Order order = new Order()
            {
                Customer = name,
                OrderDate = orderDate,
                Area = totalArea,
                Product = product,
                Tax = tax
            };

            _repo.Create(order);//pass the order to the creat method in the order file repo
            return order;
        }


        public void EditOrder(Order order) //gets eddited order from proccess edit order method in ui
        {

            Product product = _productRepo.Read(order.Product.ProductType);//passses p type and gets back p info
            Tax tax = _taxRepo.Read(order.Tax.StateAbbreviation); //passes state abb gets  back tax info

            Order editedOrder = new Order()
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                Customer = order.Customer,
                Area = order.Area,
                Product = product,
                Tax = tax
            };
            // var repos = _repo;
            _repo.Update(editedOrder, order.OrderId); //passes edited order and id to update method  in order file repo
        }


        public Order GetOrder(DateTime orderDate, int orderId)//gets date and id from user in ui
        {
            Order orderForEdit = null;
           
           // var repo = _repo;
            var orders = _repo.Read(orderDate);// passes order date to read method in order file repo and gets back list of orders on that date
            int index = orders.FindIndex(o => o.OrderId == orderId);//compares user inouted order id with order ids in list
            if (index >= 0)
            {
                orderForEdit = orders[index];// sets edited order to the index in the list of orders
            }
            return orderForEdit;
        }       


        public void RemoveOrder(DateTime orderDate, int orderId) //Gets date and id from UI
        {
            var repo = _repo;
            repo.Delete(orderDate, orderId);//passes date and id to delete method in orderFilleRepo
        }


        public List<string> GetAllStates()// gets list of state abbs from read all method in tax file repo
        {
            List<string> states;
            states = _taxRepo.ReadAll();
            return states;

        }
    }
}

