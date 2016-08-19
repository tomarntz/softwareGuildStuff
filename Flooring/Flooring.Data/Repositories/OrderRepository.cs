using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Data.Interfaces;
using Flooring.Models;

namespace Flooring.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public void CreateOrder()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int orderNumber)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
