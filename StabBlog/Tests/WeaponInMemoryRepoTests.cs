using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Data.WeaponsRepo;
using Models;

namespace Tests
{
    [TestFixture]
    public class WeaponInMemoryRepoTests
    {
        [Test]
        public void GetAllWeaponsTest()
        {
            var repo = WeaponFactoryRepo.CreateRepo();
            List<Weapon> NumberOfWeapons = repo.GetAll();

            Assert.AreEqual(NumberOfWeapons.Count, 2);
        }

        [Test]
        public void GetWeaponTest()
        {
            var repo = WeaponFactoryRepo.CreateRepo();
            Weapon ChoosenWeapon = repo.Get(2);

            Assert.AreEqual(ChoosenWeapon.Title, "Axe");
        }

        [Test]
        public void DeleteWeaponTest()
        {
            var repo = WeaponFactoryRepo.CreateRepo();
            Weapon ChoosenWeapon = repo.Get(1);
            repo.Delete(ChoosenWeapon.WeaponId);
            List<Weapon> Results = repo.GetAll();

            int expected = 1;

            Assert.AreEqual(Results.Count, expected );
        }

        [Test]
        public void PostWeaponTest()
        {
            var repo = WeaponFactoryRepo.CreateRepo();
            repo.Post(new Weapon());
            List<Weapon> NumberOfWeapons = repo.GetAll();

            int expected = 3;

            Assert.AreEqual(expected, NumberOfWeapons.Count);
        }

        [Test]
        public void GetMostRecentWeaponTest()
        {
            var repo = WeaponFactoryRepo.CreateRepo();
            var result = repo.GetMostRecentWeapon();

            int expected = 2;

            Assert.AreEqual(result.WeaponId, expected);
        }
    }
}
