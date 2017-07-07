using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            theShapes shape = new theShapes();
            Rectangle rect = new Rectangle();
            Triangle tri = new Triangle();
            Square sqr = new Square();

            Console.WriteLine(shape.GetArea());
            Console.WriteLine(rect.GetArea());
            Console.WriteLine(tri.GetArea());
            Console.WriteLine(sqr.GetArea());

            Console.ReadLine();
        }
    }
}
