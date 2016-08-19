using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;

namespace SGFlooring.Data.Tax_Repos
{
    public interface ITaxRepository
    {
        Tax Read(string stateabbreviation);
        List<string> ReadAll();
        //   Tax Create(string stateabbreviation);
        //  bool Update(string stateabbreviation, Tax tax);
        //  bool Delete(string stateabbreviation);



    }
}
