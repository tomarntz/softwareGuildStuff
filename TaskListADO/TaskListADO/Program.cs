using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskListADO.Data;
using TaskListADO.Models;

namespace TaskListADO
{
    class Program
    {
        static void Main(string[] args)
        {
            DBRepository repo = new DBRepository();
            List<Task> tasks = repo.GetAll();

            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.TasKId} {task.Discription}");
            }

            Console.WriteLine();

            Task myTask = repo.GetById(2);
            Console.WriteLine($"{myTask.TasKId} {myTask.Discription}");
            Console.WriteLine($"{myTask.DateEntered.ToLongDateString()}");
            if (myTask.DueDate != null)
            {
                Console.WriteLine($"This is due on {((DateTime) myTask.DueDate).ToShortDateString()}");
            }


            CallStoredProc(repo);

            Console.ReadLine();
        }

        public static void CallStoredProc(DBRepository repo)
        {
            List<Employee> employees = repo.GetAllEmployees();

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.EmployeeId} - {employee.FirstName} {employee.LastName}");
                Console.WriteLine("Grants");
                foreach (var g in employee.Grants)
                {
                    Console.WriteLine($"\t{g.GrantID} {g.GrantName} - {g.Amount}");
                }
                Console.WriteLine();
            }
        }
    }
}
