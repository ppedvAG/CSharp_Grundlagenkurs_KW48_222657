namespace Modul006_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ändern des durch Console verwendeten Zeichensatzes auf Unicode (damit das €-Zeichen angezeigt werden kann)
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            #region Lab 06: Fahrzeug-Klasse
            //Deklaration einer Fahrzeug-Variablen und Initialisierung mittels einer Fahrzeug-Instanz
            Fahrzeug fz1 = new Fahrzeug("Mercedes", 190, 23000);
            
            
            
            
            //Ausführen der Info()-Methode des Fahrzeugs und Ausgabe in der Konsole
            Console.WriteLine(fz1.Info() + "\n");

            //Diverse Methodenausführungen
            fz1.StarteMotor();
            fz1.Beschleunigung(120);
            Console.WriteLine(fz1.Info() + "\n");

            fz1.Beschleunigung(300);
            Console.WriteLine(fz1.Info() + "\n");

            fz1.StoppeMotor();
            Console.WriteLine(fz1.Info() + "\n");

            fz1.Beschleunigung(-500);
            fz1.StoppeMotor();
            Console.WriteLine(fz1.Info() + "\n");
            #endregion
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
            if(MotorLäuft)
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

        public void Beschleunigung (int a)
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


 

}