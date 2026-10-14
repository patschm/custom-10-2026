using DoomsdayPreppers;
using Heras;
using HikVision;
using Philips;
using Yunex;

namespace Oprijlaan;

class Program
{
    static void Main(string[] args)
    {
        var kuil = new Valkuil();
        var hek = new Hek();
        var cam = new Camera();
        var lam = new Lamp();
        var lus = new DetectieLus();

        lus.Connect(hek);
        lus.Connect(kuil);
        lus.Connect(cam);
        lus.Connect(lam);

        lus.Detecteert();
        //hek.Open(); // Geen oplossing
    }
}
