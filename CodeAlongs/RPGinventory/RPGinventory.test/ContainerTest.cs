using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RPGinventory.iteams.Container;
using RPGinventory.iteams.Potions;
using RPGinventory.iteams.Weapons;

namespace RPGinventory.test
{
    [TestFixture]

    class ContainerTest
    {
        //[Test]
        //public void CanAddItemToBackpack()
        //{
        //    var backpack = new Backpack();
        //    var hp = new HealingPotion();

        //    bool isAdded = backpack.AddItem(hp);
        //    Assert.IsTrue(isAdded);
        //}

        [Test]
        public void CanNoTAddItemToFullBackpack()
        {
            var backpack  = new Backpack();

            backpack.AddItem(new GreatAxe());
            backpack.AddItem(new GreatAxe());
            backpack.AddItem(new GreatAxe());
            backpack.AddItem(new GreatAxe());

            var isAdded = backpack.AddItem(new GreatAxe());
            Assert.IsFalse(isAdded);

        }

        [Test]
        public void CanRemoveItemFromBackpack()
        {
            var backpack = new Backpack();;
            var axe = new GreatAxe();

            backpack.AddItem(axe);

            var item = backpack.RemoveItem();

            Assert.AreEqual(axe,item);

            Assert.IsNull(backpack.RemoveItem());
        }

        [Test]
        public void CanNotAddDuplicatItemToBackpack()
        {
            var backpack = new Backpack();
            var axe = new GreatAxe();

            backpack.AddItem(axe);

            var isAdded = backpack.AddItem(axe);

            Assert.False(isAdded);
        }

        [Test]
        public void PotionBagOnlyAllowsPotions()
        {
            var bag = new PotionSatchel();

            Assert.IsTrue(bag.AddItem(new HealingPotion()));
            Assert.IsFalse(bag.AddItem(new GreatAxe()));
        }
    }
}
