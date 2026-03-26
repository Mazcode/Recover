using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverloading
{
    internal class ShapeArea
    {
        public static double CalculateAreaCircle(double radius) => Math.PI * radius * radius;

        public static double CalculateArea(double width, double height) => width * height;

        public static double CalculateArea(double side) => CalculateArea(side, side);
    }
}
