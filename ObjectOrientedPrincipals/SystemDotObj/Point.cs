using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemDotObj
{
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }

        //only constructor for this object
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //anytime we get the object to print will use this method
        public override string ToString()
        {
            return $"Point as ({x},{y})";
        }

        //allows us to determine the comparason
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            Point otherPoint = (Point) obj;

            return (this.x == otherPoint.x && this.y == otherPoint.y);
        }

        // We are going to create a member wise copy 
        //create a new object and copy only the values
        public Point copy()
        {
            return (Point) this.MemberwiseClone();
        }
    }
}
