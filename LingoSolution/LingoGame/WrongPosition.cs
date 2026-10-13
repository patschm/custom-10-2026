namespace LingoGame;

internal class WrongPosition : Letter
{
    public override Letter Clone()
    {
        return new WrongPosition { Character = this.Character, Position = this.Position };
    }
    public override void Teken(IDevice device)
    {
        device.TekenWrongPosition(Character);
        //Console.BackgroundColor = ConsoleColor.DarkYellow;
        //Console.ForegroundColor = ConsoleColor.Black;
        //Console.Write(Character);
        //Console.ResetColor();
    }
}
