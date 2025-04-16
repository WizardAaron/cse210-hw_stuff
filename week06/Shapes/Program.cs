using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square(5.0f, "Red"));
        shapes.Add(new Rectangle(5.0f, 3.0f, "Blue"));
        shapes.Add(new Circle(3.0f, "Green"));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea()}");
        }
    }
}