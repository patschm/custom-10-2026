namespace LingoGame;

internal class Letter
{
	private char _character;
	private int _position;
	public MatchResult _match = MatchResult.Incorrect;

	public ConsoleColor Color { get; set; } = ConsoleColor.Blue;
    public int Position
	{
		get { return _position; }
		set {
			if (value >= 0 && value <= 5)
			{
				_position = value;
			}
		}
	}

	public char Character
	{
		get { return _character; }
		set { _character = char.ToUpper(value); }
	}

    public static bool operator ==(Letter left, Letter right)
    {
        return left.Character == right.Character && left.Position == right.Position;
    }
    public static bool operator!=(Letter left, Letter right)
	{
		return !( left == right);
	}
	public void Teken()
	{
		Console.BackgroundColor = Color;
        Console.Write(_character);
		Console.ResetColor();
	}
}
