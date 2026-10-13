using System;
using System.Collections.Generic;
using System.Text;

namespace LingoGame;

internal class CharCounter
{
    private  Dictionary<char, int> _counter = new Dictionary<char, int>();
    public CharCounter(Woord word)
    {
        for (int i = 0; i < word.Length; i++) 
        {
            if (_counter.TryGetValue(word[i].Character, out int _))
            {
                _counter[word[i].Character]++;
            }
            else
            {
                _counter.Add(word[i].Character, 1);
            }
        }
    }
    public void Decrement(Letter c)
    {
        if( _counter.TryGetValue(c.Character, out int _) )
        {
            _counter[c.Character]--;
        }
    }
    public bool CanUse(Letter c) 
    {
        if (_counter.TryGetValue(c.Character, out int _))
        {
            return _counter[c.Character] > 0;
        }
        else return false;
    }
}
