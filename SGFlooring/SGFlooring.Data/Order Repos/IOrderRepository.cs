using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;

namespace SGFlooring.Data
{
    public interface IOrderRepository
    {
        Order Create(Order order);

        List<Order> Read(DateTime orderdate);

        List<Order> ReadAll();

        bool Update(Order order, int orderId);
        bool Delete(DateTime orderDate, int orderId);
    }
}
