using System.Diagnostics;

namespace MathLibrary
{
    public class Calculator
    {
        public double Addition(double zahl1, double zahl2)
            => zahl1 + zahl2;


        public double Multiplikation(double zahl1, double zahl2)
            => zahl1 * zahl2;


        public double Division(double dividend, double divisor)
        {
            try
            {
                Validate(dividend, divisor);
                //Unsere Aufgabe als Herrsteller ist festzustellen, dass wir valide Parameter (double dividend, double divisor) erlahlten.
                //Hierfür entwickeln wir unsere eigene Exception und dem Benutzer mitzuteilen, dass teilen durch 0 nicht funktioniert 
            }
            catch (TeileDurchNullException ex)
            {
                //Wir loggen die Fehlermeldung für uns intern 
                //Debug ist jetzt unser "Logger"
                Debug.WriteLine("NUR FEHLERMERLDUNG" + ex.Message); //Fehlermeldung in Text
                Debug.WriteLine("NUR STACKTRACE" + ex.StackTrace); // Wo ist Fehler passiert
                Debug.WriteLine("NUR ToString()" + ex.ToString()); //Fehlermeldung in Text + Wo ist Fehler passiert

                throw new TeileDurchNullException("Bitte rufen Sie Ihren Administrator oder melden Sich bei unserem Support");
            }

            return dividend / divisor;  
        }

        private void Validate(double zahl1, double zahl2)
        {
            if (zahl2 == 0)
            {
                //Wir müssen einen Fehler eskalieren 

                //Wir werfen einen Fehler
                throw new TeileDurchNullException("Zahl2 darf nicht 0 sein");
            }
        }
    }


    //Diese Fehlermeldung würde sich bei allgemeinen Fehler in der Library anbieten
    public class MathLibraryException : Exception
    {
        public MathLibraryException(string message)
            :base(message)
        { 
        
        }
    }

    public class TeileDurchNullException : MathLibraryException
    {
        public TeileDurchNullException(string message)
            :base(message) 
        {
        }
    }
}