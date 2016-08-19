using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRPortal.Models.Data;

namespace HRPortal.Models.Repositories.PolicyRepo
{
    public class PolicyRepository
    {
        private static readonly List<Policy> _policies;

        static PolicyRepository()
        {
            _policies = new List<Policy>
            {
                #region policy list
                new Policy()
                {
                    PolicyId = 0,
                    CategoryId = 0,
                    Title = "Riders",
                    Content = "All riders must be Targaryen"
                },
                new Policy()
                {
                    PolicyId = 1,
                    CategoryId = 0,
                    Title = "Food",
                    Content = "Stay out of their way they eat what they want"
                },
                new Policy()
                {
                    PolicyId = 2,
                    CategoryId = 1,
                    Title = "Sword",
                    Content = "Sword better be on fire"
                },
                new Policy()
                {
                    PolicyId = 3,
                    CategoryId = 1,
                    Title = "Religin",
                    Content = "Lord of light"
                 }
#endregion
            };
        }

        public static IEnumerable<Policy> GetAll()
        {
            return _policies;
        }

        public static Policy Get(int id)
        {
            return _policies.Find(m => m.PolicyId == id);
        }

        public static List<Policy> GetByCatId(int catId)
        {
            return _policies.FindAll(m => m.CategoryId == catId);
        }

        public static void Add(Policy policy
            )
        {
            Policy p = new Policy();
            p.Title = policy.Title;
            p.Content = policy.Content;
            p.CategoryId = policy.CategoryId;
            p.PolicyId = _policies.Max(m => m.PolicyId) + 1;
            _policies.Add(p);
        }

        public static void Edit(Policy policy)
        {
            var selectedPolicy = _policies.FirstOrDefault(m => m.PolicyId == policy.PolicyId);
            selectedPolicy.Title = policy.Title;
            selectedPolicy.Content = policy.Content;
        }

        public static void Delete(int policyId)
        {
            _policies.RemoveAll(m => m.PolicyId == policyId);
        }
    }
}