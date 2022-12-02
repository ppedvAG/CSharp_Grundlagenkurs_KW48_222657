using System;
using System.Collections;

namespace Modul009_GenericLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region List
            List<string> list = new List<string>();
            list.Add("Burghausen");
            list.Add("Augsburg");
            list.Add("Passau");

            List<int> integerListe = new List<int>();
            integerListe.Add(1);
            integerListe.Add(2);    
            integerListe.Add(3);    


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


            Person[] personenArray = personenListe.ToArray();



            List<Person> otherPersonList = new List<Person>();
            otherPersonList.AddRange(personenArray); //IEnumerable<Person> ist im Grunde ein Array mit einem MoveNext() Befehl -> Verkette-Liste eines Arrays
            #endregion

            #region Dictionary 
            Dictionary<int, Person> dictionary = new Dictionary<int, Person>();

            //Key muss eindeutig sein!!!!
            dictionary.Add(1, new Person(1, "Otto", 44));



            #region Beispiel2
            Person person = new Person(2, "Harry", 45);

            //Gibt es die den Key mit dem Wert '2' noch nicht?
            if (!dictionary.ContainsKey(person.Id)) 
                dictionary.Add(person.Id, person);


            foreach(KeyValuePair<int, Person> kvp in dictionary)
            {
                //kvp.Key
                //kvp.Value
                Console.WriteLine(kvp.Key);
                Console.WriteLine(kvp.Value.Name);
                //Console.WriteLine(kvp.Value.);
            }

            dictionary.ContainsValue(person);
            #endregion
            #endregion

            #region HashTable
            //Hashtable hashtable = new Hashtable();
            //hashtable.Add("abc", 123123);
            //hashtable.Add(123, "abc");
            //hashtable.Add(person, person);
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