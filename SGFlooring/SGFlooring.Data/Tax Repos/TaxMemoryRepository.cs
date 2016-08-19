using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;

namespace SGFlooring.Data.Tax_Repos
{
    public class TaxMemoryRepository :ITaxRepository
    {
        public List<Tax>TaxList; //list of hard coded tax info


        public TaxMemoryRepository()
        {
            if (TaxList == null)
            {
                 #region TaxList
                TaxList = new List<Tax>();
                TaxList.Add(new Tax()
                {
                    StateAbbreviation = "OH",
                    StateName = "Ohio",
                    TaxRate = 6.25m
                });
                TaxList.Add(new Tax()
                {
                    StateAbbreviation = "PA",
                    StateName = "Pensylvania",
                    TaxRate = 6.75m
                });
                TaxList.Add(new Tax()
                {
                    StateAbbreviation = "MI",
                    StateName = "Michigan",
                    TaxRate = 5.75m
                });
                TaxList.Add(new Tax()
                {
                    StateAbbreviation = "IN",
                    StateName = "Indiana",
                    TaxRate = 6.00m
                });
#endregion
            }
        }


        public Tax Read(string stateabbreviation)
        {
            Tax tax = null;
            int index = TaxList.FindIndex(t => t.StateAbbreviation == stateabbreviation);//uses state abb to get state info for specified state
            if (index >= 0)
            {
                tax = TaxList[index];//sets tax object to just the specified states tax info insted of grabing all states info
            }
            return tax;
        }

       
        public List<string> ReadAll()
        {
            List<Tax> tax;
            List<string> possibleStates;
            tax = TaxList//takes hard coded list of tax info and selects just the states names
                .GroupBy(t => t.StateName)
                .Select(s => s.First())
                .ToList();
            possibleStates = tax.Select(s => s.StateName).ToList(); //makes list of just states that i pulled from taxlist
            return possibleStates;
        }
    }
}
