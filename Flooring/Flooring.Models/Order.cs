using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models
{
    public class Order
    {
        public Product Product { get; set; }
        public Tax Tax { get; set; }
        public int CustomerName { get; set; }
        public decimal Area { get; set; }
        public decimal TotalCost { get; set; }
    }
}
