using TurkishDraughts.Properties;

namespace TurkishDraughts
{
    public partial class GameBoard : Form
    {

        PieceClass[][] pictureBoxButtons;
        PlayerClass player1, player2, currentPlayer;
        PictureBoxPressedClass pictureBoxPressed;
        private int contor;
        private int i_firstMove, j_firstMove;


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
        private void initPlayerNames()
        {
            player1 = new PlayerClass("Rosu");
            player2 = new PlayerClass("Negru");
            currentPlayer = player1;
        }
        private void initStartState()
        {
            pictureBoxPressed = new PictureBoxPressedClass(false, false);
        }
        private void clear_board()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    pictureBoxButtons[i][j].getPictureBox().BackColor = Color.Transparent;
                }
        }
        public void change_currentPlayerName()
        {
            if (pictureBoxPressed.getPlayerTurn() == false)
            {
                currentPlayerTextBox.Text = player1.getName();
                currentPlayerTextBox.ForeColor = Color.Red;
            }
            else
            {
                currentPlayerTextBox.Text = player2.getName();
                currentPlayerTextBox.ForeColor = Color.Black;
            }
        }
        public void change_playerTurn(bool turn)
        {
            if (turn == false)
                pictureBoxPressed.setPlayerTurn(true);
            else
                pictureBoxPressed.setPlayerTurn(false);
        }

        public void change_image(int i_initial, int j_initial, int i_final, int j_final)
        {
            pictureBoxButtons[i_final][j_final].getPictureBox().BackgroundImage = pictureBoxButtons[i_initial][j_initial].getPictureBox().BackgroundImage;
            pictureBoxButtons[i_initial][j_initial].getPictureBox().BackgroundImage = null;
        }
        public void change_value(int i_initial, int j_initial, int i_final, int j_final)
        {
            pictureBoxButtons[i_final][j_final].setValue(pictureBoxButtons[i_initial][j_initial].getValue());
            pictureBoxButtons[i_initial][j_initial].setValue(0);
        }
        public void move_reset(int i_initial, int j_initial, int i_final, int j_final)
        {
            pictureBoxButtons[i_initial][j_initial].getPictureBox().BackColor = Color.Transparent;
            pictureBoxPressed.setPressed(false);
        }
        public void check_initialMove(int i, int j)
        {
            i_firstMove = i;
            j_firstMove = j;
            pictureBoxButtons[i][j].getPictureBox().BackColor = Color.GreenYellow;
            pictureBoxPressed.setPressed(true);
            check_legalMove(i, j);
        }
        public void check_finalMove(int i_initial, int j_initial, int i_final, int j_final)
        {
            if (pictureBoxPressed.getPressed() == true)
            {

                if (pictureBoxButtons[i_final][j_final].getValue() != 0 ||
                    pictureBoxButtons[i_initial][j_initial].getValue() == 0 ||
                    pictureBoxButtons[i_initial][j_initial].getValue() % 2 != 0 && pictureBoxPressed.getPlayerTurn() == false ||
                    pictureBoxButtons[i_initial][j_initial].getValue() % 2 == 0 && pictureBoxPressed.getPlayerTurn() == true
                    )
                {
                    move_reset(i_initial, j_initial, i_final, j_final);
                }
                else
                {
                    move_piece(i_initial, j_initial, i_final, j_final);
                }
                clear_board();
            }
        }
        public void check_legalMove(int i, int j)
        {
            if (pictureBoxButtons[i][j].getValue() != 0)
            {
                check_emptySquare(i, j);
            }
        }
        public void check_emptySquare(int i, int j)
        {
            if (pictureBoxButtons[i][j].getValue() % 2 == 0)
            {
                //spatiu gol
                if (i > 1 && pictureBoxButtons[i - 1][j].getValue() == 0)
                    pictureBoxButtons[i - 1][j].getPictureBox().BackColor = Color.GreenYellow;
                if (j > 1 && pictureBoxButtons[i][j - 1].getValue() == 0)
                    pictureBoxButtons[i][j - 1].getPictureBox().BackColor = Color.GreenYellow;
                if (j < 7 && pictureBoxButtons[i][j + 1].getValue() == 0)
                    pictureBoxButtons[i][j + 1].getPictureBox().BackColor = Color.GreenYellow;
                //piesa langa
                if (i > 2 && pictureBoxButtons[i - 2][j].getValue() == 0 && pictureBoxButtons[i - 1][j].getValue() % 2 != 0)
                    pictureBoxButtons[i - 2][j].getPictureBox().BackColor = Color.GreenYellow;
                if (j > 2 && pictureBoxButtons[i][j - 2].getValue() == 0 && pictureBoxButtons[i][j - 1].getValue() % 2 != 0)
                    pictureBoxButtons[i][j - 2].getPictureBox().BackColor = Color.GreenYellow;
                if (j < 7 && pictureBoxButtons[i][j + 2].getValue() == 0 && pictureBoxButtons[i][j + 1].getValue() % 2 != 0)
                    pictureBoxButtons[i][j + 2].getPictureBox().BackColor = Color.GreenYellow;

            }
            if (pictureBoxButtons[i][j].getValue() % 2 != 0)
            {
                //spatiu gol
                if (i < 7 && pictureBoxButtons[i + 1][j].getValue() == 0)
                    pictureBoxButtons[i + 1][j].getPictureBox().BackColor = Color.GreenYellow;
                if (j < 7 && pictureBoxButtons[i][j + 1].getValue() == 0)
                    pictureBoxButtons[i][j + 1].getPictureBox().BackColor = Color.GreenYellow;
                if (j > 1 && pictureBoxButtons[i][j - 1].getValue() == 0)
                    pictureBoxButtons[i][j - 1].getPictureBox().BackColor = Color.GreenYellow;
                //piesa langa
                if (i < 6 && pictureBoxButtons[i + 2][j].getValue() == 0 && pictureBoxButtons[i + 1][j].getValue() % 2 == 0 && pictureBoxButtons[i + 1][j].getValue() != 0)
                    pictureBoxButtons[i + 2][j].getPictureBox().BackColor = Color.GreenYellow;
                if (j < 6 && pictureBoxButtons[i][j + 2].getValue() == 0 && pictureBoxButtons[i][j + 1].getValue() % 2 == 0 && pictureBoxButtons[i][j + 1].getValue() != 0)
                    pictureBoxButtons[i][j + 2].getPictureBox().BackColor = Color.GreenYellow;
                if (j > 2 && pictureBoxButtons[i][j - 2].getValue() == 0 && pictureBoxButtons[i][j - 1].getValue() % 2 == 0 && pictureBoxButtons[i][j - 1].getValue() != 0)
                    pictureBoxButtons[i][j - 2].getPictureBox().BackColor = Color.GreenYellow;
            }
        }
        public void move_piece(int i_initial, int j_initial, int i_final, int j_final)
        {
            pictureBoxButtons[i_initial][j_initial].getPictureBox().BackColor = Color.Transparent;
            pictureBoxPressed.setPressed(false);
            change_image(i_initial, j_initial, i_final, j_final);
            change_value(i_initial, j_initial, i_final, j_final);
            change_playerTurn(pictureBoxPressed.getPlayerTurn());
            change_currentPlayerName();
        }
        public void check_king(int i, int j)
        {
            if (pictureBoxButtons[i][j].getValue() == 1 && i == 7)
            {
                pictureBoxButtons[i][j].setValue(3);
                pictureBoxButtons[i][j].getPictureBox().BackgroundImage = Resources.BlackKing;
            }
            if (pictureBoxButtons[i][j].getValue() == 2 && i == 0)
            {
                pictureBoxButtons[i][j].setValue(4);
                pictureBoxButtons[i][j].getPictureBox().BackgroundImage = Resources.RedKing;
            }
        }

        public void pictureBox_click(object sender)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (sender == pictureBoxButtons[i][j].getPictureBox())
                    {
                        if (pictureBoxPressed.getPressed() == false)
                            check_initialMove(i, j);
                        else
                        {
                            check_finalMove(i_firstMove, j_firstMove, i, j);
                            check_king(i, j);
                        }
                    }
                }
            }

        }

        public GameBoard()
        {
            MaximizeBox = false;
            initPlayerNames();
            initStartState();
            initBtnTabla();
            InitializeComponent();
            currentPlayerTextBox.Text = currentPlayer.getName();
            currentPlayerTextBox.ForeColor = Color.Red;

        }
    }
}


