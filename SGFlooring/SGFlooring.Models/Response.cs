﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Models
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<Order> OrderInfo { get; set; }
    }
}
