namespace Figure
{
    public struct Vector
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    public abstract class Shape
    {
        /// <summary>Gets or sets the figure center.</summary>
        /// <value>  Coordinates of the figure center.</value>
        public Vector Center { get; set; }

        public abstract double GetPerimeter();
        public abstract double GetSquare();
        public abstract bool Print();
        public virtual void Move(Vector vector)
        {
            Center = new Vector(Center.X + vector.X, Center.Y + vector.Y);
        }
    }
}
