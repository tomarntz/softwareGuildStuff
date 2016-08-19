using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Models;

namespace Data.DapperRepo
{
     public static class DapperSetUp
     {
         private static string _connectionString;

         public static string ConnectionString
         {
             get
             {
                 if (string.IsNullOrEmpty(_connectionString))
                 {
                     _connectionString = ConfigurationManager.ConnectionStrings["Blog"].ConnectionString;
                 }

                 return _connectionString;
             }
         }
     }
}
