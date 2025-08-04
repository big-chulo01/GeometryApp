// GeometryLibrary/Square.cs
namespace GeometryLibrary;

public class Square : IShape
{
    private double Side { get; }

    public Square(double side)
    {
        Side = side;
    }

    public double CalculateArea() => Side * Side;

    public double CalculatePerimeter() => 4 * Side;
}