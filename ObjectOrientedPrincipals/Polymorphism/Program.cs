using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape shape = new Shape();
            Console.WriteLine(shape.Draw());

            Circle circle =  new Circle();
            circle.radius = (decimal) 17.11;
            Console.WriteLine(circle.Draw());

            Shape[] shapes = new Shape[2];
            shapes[0] = shape;
            shapes[1] = circle;

            Console.WriteLine();
            foreach (Shape s in shapes)
            {
                Console.WriteLine(s.Draw());

                if (s is Circle)
                {
                    Console.WriteLine($"\t{((Circle)s).radius}");
                }
            }

            Console.ReadLine();
        }
    }
}
