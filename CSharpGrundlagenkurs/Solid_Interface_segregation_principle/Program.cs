namespace Solid_Interface_segregation_principle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public interface IVehicle
    {
        void Drive();
        void Fly();
        void Swim();
    }

    public class Vehicle : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Kann fahren");
        }

        public void Fly()
        {
            Console.WriteLine("Kann fliegen");
        }

        public void Swim()
        {
            Console.WriteLine("Kann schwimmen");
        }
    }

    public class AmphibischesFahrzeug : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Kann fahren");
        }

        public void Fly() //Igittt
        {
            //throw new NotImplementedException();
        }

        public void Swim()
        {
            Console.WriteLine("Kann schwimmen");
        }
    }


    #region Best Practice

    public interface IDrive
    {
        void Drive();   
    }

    public interface IFly
    {
        void Fly();
    }

    public interface ISwim
    {
        void Swim();    
    }


    public class Vehicle2 : IDrive, IFly, ISwim
    {
        public void Drive()
        {
            Console.WriteLine("Kann fahren");
        }

        public void Fly() //Igittt
        {
            //throw new NotImplementedException();
        }

        public void Swim()
        {
            Console.WriteLine("Kann schwimmen");
        }
    }


    public class AmphibischesFahrzeut2 : ISwim, IDrive
    {
        public void Drive()
        {
            Console.WriteLine("kann fahren");
        }

        public void Swim()
        {
            Console.WriteLine("Kann schwimmen");
        }
    }
    #endregion

}