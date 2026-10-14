using System;
using System.Collections.Generic;
using System.Text;

namespace DeRest;

record Punt(int X, int Y)
{
    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}

internal struct Point<T>
{
    public T X { get; set; }
    public T Y { get; set; }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
   
}
