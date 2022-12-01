using System.Net.Http.Headers;

namespace Modul007_Vererbung
{
    public class Program
    {
        static void Main(string[] args)
        {
           
            Lebewesen lebewesen = new("noch unbekannt", "noch unbekannt", DateTime.Now);
            lebewesen.Kommunikation();
            Console.WriteLine(lebewesen.ToString()); 

            Mensch mensch = new Mensch("Otto", "Leuchtturm", "Mensch", "Lassagne", new DateTime(1962, 5, 5));
            mensch.Kommunikation();
            Console.WriteLine(mensch.ToString());


            Reptil reptil = new Reptil(-5, "unbekanntes Reptil", "Fleisch", DateTime.Now);

            Krokodil krokodil = new Krokodil(true, -5, "Krokodil", "Fleisch",  DateTime.Now);
            krokodil.Kommunikation();
            Console.WriteLine(krokodil.ToString());


            Spider spider = new Spider(true, 0, "Spider", "Fliegen", new DateTime(2021, 3, 3));
            spider.Kommunikation();
            Console.WriteLine(spider.ToString());
        }
    }

    //KLASSEN sind Vorlagen für Objekte. Sie bestimmen Eigenschaften und Funktionen dieser.
    public class Lebewesen //zur Verwendung vgl. Program.cs
    {
        #region Felder und Eigenschaften
        //FELDER (Membervariablen) sind die Variablen einzelner Objekte, welche die Zustände dieser Objekte definieren
        private string name = "unbekanntes Lebewesen";
        
        //EIGENSCHAFTEN (Properties) definieren mittels Getter/Setter den Lese-/Schreibzugriff für jeweils ein Feld.
        ///In den Eigenschaften können bestimmte Bedingungen für das Lesen und Schreiben der Felder gesetzt werden, sowie der Zugriff
        ///für Lesen und Schreiben einzeln angepasst werden
        //Snippet: propfull
        public string Name
        {
            get { return name; }
            set
            {
                //Das Schlüsselwort VALUE beschreibt in einer Set-Methode den übergebenen Wert
                if (value.Length > 0)
                    name = value;
            }
        }

        //Wird in einer Eigenschaft keine Spezifizierung angegeben, generiert das Programm das entsprechende Feld unsichtbar im Hintergrund
        //Snippet: prop
        public string Lieblingsnahrung { get; set; }

        //Property, welche einen komplexen Datentypen abbildet
        public DateTime Geburtsdatum { get; set; }
        //Read-only Property mit Rückbezug auf andere Property
        public int AlterInJahren
        {
            get { return ((DateTime.Now - this.Geburtsdatum).Days / 365); }
        }
        #endregion

        #region Konstruktor
        //KONSTRUKTOREN sind spezielle Methoden, welche ein neues Objekt instanziiert und den Anfangszustand festlegt. Sie definieren sich
        ///durch den Namen (derselbe, wie die Klasse) und den nicht vorhandenen Rückgabetyp (nicht mal void)
        public Lebewesen(string name, string lieblingsnahrung, DateTime geburtsdatum)
        {
            this.Name = name;
            this.Lieblingsnahrung = lieblingsnahrung;
            this.Geburtsdatum = geburtsdatum;
        }

        //Es können mehrere Konstruktoren definiert werden, welche unterschiedliche Übergabeparameter haben (Überladung). Ein Konstruktor, der keine
        //Übergabeparameter hat, wird als Basiskonstruktor bezeichnet
        public Lebewesen()
        {

        }
        #endregion

        #region Methoden

        //MEMBERMETHODEN sind Funktionen, welche jedes Objekt einer Klasse besitzt und speziell mit diesem Objekt interagiert
        public Lebewesen GebäreKind()
        {
            return new Lebewesen(name, "Lassagne", DateTime.Now);
        }


        public virtual void Kommunikation()
        {
            Console.WriteLine("Lebewesen kommuniziert in unbekannter form");
        }

        public override string ToString()
        {
            return $"{Name} ist am liebsten {Lieblingsnahrung} und ist {AlterInJahren} alt";
        }




        #endregion
    }

    
    
    public class Mensch : Lebewesen
    {
        
        public string Vorname { get; set; }
        public string Wohnort { get; set; }

        public Mensch(string vorname, string wohnort, string name, string lieblingsnahrung, DateTime geburtsdatum)
            : base(name, lieblingsnahrung, geburtsdatum)
        {
            Vorname = vorname;
            Wohnort = wohnort;
        }


        public void Spricht(string dialog)
        {
            Console.WriteLine($"Mensch spricht > {dialog}");
        }

        public override void Kommunikation()
        {
            //base.Kommunikation();
            Console.WriteLine("Der Mensch spricht in Silben");
        }

        public override string ToString()
        {
            return $"{Name} aus {Wohnort} speist am liebsten {Lieblingsnahrung} in und ist {AlterInJahren} alt";
        }
    }


    public class Reptil : Lebewesen
    {
        public decimal WinterschlafBeiTemperatur { get; set; }

        public Reptil(decimal winterschlafBeiTemperatur, string name, string lieblingsnahrung, DateTime geburtsdatum)
            :base (name, lieblingsnahrung, geburtsdatum)
        {
            WinterschlafBeiTemperatur = winterschlafBeiTemperatur;
        }

        public override void Kommunikation()
        {
            Console.WriteLine("Kommunikation über Morse-Zeichen, mithilfe von Füssen");
        }
    }

    public class Krokodil : Reptil
    {
        public bool SüßwasserKrokodil { get; set; }
        public void Jagdrolle(Lebewesen beuteLebewesen)
        {
            Console.WriteLine($"Beim Jagen erfasst das Krododil die Beute {beuteLebewesen.Name}");
        }

        public Krokodil(bool süßwasserKrokodil, decimal winterschlafBeiTemperatur, string name, string lieblingsnahrung, DateTime geburtsdatum)
            :base(winterschlafBeiTemperatur, name, lieblingsnahrung, geburtsdatum)
        {
            SüßwasserKrokodil = süßwasserKrokodil;
        }
    }

    public class Spider : Reptil
    {
        public bool VerwendetEinNetz { get; set; }

        public Spider(bool verwendetEinNetz, decimal winterschlafBeiTemperatur, string name, string lieblingsnahrung, DateTime geburtsdatum)
             : base(winterschlafBeiTemperatur, name, lieblingsnahrung, geburtsdatum)
        {
            VerwendetEinNetz = verwendetEinNetz;
        }

        public override void Kommunikation()
        {
            Console.WriteLine("Verwenden eine geheime Technologie via WLAN -> SpiderNet");
        }

        public override string ToString()
        {
            return "Spinne bestellt Fliegen via SpiderNet";
        }
    }
}