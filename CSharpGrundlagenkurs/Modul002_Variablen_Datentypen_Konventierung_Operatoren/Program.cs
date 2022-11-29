//
using System;
using System.Net.Http.Headers;

namespace Modul002_Variablen_Datentypen_Konventierung_Operatoren
{

    
    //Programm-Klasse beinhaltet den Einstiegspunkt des Programms und muss in jedem C# Programm vorhanden sein (Alternativ Top-Level Statement) 
    internal class Program
    {
        //Main-Methode ist der Einstiegspunkt, bzw erste aufgerufene Funktion. Es können auch Parameter übergeben werden 



        /// <summary>
        /// Main Methode
        /// </summary>
        /// <param name="args">Parameter die man bei Aufruf der Exe-Datei mit übergeben kann</param>
        static void Main(string[] args)
        {
            #region Einstieg - Deklaration und Initialisierung von Variablen 

            Console.WriteLine("Hello, World!");

            //Deklaration einer Variablen

            int alter; //Default wäre hier der Wert 0

            //Initialisierung einer Variable 
            alter = 32;

            //string sind Zeichenketten 
            string stadt = "Berlin";
            


            //Es gibt einen Trick für schnellere Schreibweise von Console.WriteLine("..");
            //Shortcut -> cw + tab + tab -> Console.WriteLine();
            Console.WriteLine(stadt);

            int doppeltesAlter = alter * 2;
            Console.WriteLine(doppeltesAlter);

            // Das Ergebnis von beiden Werten wird in der Ausgabe repräsentiert
            Console.WriteLine( doppeltesAlter + " + " + alter + " = " + (doppeltesAlter + alter));

            
            char textzechen = 'A';

            Console.WriteLine(textzechen);

            #endregion

            #region Ausgabe von Strings
            //SO bitte nicht
            string term = "Ich bin " + alter + " Jahre alt und wohne in " + stadt + ".";
            Console.WriteLine(term);

            //Verwandter zum printf-Befehl 
            Console.WriteLine("Ich bin jetzt {0} und wohne in {1}", alter, stadt);


            //Best Practise
            //$-Operator (Variablen werden direkt in {} - Klammern geschrieben 
            term = $"Ich bin {alter} Jahre alt und wohne in {stadt}.";
            Console.WriteLine(term);
            Console.WriteLine($"Ich bin jetzt {alter *2} und wohne in {stadt}.");

            int a = 55;
            int b = 15;
            Console.WriteLine($"{a} + {b} = {a+b}");

            //String-Formatierung mittels Escape-Sequenzen  -> https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/

            string bsp = "Dies ist ein \tTabulator und dies ist ein \n Zeilenumbruch";
            Console.WriteLine(bsp);
            //Programm stoppt, bis eine Tastatureingabe erfolgt 


            string theOldPathStyle = "C:\\Windows\\Temp";

            string bestPracticePath = @"C:\Windows\Temp"; //intern -> C:\\Windows\\Temp

            string verbatim = $@" Dies ist ein    Tabulator und dies ein
Zeilenumbruch {stadt}";

            Console.WriteLine(verbatim);

            #endregion


            #region Eingabe eines Strings

            Console.Write("Bitte gib einen Namen ein: ");
            string name = Console.ReadLine();
            Console.WriteLine(name);

            #endregion

            #region Eingabe einer Zahl + Umwandlung in Integer

            Console.WriteLine("Bitte gib deine Lieblingszahl ein:");
            string zahlAlsString = Console.ReadLine();


            //Variante 1 (älteste Schreibweise in .NET) String-Zahl -> wird nummerische Zahl (int)

            int zahl;

            //zahl = Convert.ToInt32(zahlAlsString); 

            //Variante 2 (
            //zahl = int.Parse(zahlAlsString);



            #region Zusatz -> int.TryParse
            //TryParse gibt an, ob das Konventieren erfolgreich war 
            if (int.TryParse(zahlAlsString, out zahl))
            {
                //Erfolgreich
                Console.WriteLine(zahl);
            }
            else
            {
                //Eingabefehler
                Console.WriteLine($"Konventierung hat nicht geklappt -> Eingabe war {zahlAlsString}");
            }


            #endregion

            #region Zahl -> String
            //Implziete Konventierung -> WriteLine wandelt automatisch um
            Console.WriteLine(zahl);

            //Zahl wird in ein String mithilfe der Methode ToString() konventiert
            zahlAlsString = zahl.ToString();
            #endregion


            #region Casten von Variablen

            int intZahl = 33;

            //Implizietes Casten
            double doubleZahl = intZahl; //33.0000
            doubleZahl = 45.51;

            //Explizietes Casten (müssen Zieldatentyp angeben) 
            intZahl = (int)doubleZahl; //45

            #endregion


            #endregion





            Console.ReadKey();

        }
    }
}