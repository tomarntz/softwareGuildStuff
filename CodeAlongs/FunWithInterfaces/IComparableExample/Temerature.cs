using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparableExample
{
    public class Temerature:IComparable
    {
        public double Farenheit { get; set; }
        public double celsus { get {return(Farenheit - 32)*(5.0/9); } }

        public int CompareTo(object obj)
        {
            var otherTemperature = obj as Temerature;

            if (otherTemperature != null)
            {
                if (this.Farenheit < otherTemperature.Farenheit)
                {
                    return -1;
                }
                else if (this.Farenheit == otherTemperature.Farenheit)
                {
                    return 0;
                }
                else // thiis.farenheit > other.temperature.farenheit
                {
                    return 1;
                }
            }
            else
            {
                throw new ArgumentException("Object is not a temperature");
            }
        }
    }
}
