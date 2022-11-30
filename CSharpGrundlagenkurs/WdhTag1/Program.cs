namespace WdhTag1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variablen, Arrays, Casten

            #region Ganzzahlige Variablen
            //Ganzzahlige Variable

            short shortZahl; //16 Bit
            Console.WriteLine($"short: {short.MinValue} bis {short.MaxValue}"); 
            int integerZahl; //32 Bit
            Console.WriteLine($"int: {int.MinValue} bis {int.MaxValue}");
            long longZahl; //64 Bit
            Console.WriteLine($"long: {long.MinValue} bis {long.MaxValue}");
            #endregion

            #region Gleitkomma Datentypen

            double doubleZahl = 3.14; 
            float floatZahl  = 0.5f;
            decimal moneyValues = 33.99m; //Geldbeträge werden immer mit decimal abgebildet

            char einZeichen = 'a'; //97 -> +13
            
            string eineZeichenkette = "abcdefg";
            char einZeichenAusDerZeichenkette = eineZeichenkette[0]; //Wollen den ersten Buchstaben
            Console.WriteLine(einZeichenAusDerZeichenkette);

            



            bool wahrOderFalsch = true;
            bool istABCInString = eineZeichenkette.Contains("abc");
            Console.WriteLine(eineZeichenkette.ToUpper()); //ABCDEFGH

            string csvZeile = "Kevin;Winter;39;Berlin";

            string[] csvParts = csvZeile.Split(';');

            foreach(string csvPart in csvParts ) 
            {
                Console.WriteLine(csvPart);
            }


            #endregion

            #region string zu integer

            string alterAlsZeichenkette = "39";

            //Konventiere ein String in eine Integer
            int alterAlsZahl = Convert.ToInt32(alterAlsZeichenkette);

            //Weitere Variante 
            int alterAlsZahlB = int.Parse(alterAlsZeichenkette);


            //Was ist, wenn eine Zahl, keine Zahl ist und es wird konventiert? 
            string nichtNummerischeZahlAlsZeichenkette = "123b";

            int convertedNumber;


            /* 1.) nichtNummerischeZahlAlsZeichenkette wird geprüft, ob diese Konventiert werden kann
             * 
             * 2.) Wenn nichtNummerischeZahlAlsZeichenkette eine unvalide Zahl darstellt gibt int.TryParse 'false' zurück
             * 2.) Wenn nichtNummerischeZahlAlsZeichenkette eine valide Zahl darstellt gibt int.TryParse 'true' zurück
             */
            
            if (int.TryParse(nichtNummerischeZahlAlsZeichenkette, out convertedNumber))
            {
                //Wenn wir in den Body des If-Statements kommen, haben wir eine kovnentierte Zahl in der Variable -> convertedNumber

                //Können mit convertedNumber ausgeben oder andere Dinge anstellen 
                Console.WriteLine(convertedNumber); 
            }





            #endregion


            #region Casten (Arbeiten mit Zahlen - Datentypen (int, long, short, decimal, float, double...) 

            //Ganzzahl -> Gleitkommazahl
            int eineGanzzahl = 10;

            //Implizietes Casten
            double eineKommazahl = eineGanzzahl; //10.0



            //Gleitkommazahl -> Ganzzahl (Achtung) 
            double price = 19.5;

            
            //Variante 1 (Komma wird abgeschnitten)
            int intPreis = (int)price;

            //Variante 2 -> Achtung Convert.ToInt32 rundet kaufmännisch
            intPreis = Convert.ToInt32(price);


            //Geneaueres Runden, wenn es um Kommastellen geht
            double rundenAufZweiNachkommaStellen = Math.Round(price, 2);

            #endregion


            #region Arrays


            int[] lottozahlen = { 12, 33, 41, 39, 8, 14, 49 };

            //Array hat einen Index 
            //Gibt es Variablen im Array, 
            if (lottozahlen.Length > 0)
            {
                //wenn ja
                int ersteVariableImArray = lottozahlen[0];
            }


            //Array in einer Schleife durchlaufen 0...6 
            int ersteLottozahl = lottozahlen[0];
            int zweiteLottozahl = lottozahlen[1];
            int dritteLottozahl = lottozahlen[2];
            int letzteLottozahl = lottozahlen[6];

            for (int i = 0; i < lottozahlen.Length; i++)
            {
                Console.WriteLine(lottozahlen[i]);
            }

            foreach (int aktuellLottozahl in lottozahlen)
            {
                //Lottozahlen 12, 33, 41, 39, 8, 14, 49 werden jeweils einzeln ausgegeben
                Console.WriteLine(aktuellLottozahl);
            }

            #endregion

            #endregion

            #region Funktionen
            // Funktionen stellen eine Logik und können mehfach verwendet werden
            // Niemals bitte Quellcode mit Copy&Paste vervielfältigen -> Bei Fehlerbehebung wird es unübersichtlich

            SpeichereDocument(@"C:\Documents\ABCDEF.doc");



            //Funktion ohne Parameter und Rückgabetyp
            AlertPieps();



            string csvFileLine = "Scott,Hanselmann,50,Seattle";
            string[] csvPartsResult = ReadCSV(csvFileLine);
            PrintCSVRecord(csvPartsResult);


            UebergebenEinArrayAlsParam("eins", "zwei", "drei", "hallo", "achmirfälltnochwasein");



            //Optionale Parameter
            MethodeMitOptionalenParametern(11, 22, 33, 12);
            MethodeMitOptionalenParametern(11, 22, 33);
            MethodeMitOptionalenParametern(11, 22);
            MethodeMitOptionalenParametern(11, 33);

            SaveDocument(); //Hinterlege Wert wird verwendet -> C:\Windows\Temp
            SaveDocument(@"C:\ABD\DEF");  //customize Path 
            #endregion









            #region Endlos-Schleife
            Console.WriteLine("Type something to see the echo! (Or 'stop' to quit.)");

            while (true)
            {
                Console.Write(">");
                string input = Console.ReadLine();

                if (input.ToLower() == "stop")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else if (input.ToLower() == "device start")
                {
                    StartDevice();
                }

                Console.WriteLine("> " + input.ToUpper());
            }

            #endregion




        }


        public static void SpeichereDocument(string path)
        {
            //Speichere das Dokument
            //....
        }

        public static void StartDevice()
        {
            //Starte einen Dienst
        }



        #region FunktionenOhneParameterUndRückgabewert

        public static void AlertPieps ()
        {
            Console.Beep();
        }


        //Funktion mit Parameter (zahl1, zahl2)  und Rückgabewert (int Add)
        //
        public static int Add (int zahl1, int zahl2)
        {
            int ergebnis = zahl1 + zahl2;

            return ergebnis;
        }


        public static string[] ReadCSV(string csvFileLine)
        {
            string[] partsOfCSV = csvFileLine.Split(',');

            return partsOfCSV;
        }

        public static void PrintCSVRecord(string[] csvParts)
        {
            foreach(string aktuellerCSVPart in csvParts)
            {
                Console.WriteLine(aktuellerCSVPart);
            }
        }

        public static void UebergebenEinArrayAlsParam(params string[] param)
        {
            foreach (string aktuellerStringImArray in param)
            {
                Console.WriteLine(aktuellerStringImArray);
            }
        }


        public static void MethodeMitOptionalenParametern(int a, int b, int c = 0, int d = 0)
        {
            int ergebnis = a + b + c + d;
        }


        public static void SaveDocument(string directory = @"C:\Windows\Temp")
        {
            Console.WriteLine($"Docuemnt wird in {directory} gespeichert");
        }
        #endregion
    }
}