using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Models;

namespace StabBlog.Models.ViewModels
{
    public class SingleExhibitVM
    {
        public Exhibit Exhibit { get; set; }
        public List<Weapon> WeaponsInExhibit { get; set; }

    }
}