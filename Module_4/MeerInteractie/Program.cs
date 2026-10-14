namespace MeerInteractie;

internal class Program
{
    static void Main(string[] args)
    {
        var p = new Patrick();
        var w = new WillemJan();

        // p.HaalDranken();
        w.Execute(p.HaalDranken);
        w.Execute(Ontplof);

        // TypeNaam VariabeleNaam = Initialisatie
        BarHaal bh = p.HaalDranken;
        bh();
    }

    static void Ontplof()
    {
        Console.WriteLine("Kaboooom!");
    }
}
