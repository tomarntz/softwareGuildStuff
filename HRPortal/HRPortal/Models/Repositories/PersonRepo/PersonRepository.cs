using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRPortal.Models.Data;

namespace HRPortal.Models.Repositories.Personrepo
{
    public class PersonRepository
    {
        private static readonly List<Person> _persons;

        static PersonRepository()
        {
            #region list of persons
            _persons = new List<Person>
            {
                new Person
                {
                    PersonId = 1,
                    JobId = 0,
                    FirstName = "Jamie",
                    LastName = "Lanaster",
                    Education = "knight degree",
                    Resume = "Im good Knight",
                    Phone = 1111111111,
                    Salary = 123m
                },
                new Person()
                {
                    PersonId = 2,
                    JobId = 4,
                    FirstName = "Jon",
                    LastName = "Snow",
                    Education = "Knights watch university",
                    Resume = "hire me",
                    Phone = 222222222,
                    Salary = 1234m
                   
                },
                new Person()
                {
                    PersonId = 3,
                    JobId = 7,
                    FirstName = "Kahl",
                    LastName = "Drogo",
                    Education = "Grass sea university",
                    Resume = "hire me or ill pour molton gold on you",
                    Phone = 333333333,
                    Salary =12345m
                },
                new Person()
                {
                    PersonId = 4,
                    JobId = 8,
                    FirstName = "Hodor",
                    LastName = "Hodor",
                    Education = "Hodor",
                    Resume = "Hodor",
                    Phone = 1,
                    Salary = 1
                }
            };
#endregion
        }

        public static IEnumerable<Person> GetAll()
        {
            return _persons;
        }
        
        public static Person GetPerson(int personId)
        {
            return _persons.FirstOrDefault(m => m.PersonId == personId);
        }

        public static List<Person> GetPersonByJob(int jobId)
        {
            return _persons.FindAll(m => m.JobId == jobId);
        }

        public static void Add(Person person)
        {
            _persons.Add(person);
        }

        public static void Edit(Person person)
        {
            var selectedPerson = _persons.First(m => m.PersonId == person.PersonId);
            selectedPerson.FirstName = person.FirstName;
            selectedPerson.LastName = person.LastName;
            selectedPerson.Education = person.Education;
            selectedPerson.Resume = person.Resume;
            selectedPerson.Phone = person.Phone;
            selectedPerson.Salary = person.Salary;
        }

        public static void Delete(int personId)
        {
            _persons.RemoveAll(m => m.PersonId == personId);
        }
    }
}