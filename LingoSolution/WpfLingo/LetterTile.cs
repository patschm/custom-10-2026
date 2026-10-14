namespace WpfLingo;

public enum LetterState
{
    Empty,
    Incorrect,
    WrongPosition,
    Correct
}

public record LetterTile(char Character, LetterState State)
{
    public static LetterTile Empty { get; } = new(' ', LetterState.Empty);
}
