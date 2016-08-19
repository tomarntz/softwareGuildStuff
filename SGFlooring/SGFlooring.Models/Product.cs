using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Models
{
    public class Product
    {
        public string ProductType { get; set; }

        private decimal _costPerSquareFoot;
        private decimal _laborCostPerSquareFoot;
        public decimal CostPerSquareFoot
        {
            get
            {
                return _costPerSquareFoot;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cant be negative","value");
                }
                _costPerSquareFoot = value;
            }
        }

        public decimal LaborCostPerSquareFoot
        {
            get
            {
                return _laborCostPerSquareFoot;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cant be negative","value");
                }
                _laborCostPerSquareFoot = value;
            }
        }
        public decimal CostOfMaterial { get { return (_costPerSquareFoot + _laborCostPerSquareFoot); } }
    }
}
