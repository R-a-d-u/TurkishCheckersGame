using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Drawing.Imaging;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TurkishDraughts
{
    public partial class GameBoardNetwork : Form
    {
        PieceClass[][] pictureBoxButtons;
        private const int ServerPort = 8888; // Port to communicate
        private TcpClient client;
        private TcpListener server;
        public GameBoardNetwork()
        {
            InitializeComponent();
            InitializeButtons();
        }
        private void InitializeButtons()
        {
           
        }
    }
   
}
