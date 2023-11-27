namespace ShapeLibrary
{
    public class Circle : Shape
    {
        private double r;

        public Circle(double radius) : base("Circle")
        {
            CheckDimensions(radius);
            r = radius;
            Area = Math.PI * r * r;
        }

        private void CheckDimensions(double value)
        {
            DataValidation.CheckIsPositive(value);
            CheckValuesCircleForExcessWhenOp(value);
        }

        private void CheckValuesCircleForExcessWhenOp(double value)
        {
            if (value > DataValidation.UpperLimitValForDeg2)
                throw new ArgumentException(string.Format("{0} {1} {2} {3}", 
                                            DataValidation.exDescList["leadin"], 
                                            value, 
                                            DataValidation.exDescList["_ExcessValueForCircle"], 
                                            DataValidation.UpperLimitValForDeg2));
        }

        public override string GetInfo() => base.GetInfo() +
                                    $"Radius: {r}\n" +
                                    $"Area: {Area}\n";

    }
}
