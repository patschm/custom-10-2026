namespace Philips;

public class Lamp : Standaarden.IObserver
{
    public void Aan()
    {
        Console.WriteLine("De lamp gaat aan");
    }

    public void Notify()
    {
        Aan();
    }
}
