namespace Modul002_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int entfernungInMEtern, stunden, minuten, sekunden;

            double meterProSekunde, kilometerProStunde, meilenProStunde;


            #region Eingabe
            Console.WriteLine("Bitte gib folgende Angaben ein:");
            Console.Write("Entfernung in Meter: ");

            entfernungInMEtern = int.Parse(Console.ReadLine());

            Console.Write("Stunden: ");
            stunden = int.Parse(Console.ReadLine());

            Console.Write("Minuten ");
            minuten= int.Parse(Console.ReadLine());

            Console.Write("Sekunden ");
            sekunden = int.Parse(Console.ReadLine());
            #endregion

            Console.WriteLine();

            sekunden = sekunden + (minuten * 60) + (stunden * 3600);
            meterProSekunde = entfernungInMEtern / (double)sekunden;

            kilometerProStunde = meterProSekunde * 3.6;

            meilenProStunde = kilometerProStunde * 0.62137119;




            Console.WriteLine($"Meter/Sekunde: \t\t {Math.Round(meterProSekunde, 2)}");
            Console.WriteLine($"Kilometer/Stunde: \t\t {Math.Round(kilometerProStunde, 2)}");
            Console.WriteLine($"Meilen/Stunde: \t\t {Math.Round(meilenProStunde, 2)}");



        }
    }
}