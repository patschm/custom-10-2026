namespace MeerInteractie;

// delegate is blauwdruk van een functie/procedure/method
delegate void BarHaal();

// class is blauwdruk van een object
internal class WillemJan
{
    public void Execute(BarHaal functie)
    {
        Console.WriteLine("Willem Jan voert uit:");
        functie();
    }
}
