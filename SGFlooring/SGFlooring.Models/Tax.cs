﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Models
{
    public class Tax
    {
        public string StateName { get; set; }
        public string StateAbbreviation { get; set; }
        public decimal TaxRate { get; set; }
    }
}
