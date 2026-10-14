namespace WillieWortel;

delegate int MathDel(int a, int b);

internal class WillemKlein
{
    public void Bereken(MathDel fn, int x, int y)
    {
        Console.WriteLine("Willem Klein gaat rekenen:");

        int result = fn(x, y);

        Console.WriteLine($"Willem Klein kraait: Het antwoord is {result}");
    }
}
