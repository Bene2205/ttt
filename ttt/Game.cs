using System;
namespace ttt
{
    public class Game
    {
        Player p1;
        Player p2;
        public GameField gameField;

        public Game(int gameSize)
        {
            this.p1 = null;
            this.p2 = null;
            gameField = new GameField(gameSize);
        }

        //erzeuge Spieler 1 & 2
        public void setPlayers() {
            Console.WriteLine("Player 1 Name: ");
            p1 = new Player(Console.ReadLine(), 'X');
            Console.WriteLine("Player 2 Name: ");
            p2 = new Player(Console.ReadLine(), 'O');
            Console.Clear();
            Console.WriteLine("|Name\t\t|Symbol\t|");
            Console.WriteLine("|" + p1.getName() + "\t\t|" + p1.getSymbol() + "\t|");
            Console.WriteLine("|" + p2.getName() + "\t\t|" + p2.getSymbol() + "\t|");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        // Lose startspieler aus
        public void triggerStartingPlayer(){
            Random rnd = new Random();
            switch(rnd.Next(1,3)){
                case 1:
                    p1.setActive(true);
                    break;
                case 2:
                    p2.setActive(true);
                    break;
            }
        }

        private Player getActivePlayer(){
            if(p1.getActive() == true) {
                return p1;
            } else {
                return p2;
            }
        }

        private void switchActive(){
            if(p1.getActive() == true) {
                p2.setActive(true);
                p1.setActive(false); 
            } else {
                p2.setActive(false);
                p1.setActive(true);
            }
        }

        public void newMove(){
            //wechsle aktiven spieler
            switchActive();
            gameField.writeGameField();
            Console.WriteLine(getActivePlayer().getName() + "! It's your turn.");
            Console.WriteLine(getActivePlayer().getName() + " where do you want to place your symbol?");
            try
            {
                // schreibe Symbol in angegebenen Zelle
                gameField.setValueInField(int.Parse(Console.ReadLine()), getActivePlayer().getSymbol());
            } catch(ArgumentException e) {
                Console.WriteLine(getActivePlayer().getName() + " this field is not active anymore. Try another.");
                gameField.setValueInField(int.Parse(Console.ReadLine()), getActivePlayer().getSymbol());
            }
        }

        // start Spiel solange gewinner == false 
        public void startGame() {
            while(gameField.isWinner() == false) {
                newMove(); 
                Console.Clear();

            }
            //gewinner wurde gefunden
            if(gameField.isWinner() == true) {
                gameField.writeGameField();
                Console.WriteLine(getActivePlayer().getName() + " wins!!");
                // Spiel neustarten=
                Console.WriteLine("Do you want to restart? (y/n)");
                string restart = Console.ReadLine();
                if(restart == "y") {
                    // wenn ja, dann starte von vorne
                    MainClass.run();
                }
            }
        }
    }
}
