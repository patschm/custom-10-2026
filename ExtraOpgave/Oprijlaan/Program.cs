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

        lus.Connect(hek.Open);
        lus.Connect(kuil.Open);
        lus.Connect(cam.StartOpname);
        lus.Connect(lam.Aan);

        lus.Detect += hek.Open;
        lus.Detect += kuil.Open;
        lus.Detect += cam.StartOpname;
        lus.Detect += lam.Aan;


        lus.Detecteert();
        //hek.Open(); // Geen oplossing
    }
}
