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
            

            List<theShapes> shapes = new List<theShapes>();
            shapes.Add(new Square(5));
            shapes.Add(new Square(1));
            shapes.Add(new Triangle(2, 5));
            shapes.Add(new Triangle(1, 1));
            shapes.Add(new Rectangle(4, 6));
            shapes.Add(new Rectangle(3, 9));
            shapes.Add(new theShapes(6, 7));

            Dictionary<string, theShapes> dict = new Dictionary<string, theShapes>();
            foreach (var item in dict.Keys)
            {
                Console.WriteLine(item + ", ");
            }
            Console.WriteLine("\n\nprint shapes with area equal or greater than 4: ");
            var res = shapes.Where(o => o.Area() >= 4).ToList();
            var rectlist = shapes.Where(r => r is Rectangle).ToList();

            foreach (var item in rectlist)
            {
                Console.WriteLine(item.GetType());
                Console.WriteLine(item.ToString());
            }

            var triList = (from t in shapes where t is Triangle select t).ToList();
            foreach (var item in res)
            {
                Console.WriteLine(item.GetType());
                Console.WriteLine(item.Area());
                Console.WriteLine(item.ToString());
            }
            var res2 = shapes.Where(o => o.Area() < 4).ToList();
            Console.WriteLine($"\n shapes w/ area < 4, count is {res2.Count}");
            Console.ReadLine();
        }
    }
}
