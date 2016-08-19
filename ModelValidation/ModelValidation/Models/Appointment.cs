using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ModelValidation.Models.Attributes;

namespace ModelValidation.Models
{
    public class Appointment
    {
        [Required]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
       // [Required(ErrorMessage = "Please enter a date")]
       [FutureDate]
        public DateTime Date { get; set; }

        //[Range(typeof(bool),"true","true",ErrorMessage = "You must accept the terms")]
        [MustBeTrue(ErrorMessage = "You really need to check this!")]
        public bool TermsAccepted { get; set; }
    }
}