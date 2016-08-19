using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;

namespace Flooring.Data.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder();
        Order GetOrderById(int orderNumber);
        List<Order> GetAllOrders();
        void UpdateOrder(Order order);
        void DeleteOrder(int orderId);

    }
}
