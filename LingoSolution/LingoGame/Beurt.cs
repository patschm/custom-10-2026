namespace LingoGame;

internal class Beurt
{
    private Woord[] _history;
    private readonly Woord _wordToBeGuessed;
    private readonly IGameView _gameView;
    private readonly IInputProvider _inputProvider;
    private readonly IDevice _device;

    public Beurt(Woord wordToBeGuessed, IGameView gameView, IInputProvider inputProvider, IDevice device)
    {
        _wordToBeGuessed = wordToBeGuessed;
        _history = new Woord[_wordToBeGuessed.Length];
        _gameView = gameView;
        _inputProvider = inputProvider;
        _device = device;
    }

    public Speler? CurrentPlayer { get; set; }
    public bool IsGeraden { get; private set; }
    public Woord? Gok()
    {
        //Console.WriteLine("Geef een woord");
        _gameView.AskInput();
        string guess = _inputProvider.Guess();
        //string? guess = Console.ReadLine();
        Woord word = new Woord(guess!);
        if (word.IsValid)
        {
           _wordToBeGuessed.Evaluate(word);
            AddGuess(word);
            IsGeraden = word == _wordToBeGuessed;
        }
        return word;
    }
    public void ShowHistory()
    {
#if DEBUG
        _wordToBeGuessed.Show(_device);
#endif
        foreach (var word in _history) 
        {
            if (word != null)  word.Show(_device);
        }
    }
    private void AddGuess(Woord word)
    {
        for (int i = 0; i < _history.Length; i++)
        {
            if (_history[i] == null)
            {
                _history[i] = new Woord(word);
                return;
            }
        }
    }
}
