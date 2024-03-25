using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace TurkishDraughts
{
    internal class PictureBoxSpecialProprieties
    {
        bool pressed;
        //false-nu este apasat, true-este apasat
        bool playerTurn;
        //false-negru true-rosu
        bool multipleMove;
        int i, j;
        public PictureBoxSpecialProprieties(bool pressed, bool playerTurn, bool multipleMove, int i, int j)
        {
            this.pressed = pressed;
            this.playerTurn = playerTurn;
            this.multipleMove = multipleMove;
            this.i = i;
            this.j = j;
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
        public void setI(int i)
        {
            this.i = i;
        }
        public void setJ(int j)
        {
            this.j = j;
        }
        public int getI()
        {
            return i;
        }
        public int getJ()
        {
            return j;
        }

    }
}
