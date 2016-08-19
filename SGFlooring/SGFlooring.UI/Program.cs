using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SGFlooring.Data;

namespace SGFlooring.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MainMenu menu = new MainMenu();
                menu.StartMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured will write to file");
                Thread.Sleep(1500);
                var log = new LogRepository();
                log.AddError(ex);
            }
        }
    }
}
