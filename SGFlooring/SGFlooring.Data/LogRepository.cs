using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;

namespace SGFlooring.Data
{
    public class LogRepository
    {
        private string filePath = ("DataFiles/ErrorLog.txt");

        public void AddError(Exception ex)
        {
            var listOfAlreadyLoggedErrors = GetAllLogs();//gets list of errors alreadylogged
            var newErrorToLog = new Log() { Date = DateTime.Now, ErrorMessage = ex.Message.Replace(",",";")};//get the new error
            listOfAlreadyLoggedErrors.Add(newErrorToLog);//adds new error to list of old erros
            OverWrite(listOfAlreadyLoggedErrors);//pass overwrite method list of all errors
        }


        public List<Log> GetAllLogs()
        {
            var listOfLogedErrors = new List<Log>();
            if (File.Exists(filePath))
            {
                var eacherror = File.ReadAllLines(filePath);//reads all lines in error file

                for (int i = 1; i < eacherror.Length; i++)//for every error
                {
                    var log = new Log();
                    var colomn = eacherror[i].Split(',');//colomns split by ,
                    log.ErrorMessage = colomn[0];             
                    log.Date = DateTime.Parse(colomn[1]);  
                    listOfLogedErrors.Add(log);//adds all errors to list
                }
            }
            return listOfLogedErrors;
        }


        private void OverWrite(List<Log> allLoggedErrors)
        {
            using (var write = File.CreateText(filePath))
            {
                foreach (var error in allLoggedErrors)//writes every error in thefile
                {
                    write.WriteLine("{0},{1}",error.ErrorMessage,error.Date);
                }
            }
        }
    }
}
