using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WpfLingo;

public class MainViewModel : INotifyPropertyChanged
{
    public const int MaxRows = 5;

    private string _message = "Vul de namen van de spelers in en druk op Start";
    private string _currentPlayer = "";
    private bool _isInputEnabled;
    private bool _isGameRunning;

    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<ObservableCollection<LetterTile>> Rows { get; } = new();
    public ObservableCollection<LetterTile> Solution { get; } = new();

    public MainViewModel()
    {
        ShowBoard([], []);
    }

    public string Message
    {
        get => _message;
        set => SetField(ref _message, value);
    }

    public string CurrentPlayer
    {
        get => _currentPlayer;
        set => SetField(ref _currentPlayer, value);
    }

    public bool IsInputEnabled
    {
        get => _isInputEnabled;
        set => SetField(ref _isInputEnabled, value);
    }

    public bool IsGameRunning
    {
        get => _isGameRunning;
        set
        {
            if (SetField(ref _isGameRunning, value)) OnPropertyChanged(nameof(IsSetupEnabled));
        }
    }

    public bool IsSetupEnabled => !IsGameRunning;

    public bool HasSolution => Solution.Count > 0;

    /// <summary>Replaces the board; empty rows are added so the grid always shows <see cref="MaxRows"/> rows.</summary>
    public void ShowBoard(IReadOnlyList<LetterTile[]> rows, IReadOnlyList<LetterTile> solution)
    {
        Rows.Clear();
        foreach (LetterTile[] row in rows) Rows.Add(new ObservableCollection<LetterTile>(row));
        while (Rows.Count < MaxRows)
        {
            Rows.Add(new ObservableCollection<LetterTile>(Enumerable.Repeat(LetterTile.Empty, WpfInputProvider.WordLength)));
        }

        Solution.Clear();
        foreach (LetterTile tile in solution) Solution.Add(tile);
        OnPropertyChanged(nameof(HasSolution));
    }

    /// <summary>Runs an action on the UI thread (the game itself runs on a background thread).</summary>
    public void OnUi(Action action)
    {
        var dispatcher = Application.Current?.Dispatcher;
        if (dispatcher == null || dispatcher.HasShutdownStarted) return;
        if (dispatcher.CheckAccess()) action();
        else dispatcher.Invoke(action);
    }

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
