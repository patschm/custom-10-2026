using LingoGame;

namespace ConsoleLingo;

internal class Program
{
    static void Main(string[] args)
    {
        Speler sp1 = new Speler("Jan");
        Speler sp2 = new Speler("Kees");

        Game game1 = new Game(
            new ConsoleInputProvider(),
            new ConsoleGameView(),
            new ConsoleDevice());
        game1.Register(sp2);
        game1.Register(sp1);
        game1.Start();
    }
}

