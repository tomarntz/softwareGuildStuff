using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamariDi.Items;

namespace SamariDi
{
    public class Samurai
    {
        private readonly IWeapon _weapon;
        private List<IIteam> _iteams;

        //property injection
        //property might be set might not...
        public IWeapon SecondaryWweapon { get; set; }

        // constructor injection
        // we are taking in a concret or specific object as input during creation
        public Samurai(IWeapon weapon)
        {
            _weapon = weapon;
            _iteams = new List<IIteam>();
        }

        public void Attack(string target)
        {
            _weapon.Hit(target);
        }

        //Method injection
        //be able to  provide dependency in method call
        public void PickUpItem(IIteam item)
        {
            _iteams.Add(item);
        }
    }
}
