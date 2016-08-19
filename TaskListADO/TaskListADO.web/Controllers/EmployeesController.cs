using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskListADO.Data;
using TaskListADO.Models;

namespace TaskListADO.web.Controllers
{
    public class EmployeesController : ApiController
    {
        public List<Employee> GetAll()
        {
            DBRepository repo = new DBRepository();
            return repo.GetAllEmployees();
        }

        public Employee GetById(int id)
        {
            DBRepository repo = new DBRepository();
            List<Employee> list = repo.GetAllEmployees();

            return list.FirstOrDefault(m => m.EmployeeId == id);
        }
    }
}
