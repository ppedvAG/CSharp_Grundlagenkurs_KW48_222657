using System.Security.Cryptography.X509Certificates;

namespace Modul007_AbstractSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Shape shape = new Shape();


            WordDoc wordDoc = new WordDoc("ABC.doc");
            wordDoc.Print();

            PDFDoc pdfDoc = new PDFDoc("ABC.pda");
            pdfDoc.Print();


            //Document document = new Document();

        }
    }

    #region Sample1

    //Abstrakte Klassen sind Schablonen und können nicht als Objekt instanziiert werden.
    public abstract class Shape
    {
        //Abstrakte Methoden dürfen nur in abstrakten Klassen existieren und definieren nur
        ///eine Signatur. Die erbenden Klassen werden gezwungen eine Implementierung vorzunehmen
        public abstract double GetArea(/* hier können auch Parameter verwendet werden*/);
    }


    public class Quatrat : Shape
    {
        public int X { get; set; }
        public int Y { get; set; }


        public Quatrat(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override double GetArea()
        {
            return X * Y;
        }
    }

    public class Circle : Shape
    {
        public int X { get; set; }

        public Circle(int x)
        {
            X = x;
        }

        public override double GetArea()
        {
            return 4 * Math.PI * X * X;
        }
    }




    #endregion


    #region Sample2


    //Abstrakte Klassen können keine Ínstanz erstellen 
    public abstract class Document
    {
        public virtual string FileName { get; set; }


        //Print MUSS in den Vererbten Klassen ausimplementiert werden
        public abstract void Print();

        public virtual string Info()
        {
            return $"{FileName} wird gedruckt";
        }
    }


    public class WordDoc : Document
    {
        public WordDoc(string fileName)
        {
            FileName = fileName;
        }

        public override string FileName 
        { 
            get => base.FileName; 
            
            set 
            {
                if (value.EndsWith(".doc") || value.EndsWith(".docx"))
                    base.FileName = value;
                else
                {
                    //Eine Exception ausgegben 
                    throw new Exception("Das ist kein Word-Document");
                }

            }
        }

        public override void Print()
        {
            Console.WriteLine("Word-Doc wird gedruckt");
        }

        public override string Info()
        {
            return $"Word - Document {FileName} wird gedruckt";
        }
    }

    public class PDFDoc : Document
    {

        public PDFDoc(string fileName)
        {
            FileName = fileName;
        }

        public override void Print()
        {
            Console.WriteLine("PDF Dokument wid gedruckt");
        }
    }
    #endregion


    #region Referenz-Beispiel

    abstract class Animal
    {
        // abstrakte Methode
        public abstract void makeSound();
    }

    //abgeleitete Klasse von abstract class
    class Dog : Animal
    {
        // Muss ausimplementiert werden 
        public override void makeSound()
        {
            Console.WriteLine("Bark Bark");
        }
    }

    #endregion
}