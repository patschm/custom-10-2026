using System;
using System.Collections.Generic;
using System.Text;

namespace TheFirm;

internal abstract class Werknemer : Person, IContract
{
    public abstract void DoeIets();

    public void Werk()
    {
        DoeIets();
    }
}
