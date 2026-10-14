namespace DeRadio;

internal class Program
{
    static void Main(string[] args)
    {
        RadioStation r538 = new RadioStation();
        r538.Message += ViaKabel;
        r538.Message += ViaMail;
        r538.Message += ViaSMS;
        r538.Message += ViaWhatsApp;
        r538.Message += ViaPostduif;
        r538.Message += ViaKabel;
        r538.Message += ViaKabel;
        r538.Message += ViaMail;
        r538.Message += ViaSMS;
        r538.Message += ViaWhatsApp;
        r538.Message += ViaPostduif;
        r538.Message += ViaKabel;
        r538.Message += ViaKabel;
        r538.Message += ViaMail;
        r538.Message += ViaSMS;
        r538.Message += ViaWhatsApp;
        r538.Message += ViaPostduif;
        r538.Message += ViaKabel;

        //r538.Subscribers("Hey Klojo's");

        r538.Broadcast();
    }

    static void ViaKabel(string msg)
    {
        Console.WriteLine($"Via kabel ontvangen: {msg}");
    }
    static void ViaSMS(string msg)
    {
        Console.WriteLine($"Via SMS ontvangen: {msg}");
    }
    static void ViaWhatsApp(string msg)
    {
        Console.WriteLine($"Via WhatsApp ontvangen: {msg}");
    }
    static void ViaMail(string msg)
    {
        Console.WriteLine($"Via e-mail ontvangen: {msg}");
    }
    static void ViaPostduif(string msg)
    {
        Console.WriteLine($"Via postduif ontvangen: {msg}");
    }
}
