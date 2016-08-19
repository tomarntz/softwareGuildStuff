using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;

namespace SGFlooring.Data.Product_Repos
{
    public interface IProductRepository
    {
        Product Read(string productType);
        List<string> ReadAll();
        //  Product Create(string productType);
        // bool Update(Product ProductType,string productType);
        // bool Delete(string productType);
    }
}
