using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInheritance
{
   public class Car
    {
        public int MaxSpeed { get; set; }
        public int MinSpeed { get; set; }


        //Public Property withprivate field
       private int _currentSpeed;

       public int speed
       {
            get { return _currentSpeed; }
           set
           {
               _currentSpeed = value;
               if (_currentSpeed > MaxSpeed)
               {
                   _currentSpeed = MaxSpeed;
               }
           }
       }

        //default constructor
       public Car()
       {
           MaxSpeed = 100;
           MinSpeed = 0;
       }

        // more constructor
       public Car(int max)
       {
           MaxSpeed = max;
           MaxSpeed = 0;
       }

        //another constructor
       public Car(int max,int min)
       {
           MaxSpeed = max;
           MinSpeed = min;
       }
    }
}
