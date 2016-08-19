using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Models
{
    public class Order
    {
        //private decimal _total;

        public int OrderId { get; set; }
        public string Customer { get; set; }
        private decimal _area;
        public Tax Tax { get ; set; }
        public DateTime OrderDate { get; set; }
        public Product Product { get; set; }

        public decimal TotalTax  { get { return Math.Round((Tax.TaxRate * Product.CostOfMaterial  * _area), 2); }  }

        public decimal Total
        {
            get { return (Tax.TaxRate / 100 + 1) * Product.CostOfMaterial * _area; }
        }

        public decimal Area
        {
            get
            {
                return _area;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cant be negative", "value");
                }
                _area = value;
            }
        }
    }
}
