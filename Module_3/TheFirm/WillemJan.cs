using System;
using System.Collections.Generic;
using System.Text;

namespace TheFirm;

internal class WillemJan : Werknemer
{
    public override void DoeIets()
    {
        KentDeHeleCatalogus();
    }

    public void KentDeHeleCatalogus()
    {
        Console.WriteLine("Willem Jan dreunt alle producten van ACME op");
    }
}
