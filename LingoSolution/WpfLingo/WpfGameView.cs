using LingoGame;

namespace WpfLingo;

/// <summary>
/// Translates the game's notifications into view model updates.
/// Called on the game thread; every change is marshalled to the UI thread.
/// </summary>
internal class WpfGameView : IGameView
{
    private readonly MainViewModel _viewModel;
    private readonly WpfDevice _device;
    private readonly WpfInputProvider _inputProvider;

    public WpfGameView(MainViewModel viewModel, WpfDevice device, WpfInputProvider inputProvider)
    {
        _viewModel = viewModel;
        _device = device;
        _inputProvider = inputProvider;
    }

    public bool HasWinner { get; private set; }

    public void AskInput()
    {
        _viewModel.OnUi(() => _viewModel.IsInputEnabled = true);
    }

    public void CannotStart()
    {
        _viewModel.OnUi(() => _viewModel.Message = "Kan nog niet starten");
    }

    public void PlayerTurn(string name)
    {
        FlushBoard();
        _viewModel.OnUi(() =>
        {
            _viewModel.CurrentPlayer = name;
            _viewModel.Message = $"{name} is aan de beurt";
        });
    }

    public void TooManyPlayers()
    {
        _viewModel.OnUi(() => _viewModel.Message = "Teveel deelnemers");
    }

    public void Winner(string name)
    {
        HasWinner = true;
        FlushBoard();
        _viewModel.OnUi(() => _viewModel.Message = $"Gefeliciteerd {name}!");
    }

    /// <summary>
    /// Moves everything the game drew since the last flush onto the board.
    /// The frame consists of the guessed words (5 letters each), in a DEBUG build
    /// of LingoGame preceded by the word to be guessed.
    /// </summary>
    public void FlushBoard()
    {
        List<LetterTile> frame = _device.TakeFrame();
        if (frame.Count == 0) return;

        int historyLetters = Math.Min(frame.Count, _inputProvider.ValidGuessCount * WpfInputProvider.WordLength);
        int solutionLength = frame.Count - historyLetters;

        List<LetterTile> solution = frame.Take(solutionLength).ToList();
        List<LetterTile[]> rows = frame.Skip(solutionLength).Chunk(WpfInputProvider.WordLength).ToList();

        _viewModel.OnUi(() => _viewModel.ShowBoard(rows, solution));
    }
}
