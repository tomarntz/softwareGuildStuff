using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Data.ExhibitsRepos;
using Models;

namespace Tests
{
    [TestFixture]
    public class ExhibitInMemoryRepoTests
    {
        [Test]
        public void GetAllExhibitsTest()
        {
            var repo = ExhibitRepoFactory.CreateRepo();
            List<Exhibit> NumberOfExhibits = repo.GetAll();

            int expected = 3;

            Assert.AreEqual(expected, NumberOfExhibits.Count);
        }

        [Test]
        public void GetExhibitTest()
        {
            var repo = ExhibitRepoFactory.CreateRepo();
            Exhibit ChoosenExhibit = repo.Get(3);

            Assert.AreEqual(ChoosenExhibit.Title, "Exhibit 3");
        }

        [Test]
        public void DeleteExhibitTest()
        {
            var repo = ExhibitRepoFactory.CreateRepo();
            Exhibit ChoosenExhibit = repo.Get(2);
            repo.Delete(ChoosenExhibit.ExhibitId);

            List<Exhibit> Results = repo.GetAll();

            int expected = 2;

            Assert.AreEqual(expected, Results.Count);
        }

        [Test]
        public void PostExhibitTest()
        {
            var repo = ExhibitRepoFactory.CreateRepo();
            repo.Post(new Exhibit());
            List<Exhibit> NumberOfExhibits = repo.GetAll();

            int expected = 4;

            Assert.AreEqual(expected, NumberOfExhibits.Count);
        }

        [Test]
        public void GetMostRecentExhibitTest()
        {
            var repo = ExhibitRepoFactory.CreateRepo();
            var result = repo.GetMostRecentExhibit();

            int expected = 3;

            Assert.AreEqual(result.ExhibitId, expected);
        }
    }
}
