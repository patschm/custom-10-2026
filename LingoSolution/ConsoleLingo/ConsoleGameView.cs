using LingoGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLingo;

internal class ConsoleGameView : IGameView
{
    public void AskInput()
    {
        Console.WriteLine("Geef een woord");
    }

    public void CannotStart()
    {
        Console.WriteLine("Kan nog niet starten");
    }

    public void PlayerTurn(string name)
    {
        Console.WriteLine($"{name} is aan de beurt");
    }

    public void TooManyPlayers()
    {
        Console.WriteLine("Teveel deelnemers");
    }

    public void Winner(string name)
    {
        Console.WriteLine($"Gefeliciteerd {name}");
    }
}
