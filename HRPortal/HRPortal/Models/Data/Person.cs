using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Net.Sockets;
using System.Web;

namespace HRPortal.Models.Data
{
    public class Person
    {
        public int PersonId { get; set; }
        public int JobId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Education { get; set; }
        public string Resume { get; set; }
        public int Phone { get; set; }
        public decimal Salary { get; set; }

        public Job Job { get; set; }
    }
}