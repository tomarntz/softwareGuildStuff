using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGFlooring.Data;
using SGFlooring.Models;

namespace SGFlooring.Tests
{
    [TestFixture]

    public class OrderTests
    {
        private readonly IOrderRepository repo;

        public OrderTests()
        {
            repo = RepositoryFactory.CreateOrderRepository();
        }
      

        [Test]
        public void Delete()
        {   //arrange
            DateTime date = DateTime.Today;
            List<Order> orders = repo.Read(date);
            int orderId = orders[0].OrderId;

            int expected = orders.Count - 1;
            //act
            repo.Delete(date,orderId);
            int actual = repo.Read(date).Count;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReadAll()
        {
            var orders = repo.ReadAll();
            Assert.AreEqual(6,orders.Count);
        }

        [Test]
        public void Read()
        {
            
            var orders = repo.Read(DateTime.Today);
            Assert.AreEqual(orders.Count,3);
        }

        [Test]
        public void Create()
        {
            List<Order> orderlist = repo.Read(DateTime.Today);
            int expected = orderlist.Count + 1;
            Assert.AreEqual(expected,4);
        }

        [Test]
        public void GetNextOrderNumber()
        {
            List<Order> orderList = repo.Read(DateTime.Today);
            int expected = orderList.Max(o=>o.OrderId) + 1;
            // TODO: add method to interface and call and check the actual
            Assert.AreEqual(expected,4);
        }
    }
}
