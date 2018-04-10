using System;

namespace ttt
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            run();   
        }

        public static void run() {
            Console.WriteLine("SETTINGS:");
            Console.WriteLine("Gamesize: (3: 3x3, 4: 4x4, ...)");

            //display Gamefield
            Game game = new Game(int.Parse(Console.ReadLine()));
            game.setPlayers();
            game.triggerStartingPlayer();
            game.startGame();
        }

    }
}
