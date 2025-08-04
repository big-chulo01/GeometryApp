// GeometryLibrary/Rectangle.cs
namespace GeometryLibrary;

public class Rectangle : IShape
{
    private double Length { get; }
    private double Width { get; }

    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public double CalculateArea() => Length * Width;

    public double CalculatePerimeter() => 2 * (Length + Width);
}