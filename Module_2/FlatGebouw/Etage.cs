using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace FlatGebouw;

internal class Etage
{
    // static is een gedeelde member
    // Class member
    private  static Lift _elevator = new Lift();

    // Instance Member
    public int EtageNummer { get; set; }

    public void RoepLift()
    {
        Etage._elevator.Call(this.EtageNummer);
    }

    public void DisplayLiftStatus()
    {
        _elevator.ToonStatus();
        Console.WriteLine();
    }

    static Etage()
    {
       // Console.WriteLine("Construct");
        //_elevator = new Lift();
    }
}
