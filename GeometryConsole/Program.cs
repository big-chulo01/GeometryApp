using GeometryLibrary;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

var featureManagement = new Dictionary<string, string?>
{
    { "FeatureManagement:Square", "true" },
    { "FeatureManagement:Rectangle", "true" },
    { "FeatureManagement:Triangle", "true" }
};

IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddInMemoryCollection(featureManagement)
    .Build();

var services = new ServiceCollection();
services.AddFeatureManagement(configuration);
var serviceProvider = services.BuildServiceProvider();

var featureManager = serviceProvider.GetRequiredService<IFeatureManager>();

Console.WriteLine("Welcome to Geometry Calculator!");
Console.WriteLine("Available shapes:");

if (await featureManager.IsEnabledAsync("Square"))
{
    Console.WriteLine("1. Square");
}

if (await featureManager.IsEnabledAsync("Rectangle"))
{
    Console.WriteLine("2. Rectangle");
}

if (await featureManager.IsEnabledAsync("Triangle"))
{
    Console.WriteLine("3. Triangle");
}

Console.Write("Enter your choice (1-3): ");
var choice = Console.ReadLine();

if (string.IsNullOrEmpty(choice))
{
    Console.WriteLine("No input received.");
    return;
}

IShape? shape = null;

switch (choice)
{
    case "1" when await featureManager.IsEnabledAsync("Square"):
        Console.Write("Enter side length: ");
        var sideInput = Console.ReadLine();
        if (!double.TryParse(sideInput, out var side) || side <= 0)
        {
            Console.WriteLine("Invalid input for side length.");
            return;
        }
        shape = new Square(side);
        break;
    
    case "2" when await featureManager.IsEnabledAsync("Rectangle"):
        Console.Write("Enter length: ");
        var lengthInput = Console.ReadLine();
        Console.Write("Enter width: ");
        var widthInput = Console.ReadLine();
        if (!double.TryParse(lengthInput, out var length) || length <= 0 ||
            !double.TryParse(widthInput, out var width) || width <= 0)
        {
            Console.WriteLine("Invalid input for length or width.");
            return;
        }
        shape = new Rectangle(length, width);
        break;
    
    case "3" when await featureManager.IsEnabledAsync("Triangle"):
        Console.Write("Enter side A: ");
        var sideAInput = Console.ReadLine();
        Console.Write("Enter side B: ");
        var sideBInput = Console.ReadLine();
        Console.Write("Enter side C: ");
        var sideCInput = Console.ReadLine();
        if (!double.TryParse(sideAInput, out var sideA) || sideA <= 0 ||
            !double.TryParse(sideBInput, out var sideB) || sideB <= 0 ||
            !double.TryParse(sideCInput, out var sideC) || sideC <= 0)
        {
            Console.WriteLine("Invalid input for triangle sides.");
            return;
        }
        shape = new Triangle(sideA, sideB, sideC);
        break;
    
    default:
        Console.WriteLine("Invalid choice or feature not enabled.");
        return;
}

if (shape == null)
{
    Console.WriteLine("Shape not created.");
    return;
}

Console.WriteLine($"Area: {shape.CalculateArea()}");
Console.WriteLine($"Perimeter: {shape.CalculatePerimeter()}");