using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace Modul003_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Jahreszahl: ");
            int eingabe = int.Parse(Console.ReadLine());

            bool istSchaltjahr = false; 

            if (eingabe % 4 == 0)
            {
                istSchaltjahr = true;
                if (eingabe % 100 == 0)
                {
                    istSchaltjahr = false;
                    if (eingabe % 400 == 0)
                    {
                        istSchaltjahr = true;
                    }
                }
            }

            if (istSchaltjahr)
                Console.WriteLine("Schaltjahr!!!!");



            //Alternative Lösung :-) 

            if (DateTime.IsLeapYear(eingabe))
            {
                Console.WriteLine("Ist ein Schaltjahr!!!");
            }


        }




        // Checks whether a given year is a leap year. This method returns true if
        // year is a leap year, or false if not.
        //
        public static bool IsLeapYearNET48(int year)
        {
            if (year < 1 || year > 9999)
            {
                throw new ArgumentOutOfRangeException("year", "Mehr als 9999 geht nicht.");
            }
            Contract.EndContractBlock();
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }


        // Checks whether a given year is a leap year. This method returns true if
        // year is a leap year, or false if not.
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLeapYearNETCore(int year)
        {
            if (year < 1 || year > 9999)
            {
                throw new ArgumentOutOfRangeException("year", "Mehr als 9999 geht nicht.");
            }
            if ((year & 3) != 0) return false;
            if ((year & 15) == 0) return true;
            return (uint)year % 25 != 0;
        }
    }
}