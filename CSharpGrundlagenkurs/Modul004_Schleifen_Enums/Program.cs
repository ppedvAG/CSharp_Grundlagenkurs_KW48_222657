namespace Modul004_Schleifen_Enums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Schleifen und Zählen

            int a = 0;
            int b = 10;


            //Kopfgesteuerte Schleife -> Bedeutet: erst die Prüfung, dann der auszuführende Code-Block

            while (a < b) //Wenn a den Wert 10 erreicht, wird die Schleife nicht mehr ausgeführt 
            {
                Console.WriteLine($"A ist kleiner als B! (Wert von a: {a})");
                a++;
            }

            a = -45;

            //DO-WHILE-Schleife (Fussgesteuerte Schleife) 
            ///Auch die DO-WHILE-Schleife wird wiederholt, solange die Bedingung wahr ist. Allerdings wird die Bedingung erst am Schleifen_
            ///ende geprüft, weshalb die Schleife mindestens einmal durchläuft.
            do
            {
                Console.WriteLine(a);

                a = a + 1; // a++ -> erhöht um den Wert 1
            } while (a <  0);



            //Wenn Variablen inkrementiert oder dekrementiert werden müssen, ist eine for-Schleife die bessere Wahl
            for (int i = 0; i < 10; i++)
                Console.WriteLine(i);

            for (int i = -45; i < 0; i++)
                Console.WriteLine(i);
            #endregion

            #region Endlosschleifen
            a = 0;
            b = 10;


            //Endlossschleife

            while (true) //Condition ist immer true 
            {
                a++;
                Console.WriteLine(a);


                //Wie kommen wir aus der Schleife herauf

                if (a > b)
                    break; // Ich springe aus der Schleife heraus
            }




            a = 0;
            b = 100; 
            while (true) //Condition ist immer true 
            {
                a++;
                //Ist das Ende der Schleife erreich? 

                if (a > b)
                    break; // Ich springe aus der Schleife heraus

                //Console.WriteLine(a);

                if (a % 2 != 0)
                    continue; //Bei einer ungeraden Zahl, wird der nächste Schleifen-Intervall angegangen

                Console.WriteLine($"Gerade Zahlen {a}");
            }

            //Endlosschleife mit for 
            //Eine einfache for (a = 0; a < b; a++) ist viel besser
            a = 0;
            b = 100;
            for (;true;)
            {
                a++;
                //Ist das Ende der Schleife erreich? 

                if (a > b)
                    break; // Ich springe aus der Schleife heraus

                //Console.WriteLine(a);

                if (a % 2 != 0)
                    continue; //Bei einer ungeraden Zahl, wird der nächste Schleifen-Intervall angegangen

                Console.WriteLine($"For-Schleife -> Gerade Zahlen {a}");
            }

            #endregion

            #region for-Schleife vs. foreach-Schleife 
            int[] zahlen = { 2, 3, 5, 4 };

            //Iteration über ein Array mittels For-Schleife
            for (int i = 0; i < zahlen.Length; i+=2) //ich muss nicht unbedingt mit den Wert 1 erhöhen sondern ehöhen um den Wert 2
            {
                Console.WriteLine(i);
            }


            

            //FOREACH-Schleifen können über Collections laufen und sprechen dabei jedes Element genau einmal an
            foreach (int currentZahl in zahlen)
            {
                Console.WriteLine(currentZahl);
            }




            #endregion



            #region Enums
            Wochentag wochentag = Wochentag.Montag; // Montag wird zugewiesen 

            if (wochentag == Wochentag.Freitag)
                Console.WriteLine("Es ist Wochenende");

            #endregion

            #region Warum werden Enums verwendet

            string[] wochentage = new string[] { "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag", "Sonntag" };
            string currrentWochentag = wochentage[4]; //unleserlicher als bei Enums

            if (currrentWochentag == wochentage[4])
                Console.WriteLine("Wochenende");
            #endregion

            //Deklaration und Initialisierung einer Variablen vom Enumerator-Typ
            Wochentag heutigerTag = Wochentag.Dienstag;
            Console.WriteLine($"Heute ist also {heutigerTag}.");

            Console.WriteLine("Welcher Wochentag is dein Lieblingstag?");

            for (int i = 1; i < 8; i++)
            {
                Console.WriteLine($"{i}: {(Wochentag)i}");
            }

            //Speichere einer Benutzereingabe (Int) als Enumerator
            heutigerTag = (Wochentag)int.Parse(Console.ReadLine());
            Console.WriteLine($"Dein Lieblingstag ist also {heutigerTag}.");

            //Parsen eines String in ein Enum

            heutigerTag = (Wochentag)Enum.Parse(typeof(Wochentag), "Mittwoch");


            //Warum verwendet man ein Switch z.B bei Enums
            if (heutigerTag == Wochentag.Montag)
            {

            }
            else if (heutigerTag == Wochentag.Dienstag)
            {

            }
            else if(heutigerTag == Wochentag.Mittwoch)
            {

            }
            else
            {

            }

            //Switch arbeitet schneller als if else 

            //SWITCHs sind eine verkürzte Schreibweise für IF-ELSE-Blöcke. Mögliche Zustände der übergebenen Variablen werden 
            //in den CASES definiert

            switch(heutigerTag)
            {
                case Wochentag.Montag:
                    //Wenn Montag, dann.... bis break
                    Console.WriteLine("Wochenstart");
                    break; //Springe aus dem Switch-Statement heraus
                case Wochentag.Dienstag:
                case Wochentag.Mittwoch:
                case Wochentag.Donnerstag:
                    Console.WriteLine("Normale Woche"); //Bei Di, Mi, Do
                    Console.WriteLine("Di/Mi oder Donnerstag");
                    break;
                //case Wochentag.Freitag:
                //case Wochentag.Samstag:
                //case Wochentag.Sonntag:
                    //Console.WriteLine("Wochenende");
                    //break;
                default:
                    Console.WriteLine("Wochenende");
                    break; 

            }



        }
    }

    enum Wochentag { Montag=1, Dienstag, Mittwoch, Donnerstag, Freitag, Samstag, Sonntag }
}