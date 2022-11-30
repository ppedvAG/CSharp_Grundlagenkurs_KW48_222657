using System.Net.WebSockets;
using System.Runtime.CompilerServices;

namespace Modul006_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Einstiegs-Beispiel - Variablen und Properties
            //erstellen von der Klasse Lebewesen eine Objekt-Instanz -> lebenwesen
            Lebewesen lebewesen = new Lebewesen();

            lebewesen.Name = "Delfin";
            lebewesen.Geburtsdatum = new DateTime(1983, 7, 7);

            
            int alterInJahren = lebewesen.AlterInJahren;

            lebewesen.Lieblingsnahrung = "Fische";
            #endregion


            #region Konstruktoren

            Lebewesen lebewesenMensch = new Lebewesen("Goldfisch", 30, "See", "gold", new DateTime(2001,1,2));
            lebewesenMensch.Name = "Mensch";
            lebewesen.Geburtsdatum = new DateTime(1955, 5, 3);
            lebewesen.Lebensraum = "Berlin-Köpenick";
            lebewesen.Farbe = "bunt";
            lebewesen.Gewicht = 100;

            


            Lebewesen katze = new Lebewesen("Katze", 5, "Garten", "bunt", new DateTime(2011, 2, 2), 30);

            #endregion

            #region Methoden -> Was kann ein Objekt alles tun 

            lebewesen.Atmen();


            Lebewesen babyLebewesen = lebewesen.GeburtEinesLebewesen();

            #endregion
        }
    }


    //Klassen sind Vorlagen für Objekte. Sie bestimmen Eigenschaften und Funktionen.
    public class Lebewesen
    {
        #region Klassenvariable / Fields
        //Klassenvariablen
        private DateTime    geburtsdatum;
        private double      gewicht;
        private string      name;

        private string      lieblingsnahrung;

        private string      lebensraum;


        #endregion


        #region Konstruktoren

        //KONSTRUKTOREN sind spezielle Methoden, welche ein neues Objekt instanziiert und den Anfangszustand festlegt. Sie definieren sich
        ///durch den Namen (derselbe, wie die Klasse) und den nicht vorhandenen Rückgabetyp (nicht mal void)


        //Wenn eine Klasse keinen Konstruktor beinhaltet, wird ein Default Konstrutkor beim Kompilieren hinzugefügt. 


        //ctor + tab +tab -> Default Konstruktor 


        //Default-Konstuktor
        public Lebewesen()
        {
            Name = "Alf";
            Gewicht = 30;
            Lebensraum = "Küche";
            Farbe = "Braun";

            Geburtsdatum = new DateTime(); //Default-Werte eines Datums sind 1.1.0001

            Geburtsdatum = new DateTime(1980, 3, 2); //Expliziete Werte für ein Datum
        }

       
        //WerteKonstruktor
        public Lebewesen(string name, double gewicht, string lebensraum, string farbe, DateTime geburtsdatum)
        {
            Name = name;
            Gewicht = gewicht;
            Lebensraum = lebensraum;    
            Farbe = farbe;
            Geburtsdatum = geburtsdatum;
        }

        //Verkettung von Werte-Konstuktoren - Für Version 2.0
        public Lebewesen(string name, double gewicht, string lebensraum, string farbe, DateTime geburtsdatum, double size)
            : this(name, gewicht, lebensraum, farbe, geburtsdatum) //Properties aus Version 1.0 -> wird von dem alten Konstruktor befüllt. 
        {
            //Expliziet für die neue Version wird Size befüllt
            Size = size;
        }


        //Kopier-Kontruktoren 
        public Lebewesen(Lebewesen lebewesen)
        {
            Name = lebewesen.Name;
            Lebensraum = lebewesen.Lebensraum;
            Geburtsdatum = lebewesen.Geburtsdatum;
            //...
        }

        #endregion


        #region Properties

        //Property (Eigenschaft) -> Kapselt eine Variable nach draußen
        public string Name
        {
            set
            {
                //Regel einbauen, welche Art von Values gesetzt werden dürfen 
                if (value.Length > 0)
                {
                    name = value;
                }
            }

            get
            {
                return name;
            }
        }

        public double Gewicht
        {
            set
            {
                if (value > 0)
                {
                    gewicht= value; //Gewicht bekommt einen validen Wert über 0
                }
            }
        }

        public DateTime Geburtsdatum 
        {
            get
            {
                return geburtsdatum;
            }

            set
            {
                geburtsdatum = value;
            }
        }

        public int AlterInJahren
        {
            get
            {
                TimeSpan result = DateTime.Now - geburtsdatum;



                int jahre = result.Days / 365;

                return ((DateTime.Now - geburtsdatum).Days / 365);
            }
        }


        //Eine Auto-Property -> Wird in einer Eigenschaft keine Spezifizierung angegeben,
        // generiert das Programm das entsprechende Feld (variable) unsichtbar im Hintergrund -> Wird verwendet, wenn keine Validierung benötigt wird

        //

        public string Lieblingsnahrung 
        {
            

            get => lieblingsnahrung;

            set
            {
                if (value != "Fisch")
                {
                    //Zeige einen Fehler an -> Delfine essen nur Fische
                }
                else
                    lieblingsnahrung = value;
            }
        }

        //Im Hintergurnd wird eine Variable hinzugefügt (Magic) -> Farbe = "organge" -> wird im Hintergrund die Variable 'farbe' den Wert "organge" zugewiesen 

        public string Farbe { get; set; }
        public string Lebensraum 
        { 
            get => lebensraum; 

            set => lebensraum = value; 
        }

        public double Size { get; set; } //Achtung Version 2.0 

        #endregion


        #region Methoden

        public void Atmen()
        {
            Console.WriteLine($"{Name} atmet im {Lebensraum}");
        }

        public Lebewesen GeburtEinesLebewesen ()
        {
            Lebewesen neuesLebewesen = new Lebewesen(Name, 1.5, Lebensraum, Farbe, DateTime.Now, 5);



            return neuesLebewesen;
        }

        #endregion
    }



    public class Person
    {
        public string Firstname { get; set; }

        public string MiddleName { get; set; }

        public string Lastname { get; set; }


        public string FullName
        {
            get
            {
                string fullname = string.Empty;

                //Ist der String befüllt?
                if (!string.IsNullOrEmpty(Firstname))
                    fullname += Firstname;

                if (!string.IsNullOrEmpty(MiddleName))
                    fullname += MiddleName;

                if (!string.IsNullOrEmpty(Lastname))
                    fullname += Lastname;

                return fullname;
            }
        }

    }


}