using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemDotObj
{
    class Program
    {
        static void Main(string[] args)
        {
            //creat a point and write it out
            Point p1 = new Point(7,17);
            Console.WriteLine(p1);

            //create a new point and compare
            Point p2 = new Point(7,17);
            Console.WriteLine(object.Equals(p1,p2));
            Console.WriteLine(object.ReferenceEquals(p1,p2));

            //use our copy method and create a new point and compare
            Point p3 = p1.copy();
            Console.WriteLine(object.Equals(p1, p3));
            Console.WriteLine(object.ReferenceEquals(p1, p3));


            Console.ReadLine();
        }
    }
}
