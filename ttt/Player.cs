using System;
namespace ttt
{
    public class Player
    {
        private string name;
        private char symbol;
        private bool active;

        public Player(){
            this.name = "";
            this.symbol = ' ';
            this.active = false; 
        }

        public Player(string name, char symbol) 
        {
            this.name = name;
            this.symbol = symbol;
            this.active = false; 
        }

        public string getName(){
            return name;
        }

        public char getSymbol(){
            return symbol;
        }

        public void setName(string name){
            this.name = name;
        }

        public bool getActive(){
            return active;
        }

        public void setActive(bool active) {
            this.active = active;
        }
    }
}
