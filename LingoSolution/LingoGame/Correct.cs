using System;
using System.Collections.Generic;
using System.Text;

namespace LingoGame;

internal class Correct : Letter
{
    public override Letter Clone()
    {
        return new Correct {  Character = this.Character, Position = this.Position };
    }

    public override void Teken()
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(Character);
        Console.ResetColor();
    }
}
