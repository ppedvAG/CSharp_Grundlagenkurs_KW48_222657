namespace Modul012_Delegates_Action_Func_Events
{
    internal class Program
    {
        
        
        
        static void Main(string[] args)
        {
            #region Verwenden eines Delegates -> einfaches Beispiel
            //Delegates können nur mit Methoden zusammenarbeiten, die die selbe Signatur vorweisen 
            CalculatorDelegate calculatorDelegate = new CalculatorDelegate(Addieren); //Funktionzeiger -> Speicheradresse der Methode Addiere

            //So würde es nicht gehen -> AddiereInt hat eine andere Signatur als das Delegate
            //CalculatorDelegate calculatorDelegate = new CalculatorDelegate(AddierenInt); //Funktionzeiger -> Speicheradresse der Methode Addiere
            double result = calculatorDelegate(12, 23);
            #endregion

            #region Ein Delegate kann mehere Methoden vertreten (Operatoren += oder -=)
            CalculatorDelegate mulitCalculatorDelegate = new CalculatorDelegate(Addieren); //Funktionzeiger -> Speicheradresse der Methode Addiere
            mulitCalculatorDelegate += Subtrahieren;

            //Beim einfachen Aufruf, wie in Beispiel 1 würde nur die letze angehängte Methode aufgerufen werden
            result = mulitCalculatorDelegate(34, 12);


            //Sample: Aufruf mehrere Methoden
            int erg = 0;

            foreach(Delegate aktuelleDelegateMethode in mulitCalculatorDelegate.GetInvocationList())
            {
                //erster Durchlauf wird addiert
                //zweiter druchlauf wird subtrahiert
                erg = Convert.ToInt32(aktuelleDelegateMethode.DynamicInvoke(erg, 24));
            }

            #endregion

            #region UseCase -> das geht nur mit Delegates
            
            MessageDelegate messageDelegate= new MessageDelegate(ShowMessage); //Ich merke mir die Adresse (Funktionszeiger) von der Methode ShowMessage 
            PercentValueChangedDelegate percentValueChangedDelegate = new PercentValueChangedDelegate(ShowPercentValue);

            EineKomponenteDieRechenintensivIst myComponent = new EineKomponenteDieRechenintensivIst();
            myComponent.Process(messageDelegate, percentValueChangedDelegate);

            #endregion

            #region Action - Delegate
            //Action-Delegate können nur mit Methoden zusammenarbeiten, die ein void zurückgeben 
            //public delegate void MessageDelegate(string message) VS. Action - Delagte

            Action<string> showMessageActionDelegate = new Action<string>(ShowMessage);
            showMessageActionDelegate("Hallo liebe Teilnehmer");

            #endregion

            #region Func - Delegate
            //Func können Rückgabewerte und Parameter darstellen 
            Func<double, double, double> funcDelegate = new Func<double, double, double>(Addieren);
            double result1 = funcDelegate(12, 33);
            #endregion
        }

        #region Einstiegs Beispiele




        static double Addieren(double zahl1, double zahl2)
        {
            return zahl1 + zahl2;
        }

        static double Subtrahieren(double zahl1, double zahl2)
        {
            return zahl1 - zahl2;
        }

        static int AddierenInt(int zahl1, int zahl2)
        {
            return zahl1 + zahl2;
        }


        #endregion

        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void ShowPercentValue(int value)
        {
            Console.WriteLine(value);
        }
    }

    //delegates sind Datentypen die man definieren kann. 
    public delegate double CalculatorDelegate(double zahl1, double zahl2);


    #region Das kann eine Komponente vom Herrsteller sein
    public delegate void MessageDelegate(string message);
    public delegate void PercentValueChangedDelegate(int percentValue);
    public class EineKomponenteDieRechenintensivIst
    {
        public void Process(MessageDelegate messageDelegate, PercentValueChangedDelegate percentValueChangedDelegate)
        {
            //Rechenintensives passiert hier.....1..2...3 %
            for(int i = 0; i < 100; i++)
            {
                percentValueChangedDelegate(i); //PercentValueChangedDelegate hat die Methode ShowPercentValue und ruft diese auf 
            }

            //Wir wollen nach draußen mitteilen, wann wir fertig sind
            //Kurzgesagt->Callback wollen wir senden

            messageDelegate("Wir sind fertig");
        }
    }
    #endregion
}