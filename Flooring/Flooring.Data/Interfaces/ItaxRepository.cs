using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;

namespace Flooring.Data.Interfaces
{
    public interface ItaxRepository
    {
        Tax GetTaxRateByName();
        List<Tax> GetAllTaxObjects();
    }
}
