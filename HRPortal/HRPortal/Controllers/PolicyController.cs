using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Models;
using HRPortal.Models.Data;
using HRPortal.Models.Repositories;
using HRPortal.Models.Repositories.CategoryRepo;
using HRPortal.Models.Repositories.PolicyRepo;

namespace HRPortal.Controllers
{
    public class PolicyController : Controller
    {
        // GET: Policy
        public ActionResult Policies(int? categoryId)
        {
            var model = PolicyRepository.GetAll();
            if (categoryId.HasValue)
            {
                model = model.Where(p => p.CategoryId == categoryId.Value);
            }
            return View(model.ToList());
        }

        public ActionResult Add()
        {
            List<Category> categories = CategoryRepository.ReadAll();
            var vm = new PolicyCreateVM();
            vm.AvailableCategories = new List<SelectListItem>();
            foreach (var category in categories)
            {
                vm.AvailableCategories.Add(new SelectListItem() { Text = category.Name, Value = category.CategoryId.ToString() });

            }
            return View(vm);
        }

        //[HttpPost]
        //public ActionResult Add(PolicyCreateVM vm)
        //{
        //    vm.Category.Policies = new List<Policy>();
        //    foreach (var id in vm.SelectedCategoryIds)
        //    {
        //        vm.Category.Policies.Add(PolicyRepository.Get(id));
        //    }
        //    vm.Category.Policy = CategoryRepository.Read(vm.Category.Policy.PolicyId);
            
        //}

        public ActionResult Delete(int id)
        {
            var policy = PolicyRepository.Get(id);
            return View(policy);
        }

        [HttpPost]
        public ActionResult Delete(Policy policy)
        {
            PolicyRepository.Delete(policy.PolicyId);
            return RedirectToAction("Index","Home");
        }


    }
}