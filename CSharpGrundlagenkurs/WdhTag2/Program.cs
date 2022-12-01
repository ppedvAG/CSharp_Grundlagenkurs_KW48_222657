using System.Data;
using System.Net.Security;

namespace WdhTag2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Objekt wird instanziiert (Aufruf Default-Konstruktor)
            AutoScooter autoScooter = new AutoScooter();

            autoScooter.ReperaturDesStandes();
            autoScooter.AutoScooterUnfall();


            //Kurzschreibweise
            AutoScooter autoScooter1 = new();



            HöchsteAchterbahnDerWelt höchsteAchterbahnDerWelt = new("StevenKingAg", 12, 5000, 3000, 30, 7);
            höchsteAchterbahnDerWelt.ReperaturDesStandes();

           

        }
    }

    //
    public class Jahrmarktstand
    {
        #region Member-Variable oder Fields
        private int mitarbeiterAnzahl = 0; //Default-Werte -> Vor dem Aufruf des Konstruktors wird der Default-Wert vergeben
        #endregion

        //Properties / Eigenschaften

        public string Name { get; set; } = string.Empty;
        public int FlacheInQuatratMeter { get; set; } = 0; //Default-Werte -> Vor dem Aufruf des Konstruktors wird der Default-Wert vergeben

        //Kapselung zu -> private int mitarbeiterAnzahl;
        public int MitarbeiterAnzahl 
        { 
            get
            {
                return mitarbeiterAnzahl;
            }

            set
            {
                //Valideren, dass keine negative Zahlen gesetzt werden

                if (value >= 0)
                {
                    mitarbeiterAnzahl= value;
                }
            }
        }

        #region Konstruktoren

        //Default-Konstruktor
        public Jahrmarktstand()
        {
            MitarbeiterAnzahl = 0;
            FlacheInQuatratMeter = 0;
        }

        //Werte-Konstruktor
        public Jahrmarktstand(string name, int mitarbeiterAnzahl, int flacheInQuatratMeter)
        {
            MitarbeiterAnzahl = mitarbeiterAnzahl;
            FlacheInQuatratMeter = flacheInQuatratMeter;
            Name = name;
        }
        #endregion



        public void ReperaturDesStandes()
        {
            Console.WriteLine($"Der Stand von {Name} wird für ein Tag repariert");
        }
        //Mehtoden können wir 
    }


    public class AutoScooter : Jahrmarktstand
    {

        //.... von der Basis-Klasse bekomme ich alle (public, internal, protected) Properties, Methoden 'quasi' hier in AutoScooter übertragen

        //ABER! Ich möchte bei der Inialisierung von (MitarbeiterAnzahl, FlächeInQuatrat, Name) nicht jedemals neu Implemntieren -> Redundanzen (mehrfach der selbe Code) 




        public int AnzahlDerAutoScooter { get; set; }

        public AutoScooter()
        {
            AnzahlDerAutoScooter = 0;
        }

        public AutoScooter(string name, int mitarbeiterAnzahl, int flacheInQuatratMeter, int anzahlDerAutoScooter)
            :base (name, mitarbeiterAnzahl, flacheInQuatratMeter)
        {
            AnzahlDerAutoScooter = anzahlDerAutoScooter;
        }


        public void AutoScooterUnfall()
        {
            Console.WriteLine("Ein Auto ist kaputt gegangen");
        }
        
    }


    public class HöchsteAchterbahnDerWelt : Jahrmarktstand
    {
        public int LanegerDerStrecke { get; set; }
        public int MaximaleHoehe { get; set; }
        public int Waggongs { get; set; }


        public HöchsteAchterbahnDerWelt(string name, int mitarbeiterAnzahl, int flacheInQuatratMeter, int laengeDerStrecke, int maximaleHoehe, int waggons)
            :base(name, mitarbeiterAnzahl, flacheInQuatratMeter)
        {
            this.LanegerDerStrecke= laengeDerStrecke;
        }

        
    }









}