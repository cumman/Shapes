using System;
using System.IO;
using System.Linq;
using System.Net;

namespace Figure
{
    public class Square : Shape
    {
        public double Side { get; }
        public double Angle { get; private set; }

        public Square(double x, double y, double side, double angle)
        {
            Center = new Vector(x, y);
            Side = side;
            Angle = angle;
        }
        public Square(Vector vec, double side, double angle)
        {
            Center = vec;
            Side = side;
            Angle = angle;
        }

        public override double GetPerimeter()
            => 4 * Side;
        public override double GetSquare()
            => Side * Side;
        public override bool Print()
        {
            if (Side <= 0)
                return false;

            Console.WriteLine($"Square with center: {Center.X};{Center.Y} with {Side} side, rotated on {Angle} radians");
            return true;
        }

        public void Rotate(double angle)
        {
            Angle += angle;
            Angle -= (int)(Angle / Math.PI) * Math.PI;
        }

        public static explicit operator Square(Circle circle)
            => new Square(circle.Center, circle.Radius * 2, 0);

        public static Square GetFromFile(string filePath)
        {
            var figureSettings = File.ReadAllLines(filePath)[1].Split(' ');
            return new Square(double.Parse(figureSettings[0]), double.Parse(figureSettings[1]),
                double.Parse(figureSettings[2]), double.Parse(figureSettings[3]));
        }

        public bool TryInsertCircle(Circle circle)
        {
            return Side.CompareTo(2 * circle.Radius) >= 0;
        }
    }
}
