using Modul005_HerstellerLibrary; //Library haben wir in unseren SourceCode verfügbar gemacht

//MyDataLayer ist ein Alias von Modul005a_NamespaceSample.DataAccess;
using MyDataLayer = Modul005a_NamespaceSample.DataAccess;

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


            //CSVParser vom Herrsteller 'ABC' -> jetzt ist es die CSV-Parser
            CSVParser csvParser = new CSVParser();

            string csvLine = "Harry,Weinfurt,43,Comedian";
            string[] csvParts = csvParser.ReadCSVLine(csvLine);


            //Expliziet den CSVParser des Hersteller ansprechen
            Modul005_HerstellerLibrary.CSVParser herrstellerCSVParser = new Modul005_HerstellerLibrary.CSVParser();

            Modul005a_NamespaceSample.CSVParser firmenInternerCSVParser = new Modul005a_NamespaceSample.CSVParser();

            csvParts = herrstellerCSVParser.ReadCSVLine(csvLine);
            csvParts = firmenInternerCSVParser.ReadCSVLine(csvLine);


            //Modul005a_NamespaceSample.DataAccess.DbLogger logger = new DbLogger();
            MyDataLayer.DbLogger dbLogger = new MyDataLayer.DbLogger();


        }
    }


    //Datentyp MeineKlasse
    class MeineKlasse2
    {

    }

    public class CSVParser
    {
        //private -> nur innerhalb meiner Klasse 'CSVParser' kann auf private - Variablen, Methoden 


        //string csvLine -> "Otto,Walkes,55,Comedian"
        public string[] ReadCSVLine(string csvLine)
        {
            string[] csvParts = csvLine.Split(';');

            return csvParts; //csvParts[0] = Otto... csvParts[1] = Walkes
        }
    }
}