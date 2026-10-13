using System;
using System.Collections.Generic;
using System.Text;

namespace TheFirm;

// Bokito IMPLENTEERT de interface IContract.
internal class Bokito : IContract, IDierenTuinContract
{
    public void DoeIets()
    {
        Console.WriteLine("Bokito ramt irritante dames in elkaar");
    }

    public void Werk()
    {
        DoeIets();
    }
    void IDierenTuinContract.Werk()
    {
        Console.WriteLine("Bokito eet een banaan");
    }
}
