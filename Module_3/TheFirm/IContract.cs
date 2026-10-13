using System;
using System.Collections.Generic;
using System.Text;

namespace TheFirm;

// De interface is bedoeld om INTERACTIE tussen object te ONTKOPPELEN
// De interface beschrijft wat een object KAN DOEN (can-do relatie)
// Alle members zijn public.
// Kan geen fields hebben (je kunt er geen instantie van maken)
internal interface IContract
{
    void Werk(); 
}
