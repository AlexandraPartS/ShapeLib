using ShapeLibrary;
using System.Runtime.InteropServices;

try
{
    //Circle block

    Circle c1 = new Circle(1);
    Console.WriteLine(c1.Area);
    /* Output: 
     3,141592653589793
     */

    Circle cn = new Circle(1) { Name = "Default circle" };
    Console.WriteLine(cn.GetInfo());
    /* Output:
    Shape: Default circle
    Radius: 1
    Area: 3,141592653589793
    */

    Circle c2 = new Circle(-1);
    /* Output:
    Error: ArgumentException.Message:  -1 incorrect value. The value must be positive.
    */

    Circle c3 = new Circle(Double.MaxValue);
    /* Output:
    Error: ArgumentException. Message:  1,7976931348623157E+308 value exceed limit values. Limit is:  7,564545572282618E+153
     */


    //Triangle block

    Triangle tr1 = new Triangle(2, 3, 4);
    Console.WriteLine(tr1.GetInfo());
    /* Output:
    Shape: Triangle
    Style: Default
    Sides: 2, 3, 4
    Area: 2,9047375096555625
    */

    Triangle tr21 = new Triangle(3, 4, 5);
    Triangle tr22 = new Triangle(3, 4, 6);
    Console.WriteLine(tr21.IsRight());
    Console.WriteLine(tr22.IsRight());
    /* Output:
    True
    False
    */

    Triangle tr3 = new Triangle(2, 3);
    Console.WriteLine(tr3.GetInfo());
    /* Output:
    Shape: Triangle
    Style: Isosceles
    Sides: 2, 2, 3
    Area: 1,984313483298443
    */

    Triangle tr4 = new Triangle(1);
    Console.WriteLine(tr4.GetInfo());
    /* Output:
    Shape: Triangle
    Style: Equilateral
    Sides: 1, 1, 1
    Area: 0,4330127018922193
    */

    Triangle tr5 = new Triangle(1) { Name = "Default triangle", Type = Triangle.TriangleType.Equilateral };
    Console.WriteLine(tr5.GetInfo());
    /* Output:
    Shape: Default triangle
    Style: Equilateral
    Sides: 1, 1, 1
    Area: 0,4330127018922193
    */

    Triangle tr1ex = new Triangle(3, 4, -5);
    /* Output:
    Error: ArgumentException.Message:  -5 incorrect value. The value must be positive.
    */

    Triangle tr2ex = new Triangle(Double.MaxValue);
    /* Output:
    Error: ArgumentException. Message:  one or more sides of Triangle are too large to calculate.
    */

    Triangle tr3ex = new Triangle(1.7976931348623157E+100, 4, 3);
    /* Output:
    Error: ArgumentException. Message:  3 + 4 <= 1,7976931348623157E+100 value is more or equal than sum of the other two sides
    */


    //Inheritance

    ColorCircle cc1 = new ColorCircle(1, 120); //ColorCircle : Circle
    Console.WriteLine(cc1.GetInfo());
    /* Output:
    Shape: Color circle
    Radius: 1
    Area: 3,141592653589793
    color: 120
    */

    var ctr = new ColorTriangle(120, 1);  //ColorTriangle : Triangle
    Console.WriteLine(ctr.GetInfo());
    /* Output:
    Shape: ColorEquilateralTriangle
    Style: Equilateral
    Sides: 1, 1, 1
    Area: 0,4330127018922193
    Color: 120
    */
    
    Square sq1 = new Square(1); //Square : Shape
    Console.WriteLine(sq1.GetInfo());
    /*
    Shape: Square
    Side: 1
    Area: 1
     */
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
}


//checking for library extensibility
//1
class ColorCircle : Circle
{
    public int col;

    public ColorCircle(double r, int color) : base(r) 
    {
        Name = "Color circle";
        col = color;
    }

    public override string GetInfo() =>
        base.GetInfo() + $"color: {col}\n";
}
//2
class ColorTriangle : Triangle
{
    public int col;

    public ColorTriangle(int color, double side1, [Optional] double side2, [Optional] double side3) : base(side1, side2, side3)
    {
        Name = "Color Triangle";
        col = color;
    }
    public override string GetInfo() => base.GetInfo() +
                                        $"Color: {col}\n";
}
//3
class Square : Shape
{
    private double a;

    public Square(double value) : base("Square")
    {
        //validate
        DataValidation.CheckIsPositive(value);
        DataValidation.CheckValuesForExcessOfDeg2(value, value);
        a = value;
        Area = value * value;
    }

    public override string GetInfo() =>
        base.GetInfo() + $"Side: {a}\n" +
                         $"Area: {Area}\n";
}
