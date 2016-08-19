using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;

namespace SGFlooring.Data.Product_Repos
{
    public class ProductMemoryRepository :IProductRepository
    {

        public static List<Product> ProductsList { get; private set; }


        public ProductMemoryRepository()
        {
            if (ProductsList == null)
            {
                ProductsList = new List<Product>();//makes hard coded list of product info
#region Productlist
                ProductsList.Add(new Product()
                {
                    ProductType = "Carpet",
                    CostPerSquareFoot = 2.25m,
                    LaborCostPerSquareFoot = 2.10m,
                });

                ProductsList.Add(new Product()
                {
                    ProductType = "Laminate",
                    CostPerSquareFoot = 1.75m,
                    LaborCostPerSquareFoot = 2.10m
                });
                ProductsList.Add(new Product()
                {
                    ProductType = "Tile",
                    CostPerSquareFoot = 3.50m,
                    LaborCostPerSquareFoot = 4.15m
                });
                ProductsList.Add(new Product()
                {
                    ProductType = "Wood",
                    CostPerSquareFoot = 5.15m,
                    LaborCostPerSquareFoot = 4.75m
                });
#endregion
            }
        }


        public Product Read(string productType)
        {
            Product productToReturn = null;
            int index = ProductsList.FindIndex(pType => pType.ProductType == productType);// finds the product in the list that == the product the user inputed
            if (index >= 0)
            {
                productToReturn = ProductsList[index];//returns the product where its == to the product entered by user
            }
            return productToReturn;
        }


        public List<string> ReadAll()
        {
            List<Product> Products;
            List<string> possibleProducttype;

            Products = ProductsList//takes gard coded list o product info and takes the product type from it
                .GroupBy(p => p.ProductType)
                .Select(g => g.First())
                .ToList();

            possibleProducttype = Products.Select(p => p.ProductType).ToList();//makes a list just product types that i pulled from the hard coded list
            return possibleProducttype;
        }
    }
}
