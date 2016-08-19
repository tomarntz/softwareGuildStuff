using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Responses
{
    public class ProductResponse : Response
    {
        public Product OrderInfo { get; set; }
    }
}
