using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunWithLinq.Data;
using FunWithLinq.Modles;

namespace FunWithLinq
{
    class Program
    {
        static void Main(string[] args)
        {

            GroupBy();
            AnonymousTypes();
            joins();

            Console.ReadLine();
        }

        static void AnonymousTypes()
        {
            Console.WriteLine("<= AnonymousTypes");

            //Getting our data from our reposittories
            //this is something we will see from here on out
            List<Student> students = StudentRepository.GetAllStudents();
           
            //query syntax
            //var Ladies = from s in students
            //    where s.Gender == "F"
            //    select new
            //    {
            //        Name = $"{s.FirstName}{s.LastName}",
            //        s.Major
            //    };

            //method syntax
            var ladies =
                students.Where(s => s.Gender == "F").Select(x => new {Name = $"{x.FirstName}{x.LastName}", x.Major});

            //using var because the type of collections is an aninomous type
            //cant say anything but var
            foreach (var Lady in Ladies)
            {
                Console.WriteLine($"{Lady.Name} is majoring in {Lady.Major}");
            }

            Console.ReadLine();
        }

        static void joins()
        {
            Console.WriteLine("<= Joins");

            List<Student> students = StudentRepository.GetAllStudents();
            List<StudentCourse> courses = StudentRepository.GetAllStudentCourses();

            // join the student to the coourse the student is in

            // query syntax
            //var results = from s in students
            //    join c in courses
            //        on s.ID equals c.StudentId
            //    select new
            //    {
            //        c.CourseName,
            //        studentName = $"{s.FirstName}{s.LastName}"
            //    };
        
            //method syntax
            var results = students.Join(courses, student => student.ID, course => course.StudentId,
                (student, course) => new
                {
                    course.CourseName,
                    studentName = $"{student.FirstName} {student.LastName}"
                });

            foreach (var result in results)
            {
                Console.WriteLine($"{result.studentName} is taking {result.CourseName}");
            }

        }

        static void GroupBy()
        {
            Console.WriteLine("<= Group By");

            var students = StudentRepository.GetAllStudents();

            //Query syntax
            //Take is demonstrating mixed syntax
            var result = (from s in students
                          where s.Major != "Chemistry"
                         orderby s.Major descending, s.LastName  
                         group s by s.Major).Take(2);

            //method syntax
            //var result = students.Where(student => student.Major != "Chemistry")
            //    .OrderBy(s => s.Major)
            //    .ThenBy(s => s.LastName)
            //    .GroupBy(student => student.Major);

            foreach (var group in result)
            {
                Console.WriteLine(group.Key);

                foreach (var student in group)
                {
                    Console.WriteLine($"\t{student.FirstName}{student.LastName} - {student.Major}");
                }
                
            }

            Console.WriteLine();
        }
    }
}
