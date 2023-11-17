using System;
using System.Collections.Generic;

abstract class Shape
{
    public string Color { get; set; }

    public abstract double GetArea();
}

public class Square : Shape
{
    private double Side { get; set; }

    public Square(string color, double side)
    {
        Color = color;
        Side = side;
    }

    public override double GetArea()
    {
        return Side * Side;
    }
}

class Rectangle : Shape
{
    private double Length { get; set; }
    private double Width { get; set; }

    public Rectangle(string color, double length, double width)
    {
        Color = color;
        Length = length;
        Width = width;
    }

    public override double GetArea()
    {
        return Length * Width;
    }
}

class Circle : Shape
{
    private double Radius { get; set; }

    public Circle(string color, double radius)
    {
        Color = color;
        Radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}

class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>
        {
            new Square("Red", 3),
            new Rectangle("Blue", 4, 5),
            new Circle("Green", 6)
        };

        foreach (Shape shape in shapes)
        {
            string color = shape.Color;
            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}

