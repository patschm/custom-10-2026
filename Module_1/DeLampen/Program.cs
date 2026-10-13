namespace DeLampen;

internal class Program
{
    static void Main(string[] args)
    {
        // Oerknal
        // Hier begint mijn virtuele wereld
        // l1 is het object (instantie van Lamp)
        //Lamp l1 = new Lamp("aanrechtlampje", 200, ConsoleColor.Yellow);
        Lamp l1 = new TL("Kacklampje", intensity: 4_000_000_000);
        l1.Name = "Aanrechtlampje";
        //l1.color = ConsoleColor.DarkRed;
        //l1.intensity = 200;

        l1.On();
        Console.WriteLine("We kunnen nu afwassen");
        l1.Off();
        Console.WriteLine("Wat is het donker hier");

        Lamp l2 = new StaLamp { 
            Color = ConsoleColor.Red, 
            Intensity = 300, 
            Name = "Rosse buurt lamp" };

        //l2.SetIntensity(1000);
        l2.Intensity = 1000;
        l2.On(); 

        l2.Off();

        Lamp l3 = new StaLamp
        {
            Color = ConsoleColor.Green,
            Name = "Lichttherapy"
        };

        //l3.intensity = 4_000_000_000;
        //l3.SetIntensity(4_000_000_000);
        l3.Intensity = 4_000_000_000;
        l3.On();

        l3.Off();


        // Hier generaliseer ik de TL naar een Lamp
        Lamp l4 = new TL { Color = ConsoleColor.Red, KnipperAantal = 4 };

        // Dit moet je niet willen
        //(l4 as TL).KnipperAantal

        l4.On();
        Console.WriteLine("We lezen nu onder TL verlichting");
        l4.Off();

    }

    static void ZetAan(Lamp lamp)
    {
        lamp.On();
    }
    //static void ZetAan(StaLamp lamp)
    //{
    //    lamp.On();
    //}
}
