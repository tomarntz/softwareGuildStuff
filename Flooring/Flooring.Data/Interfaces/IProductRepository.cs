using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;

namespace Flooring.Data.Interfaces
{
    public interface IProductRepository
    {
        Product GetProductByType();
        List<Product> GetAllProducts();

    }
}
