using System;
namespace Modul008_InterfaceSample
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region List Sample
            List<string> staedteName = new List<string>();
            staedteName.Add("Berlin");
            staedteName.Add("München");
            staedteName.Add("Hamburg");

            foreach (string stadt in  staedteName)
            {
                Console.WriteLine(stadt);
            }
            #endregion


            #region Polymorphy

            List<Jahrmarktstand> jahrmarktstaendeImPark = new List<Jahrmarktstand>();

            jahrmarktstaendeImPark.Add(new AutoScooter());
            jahrmarktstaendeImPark.Add(new HorrorCabinet());
            jahrmarktstaendeImPark.Add(new HöchsteAchterbahnDerWelt());
            jahrmarktstaendeImPark.Add(new Streichelzoo());
            jahrmarktstaendeImPark.Add(new Karusell());

            foreach(Jahrmarktstand aktuellerJahrmarktstand in jahrmarktstaendeImPark)
            {
                //Was kann Jahrmarktstand aktuellerJahrmatstand 

                //aktuellerJahrmarktstand.MitarbeiterAnzahl
                //aktuellerJahrmarktstand.FlaecheInQuatratmeter
                //aktuellerJahrmarktstand.Name;

                #region Typprüfung
                if (aktuellerJahrmarktstand is AutoScooter aScooter)
                {
                    Console.WriteLine("Jahrmarktstand ist ein AutoScooter");
                    Console.WriteLine($"Anzahl der Autos > {aScooter.AnzahlAutoScooters}");
                }

                //Alte aus der C/C++ Welt
                if(aktuellerJahrmarktstand.GetType() == typeof(AutoScooter))
                {
                    AutoScooter autoScooter = (AutoScooter)aktuellerJahrmarktstand;


                    Console.WriteLine("Jahrmarktstand ist ein AutoScooter");
                    Console.WriteLine($"Anzahl der {autoScooter.AnzahlAutoScooters}");
                }
                #endregion

                #region Interface Prüfung

                //Prüfe ob die Klasse das Interface IFSK18Check enthält
                //Wenn ja, verwenden wir die Methode CheckAge mithilfe von fSK18Check 
                if (aktuellerJahrmarktstand is IFSK18Check fSK18Check)
                {
                    if (fSK18Check.CheckAge(16))
                    {
                        Console.WriteLine("Darf");
                    }
                    else
                        Console.WriteLine("Darf nicht");
                }
                else
                    Console.WriteLine("Darf");

                Random rand = new Random(); 

                //Muss auf Toilette oder nicht
                if (rand.Next() % 2 == 0) //Bei Gerade Zahl ja
                {
                    //Frit muss jetzt unbedingt auf Toilete 

                    //Hat der Aktuelle Stand ein WC 
                    if (aktuellerJahrmarktstand is IToiletten haveToilets)
                    {
                        Console.WriteLine("Gut für Fritz");
                    }
                    else
                        Console.WriteLine("wird nicht weiter kommentiert");
                }

                #endregion


            }


            #endregion

        }
    }


    //Interfaces müssen implementiert werden
    public interface IFSK18Check
    {
        bool CheckAge(int age);
    }

    public interface IToiletten
    {
        public int Anzahl { get; set; }
    }

    public class Jahrmarktstand
    {
        public string Name { get; set; }    
        public int MitarbeiterAnzahl { get; set; }
        public int FlaecheInQuatratmeter { get; set; }
    }

    public class AutoScooter : Jahrmarktstand
    {
        public int AnzahlAutoScooters { get; set; } = 10;
    }

    public class HöchsteAchterbahnDerWelt : Jahrmarktstand, IFSK18Check
    {
        public int LaengeDerStrecke { get; set; }
        public int Hoehe { get; set; }
        public int MaxGeschwindigkeit { get; set; }

        public bool CheckAge(int age)
        {
            return age >= 18 ? true : false;
        }
    }

    public class Streichelzoo : Jahrmarktstand, IToiletten
    {
        public int AnzahlTiere { get; set; }
        public int Anzahl { get; set; } = 5;
    }

    public class Karusell : Jahrmarktstand, IToiletten
    {
        public int Fahrdauer { get; set; }
        public int Anzahl { get; set; } = 2;
    } 

    public class HorrorCabinet : Jahrmarktstand, IFSK18Check
    {
        public int EingebautShockMomente { get; set; }

        public bool CheckAge(int age)
        {
            return age >= 18 ? true : false;
        }
    }
}