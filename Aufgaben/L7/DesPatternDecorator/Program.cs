using System;
using System.Collections.Generic;

namespace DesPatternDecorator
{
    interface Spielfigur
    {
        void Drohe();  
    }

    class Monster : Spielfigur
    {
        public void Drohe()
        {
            Console.Write("Grrrrr!");
        }
    } 


    class Held : Spielfigur
    {
        public void Drohe()
        {
            Console.Write("Weiche zurück!");
        }        
    }


    // Decorator
    class Basis : Spielfigur
    {
        protected Spielfigur _original;

        public Basis(Spielfigur original)
        {
            _original = original; 
        }

        virtual public void Drohe()
        {
            _original.Drohe();
        }
}
   class ErkaelteteFigur : Basis
    {
        public ErkaelteteFigur(Spielfigur original) : base(original){}

        override public void Drohe()
        {
            _original.Drohe();
            Console.Write(" Hust!");
        }
}

    class HeisereFigur : Basis
    {
        public HeisereFigur(Spielfigur original) : base(original){}

        override public void Drohe()
        {
            Console.Write("Räusper...");
            _original.Drohe();
        }
}


    class Program
    {
        static void Main(string[] args)
        {
            List<Spielfigur> figuren = new List<Spielfigur>();

            figuren.Add(new Monster());
            figuren.Add(new Held());
            figuren.Add(new ErkaelteteFigur(new Held()));
            figuren.Add(new ErkaelteteFigur(new ErkaelteteFigur(new Monster())));
            figuren.Add(new HeisereFigur(new Monster()));
            figuren.Add(new ErkaelteteFigur(new HeisereFigur(new Held())));

            foreach(var spielfigur in figuren)
            {
                spielfigur.Drohe();
                Console.WriteLine();
            }

        }
    }
}
