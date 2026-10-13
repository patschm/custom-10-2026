using System;
using System.Collections.Generic;
using System.Text;

namespace DeLampen;

// TL erft van Lamp. 
// Je mag maar van 1 class erfen.
// Bevordert hergebruik (DRY)
// Belangrijke: Geeft mij de mogelijkheid om te generaliseren.
// Nog belangrijker: Overerving is om families van classen te structureren.
// Is-a-relation: Stel jezelf de vraag "is het een"
internal sealed class TL : Lamp
{
    public int KnipperAantal { get; set; } = 5;
   
    // Met override aciveer ik het polymorf.
    public sealed  override void On()
    {
        for(int i = 0; i < KnipperAantal; i++)
        {
            Console.BackgroundColor = Color;
            Console.WriteLine("Knipper");
            Console.ResetColor();
            Task.Delay(100).Wait();
        }
        Console.BackgroundColor = Color;
        Console.WriteLine($"De TL ({Name}) is nu aan en brandt met {Intensity}lm");
    }
    public override void Off()
    {
        Console.WriteLine("De TL gaat uit");
        Console.ResetColor();

    }

    public TL(string name, uint intensity = 200, ConsoleColor color = ConsoleColor.DarkBlue)
        : base(name, intensity, color)
    {

    }

    public TL(string name) : this(name, 200, ConsoleColor.Yellow)
    {

    }
    public TL()
    {
        
    }
}
