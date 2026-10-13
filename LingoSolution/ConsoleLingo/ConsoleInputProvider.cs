using LingoGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLingo;

internal class ConsoleInputProvider : IInputProvider
{
    public string Guess()
    {
        return Console.ReadLine();
    }
}
