namespace LingoGame;

internal class Woord
{
    private readonly Letter[] _word;

    public Woord(string word)
    {
        _word = new Letter[word.Length];
        for (int i = 0; i < word.Length; i++)
        {
            _word[i] = new Incorrect { Character = word[i], Position = i };
        }
    }
    public Woord(Woord word)
    {
        _word = new Letter[word.Length];
        for(int i = 0;i < word.Length;i++)
        {
            _word[i] = word[i].Clone();
        }
    }
    public Letter this[int idx]
    {
        get
        {
            if (idx >= 0 && idx < _word.Length)
                return _word[idx];
            throw new IndexOutOfRangeException();
        }
        set
        {
            if (idx >= 0 && idx < _word.Length)
                _word[idx] = value;
            else throw new IndexOutOfRangeException();

        }
    }
    public int Length
    {
        get { return _word.Length; }
    }

    public void Show(IDevice device)
    {
        foreach (Letter letter in _word) letter.Teken(device);
        Console.WriteLine();
    }
    public static bool operator !=(Woord left, Woord right)
    {
        return !(left == right);
    }
    public static bool operator==(Woord? left, Woord? right)
    {
        if (left is null & right is null) return true;
        if (left is null ^ right is null) return false;
        for (int i = 0; i < left.Length; i++)
        {
            if (left._word[i] != right._word[i]) return false;
        }
        return true;
    }

    public bool IsValid { get { return _word.Length == 5; } }
    public void Evaluate(Woord guess)
    {
        CharCounter counter = new CharCounter(this);
        for (int i = 0; i < guess.Length; i++) 
        { 
            if (_word[i] == guess[i])
            {
                guess[i] = new Correct { Character = _word[i].Character, Position = _word[i].Position };
                counter.Decrement(guess[i]);
            }
        }
        for (int i = 0; i < guess.Length; i++)
        {
            if (guess[i] is Correct) continue;
            if (!counter.CanUse(guess[i])) continue;
            foreach (Letter letter in _word)
            {
                if (letter.Character == guess[i].Character)
                {
                    guess[i] = new WrongPosition { Character = letter.Character, Position = letter.Position };
                    counter.Decrement(guess[i]);
                    break;
                }
            }
        }
    }
}
