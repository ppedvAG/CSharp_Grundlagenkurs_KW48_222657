namespace Modul007_sealed_Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }


    //sealed besagt, dass man von BaseClass nicht erben kann
    public sealed class BaseClass
    {
        //...
    }

    //Geht mit sealed nicht!
    //public  class AbgeleiteteKlasse : BaseClass
    //{

    //}

  


}