using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Web;

namespace HRPortal.Models.Data
{
    public class Job
    {
        public int JobId { get; set; }

        
        [Required(ErrorMessage = "Enter job")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Enter discription")]
        public string Discription { get; set; }

        public List<Person> Person { get; set; }

        public Job()
        {
            Person = new List<Person>();
        }
    }
}