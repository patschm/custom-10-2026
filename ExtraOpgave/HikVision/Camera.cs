namespace HikVision;

public class Camera:Standaarden.IObserver
{
    public void Notify()
    {
        StartOpname();
    }

    public void StartOpname()
    {
        Console.WriteLine("De camera gaat opnemen");
    }
}
