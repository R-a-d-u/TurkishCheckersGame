using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkishDraughts
{
    internal class PictureBoxPressedClass
    {
        bool pressed;
        //false-nu este apasat, true-este apasat
        bool playerTurn;
        //false-negru true-rosu
        public PictureBoxPressedClass(bool pressed, bool playerTurn)
        {
            this.pressed = pressed;
            this.playerTurn = playerTurn;
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
    }
}
