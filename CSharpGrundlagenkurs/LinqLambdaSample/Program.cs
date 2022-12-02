namespace LinqLambdaSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> personenListe = new List<Person>();
            personenListe.Add(new Person(1, "Otto", 44));
            personenListe.Add(new Person(2, "Eva", 21));
            personenListe.Add(new Person(3, "Karl", 34));

            personenListe.Add(new Person(4, "Hannes", 56));
            personenListe.Add(new Person(5, "Andre", 78));
            personenListe.Add(new Person(6, "Bill", 12));

            personenListe.Add(new Person(7, "James", 32));
            personenListe.Add(new Person(8, "Anna", 23));
            personenListe.Add(new Person(9, "Lena", 29));


            //Beide befinden sich im Namespace: System.Linq;

            //Was war ein Linq-Statement -> 101 Sample -> 

            List<Person> personenUnter30 = (from p in personenListe
                                            where p.Alter < 30
                                            orderby p.Name
                                            select p).ToList();

            //Linq-Functions ->  personenListe.Where(...)
            //Lambda Expression -> p => p.Alter < 30

            List<Person> personenUnter30B = personenListe.Where(p => p.Alter < 30)
                                                         .OrderBy(p=>p.Name)
                                                         .ToList();



            #region Linq-Function -> Mathematische Funktionen 

            double altersdurschnittAllerPersonen = personenListe.Average(p =>p.Alter);
            double altersdurschnittAllerPErsonenUeber30 = personenListe.Where(p=>p.Alter > 30)
                                                                       .Average(p=>p.Alter);

            int gesamtesAlterAllerPersonen = personenListe.Sum(p=>p.Alter);
            #endregion

            #region Einzelene Datensätze ermitteln
            Person erstePersonInListe = personenListe.First(); //Erste Person in der Liste
            Person letztePersonInListe = personenListe.Last(); //Letze Person in Liste
            //getbyId wird es gerne verwendet
            Person eindeutigePerson = personenListe.Single(p => p.Id == 1);

            Person? person = personenListe.SingleOrDefault(p => p.Id == 112);

            if (person == null)
                Console.WriteLine("Person wurde nicht gefunden");

            #endregion




            #region Exkursus Nullbare Datentypen
            int intergerVariable;

            int? nullableInteger = null; 

            if (nullableInteger.HasValue)
                Console.WriteLine(nullableInteger.Value);
           
            #endregion
        }
    }


    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Alter { get; set; }

        public Person(int id, string name, int alter)
        {
            Id = id;
            Name = name;
            Alter = alter;
        }
    }
}