using TurkishDraughts.Properties;

namespace TurkishDraughts
{
    internal class PieceClass
    {
        private int i, j, value;
        private PictureBox? pictureBoxButtons;
        private GameBoard? gameBoard;
        private GameBoardNetwork? gameBoardNetwork;
        private GameBoardVsRobot? gameBoardVsRobot;

        private void pictureBoxClick(object sender, EventArgs e)
        {
            if (gameBoard != null)
                gameBoard.pictureBoxClick(sender);
            if (gameBoardNetwork != null)
                gameBoardNetwork.pictureBoxClick(sender);
            if (gameBoardVsRobot != null)
                gameBoardVsRobot.pictureBoxClick(sender);
        }

        //value=0 spatiu gol
        //value=1 piesa neagra
        //value=2 piesa rosie
        //value=3 rege negru
        //value=4 rege rosu
        public PieceClass(int i, int j, int value, GameBoard gameBoard, GameBoardNetwork gameBoardNetwork, GameBoardVsRobot gameBoardVsRobot)
        {
            this.gameBoard = gameBoard;
            this.gameBoardNetwork = gameBoardNetwork;
            this.gameBoardVsRobot = gameBoardVsRobot;
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
                value = 0;
            }
            this.value = value;
           


            pictureBoxButtons = new RoundPictureBox
            {
                BackColor = System.Drawing.Color.Transparent,
                BackgroundImage = tempRes,
                BackgroundImageLayout = ImageLayout.Zoom,
                SizeMode = PictureBoxSizeMode.Zoom, // Set the SizeMode to Zoom
                Location = new System.Drawing.Point((29 + j * 79), (83 + i * 77)),
                Name = "pictureBox" + i + j,
                Size = new System.Drawing.Size(68, 68), // Increase the size to make it bigger
                TabIndex = 9,
                TabStop = false,
            };
            pictureBoxButtons.Click += new System.EventHandler(this.pictureBoxClick); //atribuie functia generala de click de piesa locatiei curente
        }

        public PictureBox getPictureBox()
        {
            return pictureBoxButtons;
        }

        public int getValue()
        {
            return value;
        }

        public void setValue(int value)
        {
            this.value = value;
        }
    }
}