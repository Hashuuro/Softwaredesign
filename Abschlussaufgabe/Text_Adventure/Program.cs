using System;
using System.Collections.Generic;

namespace Text_Adventure
{
    class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game();

            while (game.Game_running)
            {
                game.Update();
            }

        }
    }
}
