namespace TechoTalk;

internal class Program
{
    static void Main(string[] args)
    {
        int x = 0;
        Function1();
        Function2();
    }

    private static void Function1()
    {
        int x = 10;
        Console.WriteLine(x);
        Function2();
        int[][] intarrays = new int[10][];
        void Function3()
        {
            int[] array = new int[100_000_000];
            int x = 30;
            Console.WriteLine(x);

            intarrays[0] = array;
        }
        

        for (int i = 0; i < 10; i++)
        {
            Function3();
        }

        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.ReadLine();
    }
    private static void Function2()
    {
       int x = 20;
        Console.WriteLine(x);
    }
}
