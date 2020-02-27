using System;

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
    }
}
