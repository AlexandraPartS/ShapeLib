﻿namespace ShapeLibrary
{
    public class DataValidation
    {
        public const double UpperLimitValForDeg2 = 7.564545572282618E+153;//Math.Sqrt((Double.MaxValue)/Math.PI)

        public static Dictionary<string, string> exDescList = new Dictionary<string, string>()
        {
            { "leadin", "Error: ArgumentException. Message: " },
            { "_IsPositive", "incorrect value. The value must be positive." },
            { "_ExcessValueForCircle", "value exceed limit values. Limit is: " },
            { "_ExcessValueForTriangle", "one or more sides of Triangle are too large to calculate." },
            { "_ExcessValueOfDeg2", "one or more sides of shape are too large to calculate." },
            { "_CorrectTriangleSidesSum", "value is more or equal than sum of the other two sides" }
        };

        public static void CheckIsPositive(params double[] values)
        {
            foreach(var value in values)
            {
                if(value <= 0)
                {
                    throw new ArgumentException(string.Format("{0} {1} {2}", exDescList["leadin"], value, exDescList["_IsPositive"]));
                }
            }
        }

        public static  void CheckValuesCircleForExcessWhenOp(double value)
        {
            if (value > UpperLimitValForDeg2)
                throw new ArgumentException(string.Format("{0} {1} {2} {3}", exDescList["leadin"], value, exDescList["_ExcessValueForCircle"], UpperLimitValForDeg2));
        }
        public static  void CheckValuesTriangleForExcessWhenOp(params double[] values)
        {
            double p = 0;
            if (values.Length == 1) { p = values[0] * 3 / 2; }
            if (values.Length == 2) { p = (values[0] + values[0] + values[1]) / 2; }
            if (values.Length == 3) { p = (values[0] + values[1] + values[2]) / 2; }
            if (double.IsPositiveInfinity(p))
            {
                throw new ArgumentException(string.Format("{0} {1}", exDescList["leadin"], exDescList["_ExcessValueForTriangle"]));
            }
            else
            {
                for (int i = 1; i < 4; i++)
                {
                    if (double.IsPositiveInfinity(Math.Pow(p, i)))
                        throw new ArgumentException(string.Format("{0} {1}", exDescList["leadin"], exDescList["_ExcessValueForTriangle"]));
                }
            }
        }

        public static void CheckValuesForExcessOfDeg2(double value1, double value2)
        {
            if (double.IsPositiveInfinity(value1 * value2))
                throw new ArgumentException(string.Format("{0} {1}", exDescList["leadin"], exDescList["_ExcessValueOfDeg2"]));
        }

        //public static void CheckValuesForExcessOfDeg3(double value1, double value2, double value3){}
        //public static void CheckValuesForExcessOfDeg4(double value1, double value2, double value3, double value4){}

    }
}