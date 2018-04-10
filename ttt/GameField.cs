using System;
namespace ttt
{
    public class GameField
    {

        private int fieldSize;
        string[,] fields;


        public GameField()
        {
            this.fieldSize = 0;
            this.fields = new string[0,0];
        }

        public GameField(int fieldSize)
        {
            this.fieldSize = fieldSize;
            this.fields = new string[fieldSize,fieldSize];

            int fieldNumber = 1;
            for (int i = 0; i < fieldSize; i++)
            {
                string gameFieldLine1 = "";
                string gameFieldLine2 = "";
                string gameFieldLine3 = "";
                for (int y = 0; y < fieldSize; y++)
                {
                    fields[i,y] = fieldNumber.ToString();
                    fieldNumber++;
                    gameFieldLine1 = gameFieldLine1 + "|-----|";
                    if (fields[i, y].Length > 1)
                    {
                        gameFieldLine2 = gameFieldLine2 + "| " + fields[i, y] + "  |";
                    }
                    else
                    {
                        gameFieldLine2 = gameFieldLine2 + "|  " + fields[i, y] + "  |";
                    }
                    gameFieldLine3 = gameFieldLine3 + "|-----|";
                }
                Console.WriteLine(gameFieldLine1);
                Console.WriteLine(gameFieldLine2);
                Console.WriteLine(gameFieldLine3);

            }
        }

        public void writeGameField()
        {
            for (int i = 0; i < fieldSize; i++)
            {
                string gameFieldLine1 = "";
                string gameFieldLine2 = "";
                string gameFieldLine3 = "";
                for (int y = 0; y < fieldSize; y++)
                {
                    gameFieldLine1 = gameFieldLine1 + "|-----|";
                    if (fields[i, y].Length > 1)
                    {
                        gameFieldLine2 = gameFieldLine2 + "| " + fields[i, y] + "  |";
                    }
                    else
                    {
                        gameFieldLine2 = gameFieldLine2 + "|  " + fields[i, y] + "  |";
                    }
                    gameFieldLine3 = gameFieldLine3 + "|-----|";
                }
                Console.WriteLine(gameFieldLine1);
                Console.WriteLine(gameFieldLine2);
                Console.WriteLine(gameFieldLine3);

            }
        }

        public void setValueInField(int field, char symbol)
        {
            int count = 1;   
            for (int row = 0; row < fieldSize; row++) {
                for (int cell = 0; cell < fieldSize; cell++){
                    if(count == field) {
                        // prüfe ob feld schon gefüllt ist
                        if(fields[row, cell] == "X" ||fields[row, cell] == "O"){
                            throw new ArgumentException();
                        }
                        // schreibe wert in Zelle 
                        fields[row,cell] = symbol.ToString();
                    }
                    count++;
                }
            }
        }

        public string[,] getFields()
        {
            return fields;
        }

        // prüfe ob aktueller spieler gewonnen hat (gleicher Symbole in einer Reihe)
        public bool isWinner()
        {
            string[] values = new string[fieldSize];
            string[] valuesCross1 = new string[fieldSize];
            string[] valuesCross2 = new string[fieldSize];
            for (int row = 0; row < fieldSize; row++)
            {
                string firstVal = fields[row,0];
                for (int cell = 0; cell < fieldSize; cell++)
                {
                    values[cell] = fields[row,cell];
                }
                // prüfe ob gleiche X oder O in den Reihen
                if(checkArray(values) == true) {
                    return true;
                }
                for (int column = 0; column < fieldSize; column++) {
                    values[column] = fields[column, row];
                }
                // prüfe ob gleiche X oder O in den Spalten 
                if (checkArray(values) == true)
                {
                    return true;
                }
                valuesCross1[row] = fields[row, row];
                valuesCross2[row] = fields[row, fieldSize - row - 1];
            }
            // prüfe ob gleiche X oder O in den schräg untereinander liegenden Feldern 
            if (checkArray(valuesCross1) == true ||checkArray(valuesCross2) == true)
            {
                return true;
            }
            // kein spieler hat akutell gewonnen
            return false;
        }

        private bool checkArray(string[] values) {
            string firstVal = values[0];
            for (int i = 1; i < values.Length; i++) {
                if(firstVal != values[i]){
                    return false;
                }
            }

            return true;
        }

    }
}