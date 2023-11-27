using System.Runtime.InteropServices;

namespace ShapeLibrary
{
    public class Triangle : Shape
    {
        private double a, b, c;
        public TriangleType Type { get; init; }

        private double[] sortSides;

        public enum TriangleType
        {
            Default,
            Isosceles,
            Equilateral,
            Right
        }

        public Triangle(double side1, [Optional] double side2, [Optional] double side3) : base("Triangle")
        {
            if(side2 == default && side3 == default)
            {
                CheckDimensions(side1);
                a = b = c = side1;
                Type = TriangleType.Equilateral;
            }
            else if(side3 == default)
            {
                CheckDimensions(side1, side2);
                a = b = side1;
                c = side2;
                Type = TriangleType.Isosceles;
            }
            else
            {
                CheckDimensions(side1, side2, side3);
                a = side1;
                b = side2;
                c = side3;
                Type = TriangleType.Default;
            }

            Area = CalcArea(a, b, c);

        }

        private void CheckDimensions(params double[] values)
        {
            DataValidation.CheckIsPositive(values);
            CheckValuesTriangleForExcessWhenOp(values);
            if(values.Length != 1)
            {
                CheckSumOfTriangleSides(values);
            }
        }

        private double CalcArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public bool IsRight()
        {
            //Heron's formula
            return sortSides[2] == Math.Sqrt(sortSides[0] * sortSides[0] + sortSides[1] * sortSides[1]); 
        }

        public void CheckSumOfTriangleSides(params double[] values)
        {
            if(values.Length == 2) 
                SortSides(values[0], values[0], values[1]);
            else 
                SortSides(values[0], values[1], values[2]);
            if (sortSides[0] + sortSides[1] <= sortSides[2])
            {
                string mathexpression = $"{sortSides[0]} + {sortSides[1]} <= {sortSides[2]}";
                throw new ArgumentException(string.Format("{0} {1} {2}",
                                            DataValidation.exDescList["leadin"], 
                                            mathexpression, 
                                            DataValidation.exDescList["_CorrectTriangleSidesSum"]));
            }
        }

        private void SortSides(double value1, double value2, double value3)
        {
            sortSides = new double[3]{ value1, value2, value3 };
            Array.Sort(sortSides);
        }

        private void CheckValuesTriangleForExcessWhenOp(params double[] values)
        {
            double p = 0;
            if (values.Length == 1) { p = values[0] * 3 / 2; }
            if (values.Length == 2) { p = (values[0] + values[0] + values[1]) / 2; }
            if (values.Length == 3) { p = (values[0] + values[1] + values[2]) / 2; }
            if (double.IsPositiveInfinity(p))
            {
                throw new ArgumentException(string.Format("{0} {1}", 
                                            DataValidation.exDescList["leadin"], 
                                            DataValidation.exDescList["_ExcessValueForTriangle"]));
            }
            else
            {
                for (int i = 1; i < 4; i++)
                {
                    if (double.IsPositiveInfinity(Math.Pow(p, i)))
                        throw new ArgumentException(string.Format("{0} {1}", 
                                                    DataValidation.exDescList["leadin"], 
                                                    DataValidation.exDescList["_ExcessValueForTriangle"]));
                }
            }
        }

        public override string GetInfo() => base.GetInfo() +
                                    $"Style: {Type}\n" +
                                    $"Sides: {a}, {b}, {c}\n" +
                                    $"Area: {Area}\n";

    }
}
