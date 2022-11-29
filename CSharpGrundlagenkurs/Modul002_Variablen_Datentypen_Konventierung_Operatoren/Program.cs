//
using System;

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



            //Programm stoppt, bis eine Tastatureingabe erfolgt 
            Console.ReadKey(); 
        }
    }
}