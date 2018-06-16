using System;

namespace L8
{
     class Program
    {
        public static char[] gameData = {'1','2','3','4','5','6','7','8','9'};
        public static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            StartGame();
        }

        public static void StartGame()
        {
            string endGame = "";


            for (;;)
            {
                PrintGameBoard();

                
                Console.WriteLine($"Spieler {currentPlayer}: Bitte Zeichen setzen.");
                Console.Write("Zeichen:  ");
                string PlayerInput = Console.ReadLine();
                Console.WriteLine("────────────────────────");

                
                processData(PlayerInput);
                
               
                if (IsFieldFull() && GetWinner() == '0')
                {
                    endGame = "Unentschieden!";
                    break;
                }

                
                if (GetWinner() != '0')
                {
                    endGame = $"Spieler {GetWinner()} hat gewonnen!";
                    break;
                }

                
                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            }

            PrintGameBoard();
            Console.WriteLine("Spiel zu Ende.");
            Console.WriteLine(endGame);
        }

        public static void processData(string PlayerInput)
        {
            if (PlayerInput.Length > 1)
            {
                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                Console.WriteLine("Ungültige Eingabe.");
                Console.WriteLine("────────────────────────");
                return;
            }

            try
            {
                if (int.Parse(gameData[int.Parse(PlayerInput) - 1]+"").GetType() == typeof(int))
                    gameData[int.Parse(PlayerInput) - 1] = currentPlayer;
                else
                {
                    currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                    Console.WriteLine("Die angegebene Stelle ist schon besetzt.");
                    Console.WriteLine("────────────────────────");
                }

            }
            catch (Exception)
            {
                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                Console.WriteLine("Ungültige Eingabe.");
                Console.WriteLine("────────────────────────");
            }
        }

        public static char GetWinner()
        {
            int[,] CheckPatterns = new int[,] {{1,2,3},{4,5,6},{7,8,9},{1,4,7},{2,5,8},{3,6,9},{1,5,9},{3,5,7}};
            char Winner = '0';

            for (var i = 0; i < CheckPatterns.GetLength(0); i++)
            {
                if (gameData[CheckPatterns[i,0] - 1] == gameData[CheckPatterns[i,1] - 1] && gameData[CheckPatterns[i,1] - 1] == gameData[CheckPatterns[i,2] - 1])
                {
                    Winner = gameData[CheckPatterns[i,0] - 1];
                }
            }

            return Winner;
        }

        public static bool IsFieldFull()
        {
            foreach (var gameDataEntry in gameData)
            {
                try
                {
                    if (int.Parse(gameDataEntry+"").GetType() == typeof(int))
                    {
                        return false;
                    }
                }
                catch (Exception) {}
            }
            return true;
        }

        public static void PrintGameBoard()
        {
            Console.WriteLine($"────────────────────────");
            Console.WriteLine($"| {gameData[0]} | {gameData[1]} | {gameData[2]} |");
            Console.WriteLine($"| {gameData[3]} | {gameData[4]} | {gameData[5]} |");
            Console.WriteLine($"| {gameData[6]} | {gameData[7]} | {gameData[8]} |");
            Console.WriteLine($"────────────────────────");
        }
    }
}
