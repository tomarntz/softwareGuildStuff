using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRPortal.Models.Data;

namespace HRPortal.Models.Repositories.JobRepos
{
    public class JobRepository
    {
        private static List<Job> _jobs;

        static JobRepository()
        {
            _jobs = new List<Job>
            {
                #region list of jobs
                new Job()
                {
                    JobId = 0,
                    Position = "Knight",
                    Discription = "Defend the weak and protect the innocent"
                },
                new Job()
                {
                    JobId = 1,
                    Position = "Archer",
                    Discription = "shoot arrows"
                },
                new Job()
                {
                    JobId = 2,
                    Position = "Dragon Rider",
                    Discription = "Ride Dragon"
                },
                new Job()
                {
                    JobId = 3,
                    Position = "King/Queen",
                    Discription = "Rule the Kingdom"
                },
                new Job()
                {
                    JobId = 4,
                    Position = "Azor Ahai",
                    Discription = "Use Lightbringer to defeat the darkness of the great others"
                },
                new Job()
                {
                    JobId = 5,
                    Position = "Maester",
                    Discription = "Knights of the mind"
                },
                new Job()
                {
                    JobId = 6,
                    Position = "Three Eyed Raven",
                    Discription = "Time travel using trees"
                },
                new Job()
                {
                    JobId = 7,
                    Position = "Dothraki",
                    Discription = "Horse mounted warrior"
                },
                new Job()
                {
                    JobId = 8,
                    Position = "Door Man",
                    Discription = "Open/Close doors"
                },
                new Job()
                {
                    JobId = 9,
                    Position = "High Septon",
                    Discription = "Head of the faith of the Seven"
                }
#endregion
            };
        }

        public static IEnumerable<Job> GetAllJobs()
        {
            return _jobs;
        }

        public static Job Get(int id)
        {
            return _jobs.FirstOrDefault(m => m.JobId == id);
        }

        public static void Add(string position, string discription)
        {
            Job job = new Job();
            job.Position = position;
            job.Discription = discription;
            if (_jobs.Count == 0)
            {
                job.JobId = 1;
            }
            else
            {
                job.JobId = _jobs.Max(m => m.JobId) + 1;

            }
            _jobs.Add(job);
        }

        public static void Edit(Job job)
        {
            var selectedJob = _jobs.FirstOrDefault(m => m.JobId == job.JobId);
            selectedJob.Discription = job.Discription;
            selectedJob.Position = job.Position;
        }

        public static void Delete(int jobId)
        {
            _jobs.RemoveAll(m => m.JobId == jobId);
        }
    }
}