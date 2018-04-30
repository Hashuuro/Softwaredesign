using System;

namespace L1
{
    class Program
    {
        static void Main(string[] args)
        {


            double result;


            if (args.Length == 0)// Lieber switch case, einfacher zu lesen, args[0] als Variable, damit Programm nicht immer in Array muss
            {
                System.Console.WriteLine("Bitte das Kürzel für den zu berechnenden Körper eingeben. w=Würfel, k=Kugel, o=Oktaeder.");
                System.Console.WriteLine("Danach den Wert für die Kantenlänge bzw. den Durchmesser. Bsp: dotnet run w 2,34");
            }
            else if (args[0] == "w")
            {

                string character = args[1];
                result = Double.Parse(character);
                getcubeInfo(result);
            }
            else if (args[0] == "k")
            {

                string character = args[1];
                result = Double.Parse(character);
                getballInfo(result);

            }
            else if (args[0] == "o")
            {

                string character = args[1];
                result = Double.Parse(character);
                getOktaederInfo(result);

            }
            else
            {

                System.Console.WriteLine("Bitte gültiges Kürzel eingeben.");
            }


        }

        public static double cubearea(double d) // Variabeln und Code auf Englisch. Zur Übersicht region info!
        {
            double A = Math.Pow((6 * d), 2);
            return A;
        }
        public static double cubeVolume(double d)
        {
            double V = Math.Pow(d, 3);
            return V;
        }

        public static void getcubeInfo(double d) // keine Rückgabe, obwohl in Aufgabenstellung vorgegeben
        {
            double areac = Math.Round(cubearea(d), 2);
            double volumec = Math.Round(cubeVolume(d), 2);
            Console.WriteLine("Würfelfläche A: " + areac + " Würfelvolumen V: " + volumec);
        }
        public static double ballarea(double d)
        {
            double A = Math.Pow((Math.PI * d), 2);
            return A;
        }
        public static double ballVolume(double d)
        {
            double V = (Math.Pow(Math.PI * d, 3)) / 6;
            return V;
        }

        public static void getballInfo(double d) // keine Rückgabe, obwohl in Aufgabenstellung vorgegeben
        {
            double areaB = Math.Round(ballarea(d), 2);
            double volumeB = Math.Round(ballVolume(d), 2);
            Console.WriteLine("Kugelfläche A: " + areaB + " Kugelvolumen V: " + volumeB);
        }
        public static double Oktaederarea(double d)
        {
            double a = 2 * Math.Sqrt(3);
            double b = Math.Pow(d, 2);
            double A = a * b;
            return A;
        }
        public static double OktaederVolume(double d)
        {
            double a = Math.Sqrt(2);
            double b = Math.Pow(d, 3);
            double c = a * b;
            double V = c / 3;
            return V;
        }

        public static void getOktaederInfo(double d) // keine Rückgabe, obwohl in Aufgabenstellung vorgegeben
        {
            double areaO = Math.Round(Oktaederarea(d), 2);
            double volumeO = Math.Round(OktaederVolume(d), 2);
            Console.WriteLine("Oktaederfläche A: " + areaO + " Oktaedervolumen V: " + volumeO);
        }
    }
}
