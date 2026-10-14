using System.ComponentModel;
using System.Windows;
using LingoGame;

namespace WpfLingo;

public partial class MainWindow : Window
{
    private readonly MainViewModel _viewModel = new();
    private CancellationTokenSource? _cancellation;
    private WpfInputProvider? _inputProvider;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = _viewModel;
        _viewModel.PropertyChanged += (_, e) =>
        {
            if (e.PropertyName == nameof(MainViewModel.IsInputEnabled) && _viewModel.IsInputEnabled)
            {
                // The panel is enabled by the binding after this handler; focus once layout has caught up.
                Dispatcher.BeginInvoke(() => GuessBox.Focus());
            }
        };
    }

    private void Start_Click(object sender, RoutedEventArgs e)
    {
        string name1 = Player1Box.Text.Trim();
        string name2 = Player2Box.Text.Trim();
        if (name1.Length == 0 || name2.Length == 0 || name1 == name2)
        {
            _viewModel.Message = "Geef twee verschillende namen op";
            return;
        }

        _cancellation = new CancellationTokenSource();
        var device = new WpfDevice();
        var inputProvider = new WpfInputProvider(_cancellation.Token);
        var gameView = new WpfGameView(_viewModel, device, inputProvider);
        _inputProvider = inputProvider;

        var game = new Game(inputProvider, gameView, device);
        game.Register(new Speler(name1));
        game.Register(new Speler(name2));

        _viewModel.ShowBoard([], []);
        _viewModel.IsGameRunning = true;

        // Game.Start() runs a blocking loop (it waits in IInputProvider.Guess),
        // so it must not run on the UI thread.
        Task.Run(() =>
        {
            try
            {
                game.Start();
                gameView.FlushBoard();
                if (!gameView.HasWinner)
                {
                    _viewModel.OnUi(() => _viewModel.Message = "Helaas, niemand heeft het woord geraden");
                }
            }
            catch (OperationCanceledException)
            {
                _viewModel.OnUi(() => _viewModel.Message = "Spel gestopt");
            }
            finally
            {
                _viewModel.OnUi(() =>
                {
                    _viewModel.IsInputEnabled = false;
                    _viewModel.IsGameRunning = false;
                });
            }
        });
    }

    private void Stop_Click(object sender, RoutedEventArgs e)
    {
        _cancellation?.Cancel();
    }

    private void Guess_Click(object sender, RoutedEventArgs e)
    {
        if (_inputProvider == null) return;

        _viewModel.IsInputEnabled = false; // re-enabled when the game asks for the next word
        _inputProvider.Submit(GuessBox.Text.Trim());
        GuessBox.Clear();
    }

    private void Window_Closing(object? sender, CancelEventArgs e)
    {
        _cancellation?.Cancel();
    }
}
