using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGinventory.iteams.Container
{
    public abstract class SpecificContainer:Container
    {
        protected IteamType RequiredType;

        public SpecificContainer(int capacity, IteamType reqiredType)
            : base(capacity)
        {
            RequiredType = reqiredType;
        }

        public override bool AddItem(Iteam iteamToAdd)
        {
            if (iteamToAdd.Type != RequiredType)
            {
                return false;
            }
            return base.AddItem(iteamToAdd);
        }
    }
}
