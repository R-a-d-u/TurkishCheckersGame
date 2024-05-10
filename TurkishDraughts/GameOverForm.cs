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
    public partial class GameOverForm : Form
    {
        public GameOverForm(String text)
        {
            InitializeComponent();
            MaximizeBox = false;
            labelText.Text= text;
            var pos = labelText.Parent.PointToScreen(labelText.Location);
            pos = pictureBox1.PointToClient(pos);
            labelText.Parent = pictureBox1;
            labelText.Location = pos;
            labelText.BackColor = Color.Transparent;
        }
    }
}
