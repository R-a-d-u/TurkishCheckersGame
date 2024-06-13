namespace TurkishDraughts
{
    internal class SpecialProprieties
    {
        private bool pieceCanDoAMultipleMove;
        private int lastMultipleMovePositionI, lastMultipleMovePositionJ, currentMultipleMovePositionI, currentMultipleMovePositionJ;

        public SpecialProprieties(bool pieceCanDoAMultipleMove, int lastMultipleMovePositionI, int lastMultipleMovePositionJ, int currentMultipleMovePositionI, int currentMultipleMovePositionJ)
        {
            this.pieceCanDoAMultipleMove = pieceCanDoAMultipleMove;
            this.lastMultipleMovePositionI = lastMultipleMovePositionI;
            this.lastMultipleMovePositionJ = lastMultipleMovePositionJ;
            this.currentMultipleMovePositionI = currentMultipleMovePositionI;
            this.currentMultipleMovePositionJ = currentMultipleMovePositionJ;
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