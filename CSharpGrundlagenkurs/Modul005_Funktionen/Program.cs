namespace Modul005_Funktionen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 11;
            int b = 12;

            //Methodenaufruf mit Parameter und Rückgabewert
            int result = Addieren(a, b); 
            Console.WriteLine(result); //23


            double c = 11.4;
            double d = 23.7;
            //Überladung einer Methode 
            double resultB =  Addieren(c, d);
            Console.WriteLine(resultB);

            //Verwenden von Params
            int erg = BildeSumme(2, 5, 4, 3, 6, 3, 2, 6, 34, 3, 4, 6, 3, 2222, 44);


            //Verwenden ohne Params 
            int[] array = { 1, 4, 6, 34, 21 };
            erg = BildeSummeWithoutParams(array);


            erg = Subtrahieren(22, 11);//c = 0 und d = 0
            erg = Subtrahieren(33, 1, 4); // d = 0
            erg = Subtrahieren(100, 2, 3, 5); //c und d haben expliziet einen Wert zugewiesen bekommen 

        }


        //Jede Funktion/Methode besteht aus einem Kopf und einem Körper
        ///Der Kopf besteht aus den MODIFIERN (public static), dem RÜCKGABEWERT (int), dem NAMEN (Addiere) sowie den ÜBERGABEPARAMETERN <summary>
        /// Der Kopf besteht aus den MODIFIERN (public static), dem RÜCKGABEWERT (int), dem NAMEN (Addiere) sowie den ÜBERGABEPARAMETERN
        
        /// </summary>
        /// <param name="a">Parameter 1</param>
        /// <param name="b">Parameter 2</param>
        /// <returns>Summe</returns>
        static int Addieren(int a, int b)
        {
            return a + b;
        }

        static int Addieren(int a, int b, int c)
            => Addieren(a, b) + c;

        static double Addieren(double a, double b)
        {
            return a + b;
        }


        //Params wird selten verwenden

        //Das PARAMS-Stichwort erlaubt die Übergabe einer beliebige Anzahl von gleichartigen Daten, welche innerhalb
        //der Methode als Array interpretiert werden
        static int BildeSumme(params int[] summanden)
        {
            int summe = 0;

            foreach (int currentSummanden in summanden)
            {
                summe = summe + currentSummanden; //summe += currentSummanden;
            }

            //Best Practice
            //int result = summanden.Sum();

            return summe;
        }

        static int BildeSummeWithoutParams(int[] summanden)
            => summanden.Sum();



        ///Wird einem Parameter mittels =-Zeichen ein Defaultwert zugewiesen wird dieser Parameter OPTIONAL und muss bei Aufruf nicht zwangs-
        ///läufig mitgegeben werden. OPTIONALE Parameter müssen am Ende der Parameter stehen.
        static int Subtrahieren(int a, int b, int c=0, int d = 0)
        {
            return a - b - c - d;
        }

    }
}