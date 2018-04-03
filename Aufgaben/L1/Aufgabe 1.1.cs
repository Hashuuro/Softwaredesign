using System;

namespace L1
{
    class Program
    {
        static void Main(string[] args)
        {

        string w = "w";
        string k = "k";
        string o = "o";
        double result;


        if (args.Length == 0)
        {
            System.Console.WriteLine("Bitte das Kürzel für den zu berechnenden Körper eingeben. w=Würfel, k=Kugel, o=Oktaeder.");
            System.Console.WriteLine("Danach den Wert für die Kantenlänge bzw. den Durchmesser. Bsp: dotnet run w 2,34");
        }
        else if (args[0]==w){

            string v = args[1];
            result = Double.Parse(v);
            getKubusInfo(result);
        }
        else if(args[0]==k){

            string v = args[1];
            result = Double.Parse(v);
            getKugelInfo(result);

        }
        else if(args[0]==o){
            
            string v = args[1];
            result = Double.Parse(v);
            getOktaederInfo(result);

        }
        else{

            System.Console.WriteLine("Bitte gültiges Kürzel eingeben.");
        }

          
        }

        public static double Kubusflaeche(double d)
        {
            double A = Math.Pow((6 * d), 2);
            return A;
        }
        public static double KubusVolumen(double d)
        {
            double V = Math.Pow(d, 3);
            return V;
        }

        public static void getKubusInfo(double d)
        {
            double a = Math.Round(Kubusflaeche(d),2);
            double b = Math.Round(KubusVolumen(d),2);
            Console.WriteLine("Würfelfläche A: " + a + " Würfelvolumen V: " + b);
        }
        public static double Kugelflaeche(double d)
        {
            double A = Math.Pow((Math.PI * d), 2);
            return A;
        }
        public static double KugelVolumen(double d)
        {
            double V = (Math.Pow(Math.PI * d, 3)) / 6;
            return V;
        }

        public static void getKugelInfo(double d)
        {
             double a = Math.Round(Kugelflaeche(d),2);
            double b = Math.Round(KugelVolumen(d),2);
            Console.WriteLine("Kugelfläche A: " + a + " Kugelvolumen V: " + b);
        }
        public static double Oktaederflaeche(double d)
        {
            double a = 2 * Math.Sqrt(3);
            double b = Math.Pow(d, 2);
            double A = a * b;
            return A;
        }
        public static double OktaederVolumen(double d)
        {
            double a = Math.Sqrt(2);
            double b = Math.Pow(d, 3);
            double c = a * b;
            double V = c / 3;
            return V;
        }

        public static void getOktaederInfo(double d)
        {
            double a = Math.Round(Oktaederflaeche(d),2);
            double b = Math.Round(OktaederVolumen(d),2);
            Console.WriteLine("Oktaederfläche A: " + a + " Oktaedervolumen V: " + b);
        }
    }
}
