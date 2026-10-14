namespace DeRadio;

delegate void OntvangstMethode(string msg);


internal class RadioStation
{
    //private OntvangstMethode _subscribers;

    public event OntvangstMethode Message;
    //{
    //    add
    //    {
    //        _subscribers += value;
    //    }
    //    remove
    //    {
    //        _subscribers -= value;
    //    }
    //}

    public void Broadcast()
    {
        Console.WriteLine("Het radiostation zendt nu uit:");
        Message?.Invoke("Hallo luisteraars!!!");
    }
}
