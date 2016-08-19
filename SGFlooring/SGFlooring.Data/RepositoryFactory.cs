using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Product_Repos;
using SGFlooring.Data.Tax_Repos;

namespace SGFlooring.Data
{
    public static class RepositoryFactory
    {
        public static IOrderRepository CreateOrderRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            IOrderRepository repo;
            switch (mode.ToUpper())
            {
                case "TEST":
                    repo = new OrderMemoryRepository();             
                    break;
                case "PROD":
                    repo = new OrderFileRepository();
                    break;
                default:
                    throw new Exception();
            }
            return repo;
        }

        public static ITaxRepository CreateTaxRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            ITaxRepository repoTax;
            switch (mode.ToUpper())
            {
                case "TEST":
                    repoTax = new TaxMemoryRepository();
                    break;
                case "PROD":
                    repoTax = new TaxFileRepository();
                    break;
                default:
                    throw new ArgumentException();
            }
            return repoTax;
        }

        public static IProductRepository CreateProductRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            IProductRepository repoProd;
            switch (mode.ToUpper())
            {
                case "TEST":
                    repoProd = new ProductMemoryRepository();
                    break;
                case "PROD":
                    repoProd = new ProductFileRepository();
                    break;
                default:
                    throw new ArgumentException();
            }
            return repoProd;
        }
    }
}
