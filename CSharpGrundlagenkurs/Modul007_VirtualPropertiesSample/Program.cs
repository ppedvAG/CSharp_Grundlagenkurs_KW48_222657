namespace Modul007_VirtualPropertiesSample
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ApothekenProdukte apothekenProdukte = new ApothekenProdukte("A-1234");

            ElektroArtikel elektroArtikel = new ElektroArtikel("E-1234", 3);

           


            Lebewesen lebewesen = new Lebewesen();
            lebewesen.Geburtstag = new DateTime(1983, 3,3);
            Console.WriteLine(lebewesen.Geburtstag.ToShortDateString());

        }
    }
    #region Sample 1
    public class Lebewesen
    {
        public string Name { get; set; }

        public virtual DateTime Geburtstag { get; set; }
    }

    public class EintagsFliege : Lebewesen
    {
        public override DateTime Geburtstag 
        { 
            get => Geburtstag; 
            
            
            set 
            {
                TimeSpan timeSpan = (DateTime.Now - value);

                if (timeSpan.Days <= 3)
                {
                    Geburtstag = value;
                }
                else
                    Console.WriteLine("Eine Eintagsfliege kann keine 3 Tage überleben");
            } 
        }
    }
    #endregion

    #region Sample2

    public class Artikel
    {
        public virtual string ArtikelNr { get; set; }
        public int Garantie { get; set; } = 0;



        public Artikel(int garantie)
        {
            Garantie = garantie;
        }

        public Artikel(string artikelNr, int garantie)
        {
            ArtikelNr = artikelNr;
            Garantie = garantie;
        }


    }

    public class ElektroArtikel : Artikel
    {
        public ElektroArtikel(string artikelNr, int garantie = 2)
            :base(garantie)
        {
            ArtikelNr = artikelNr;
        }

        public override string ArtikelNr 
        { 
            get => ArtikelNr;

            set
            {
                if (value.StartsWith("E-"))
                    ArtikelNr = value;
                else
                    Console.WriteLine("Artikelnummer passt nicht zu Elektrogeräte"); //Alternative wäre eine Exception besser 
            }
        }
    }


    public class ApothekenProdukte : Artikel
    {
        public ApothekenProdukte(string artikelNr)
            :base(artikelNr, 0)
        {

        }
    }
    




    #endregion





}