using System;
using System.Collections.Generic;
using System.Text;

namespace FlatGebouw;

internal class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public static Point operator+(Point p1,  Point p2)
    {
        return new Point { Y = p1.Y + p2.Y, X = p2.X + p1.X };
    }

    public static bool operator==(Point p1, Point p2)
    {
        return p1.X == p2.X && p1.Y == p2.Y;
    }
    public static bool operator !=(Point p1, Point p2)
    {
        return !(p1 == p2);
    }

    public void Show()
    {
        Console.WriteLine($"({X}, {Y})");
    }
}
