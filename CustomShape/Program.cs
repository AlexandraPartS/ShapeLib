namespace CustomShape;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

private static double PseudoscolarMult(Point k, Point a, Point b)
{        
        return ((a.X - k.X) * (b.Y - k.Y) - (b.X - k.X) * (a.Y - k.Y));
}
 
private static void SwapPoints(ref Point a, ref Point b)
{
    Point tmp = a;
    a = b;
    b = tmp;
}
     
public static List<Point> JarvisHull(Point[] points)
{
    var Shell = new List<Point>();

    //Ищем отправную точку
    Int32 asStart = 0;
    for (int i = 1; i < points.Length; i++)
    {
        if (Math.Abs(points[i].Y - points[asStart].Y) < 0.000001)
            if (points[i].X < points[asStart].X)
                asStart = i;
            else ;
        else if (points[i].Y < points[asStart].Y)
            asStart = i;

    }
    var startpoint = new Point(points[asStart].X, points[asStart].Y);

    Shell.Add(points[asStart]);

    Point current = points[asStart];
    SwapPoints(ref points[points.Length - 1], ref points[asStart]);
    Int32 k = 0;

    //Алгоритм выборки точек
    do
    {

        for (int i = k; i < points.Length; i++)
            if (PseudoscolarMult(current, points[i], points[k]) < 0)
                SwapPoints(ref points[k], ref points[i]);
        current = points[k];
        Shell.Add(points[k]);
        k++;
    }
    while (!IsEqualPoints(current, startpoint));
    Shell.Add(startpoint);
    return Shell;
}

public static List<Point> CreateConvexHull(List<Point> source)
{
    //1. create a stack of points
    Stack<Point> result = new Stack<Point>();
    //2. sort the incoming points
    SortByPolarAngle(source);
    //3. init stack with 2 first points
    result.Push(source[0]);
    result.Push(source[1]);
    
    //4. perform test for every other point
    for (int i = 2; i < source.Count; i++)
    {
        //5. the angle between NEXT_TO_TOP[S], TOP[S], and p(i) makes a nonleft turn -> remove if not a vertex
        while (ConterClockWise(result.ElementAt(1), result.Peek(), source[i]) > 0)
        {
            result.Pop();

        }
        result.Push(source[i]);
    }
    return new List<Point>(result);
}