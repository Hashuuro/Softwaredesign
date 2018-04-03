using System;

namespace L1._2
{
    class Program
    {
        static string[] subjects = { "Harry", "Hermine", "Ron", "Hagrid", "Snape", "Dumbledore" };
        static string[] verbs = { "braut", "liebt", "studiert", "hasst", "zaubert", "zerstört" };
        static string[] objects = { "Zaubertränke", "den Grimm", "Lupin", "Hogwards", "die Karte des Rumtreibers", "Dementoren" };
        static string sub;
        static string verb;
        static string obj;
        static void Main(string[] args)
        {
            string[] zwischenspeicher = new string[subjects.Length];

            for (int i = 0; i < subjects.Length; i++)
            {
                getVers();

                zwischenspeicher[i] = sub + " " + verb + " " + obj;
                Console.WriteLine(zwischenspeicher[i]);
            }
        
        }

        public static void getVers()
        {

            Random ran = new Random();

            int s = ran.Next(0, subjects.Length);
            int v = ran.Next(0, verbs.Length);
            int o = ran.Next(0, objects.Length);
              
            while (subjects[s] == "vergeben")
            {
                s = ran.Next(0, subjects.Length);
            }
            sub = subjects[s];
            subjects[s] = "vergeben";

            while (verbs[v] == "vergeben")
            {
                v = ran.Next(0, subjects.Length);
            }
            verb = verbs[v];
            verbs[v] = "vergeben";

            while (objects[o] == "vergeben")
            {
                o = ran.Next(0, subjects.Length);
            }
            obj = objects[o];
            objects[o] = "vergeben";

        }
    }




}
