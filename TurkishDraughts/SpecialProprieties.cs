namespace TurkishDraughts
{
    internal class SpecialProprieties
    {
        //false-nu este apasat, true-este apasat
        private bool pressed;

        //false-negru true-rosu
        private bool playerTurn;

        private bool pieceCanDoAMultipleMove;

        //daca suntem in proces de mutare multipla
        private int lastMultipleMovePositionI, lastMultipleMovePositionJ, currentMultipleMovePositionI, currentMultipleMovePositionJ;

        //pozitia actuala si trecuta a piesei cu miscare multipla
        public SpecialProprieties(bool pressed, bool playerTurn, bool pieceCanDoAMultipleMove, int lastMultipleMovePositionI, int lastMultipleMovePositionJ, int currentMultipleMovePositionI, int currentMultipleMovePositionJ)
        {
            this.pressed = pressed;
            this.playerTurn = playerTurn;
            this.pieceCanDoAMultipleMove = pieceCanDoAMultipleMove;
            this.lastMultipleMovePositionI = lastMultipleMovePositionI;
            this.lastMultipleMovePositionJ = lastMultipleMovePositionJ;
            this.currentMultipleMovePositionI = currentMultipleMovePositionI;
            this.currentMultipleMovePositionJ = currentMultipleMovePositionJ;
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

        public void setPieceCanDoAMultipleMove(bool multipleMove)
        {
            this.pieceCanDoAMultipleMove = multipleMove;
        }

        public bool getPieceCanDoAMultipleMove()
        {
            return pieceCanDoAMultipleMove;
        }

        public void setLastMultipleMovePositionI(int lastMultipleMovePositionI)
        {
            this.lastMultipleMovePositionI = lastMultipleMovePositionI;
        }

        public void setLastMultipleMovePositionJ(int lastMultipleMovePositionJ)
        {
            this.lastMultipleMovePositionJ = lastMultipleMovePositionJ;
        }

        public void setCurrentMultipleMovePositionI(int currentMultipleMovePositionI)
        {
            this.currentMultipleMovePositionI = currentMultipleMovePositionI;
        }

        public void setCurrentMultipleMovePositionJ(int currentMultipleMovePositionJ)
        {
            this.currentMultipleMovePositionJ = currentMultipleMovePositionJ;
        }

        public int getLastMultipleMovePositionI()
        {
            return lastMultipleMovePositionI;
        }

        public int getLastMultipleMovePositionJ()
        {
            return lastMultipleMovePositionJ;
        }

        public int getCurrentMultipleMovePositionI()
        {
            return currentMultipleMovePositionI;
        }

        public int getCurrentMultipleMovePositionJ()
        {
            return currentMultipleMovePositionJ;
        }
    }
}