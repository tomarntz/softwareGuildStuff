using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Data.Interfaces;
using Flooring.Models;

namespace Flooring.Data.Repositories
{
    public class TaxRepository : ItaxRepository
    {
        public Tax GetTaxRateByName()
        {
            throw new NotImplementedException();
        }

        public List<Tax> GetAllTaxObjects()
        {
            throw new NotImplementedException();
        }
    }
}
