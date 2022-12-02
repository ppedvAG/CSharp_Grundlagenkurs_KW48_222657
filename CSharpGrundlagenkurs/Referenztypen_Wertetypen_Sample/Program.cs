namespace Referenztypen_Wertetypen_Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Was sind Wertetypen: 
            //int, long, short, byte, bool, decimal, float, double, struct

            //Was sind Referenztypen:
            //objekte, interface, 
            //string (ist Referenztypen) 


            SPerson personS = new SPerson("Anna", 30);
            CPerson personC = new CPerson("Bert", 30); //personC hat die Adresse im Speicher: 0x123

            PersonSAltern(personS);



            PersonCAltern(personC);

            Console.WriteLine("Personen-Struct -> Alter: " + personS.Age);
            Console.WriteLine("Personen-Klasse -> Alter: " + personC.Age);


            int meinAlter = 38;
            Altern(meinAlter); //Ich gebe eine Kopie hier herüber
            
            
            
            //Mit ref, out in, können Wertetypen, wie Referenztypen behandelt werden
            

            //ref ist Allgemein
            //out ist auch wie 'ref' ABER mit REGEL -> Es muss initialiisert werden 
            //in ist auch wie 'ref' ABER nur Readonly 

            AlternMitReference(ref meinAlter); //Wir wollen den Wertetyp als Referenztyp verwenden
            Console.WriteLine(meinAlter);

            string numberAlsText = "123";
            int number;
            if (int.TryParse(numberAlsText, out number)) //number wird bei erfolgreichen konventieren befüllt und wir können es verwenden
            {
                Console.WriteLine(number); //123 wird ausgegeben
            }
        }



        public static void Altern(int age)
        {
            age++;
        }


        //ref / out / in
        public static void AlternMitReference(ref int age) //Gebe keine Kopie von sondern die Referenz
        {
            age++;
        }



        public static void PersonSAltern(SPerson sPerson)
        {
            sPerson.Age++;
        }
        public static void PersonCAltern(CPerson cPerson) //
        {
            //cPerson -> 0x123 
            cPerson.Age++;
            cPerson.Name = "Gustav"; 
        }

        //Ein Struct ist ein Wertetyp -> es kann Eigentschaften / Konstruktoren / Methoden usw..wie bei einer Klasse darstellen.
        //Ist ein Wertetyp

        public struct SPerson
        {
            public int Age { get; set; }    
            public string  Name { get; set;}

            public SPerson(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }


        public class CPerson
        {
            public int Age { get; set; }
            public string Name { get; set; }

            public CPerson(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }
    }
}