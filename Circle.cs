using System;
using System.IO;

namespace Figure
{
    public class Circle : Shape
    {
        public double Radius { get; }

        public Circle(double x, double y, double radius)
        {
            Center = new Vector(x, y);
            Radius = radius;
        }

        public Circle(Vector vec, double radius)
        {
            Center = vec;
            Radius = radius;
        }

        public override double GetPerimeter()
            => 2 * Math.PI * Radius;

        public override double GetSquare()
            => Math.PI * Radius * Radius;

        public override bool Print()
        {
            if (!(Radius > 0))
                return false;

            Console.WriteLine($"Circle center is {Center.X};{Center.Y} with {Radius} radius");
            return true;
        }

        public override bool ContainsPoint(double x, double y)
        {
            return GetDistance(new Vector(x, y), Center).CompareTo(Radius) <= 0;
        }

        public static explicit operator Circle(Square square)
            => new Circle(square.Center, square.Side);

        public static Circle GetFromFile(string filePath)
        {
            var figureSettings = File.ReadAllLines(filePath)[1].Split(' ');
            return new Circle(double.Parse(figureSettings[0]), double.Parse(figureSettings[1]),
                double.Parse(figureSettings[2]));
        }
    }
}