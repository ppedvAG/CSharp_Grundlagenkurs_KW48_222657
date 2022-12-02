using System.Collections;

namespace WdhTag3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.OutputEncoding.
            #region Virtual Sample
            PersonA person = new PersonA() { FirstName = "Otto", LastName = "Walkes", City = "Ostfriesland" };

            Mitarbeiter mitarbeiter = new Mitarbeiter { FirstName = "Steffi", LastName = "Muster", City = "Freiburg", Company = "Microsoft", Salary = 120000 };

            //Ohne override -> WdhTag3.Person 
            //mit override -> 
            Console.WriteLine(person.ToString());
            Console.WriteLine(mitarbeiter.ToString());

            #endregion

            #region Abstract Sample
            //Siehe Verbte Klassen von Employee
            #endregion

            #region Polymorphie



            //Erstellen 3 vertragloche Mitarbeiter
            ContractedEmployee contractedEmployee1 = new ContractedEmployee() { FirstName = "Petra", LastName = "Musterfrau" };
            ContractedEmployee contractedEmployee2 = new ContractedEmployee() { FirstName = "Peter", LastName = "Mustermann" };
            ContractedEmployee contractedEmployee3 = new ContractedEmployee() { FirstName = "Jan", LastName = "Muster" };

            Freelance freelancer1 = new Freelance() { FirstName = "Mareike", LastName = "Coder", Stundenanzahl = 140, Stundensatz = 120 };
            Freelance freelancer2 = new Freelance() { FirstName = "Mike", LastName = "Buger", Stundenanzahl = 90, Stundensatz = 160 };
            Freelance freelancer3 = new Freelance() { FirstName = "Frauke", LastName = "Coder", Stundenanzahl = 100, Stundensatz = 70 };

            Trainee trainee1 = new Trainee() { FirstName = "Pascal", LastName = "Müller", TarifSalary = 1000 };
            Trainee trainee2 = new Trainee() { FirstName = "Heike", LastName = "Müller", TarifSalary = 1000 };

            Intern intern1 = new Intern() { FirstName = "Theo", LastName = "Muster" };


            //Fügen diese in Firmenliste hinzu
            List<Employee> alleMitarbeiterInMeinerFirma = new List<Employee>();

            //Mitarbeiter
            alleMitarbeiterInMeinerFirma.Add(contractedEmployee1);
            alleMitarbeiterInMeinerFirma.Add(contractedEmployee2);
            alleMitarbeiterInMeinerFirma.Add(contractedEmployee3);

            //Freiberufler
            alleMitarbeiterInMeinerFirma.Add(freelancer1);
            alleMitarbeiterInMeinerFirma.Add(freelancer2);
            alleMitarbeiterInMeinerFirma.Add(freelancer3);

            //Praktikanten
            alleMitarbeiterInMeinerFirma.Add(trainee1);
            alleMitarbeiterInMeinerFirma.Add(trainee2);

            //Intern 
            alleMitarbeiterInMeinerFirma.Add(intern1);

            double gehaltsPostenAlleMitarbeiterInEinemMonat = 0;

            double gehaltAllerVertragsMitarbeiter = 0;
            double gehaltAllerFreiberufler = 0;
            double gehaltAlleTrainees = 0;

            for (int i = 0; i < alleMitarbeiterInMeinerFirma.Count; i++)
            {
                //Employee ist nur ein Platzhalter für die Verebten Objekte (Klasse) 
                Employee employee = alleMitarbeiterInMeinerFirma[i];

                gehaltsPostenAlleMitarbeiterInEinemMonat += employee.Salary();

                //Casten-> employee object ist eigentlich ein ContractedEmployee...dann bieten wir die ControctedEmployee-Struktur an. 
                if (employee is ContractedEmployee contractedEmployee)
                {

                    gehaltAllerVertragsMitarbeiter += contractedEmployee.Salary();
                    contractedEmployee.Betriebsrente();

                    Console.WriteLine($"Vertraglicher Mitarbeiter {contractedEmployee.FirstName} {contractedEmployee.LastName} verdient {contractedEmployee.Salary}: ");
                    //contractedEmployee.FirstName
                    //contractedEmployee.LastName
                    //contractedEmployee.TarifSalary 
                    //contractedEmployee.Boni
                }
            }

            Console.WriteLine($"Alle Miarbeiten kosten im Monat {gehaltsPostenAlleMitarbeiterInEinemMonat}");
            Console.WriteLine($"Alle Vertraglichen Miarbeiten kosten im Monat {gehaltAllerVertragsMitarbeiter}");
            #endregion

            #region Interfaces

            List<Employee> mitarbeiterDieSofortGekündigtWerdenKönnen = new List<Employee>();
            for (int i = 0; i < alleMitarbeiterInMeinerFirma.Count; i++)
            {
                //Employee ist nur ein Platzhalter für die Verebten Objekte (Klasse) 
                Employee employee = alleMitarbeiterInMeinerFirma[i];


                //Kann ich sofort Kündigen
                if (employee is IBetriebsratSupport employeeWithBetriebsratSupport)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} kann erst in  {employeeWithBetriebsratSupport.KuendigungsschutzInMonaten()} gekündigt werden" );
                }
                else
                    mitarbeiterDieSofortGekündigtWerdenKönnen.Add(employee);


            }

            #endregion
        }
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


        //In den Verbten Klassen wirst du ausprogrammiert 
        //abstrakte Methoden sind eine Muss-Implementierung in der Verbten klassen
        public abstract double Salary();
    };

    //vertraglicher Mitarbeiter
    public class ContractedEmployee : Employee, IBetriebsratSupport
    {
        public int TarifSalary { get; set; } = 4500;
        public int Boni { get; set; } = 500;
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
    }

    //Freiberufler
    public class Freelance : Employee
    {
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