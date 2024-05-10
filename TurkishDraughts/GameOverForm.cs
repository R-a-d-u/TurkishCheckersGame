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
            label1.Text= text;
            var pos = label1.Parent.PointToScreen(label1.Location);
            pos = pictureBox1.PointToClient(pos);
            label1.Parent = pictureBox1;
            label1.Location = pos;
            label1.BackColor = Color.Transparent;
        }
    }
}
