using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;

namespace SGFlooring.Data.Product_Repos
{
    public class ProductFileRepository :IProductRepository
    {
        private List<Product> _products;
        private const string FILENAME = @"DataFiles\Product.txt";


        public ProductFileRepository() //gets list of product , cost per square foot and labor cost per square foot
        {
            _products = new List<Product>();
            using (StreamReader sr = File.OpenText(FILENAME))
            {
                string productInfo = "";
                string[] eachPart;
                sr.ReadLine(); //Skips first line in file
                while ((productInfo = sr.ReadLine())!=null)
                {
                    eachPart = productInfo.Split(',');

                    Product product = new Product()
                    {
                        ProductType = eachPart[0],
                        CostPerSquareFoot = decimal.Parse(eachPart[1]),
                        LaborCostPerSquareFoot = decimal.Parse(eachPart[2]),
                    };
                    _products.Add(product); //adds all products and info to list
                }
            }
        }


        public Product Read(string productType)//get product type from  bll
        {
            Product productToReturn = null;
            int index = _products.FindIndex(pType => pType.ProductType == productType);//takes list of product info gets product type where the product type is == to the users inputed product type
            if (index >= 0)
            {
                productToReturn = _products[index];//sets the product to return to a list of just the inputed product type info insted of all the  products info
            }
            return productToReturn;
        }


        public List<string> ReadAll()//takes of all product info and makes a new list with just thye product types
        {
            List<string> allProductList = _products.Select(p => p.ProductType).Distinct().ToList();
            return allProductList;
        } 
    }
}
