namespace TheFirm;

internal class Program
{
    static void Main(string[] args)
    {
        IDierenTuinContract bok2 = new Bokito();
        bok2.Werk();

        WillemJan wj = new();
        Alard al = new();
        Patrick pat = new();
        Bokito bok = new();
        ACME comp = new();

        comp.Hire(pat);
        comp.Hire(wj);
        comp.Hire(al);
        comp.Hire(bok);
        comp.Start();
    }
}
