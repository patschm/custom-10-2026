namespace DeRest;

internal class Program
{
    static void Main(string[] args)
    {
        //short a = 10;
        //short b = 20;

        Point<int> a = new Point<int> { X = 10, Y = 20 };
        Point<int> b = new Point<int> { X = 100, Y = 200 };
        Console.WriteLine($"A={a}, B={b}");
        Swap(ref a, ref b);
        Console.WriteLine($"A={a}, B={b}");

        Console.WriteLine(a);
        DoeIets(ref a);
        Console.WriteLine(a);

        string c = "Hi";
        DoeIets(c);
        Console.WriteLine(c);

        Punt r1 = new Punt(10, 20);
        DoeIets(r1);
        Console.WriteLine(r1);
    }

    private static void DoeIets<T>(T a) where T : class
    {
        //a.X = 1000;
        //a.Y = 2000;
    }
    private static void DoeIets(ref Point<int> a)
    {
        a.X = 1000;
        a.Y = 2000;
    }
    private static void DoeIets(string a)
    {
        a = "hooooooooooooooooooooooooi";
    }

    private static void Swap(ref int aa, ref int bb)
    {
        int tmp = aa;
        aa = bb;
        bb = tmp;
    }
    private static void Swap(ref long aa, ref long bb)
    {
        long tmp = aa;
        aa = bb;
        bb = tmp;
    }
    private static void Swap(ref float aa, ref float bb)
    {
        float tmp = aa;
        aa = bb;
        bb = tmp;
    }

    private static void Swap<P>(ref P aa, ref P bb) //where P: IFormattable, new()
    {
        P tmp = aa;
        aa = bb;
        bb = tmp;
    }
}
