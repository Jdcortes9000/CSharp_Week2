using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class theShapes
    {
        public theShapes()
        {
            height = 0;
            width = 0;
        }

        public theShapes(double l, double w)
        {
            height = l;
            width = w;
        }

        double height = 5;
        double width = 5;
        public virtual double Area()
        {
            return this.height * this.width;
        }

        public string GetShapeInfo()
        {
            string result = "";

            result = $"lenght: {height} \n and width {width}";

            return result;
        }
        public override string ToString()
        {
            return $"The shape: {GetShapeInfo()}";
        }
    }
    class Rectangle:theShapes
    {
        public Rectangle(double heigth, double width) : base(heigth, width)
        {

        }
    }
    class Square: Rectangle
    {
        public Square(int length) : base(length, length)
        {

        }
    }
    class Triangle: theShapes
    {
        public Triangle(int heigth, int width) : base(heigth, width)
        {
        }

        /// <summary>
        /// override the base Shape Area() method
        /// </summary>
        /// <returns></returns>
        public override double Area()
        {
            return base.Area() / 2;
        }
    }
    class Circle : theShapes
    {
        public Circle(int heigth, int width) : base(heigth, width)
        {
        }
    }
    class ShapeZeroAreaException : Exception
    {
        public ShapeZeroAreaException(string message) : base(message)
        {
        }
    }
}
