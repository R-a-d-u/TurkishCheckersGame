using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkishDraughts.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using System.Xml.Serialization;



namespace TurkishDraughts
{
    internal class PieceClass
    {
        private int i, j, value;
        public PictureBox pictureBoxButtons;
        protected GameBoard gameBoard;

        public PieceClass(int i, int j, int value, GameBoard gameBoard)
        {
            this.gameBoard = gameBoard;
            this.i = i;
            this.j = j;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameBoard));
            Image tempRes = ((System.Drawing.Image)(resources.GetObject("EmptySquare"))); //imagine default
            if (i == 1 || i == 2)
            {
                tempRes = Resources.BlackPiece;
                value = 1;
            }
            if (i == 5 || i == 6)
            {
                tempRes = Resources.RedPiece;
                value = 2;
            }
            if (i == 0 || i == 7 || i > 2 && i < 5)
            {
                tempRes = Resources.EmptySquare;
                value = 0;
            }

        }
    }
}
