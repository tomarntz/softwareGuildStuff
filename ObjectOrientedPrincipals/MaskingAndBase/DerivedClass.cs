using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaskingAndBase
{
   public class DerivedClass : BaseClass
    {
        //masking the base field
       public string Field1 = "Derived Class Field1";

       public void PrintField1()
       {
           //write derived field
           Console.WriteLine(Field1);

            //write base field
            Console.WriteLine(base.Field1);
       }
    }
}
