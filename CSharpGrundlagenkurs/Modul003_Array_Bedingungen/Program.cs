using System.Linq;

namespace Modul003_Array_Bedingungen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Arrays
            //ARRAYS

            //Arrays sind Collections, welche mehrere Variablen eines Datentyps speichern können. 
            //Die Größe des Arrays muss bei der Initialisierung entweder durch eine Zahl oder durch die Menger der verwendeten Variablen definiert werden 

            int[] zahlen = { 2, 4, 78, -123, -8, 0, 11111 }; // Array hat eine größe von 7 Elementen (Variablen) 

            //Einfacher Zugriff auf das Array
            Console.WriteLine(zahlen[2]); //78

            //Index fängt immer bei dem Wert 0 an. 
            //Zugriff auf das erste Elemnt im Array
            Console.WriteLine(zahlen[0]); //2

            //Via Index können wir nicht nur auslesen, sondern einen Wert setzen
            zahlen[1] = 123; //aus 4 wird 123


            string[] worte = new string[5]; // Index geht von 0..4
            worte[0] = "Hallo";
            worte[1] = "liebe";
            worte[2] = "Teilnehmer";
            worte[3] = "C#";
            worte[4] = ".NET";

            

            //System.IndexOutOfRangeException: 'Index was outside the bounds of the array.'
            //worte[5] = "Hier passiert eine Exception (Index geht bis zum Wert 4)"; 


            //Gibt es den Wert 78 im Array? Antwort: true oder false 
            Console.WriteLine(zahlen.Contains(78)); // Gibt es die Zahl im Array

            Console.WriteLine(!zahlen.Contains(78)); //Gibt es ncht die Zahl im Array
            
            //ist Vergleichbar mir
            if (zahlen.Contains(78) != true)
            {
                //Zahl 78 ist bisher nicht vergeben
            }

            //Gebe mir die Anzahl der Array-Elemente zurück
            Console.WriteLine($"Das Array hat {zahlen.Length} Elemente");


            //Mehrdimensionales Array (hier 2 Dimensional)
            //int[,] zweiDimArray   = { { 1, 2, 3 }, { 4, 5, 6 }, { 6, 7, 8 }, { 4, 5, 6 }, { 4, 5, 6 } };
            
            
            int[,] zweiDimArray = new int[3, 5];

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 5; y++) 
                {
                    zweiDimArray[x, y] = x * y;
                }
            }

            Console.WriteLine(zweiDimArray[2,3]);
            #endregion

            //int[,,] dreidimensionalesArray = new int[3,2,2]  



            int a = 23;
            int b = 23;

            #region Bedienungen
            if (a < b)
            {
                //Codeblock (mehrere Anweisungen
                Console.WriteLine("A ist kleiner als B");
            }
            else if (a > b)
            {
                Console.WriteLine("A ist größer als B");
            }
            else
            {
                Console.WriteLine("A und B ist gleich groß");
            }

            #endregion


            #region Kurzschreibweise
            string ergebnis = (a == b) ? "A ist gleich B" : "A ist ungleich B"; //Syntax  (Condition)?(True-Anweisung):(False-Anweisung); 
            #endregion

            string name1 = "Otto";
            string name2 = "Otto";

            //Equals vergleicht einen String mit dem anderen String
            if (name1.Equals(name2)) 
            {
                Console.WriteLine("Beide Namen sind gleich");
            }

            if (name1 == name2)
            {
                Console.WriteLine("Beide Namen sind gleich");
            }


            //Modulo 

            int number = 144; 

            if (number % 2 == 0) //Modulo erfragt den Restzahlenwert nach einer Division 
            {
                //Die Zahl ist durch 2 Teilbar 
            }
            else
            {
                //ungerade Zahl
            }
        }

    }
}