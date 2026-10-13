namespace LingoGame;

internal class Woord
{
    private readonly Letter[] _word;

    public Woord(string word)
    {
        _word = new Letter[word.Length];
        for (int i = 0; i < word.Length; i++)
        {
            _word[i] = new Letter { Character = word[i], Position = i };
        }
    }

    public int Length
    {
        get { return _word.Length; }
    }

    public void Show()
    {
        foreach (Letter letter in _word) letter.Teken();
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
    public bool Evaluate(Woord? guess)
    {
        for (int i = 0; i < guess?._word.Length; i++)
        {
            if (_word[i].Character != guess._word[i].Character) return false;
            _word[i]._match = MatchResult.Correct;
        }
        return true;
    }
}
