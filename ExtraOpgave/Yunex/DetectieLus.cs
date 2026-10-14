namespace Yunex;

using Observer = Standaarden.IObserver;

public class DetectieLus
{
    private List<Observer> _devices = new();

    public void Connect(Observer device)
    {
        _devices.Add(device);
    }

    public void Detecteert()
    {
        Console.WriteLine("De detectielus ziet iets");
        foreach (Observer device in _devices)
        {
            device.Notify();
        }
    }
}
