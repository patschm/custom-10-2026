using System.Diagnostics;
using System.Text;

namespace Houston;

internal class Program
{
    static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();
        //string s = "";
        StringBuilder s = new StringBuilder(1000);

        sw.Start();
        for (int i = 0; i < 100000; i++)
        {
            s.Append(i);// += i;
        }
        sw.Stop();
        Console.WriteLine(sw.Elapsed);
    }
}
