using LingoGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLingo;

internal class ConsoleDevice : IDevice
{
    public void TekenCorrect(char c)
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(c);
        Console.ResetColor();
    }

    public void TekenIncorrect(char c)
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(c);
        Console.ResetColor();
    }

    public void TekenWrongPosition(char c)
    {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write(c);
        Console.ResetColor();
    }
}
