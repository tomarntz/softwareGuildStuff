using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGinventory.iteams.Container
{
    public abstract class Container: Iteam
    {
        protected int Capacity;
        protected Iteam[] Iteams;
        protected int[] IteamIndex;

        public Container(int Capacity)
        {
            Capacity = Capacity;
            Iteams = new Iteam[Capacity];

            Type = IteamType.Container;
        }

        public virtual bool AddItem(Iteam iteamToAdd)
        {
            if (IteamIndex == Capacity)
            {
                return false;
            }

            if (iteams.Contains(iteamToAdd))
            {
                return false;
            }

            iteams[IteamIndex] = iteamToAdd;
            IteamIndex++:
            return true;
        }

        public Iteam RemoveItem()
        {
            if (IteamIndex == 0)
            {
                return null;
            }

            IteamIndex--;
            Iteam i = Iteams[IteamIndex];
            iteams[IteamIndex] = null;
            return iteams;
        }
    }
}
