namespace LingoGame;

public class Game
{
    private Speler? _speler1 = null;
    private Speler? _speler2 = null;
    private Beurt? _currentBeurt;
    private const int maxAttempts = 5;
    private static Woordenboek dictionary= new Woordenboek();
    private readonly IInputProvider _inputProvider;
    private readonly IGameView _gameView;
    private readonly IDevice _device;


    public Game(IInputProvider inputProvider, IGameView gameView, IDevice device)
    {
        _inputProvider = inputProvider;
        _gameView = gameView;
        _device = device;
    }


    public void Register(Speler speler)
    {
        if (_speler1 == null)
        {
            _speler1 = speler;
            return;
        }
        if (_speler2 == null) 
        {
            _speler2 = speler;
            return;
        }
        _gameView.TooManyPlayers();
       // Console.WriteLine("Teveel deelnemers");
    }

    public void Start()
    {
        if (_speler1 == null || _speler2 == null)
        {
            //Console.WriteLine("Kan nog niet starten");
            _gameView.CannotStart();

            return;
        }
        
        Speel();
    }
    private void Speel()
    {
        if (_currentBeurt == null)
        {
            _currentBeurt = new Beurt(dictionary.RandomWord(), _gameView, _inputProvider, _device) { CurrentPlayer = _speler1 };
        }
        
        for (int attempt = 0; attempt < maxAttempts;)
        {
            //Console.WriteLine($"{_currentBeurt?.CurrentPlayer?.Naam} is aan de beurt");
            _gameView.PlayerTurn(_currentBeurt?.CurrentPlayer?.Naam);
            Woord? guess = _currentBeurt?.Gok();
            if (!guess!.IsValid)
            {
                SwapPlayer();
                continue;
            }
            _currentBeurt.ShowHistory();
            if (_currentBeurt.IsGeraden)
            {
                //Console.WriteLine($"Gefeliciteerd {_currentBeurt.CurrentPlayer.Naam}");
                _gameView.Winner(_currentBeurt.CurrentPlayer.Naam);
                return;
            }
            attempt++;
            
        }

    }

    
    private void SwapPlayer()
    {
        if (_currentBeurt?.CurrentPlayer?.Naam == _speler1?.Naam)
        {
            _currentBeurt?.CurrentPlayer = _speler2;
        }
        else
        {
            _currentBeurt?.CurrentPlayer = _speler1;
        }
    }
}
