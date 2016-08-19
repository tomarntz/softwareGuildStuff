using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Data.Interfaces;
using Flooring.Models;

namespace Flooring.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Product GetProductByType()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}
