namespace FlatGebouw;

internal class Program
{
    static void Main(string[] args)
    {
        Point p1 = new Point { X = 10, Y = 20 };
        p1.Show();

        Point p2 = new Point { X = 10, Y = 20 };
        p2.Show();

        int x = 10;
       // FlatGebouw.MyExtnsions.SponsoredBy

        string s = x.SponsoredBy("Patrick");
        Console.WriteLine(s);
        //Point p3 = Point.Add(p1, p2);
        Point p3 = p1 +p2;
        p3.Show();

        bool isGelijk = p1 == p2;
        Console.WriteLine(isGelijk);

        Etage[] flat = CreateFlat(45);

        flat[30].RoepLift();

        foreach(Etage et in flat)
        {
           // et.DisplayLiftStatus();
        }
    }

    public static Etage[] CreateFlat(int nrFloor)
    {
        Etage[] flat = new Etage[nrFloor];
        for (int i = 0; i < flat.Length; i++)
        {
            flat[i] = new Etage { EtageNummer = i };
        }
        return flat;
    }
}
