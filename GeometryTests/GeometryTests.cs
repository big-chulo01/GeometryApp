// GeometryTests/GeometryTests.cs
using GeometryLibrary;
using FluentAssertions;

public class SquareTests
{
    [Fact]
    public void CalculateArea_WithSide5_Returns25()
    {
        // Arrange
        var square = new Square(5);
        
        // Act
        var result = square.CalculateArea();
        
        // Assert
        result.Should().Be(25);
    }

    [Fact]
    public void CalculatePerimeter_WithSide5_Returns20()
    {
        // Arrange
        var square = new Square(5);
        
        // Act
        var result = square.CalculatePerimeter();
        
        // Assert
        result.Should().Be(20);
    }
}

public class RectangleTests
{
    [Fact]
    public void CalculateArea_WithLength5AndWidth4_Returns20()
    {
        // Arrange
        var rectangle = new Rectangle(5, 4);
        
        // Act
        var result = rectangle.CalculateArea();
        
        // Assert
        result.Should().Be(20);
    }

    [Fact]
    public void CalculatePerimeter_WithLength5AndWidth4_Returns18()
    {
        // Arrange
        var rectangle = new Rectangle(5, 4);
        
        // Act
        var result = rectangle.CalculatePerimeter();
        
        // Assert
        result.Should().Be(18);
    }
}

public class TriangleTests
{
    [Fact]
    public void CalculateArea_WithSides3_4_5_Returns6()
    {
        // Arrange
        var triangle = new Triangle(3, 4, 5);
        
        // Act
        var result = triangle.CalculateArea();
        
        // Assert
        result.Should().BeApproximately(6, 0.0001);
    }

    [Fact]
    public void CalculatePerimeter_WithSides3_4_5_Returns12()
    {
        // Arrange
        var triangle = new Triangle(3, 4, 5);
        
        // Act
        var result = triangle.CalculatePerimeter();
        
        // Assert
        result.Should().Be(12);
    }
}