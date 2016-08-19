using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGinventory.iteams
{
    public abstract class Iteam
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public int Weight { get; set; }
        public ItemType Type { get; set; }
    }
}
