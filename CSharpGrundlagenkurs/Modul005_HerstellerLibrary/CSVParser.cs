using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul005_HerstellerLibrary
{
    public class CSVParser
    {
        //private -> nur innerhalb meiner Klasse 'CSVParser' kann auf private - Variablen, Methoden 


        //string csvLine -> "Otto,Walkes,55,Comedian"
        public string[] ReadCSVLine(string csvLine)
        {
            string[] csvParts = csvLine.Split(',');

            return csvParts; //csvParts[0] = Otto... csvParts[1] = Walkes
        }
    }
}
