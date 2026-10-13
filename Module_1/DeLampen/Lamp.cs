namespace DeLampen;


// Class is een _blauwdruk_ van een object (custom type)
// Abstract voorkomt dat je new Lamp() kunt doen.
internal abstract class Lamp
{
    // Fields. Hierin slaan we de eigenschappen van een object op.
    //private string name = "Lamp";
    private uint intensity = 200;
    //private ConsoleColor color = ConsoleColor.Yellow;

    // Encapsulation. Gecontroleerde toegang to jouw fields (die dan natuurlijk private moeten zijn)
    // Zo doet men dat in Java, C++
    //public uint GetIntensity()
    //{
    //    return intensity;
    //}
    //public void SetIntensity(uint val)
    //{
    //    if (val >=0 && val <= 1000)
    //    {
    //        intensity = val;
    //    }
    //    else
    //    {
    //        Console.WriteLine("Ongeldige waarde");
    //    }
    //}

    // In C# den we dat met Properties. Cosmetisch
    public uint Intensity
    {
        get {  return intensity; }
        set 
        {
            if (value >= 0 && value <= 1000)
            {
                intensity = value;
            }
            else
            {
                Console.WriteLine("Ongeldige waarde");
            }
        }
    }

    // Auto generating properties
    // Genereren hun eigen field dat zo private dat je er zelf niet eens bij kunt
    public string Name { get; set; } = "Default Name";
    public ConsoleColor Color { get; set; } = ConsoleColor.Yellow;


    // Methods (veredelde functie of procedures)
    // Met virtual geef ik aan dat dit gedrag polymorf-ready
    // virtual is optioneel, een afgeleide class HOEFT NIET te overriden
    public virtual void On()
    {
        
        Console.BackgroundColor = Color;
        Console.WriteLine($"De lamp ({Name}) is nu aan en brandt met {Intensity}lm");
    }
    // Als je het optioneel overriden wilt verplichten, gebruik dan abstract.
    // Een abstracte methode heeft geen implementatie
    public abstract void Off();

    // Constructors
    // Zijn bedoeld om _field_ een initiele waarde te geven.
    // Die taak wordt overgenomen door de default constructor die 
    // verdwijnt op het moment dat jij een constructor maakt.
    // Gebruik Constructors alleen voor fields die _van buitenaf_ een waarde _moeten_ krijgen.
    public Lamp( string name, uint intensity = 200, ConsoleColor color = ConsoleColor.DarkBlue )
    {
        Name = name;
        Intensity = intensity;
        Color = color;
    }

    public Lamp(string name) : this(name, 200, ConsoleColor.Yellow)
    {
                
    }

    // Is dan ook vreemd
    public Lamp()
    {
        
    }
}
