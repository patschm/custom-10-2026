namespace Heras;

public class Hek : Standaarden.IObserver
{
    public void Notify()
    {
        Open();
    }

    public void Open()
    {
        Console.WriteLine("Het hek gaat open (met welkomsteken)");
    }
}
