using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurkishDraughts
{
    public partial class GameBoard : Form
    {

        PieceClass[][] pictureBoxButtons;
        private int contor;
        private int i, j;


        private void initBtnTabla()
        {
            int value = 0;//valoare default pentru picturebox gol
            pictureBoxButtons = new PieceClass[8][];
            for (int i = 0; i < 8; i++)
            {
                pictureBoxButtons[i] = new PieceClass[8];
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    pictureBoxButtons[i][j] = new PieceClass(i, j, value, this);
                    Controls.Add(pictureBoxButtons[i][j].getPictureBox());
                }
            }
        }

        public void pictureBox_click(object sender)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (sender == pictureBoxButtons[i][j].getPictureBox())
                        pictureBoxButtons[i][j].getPictureBox().BackColor = Color.Green;
                }
            }
                   
        }
        public GameBoard()
        {
            i = 9;
            j = 9;
            contor = 0;
            MaximizeBox = false;
            //
            initBtnTabla();
            InitializeComponent();
            
            
         }
    }
}
    

