using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StabBlog.Models.AppModels
{
    public class WeaponPage
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [UIHint("tinymce_full"), AllowHtml]
        public string Content { get; set; }
        public int WeaponId { get; set; }
        [Required]
        public int ExhibitId { get; set; }
        public bool ComingSoon { get; set; }
        public string ImagePath { get; set; }
    }
}