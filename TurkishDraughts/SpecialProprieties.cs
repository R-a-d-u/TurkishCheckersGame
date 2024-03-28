namespace TurkishDraughts
{
    internal class SpecialProprieties
    {
        bool pressed;
        //false-nu este apasat, true-este apasat
        bool playerTurn;
        //false-negru true-rosu
        bool multipleMove;
        //daca suntem in proces de mutare multipla
        int lastMultipleMoveI, lastMultipleMoveJ, currentMultipleMoveI, currentMultipleMoveJ;
        //pozitia actuala si trecuta a piesei cu miscare multipla
        public SpecialProprieties(bool pressed, bool playerTurn, bool multipleMove, int lastMultipleMoveI, int lastMultipleMoveJ, int currentMultipleMoveI, int currentMultipleMoveJ)
        {
            this.pressed = pressed;
            this.playerTurn = playerTurn;
            this.multipleMove = multipleMove;
            this.lastMultipleMoveI = lastMultipleMoveI;
            this.lastMultipleMoveJ = lastMultipleMoveJ;
            this.currentMultipleMoveI = currentMultipleMoveI;
            this.currentMultipleMoveJ = currentMultipleMoveJ;
        }
        public bool getPressed()
        {
            return pressed;
        }
        public bool getPlayerTurn()
        {
            return playerTurn;
        }
        public void setPressed(bool pressed)
        {
            this.pressed = pressed;
        }
        public void setPlayerTurn(bool playerTurn)
        {
            this.playerTurn = playerTurn;
        }
        public void setMultipleMoves(bool multipleMove)
        {
            this.multipleMove = multipleMove;
        }
        public bool getMultipleMove()
        {
            return multipleMove;
        }
        public void setLastMultipleMoveI(int lastMultipleMoveI)
        {
            this.lastMultipleMoveI = lastMultipleMoveI;
        }
        public void setLastMultipleMoveJ(int lastMultipleMoveJ)
        {
            this.lastMultipleMoveJ = lastMultipleMoveJ;
        }
        public void setCurrentMultipleMoveI(int currentMultipleMoveI)
        {
            this.currentMultipleMoveI = currentMultipleMoveI;
        }
        public void setCurrentMultipleMoveJ(int currentMultipleMoveJ)
        {
            this.currentMultipleMoveJ = currentMultipleMoveJ;
        }
        public int getLastMultipleMoveI()
        {
            return lastMultipleMoveI;
        }
        public int getLastMultipleMoveJ()
        {
            return lastMultipleMoveJ;
        }
        public int getCurrentMultipleMoveI() 
        {
            return currentMultipleMoveI;
        }
        public int getCurrentMultipleMoveJ()
        {
            return currentMultipleMoveJ;
        }

    }
}
