namespace Yunex;

using Observer = Standaarden.IObserver;


public delegate void Actor();

public class DetectieLus
{
    private List<Observer> _devices = new();
    private List<Actor> _actors = new();
    public event Actor Detect;


    public void Connect(Observer device)
    {
        _devices.Add(device);
    }
    public void Connect(Actor actor)
    {
        _actors.Add(actor);
    }

    public void Detecteert()
    {
        Console.WriteLine("De detectielus ziet iets");
        Console.WriteLine("=== Via interfaces");
        foreach (Observer device in _devices)
        {
            device.Notify();
        }
        Console.WriteLine("=== Via events");
        try
        {
            Detect?.Invoke();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine("=== Via delegate");
        foreach (Actor device in _actors)
        {
            try
            {
                device();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
