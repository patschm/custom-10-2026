using LingoGame;

namespace WpfLingo;

/// <summary>
/// Collects the letters the game draws. The game redraws the complete history
/// after every valid guess, so the letters are buffered until the game view
/// tells us the drawing is finished (see <see cref="TakeFrame"/>).
/// Called on the game thread.
/// </summary>
internal class WpfDevice : IDevice
{
    private readonly List<LetterTile> _frame = new();

    public void TekenCorrect(char c) => _frame.Add(new LetterTile(c, LetterState.Correct));

    public void TekenIncorrect(char c) => _frame.Add(new LetterTile(c, LetterState.Incorrect));

    public void TekenWrongPosition(char c) => _frame.Add(new LetterTile(c, LetterState.WrongPosition));

    public List<LetterTile> TakeFrame()
    {
        var frame = new List<LetterTile>(_frame);
        _frame.Clear();
        return frame;
    }
}
