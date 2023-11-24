namespace ShapeLibrary
{
    public class Circle : Shape
    {
        private double r;
        public override double Area { get; }

        public Circle(double radius) : base("Circle")
        {
            CheckDimensions(radius);
            r = radius;
            Area = Math.PI * r * r;
        }

        private void CheckDimensions(double value)
        {
            DataValidation.CheckIsPositive(value);
            DataValidation.CheckValuesCircleForExcessWhenOp(value);
        }

        public override string GetInfo() => base.GetInfo() +
                                    $"Radius: {r}\n" +
                                    $"Area: {Area}\n";

    }
}
