using System.Collections.Generic;
using System.Web.Mvc;
using HRPortal.Models.Data;

namespace HRPortal.Models
{
    public class PolicyCreateVM
    {
        public Category Category { get; set; }
        public List<SelectListItem> AvailableCategories { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }

        public PolicyCreateVM()
        {
            AvailableCategories = new List<SelectListItem>();
        }

        public void SetAvailableCategories(IEnumerable<Category> categories)
        {
            foreach (var category in categories)
            {
                AvailableCategories.Add(new SelectListItem()
                {
                    Value = category.CategoryId.ToString(),
                    Text = category.Name
                });
            }
        }
    }
}