using System;

namespace Modul009_StaticMethods
{
    //Program.Main 
    internal class Program
    {
        static void Main(string[] args)
        {
            //Fügen diese in Firmenliste hinzu
            //List<Employee> alleMitarbeiterInMeinerFirma = new List<Employee>();

            ////Mitarbeiter
            //alleMitarbeiterInMeinerFirma.Add(contractedEmployee1);
            //alleMitarbeiterInMeinerFirma.Add(contractedEmployee2);
            //alleMitarbeiterInMeinerFirma.Add(contractedEmployee3);

            ////Freiberufler
            //alleMitarbeiterInMeinerFirma.Add(freelancer1);
            //alleMitarbeiterInMeinerFirma.Add(freelancer2);
            //alleMitarbeiterInMeinerFirma.Add(freelancer3);

            ////Praktikanten
            //alleMitarbeiterInMeinerFirma.Add(trainee1);
            //alleMitarbeiterInMeinerFirma.Add(trainee2);

            ////Intern 
            //alleMitarbeiterInMeinerFirma.Add(intern1);


            Methode();

            //Hier wissen wir, dass die Objekt-Instanzen in Methode() nicht mehr verwendbar
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine(Employee.ZeigeAnzahlDerMitarbeiterAn());




            #region Einstiegs-Sample static anhand von Strings

            string meinText = "Hallo Welt";

            //Methoden für String-Manipulation werden über die Variable 'meintText' angeboten 
            meinText.StartsWith("Hallo");
            meinText.Substring(0, 5); //Hole mir von Index 0 (ersterBuchstabe im String), bis zu den nächsten 5 Zeichen

            //Der Datentyp string hat auch Hilfsmethoden

            //string.Empty hilf einen leeren String zu initialisieren
            string text = string.Empty;

            //IsNullOrEmpty ist eine Hilfsmethode, um auszusagen ob der String befüllt
            if (string.IsNullOrEmpty(text))
            {

            }

            #endregion
        }


        static void Methode()
        {

            ContractedEmployee contractedEmployee1 = new ContractedEmployee() { FirstName = "Petra", LastName = "Musterfrau" };
            ContractedEmployee contractedEmployee2 = new ContractedEmployee() { FirstName = "Peter", LastName = "Mustermann" };
            ContractedEmployee contractedEmployee3 = new ContractedEmployee() { FirstName = "Jan", LastName = "Muster" };

            Freelance freelancer1 = new Freelance() { FirstName = "Mareike", LastName = "Coder", Stundenanzahl = 140, Stundensatz = 120 };
            Freelance freelancer2 = new Freelance() { FirstName = "Mike", LastName = "Buger", Stundenanzahl = 90, Stundensatz = 160 };
            Freelance freelancer3 = new Freelance() { FirstName = "Frauke", LastName = "Coder", Stundenanzahl = 100, Stundensatz = 70 };

            Trainee trainee1 = new Trainee() { FirstName = "Pascal", LastName = "Müller", TarifSalary = 1000 };
            Trainee trainee2 = new Trainee() { FirstName = "Heike", LastName = "Müller", TarifSalary = 1000 };

            Intern intern1 = new Intern() { FirstName = "Theo", LastName = "Muster" };


            Console.WriteLine(Employee.ZeigeAnzahlDerMitarbeiterAn());
        } //Hier unten werden alle Objekt instancen und Variablen wieder freigegeben...bzw Dekonstruktor sollte ausgeführt werden 
    }

    #region Virtual Sample
    //Virtuelle Methoden haben eine allgemeine Basis-Implementierung
    //Wenn wir am Beispiel ToString() keine Überschreibung (override) vornehmen wird -> Namespace.Klassenname ausgegeben
    //Mithilfe von override ToString() kann meine Klasse bestimmen, was ausgegeben wird. 

    public class PersonA
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            //string result = base.ToString();
            return $"{FirstName} {LastName} wohnt in {City}";
        }
    }

    public class Mitarbeiter : PersonA
    {
        public string Company { get; set; }
        public int Salary { get; set; }

        public override string ToString()
        {
            //Man kann mit der base.ToString() auf Person.ToString() zugreifen
            string ergebnisMeineBaseMethode = base.ToString();
            ergebnisMeineBaseMethode += $"und arbeitet mit einem Verdienst von {Salary} bei {Company}";
            return ergebnisMeineBaseMethode;


            //return $"{FirstName} {LastName} wohnt in {City} und arbeitet mit einem Verdienst von {Salary} bei {Company}";
        }
    }
    #endregion

    #region Abstract Sample

    //Employee ist eine Schablone für (ContractedEmployee, Freelance)
    //Employee kann als Objekt ansich verwendet werden 
    public abstract class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static int AnzahlDerMitarbeiter = 0;
        public static string ZeigeAnzahlDerMitarbeiterAn()
        {
            return $"Es gibt {AnzahlDerMitarbeiter} Mitarbeiter";
        }


        //In den Verbten Klassen wirst du ausprogrammiert 
        //abstrakte Methoden sind eine Muss-Implementierung in der Verbten klassen
        public abstract double Salary();

        public Employee()
        {
            AnzahlDerMitarbeiter++;
        }

        //Dekonstruktor wird aufgerufen, wenn das OBjekt vom Garbage Collector abgegaubt wird
        ~Employee()
        {
            AnzahlDerMitarbeiter--;
        }


    };

    //vertraglicher Mitarbeiter
    public class ContractedEmployee : Employee, IBetriebsratSupport
    {
        public int TarifSalary { get; set; } = 4500;
        public int Boni { get; set; } = 500;

        public ContractedEmployee()
            : base()
        {

        }

        public override double Salary()
        {
            return TarifSalary + Boni;
        }

        public void Betriebsrente()
        {
            //
        }

        public int KuendigungsschutzInMonaten()
        {
            return 5; //5 Monate 
        }

        //Factory Methode
        public static ContractedEmployee CreateEmployee()
        {
            return new ContractedEmployee() { FirstName = "Petra", LastName = "Musterfrau" };
        }

    }

    //Freiberufler
    public class Freelance : Employee
    {

        public Freelance()
            : base()
        {

        }
        public int Stundensatz { get; set; } = 75;
        public int Stundenanzahl { get; set; } = 0;

        public override double Salary()
        {
            return Stundensatz * Stundenanzahl;
        }
    }

    //Azubi
    public class Trainee : Employee, IBetriebsratSupport
    {

        public Trainee()
            :base()
        {

        }
        public int TarifSalary { get; set; } = 1200;

        public override double Salary()
        {
            return TarifSalary;
        }

        public int KuendigungsschutzInMonaten()
        {
            return 3; //5 Monate 
        }
    }

    //Praktikant
    public class Intern : Employee
    {

        public Intern()
            : base()
        {

        }
        public int InternSalary { get; set; } = 0;
        public override double Salary()
        {
            //Random random =new Random();
            //random.Next();
            InternSalary = new Random().Next(0, 1000);

            return InternSalary;
        }
    }


    #endregion

    #region Interface

    public interface IBetriebsratSupport
    {
        public int KuendigungsschutzInMonaten();
    }

    #endregion
}