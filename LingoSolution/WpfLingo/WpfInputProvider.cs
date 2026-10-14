using System.Collections.Concurrent;
using LingoGame;

namespace WpfLingo;

/// <summary>
/// Bridges the blocking <see cref="IInputProvider.Guess"/> call (game thread)
/// with the text box in the window (UI thread).
/// </summary>
internal class WpfInputProvider : IInputProvider
{
    public const int WordLength = 5;

    private readonly BlockingCollection<string> _guesses = new();
    private readonly CancellationToken _cancellationToken;

    public WpfInputProvider(CancellationToken cancellationToken)
    {
        _cancellationToken = cancellationToken;
    }

    /// <summary>Number of guesses the game accepted as valid (and therefore stored in its history).</summary>
    public int ValidGuessCount { get; private set; }

    public void Submit(string guess) => _guesses.Add(guess);

    public string Guess()
    {
        // Throws OperationCanceledException when the game is abandoned (new game / window closed).
        string guess = _guesses.Take(_cancellationToken);
        if (guess.Length == WordLength) ValidGuessCount++;
        return guess;
    }
}
