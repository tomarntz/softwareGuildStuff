using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using StabBlog.Models.AppModels;

namespace StabBlog.Models.ViewModels
{
    public class WeaponVM
    {
        public WeaponPage Weapon { get; set; }
        public List<SelectListItem> Exhibits { get; set; }

        public WeaponVM()
        {
            Exhibits = new List<SelectListItem>();
        }

        public void SetExhibits()
        {
            PostManagement pm = new PostManagement();
            List<Exhibit> listOfExhibits = pm.GetAllExhibits();

            foreach (var exhibit in listOfExhibits)
            {
                if (exhibit.PostStatus)
                {
                    Exhibits.Add(new SelectListItem()
                    {
                        Text = exhibit.Title,
                        Value = exhibit.ExhibitId.ToString()
                    });
                }
               
            }
        }
    }
}