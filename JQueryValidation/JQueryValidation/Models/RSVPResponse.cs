using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JQueryValidation.Models
{
    public class RSVPResponse
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [RegularExpression(@"^\S+@\S+$",ErrorMessage = "Format isn't valid for email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "please enter your phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your faviorte game")]
        public string FavoriteGame { get; set; }

        [Required(ErrorMessage = "Please specify whether or not you plan on attending")]
        public bool? WillAttend { get; set; }
    }
}