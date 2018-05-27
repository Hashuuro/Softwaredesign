using System;

namespace L6_UML
{


    public interface Fahrzeug
    {
        void Fahrlos(double MaxSpeed);
    }
    public class BMW : Fahrzeug
    {
        public string Farbe;
        public int  Zylinder;
        public void Fahrlos(double MaxSpeed)
        {
            if(MaxSpeed>=100){
                Console.WriteLine("Blitzer!!");
            }
            else{
                Console.WriteLine("toller Fahrer");
            }
        } 

    }
    class Program
    {
        static void Main(string[] args)
        {
        var auto = new BMW();
        auto.Zylinder = 4;
        auto.Farbe = "grün";
        auto.Fahrlos(100);
       
        }
    }
}
