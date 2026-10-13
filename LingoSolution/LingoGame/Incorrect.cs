using System;
using System.Collections.Generic;
using System.Text;

namespace LingoGame;

internal class Incorrect : Letter
{
    public override Letter Clone()
    {
        return new Incorrect { Character = this.Character, Position = this.Position };
    }
    public override void Teken()
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(Character);
        Console.ResetColor();
    }
}
