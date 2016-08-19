using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;

namespace SGFlooring.Data.Tax_Repos
{
    public class TaxFileRepository : ITaxRepository
    {

        public static Dictionary<string, string> _stateTranslation;

        private List<Tax> _taxes;

        private const string FILENAME = @"DataFiles\Taxes.txt";

        public TaxFileRepository() // gets list of tax info from file
        {
            _taxes = new List<Tax>();
            _stateTranslation = new Dictionary<string, string>(); //dictionar key state name value abb
            using (StreamReader sr = File.OpenText(FILENAME))
            {
                string taxInfo = "";
                string[] eachPart;
                sr.ReadLine();
                while ((taxInfo = sr.ReadLine()) != null)
                {
                    eachPart = taxInfo.Split(',');

                    Tax tax = new Tax()
                    {
                        StateAbbreviation = eachPart[0],
                        StateName = eachPart[1],
                        TaxRate = decimal.Parse(eachPart[2]),
                    };
                    _taxes.Add(tax); //adds all  tax info to list
                    _stateTranslation.Add(tax.StateName, tax.StateAbbreviation);//adds name and abb from list to dictionary
                }
            }
        }

       
        public Tax Read(string stateabbreviation)//gets state abb from bll
        {

            Tax tax = null;
            int index = _taxes.FindIndex(t => t.StateAbbreviation == stateabbreviation);// takes the list of all tax info and gets state abb from list where it == the user inputed state abb
            if (index >= 0)
            {
                tax = _taxes[index];// gets all tax info at specified index
            }
            return tax;//returns a list of the specified states tax info
        }
       

        public List<string> ReadAll() // takes list of tax info and makes list of just state abbs
        {
            List<string> States;
            List<Tax> stateAbbList = _taxes
                .GroupBy(t => t.StateAbbreviation)
                .Select(i => i.First())//  returns first element
                .ToList();
            States = stateAbbList.Select(p => p.StateAbbreviation).ToList();
            return States;
        }
    }
}
