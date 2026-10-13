namespace LingoGame;

internal abstract class Letter
{
	private char _character;
	private int _position;
	//public MatchResult _match = MatchResult.Incorrect;

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
	public abstract void Teken(IDevice device);
	//{
	//	Console.BackgroundColor = Color;
	//       Console.Write(_character);
	//	Console.ResetColor();
	//}

	public abstract Letter Clone();
	
}
