using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using HRPortal.Models.Data;

namespace HRPortal.Models
{
    public class PersonVM
    {
        public Person Person { get; set; }
        public List<SelectListItem> JobItems { get; set; }

        public PersonVM()
        {
            JobItems = new List<SelectListItem>();
            Person = new Person();
        }

        public void SetJobItems(IEnumerable<Job> jobs)
        {
            foreach (var job in jobs)
            {
                JobItems.Add(new SelectListItem()
                {
                    Value = job.JobId.ToString(),
                    Text = job.Position
                });
            }
        }
    }
}