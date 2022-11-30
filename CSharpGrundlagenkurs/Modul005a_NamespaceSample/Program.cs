namespace Modul005a_NamespaceSample
{
    //Was ist ein Namespace?
    //Eine Art Wörtbuch in dem Datentypen definiert sind -> Der Name eines Datentypes muss eindeutig sein. Es muss unterscheidbar bleiben


    internal class Program
    {
        static void Main(string[] args)
        {
            //Verwendung einer Klasse -> Objekt-Instance
             MeineKlasse2 meineKlasse2 = new MeineKlasse2();

            //Absolute Schreibweise
            Modul005a_NamespaceSample.MeineKlasse2 meineKlasse = new Modul005a_NamespaceSample.MeineKlasse2();
        }
    }


    //Datentyp MeineKlasse
    class MeineKlasse2
    {

    }
}