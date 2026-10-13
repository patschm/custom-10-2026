namespace LingoGame;

internal class Beurt
{
    private Woord[] _history;
    private readonly Woord _wordToBeGuessed;

    public Beurt(Woord wordToBeGuessed)
    {
        _wordToBeGuessed = wordToBeGuessed;
        _history = new Woord[_wordToBeGuessed.Length];
    }

    public Speler? CurrentPlayer { get; set; }
    public bool IsGeraden { get; private set; }
    public Woord? Gok()
    {
        Console.WriteLine("Geef een woord");
        string? guess = Console.ReadLine();
        Woord word = new Woord(guess!);
        if (word.IsValid)
        {
            AddGuess(word);
           _wordToBeGuessed.Evaluate(word);
            IsGeraden = word == _wordToBeGuessed;
        }
        return word;
    }
    public void ShowHistory()
    {
#if DEBUG
        _wordToBeGuessed.Show();
#endif
        foreach (var word in _history) 
        {
            if (word != null)  word.Show();
        }
    }
    private void AddGuess(Woord word)
    {
        for (int i = 0; i < _history.Length; i++)
        {
            if (_history[i] == null)
            {
                _history[i] = word;
                return;
            }
        }
    }
}
