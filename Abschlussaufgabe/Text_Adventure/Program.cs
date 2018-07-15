using System;
using System.Collections.Generic;

namespace Text_Adventure
{
    class Program
    {
        static void Main(string[] args)
        {

            Game Game = new Game();

            while (Game.game_running)
            {
                Game.Update();
            }

        }
    }
}
