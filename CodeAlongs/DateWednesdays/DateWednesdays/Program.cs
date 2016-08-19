using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateWednesdays
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prog = new Program();

            string dateString = prog.DisplayPrompt("pleas enter the date you wish to  start  with");
            DateTime startDate = DateTime.Parse(dateString);

            string numwedstring = prog.DisplayPrompt("how many wednesdays do you want?");
            int numWed = int.Parse(numwedstring);

            while (startDate.DayOfWeek != DayOfWeek.Wednesday)
            {
                startDate = startDate.AddDays(1);
            }

            for (int i = 0; i < numWed; i++)
            {
                Console.WriteLine(startDate.ToShortDateString());
                Console.WriteLine(startDate.ToLongDateString());
                Console.WriteLine();

                startDate = startDate.AddDays(7);
            }
            Console.ReadLine();
        }

        public string DisplayPrompt(string message)
        {
            Console.Write(message);
            Console.ReadLine();
        }
    }
}
