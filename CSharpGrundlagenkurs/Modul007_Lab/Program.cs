namespace Modul007_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }


    public class Fahrzeug
    {
        public string Name { get; set; }

        public int MaxGeschwindigkeit { get; set; }
        public int AktGeschwindigkeit { set; get; }

        public double Preis { get; set; }
        public bool MotorLäuft { get; set; }

        public Fahrzeug(string name, int maxG, double preis)
        {
            Name = name;
            MaxGeschwindigkeit = maxG;
            Preis = preis;

            AktGeschwindigkeit = 0;
            MotorLäuft = false;
        }

        public void StarteMotor()
        {
            if (MotorLäuft)
            {
                Console.WriteLine($"Der Motor von {Name} läuft bereits");
            }
            else
            {
                MotorLäuft = true;
                Console.WriteLine($"Der Motor von {Name} wurde gestartet");
            }
        }

        public void StoppeMotor()
        {
            //Ist der Motor schon aus? 
            if (!MotorLäuft)
            {
                Console.WriteLine($"Der Motor von {this.Name} ist bereits gestoppt");
            }
            else if (AktGeschwindigkeit > 0)
                Console.WriteLine($"Der Motor kann nicht gestoppt werden, da sich {this.Name} noch bewegt");
            else
            {
                MotorLäuft = false;
                Console.WriteLine($"Der Motor von {this.Name} wurde gestoppt");
            }
        }

        public void Beschleunigung(int a)
        {
            if (MotorLäuft)
            {
                if (AktGeschwindigkeit + a > MaxGeschwindigkeit)
                    AktGeschwindigkeit = MaxGeschwindigkeit;
                else if (AktGeschwindigkeit + a < 0)
                    AktGeschwindigkeit = 0;
                else
                    AktGeschwindigkeit += a;

                Console.WriteLine($"{this.Name} bewegt sich jetzt mit {this.AktGeschwindigkeit}km/h");
            }
        }

        public void Bremsen()
        {
            if (MotorLäuft)
            {
                if (AktGeschwindigkeit - 20 > 0)
                    AktGeschwindigkeit -= 20;
                else
                    AktGeschwindigkeit = 0;
            }
        }

        public string Info()
        {
            if (this.MotorLäuft)
                return $"{this.Name} kostet {this.Preis}€ und fährt momentan mit {this.AktGeschwindigkeit} von maximal {this.MaxGeschwindigkeit}km/h.";
            else
                return $"{this.Name} kostet {this.Preis}€ und könnte maximal {this.MaxGeschwindigkeit}km/h fahren.";
        }


    }



    public class Schiff : Fahrzeug
    {
        public double Tiefgang { get; set; }

        public Schiff(string name, int maxG, double preis, double tiefgang)
            :base (name, maxG, preis)
        {
            Tiefgang = tiefgang;
        }
    }

    public class PKW : Fahrzeug
    {
        public int AnzahlTüren { get; set; }
        public bool MitAnhängerKupplung { get; set; }

        public PKW(string name, int maxG, double preis, int anzahlDerTüren, bool mitAnhängerKupplung)
             : base(name, maxG, preis)
        {
            AnzahlTüren = anzahlDerTüren;
            MitAnhängerKupplung = mitAnhängerKupplung;
        }
    }

    public class Flugzeug : Fahrzeug
    {
        public int MaxFlughoehe { get; set; }
        public double Spannweite { get; set; }

        public Flugzeug(string name, int maxG, double preis, int maxFlughoehe, int spannweite)
            :base(name, maxG, preis)
        {
            MaxFlughoehe = maxFlughoehe;
            Spannweite = spannweite;
        }
    }

}