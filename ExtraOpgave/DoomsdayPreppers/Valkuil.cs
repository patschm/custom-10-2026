namespace DoomsdayPreppers;

public class Valkuil : Standaarden.IObserver
{
    public void Notify()
    {
        Open();
    }

    public void Open()
    {
        Console.WriteLine("De valkuil, met scherpe spiezen, gaat open");
    }
}
