namespace FlatGebouw;

internal class Lift
{
    private int _currentFloor = 0;
    public void Call(int etageNummer)
    {
        Console.WriteLine($"De lift zoemt naar de {etageNummer}e verdieping");
        _currentFloor = etageNummer;
    }
    public void ToonStatus()
    {
        Console.WriteLine($"De lift staat nu op de {_currentFloor}e verdieping");
    }
    public Lift()
    {
        Console.WriteLine("Lift construct");
    }
}