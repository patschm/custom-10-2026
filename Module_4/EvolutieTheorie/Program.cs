namespace EvolutieTheorie;

delegate int MathDel(int x, int y);

internal class Program
{
    static MathDel[] dels = new MathDel[10];

    static void Main(string[] args)
    {
        // 2002. .NET Framework 1.0/1.1 (2003)
        MathDel m1 = new MathDel(Add);
        int result = m1(1, 2);

        // 2005 .NET Framework 2.0
        MathDel m2 = Add;
        result = m2(2, 3);

        int c = 100;
        MathDel m3 = delegate (int a, int b)
        {
            return a + b;
        };

        result = m3(3, 4);

        // 2008. .NET Framework 3.0/3.5
        MathDel m4 =  (a, b) => a + b;
        result = m4(4, 5);

        // Procedures
        Action<string> a1 = Console.WriteLine;
        a1("Hello");

        // Functions
        Func<int, int, int> m5 = Add;
        result = m5(5, 6);


        Console.WriteLine(result);

        Test1();
        ExecArray();
    }

    static int Add(int a, int b)
    {
        return a + b;
    }

    static void Test1()
    {
        for (int i = 0; i < 10; i++)
        {
            MathDel m3 = delegate (int a, int b)
            {
                return a + b + i;
            };
            dels[i] = m3;
        }
    }

    static void ExecArray()
    {
        int i = 1000;
        foreach (var d in dels)
        {
            Console.Write($"{d(1, 2)}, ");
        }
    }
}
