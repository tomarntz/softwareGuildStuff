using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRPortal.Models.Data
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public Policy Policy { get; set; }
        public List<Policy> Policies { get; set; }
    }
}