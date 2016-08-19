using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    interface IDog
    {
        string Name { get; }

        void bark();
        string GoForWalk();

    }
}
