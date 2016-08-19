using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Models;

namespace StabBlog.Models.ViewModels
{
    public class ExhibitHomeVM
    {
        public List<Exhibit> AllExhibits { get; set; }
        public List<Weapon> AllWeapons { get; set; }

        public ExhibitHomeVM()
        {
            PostManagement pm = new PostManagement();
            AllExhibits = pm.GetAllExhibits();
            AllWeapons = pm.GetAllWeapons();

        }
    }
}