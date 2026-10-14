namespace WillieWortel;

internal class Program
{
    static void Main(string[] args)
    {
        var simon = new SimonVdMeer();
        var willem = new WillemKlein();

        //willem.Bereken(simon.Add, 3, 4);
        //willem.Bereken(simon.Subtract, 3, 4);


        MathDel del = simon.Add;
        del = del + simon.Add;
        del = del + simon.Subtract;
        del = del + simon.Add;
        del += simon.Subtract;
        del -= simon.Subtract;

        foreach (var item in del.GetInvocationList())
        {
            Console.WriteLine(item.Method.Name);
        }

        int result = del(1, 2);


        Console.WriteLine(result);

    }
}
