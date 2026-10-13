
namespace TheFirm;

internal class ACME
{
    // ACME weet nu wat employees KUNNEN doen
    private List<IContract> employees = new List<IContract>();

    public void Hire(IContract e)
    {
        employees.Add(e);
    }

    public void Start()
    {
        Console.Beep(5000, 1000);
        Console.WriteLine("ACME start met produceren");
        foreach (IContract employee in employees) 
            employee.Werk(); // Contractbepaling
    }
}
