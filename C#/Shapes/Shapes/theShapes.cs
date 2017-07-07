using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class theShapes
    {
        double lenght = 5;
        double width = 5;

        public double GetArea()
        {
            return this.lenght * this.width;
        }

    }
    class Rectangle:theShapes
    {

    }
    class Square: Rectangle
    {
                       
    }
    class Triangle: theShapes
    {
        
        public double GetArea()
        {
            return base.GetArea() / 2;
        }
    }
}
