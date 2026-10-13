using System;
using System.Collections.Generic;
using System.Text;

namespace LingoGame;

public interface IGameView
{
    public void AskInput();
    public void TooManyPlayers();
    public void CannotStart();

    public void PlayerTurn(string name);
    public void Winner(string name);
}
