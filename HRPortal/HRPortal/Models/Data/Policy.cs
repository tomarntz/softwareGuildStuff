using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRPortal.Models.Data
{
    public class Policy
    {
        public int PolicyId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Prompt = "lalalalalalalala")]
        public string Content { get; set; }
        public int CategoryId { get; set; } 
    }
}