using System;
using System.Collections.Generic;
using System.Text;

namespace FlatGebouw;

internal static class MyExtnsions
{
    public static string SponsoredBy(this int x, string merk)
    {
       return $"{x} is sponsered by {merk}";
    }
}
