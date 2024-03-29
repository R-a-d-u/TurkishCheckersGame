using TurkishDraughts.Properties;

namespace TurkishDraughts
{
    public partial class GameBoard : Form
    {

        PieceClass[][] pictureBoxButtons;
        PlayerClass player1, player2, currentPlayer;
        SpecialProprieties specialProprieties;
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
        private void testTablA()
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
                    pictureBoxButtons[i][j].setValue(0);
                    pictureBoxButtons[i][j].getPictureBox().BackgroundImage = null;
                }
            }

            // pictureBoxButtons[0][2].setValue(1);
            // pictureBoxButtons[2][3].setValue(1);
            // pictureBoxButtons[3][1].setValue(1);
            // pictureBoxButtons[1][0].setValue(1);
            pictureBoxButtons[4][0].setValue(4);
            // pictureBoxButtons[7][7].setValue(1);
            pictureBoxButtons[3][0].setValue(3);

            // pictureBoxButtons[7][7].getPictureBox().BackgroundImage = Resources.BlackPiece;
            // pictureBoxButtons[0][2].getPictureBox().BackgroundImage = Resources.BlackPiece;
            // pictureBoxButtons[2][3].getPictureBox().BackgroundImage = Resources.BlackPiece;
            // pictureBoxButtons[3][1].getPictureBox().BackgroundImage = Resources.BlackPiece;
            // pictureBoxButtons[1][0].getPictureBox().BackgroundImage = Resources.BlackPiece;
            pictureBoxButtons[4][0].getPictureBox().BackgroundImage = Resources.RedKing;
            pictureBoxButtons[3][0].getPictureBox().BackgroundImage = Resources.BlackKing;




        }
        private void initPlayerNames(String name1,String name2)
        {
            if (name1 == "")
                name1 = "Rosu";
            if (name2 == "")
                name2 = "Negru";
            player1 = new PlayerClass(name1);
            player1TextBox.Text = player1.getName();
            player2 = new PlayerClass(name2);
            player2TextBox.Text = player2.getName();
            currentPlayer = player1;
            currentPlayerTextBox.Text = "Rosu muta";
            player2TextBox.BackColor = Color.FromArgb(49, 46, 43);
            player2TextBox.ForeColor = Color.FromArgb(49, 46, 43);

        }
        private void initStartState()
        {
            specialProprieties = new SpecialProprieties(false, false, false, 0, 0, 0, 0);
        }
        private void remove_boardTraces()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    pictureBoxButtons[i][j].getPictureBox().BackColor = Color.Transparent;
                }
        }
        private void block_pictureBox()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    pictureBoxButtons[i][j].getPictureBox().Enabled = false;
                }
            }
            remove_boardTraces();
        }
        private bool check_gameOver(PlayerClass player1, PlayerClass player2)
        {
            int counterRed = 0, counterBlack = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (pictureBoxButtons[i][j].getValue() % 2 == 0 && pictureBoxButtons[i][j].getValue() != 0)
                        counterRed++;
                    if (pictureBoxButtons[i][j].getValue() % 2 != 0 && pictureBoxButtons[i][j].getValue() != 0)
                        counterBlack++;
                }
            }
            if (counterBlack == 0 || counterRed == 0)
            {
                if (counterBlack == 0)
                {
                    player1TextBox.BackColor = Color.FromArgb(49, 46, 43);
                    player2TextBox.BackColor = Color.FromArgb(49, 46, 43);
                    currentPlayerTextBox.Text = "Jocul s-a incheiat";
                    currentPlayerTextBox.ForeColor = Color.Blue;
                    MessageBox.Show(player1.getName() + " a castigat");
                }
                if (counterRed == 0)
                {
                    player1TextBox.BackColor = Color.FromArgb(49, 46, 43);
                    player2TextBox.BackColor = Color.FromArgb(49, 46, 43);
                    currentPlayerTextBox.Text = "Jocul s-a incheiat";
                    currentPlayerTextBox.ForeColor = Color.Blue;
                    MessageBox.Show(player2.getName() + " a castigat");
                }
                return true;
            }
            return false;
        }
        public void swap_currentPlayerName()
        {
            if (specialProprieties.getPlayerTurn() == false)
            {
                currentPlayerTextBox.Text = "Rosu muta";
                currentPlayerTextBox.ForeColor = Color.Red;
                player1TextBox.BackColor = Color.DarkGoldenrod;

                player2TextBox.BackColor = Color.FromArgb(49, 46, 43);
                player2TextBox.ForeColor = Color.FromArgb(49, 46, 43);

            }
            else
            {
                currentPlayerTextBox.Text = "Negru muta";
                currentPlayerTextBox.ForeColor = Color.Black;
                player2TextBox.BackColor = Color.DarkGoldenrod;
                player1TextBox.BackColor = Color.FromArgb(49, 46, 43);
                player1TextBox.ForeColor = Color.FromArgb(49, 46, 43);

            }
        }
        public void swap_currentPlayerTurn(bool turn)
        {
            if (turn == false)
                specialProprieties.setPlayerTurn(true);
            else
                specialProprieties.setPlayerTurn(false);
        }

        public void swap_image(int i_initial, int j_initial, int i_final, int j_final)
        {
            pictureBoxButtons[i_final][j_final].getPictureBox().BackgroundImage = pictureBoxButtons[i_initial][j_initial].getPictureBox().BackgroundImage;
            pictureBoxButtons[i_initial][j_initial].getPictureBox().BackgroundImage = null;
        }
        public void swap_value(int i_initial, int j_initial, int i_final, int j_final)
        {
            pictureBoxButtons[i_final][j_final].setValue(pictureBoxButtons[i_initial][j_initial].getValue());
            pictureBoxButtons[i_initial][j_initial].setValue(0);
        }
        public void reset_pictureboxPressed(int i_initial, int j_initial, int i_final, int j_final)
        {
            pictureBoxButtons[i_initial][j_initial].getPictureBox().BackColor = Color.Transparent;
            specialProprieties.setPressed(false);
        }
        public void check_initialMove(int i, int j)
        {
            i_firstMove = i;
            j_firstMove = j;
            pictureBoxButtons[i][j].getPictureBox().BackColor = Color.GreenYellow;
            specialProprieties.setPressed(true);
            check_legalMoves(i, j);
        }
        public void check_finalMove(int i_initial, int j_initial, int i_final, int j_final)
        {
            if (specialProprieties.getPressed() == true)
            {

                if (pictureBoxButtons[i_final][j_final].getValue() != 0 ||
                    pictureBoxButtons[i_initial][j_initial].getValue() == 0 ||
                    pictureBoxButtons[i_initial][j_initial].getValue() % 2 != 0 && specialProprieties.getPlayerTurn() == false ||
                    pictureBoxButtons[i_initial][j_initial].getValue() % 2 == 0 && specialProprieties.getPlayerTurn() == true ||
                    pictureBoxButtons[i_final][j_final].getPictureBox().BackColor != Color.GreenYellow ||
                    (specialProprieties.getMultipleMove() == true &&
                    (specialProprieties.getCurrentMultipleMoveI() != i_initial || specialProprieties.getCurrentMultipleMoveJ() != j_initial))
                    )
                {
                    reset_pictureboxPressed(i_initial, j_initial, i_final, j_final);
                }
                else
                {
                    move_piece(i_initial, j_initial, i_final, j_final);
                }
                remove_boardTraces();
            }
            if (check_gameOver(player1, player2))
            {
                block_pictureBox();
                remove_boardTraces();
            }
        }
        public void check_legalMoves(int i, int j)
        {
            if (pictureBoxButtons[i][j].getValue() != 0)
            {
                draw_LegalMovesTraces(i, j);
            }
        }
        public bool check_multipleMovesBlackPiece(int i_intial, int j_initial, int i, int j)
        {
            if (i < 6 && pictureBoxButtons[i + 2][j].getValue() == 0 && pictureBoxButtons[i + 1][j].getValue() % 2 == 0 && pictureBoxButtons[i + 1][j].getValue() != 0)
                return true;
            if (j < 6 && pictureBoxButtons[i][j + 2].getValue() == 0 && pictureBoxButtons[i][j + 1].getValue() % 2 == 0 && pictureBoxButtons[i][j + 1].getValue() != 0)
                return true;
            if (j > 1 && pictureBoxButtons[i][j - 2].getValue() == 0 && pictureBoxButtons[i][j - 1].getValue() % 2 == 0 && pictureBoxButtons[i][j - 1].getValue() != 0)
                return true;
            return false;
        }
        public bool check_multipleMovesRedPiece(int i_intial, int j_initial, int i, int j)
        {
            if (i > 1 && pictureBoxButtons[i - 2][j].getValue() == 0 && pictureBoxButtons[i - 1][j].getValue() % 2 != 0)
                return true;
            if (j > 1 && pictureBoxButtons[i][j - 2].getValue() == 0 && pictureBoxButtons[i][j - 1].getValue() % 2 != 0)
                return true;
            if (j < 6 && pictureBoxButtons[i][j + 2].getValue() == 0 && pictureBoxButtons[i][j + 1].getValue() % 2 != 0)
                return true;
            return false;
        }
        public bool check_multipleMovesRedKingLeft(int i_intial, int j_initial, int i, int j)
        {
            int i_search = i, j_search = j;
            bool redPieceInBetween = false;
            bool doubleBlackPiece = false;
            while (j_search > 1 && !redPieceInBetween && !doubleBlackPiece)
            {
                j_search--;
                if (pictureBoxButtons[i][j_search].getValue() % 2 != 0 &&
                 pictureBoxButtons[i][j_search].getValue() != 0 &&
                 pictureBoxButtons[i][j_search - 1].getValue() % 2 != 0 &&
                 pictureBoxButtons[i][j_search - 1].getValue() != 0)
                    doubleBlackPiece = true;
                if (pictureBoxButtons[i][j_search].getValue() % 2 == 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                    redPieceInBetween = true;
                if (pictureBoxButtons[i][j_search].getValue() % 2 != 0 && pictureBoxButtons[i][j_search].getValue() != 0 && pictureBoxButtons[i][j_search - 1].getValue() == 0)
                    return true;
            }
            return false;
        }
        public bool check_multipleMovesRedKingRight(int i_intial, int j_initial, int i, int j)
        {
            int i_search = i, j_search = j;
            bool redPieceInBetween = false;
            bool doubleBlackPiece = false;
            while (j_search < 6 && !redPieceInBetween && !doubleBlackPiece)
            {
                j_search++;
                if (pictureBoxButtons[i][j_search].getValue() % 2 != 0 &&
                 pictureBoxButtons[i][j_search].getValue() != 0 &&
                 pictureBoxButtons[i][j_search + 1].getValue() % 2 != 0 &&
                 pictureBoxButtons[i][j_search + 1].getValue() != 0)
                    doubleBlackPiece = true;
                if (pictureBoxButtons[i][j_search].getValue() % 2 == 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                    redPieceInBetween = true;
                if (pictureBoxButtons[i][j_search].getValue() % 2 != 0 && pictureBoxButtons[i][j_search].getValue() != 0 && pictureBoxButtons[i][j_search + 1].getValue() == 0)
                    return true;
            }
            return false;
        }
        public bool check_multipleMovesRedKingUp(int i_intial, int j_initial, int i, int j)
        {
            int i_search = i, j_search = j;
            bool redPieceInBetween = false;
            bool doubleBlackPiece = false;
            while (i_search > 1 && !redPieceInBetween && !doubleBlackPiece)
            {
                i_search--;
                if (pictureBoxButtons[i_search][j].getValue() % 2 != 0 &&
                  pictureBoxButtons[i_search][j].getValue() != 0 &&
                  pictureBoxButtons[i_search - 1][j].getValue() % 2 != 0 &&
                  pictureBoxButtons[i_search - 1][j].getValue() != 0)
                    doubleBlackPiece = true;
                if (pictureBoxButtons[i_search][j].getValue() % 2 == 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                    redPieceInBetween = true;
                if (pictureBoxButtons[i_search][j].getValue() % 2 != 0 && pictureBoxButtons[i_search][j].getValue() != 0 && pictureBoxButtons[i_search - 1][j].getValue() == 0)
                    return true;
            }

            return false;
        }
        public bool check_multipleMovesRedKingDown(int i_intial, int j_initial, int i, int j)
        {
            int i_search = i, j_search = j;
            bool redPieceInBetween = false;
            bool doubleBlackPiece = false;
            while (i_search < 6 && !redPieceInBetween && !doubleBlackPiece)
            {
                i_search++;
                if (pictureBoxButtons[i_search][j].getValue() % 2 != 0 &&
                   pictureBoxButtons[i_search][j].getValue() != 0 &&
                   pictureBoxButtons[i_search + 1][j].getValue() % 2 != 0 &&
                   pictureBoxButtons[i_search + 1][j].getValue() != 0)
                    doubleBlackPiece = true;
                if (pictureBoxButtons[i_search][j].getValue() % 2 == 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                    redPieceInBetween = true;
                if (pictureBoxButtons[i_search][j].getValue() % 2 != 0 && pictureBoxButtons[i_search][j].getValue() != 0 && pictureBoxButtons[i_search + 1][j].getValue() == 0)
                    return true;
            }

            return false;
        }
        public bool check_multipleMovesBlackKingLeft(int i_intial, int j_initial, int i, int j)
        {
            int i_search = i, j_search = j;
            bool blackPieceInBetween = false;
            bool doubleRedPiece = false;
            while (j_search > 1 && !blackPieceInBetween && !doubleRedPiece)
            {
                j_search--;
                if (pictureBoxButtons[i][j_search].getValue() % 2 == 0 &&
                  pictureBoxButtons[i][j_search].getValue() != 0 &&
                  pictureBoxButtons[i][j_search - 1].getValue() % 2 == 0 &&
                  pictureBoxButtons[i][j_search - 1].getValue() != 0)
                    doubleRedPiece = true;
                if (pictureBoxButtons[i][j_search].getValue() % 2 != 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                    blackPieceInBetween = true;
                if (pictureBoxButtons[i][j_search].getValue() % 2 == 0 && pictureBoxButtons[i][j_search].getValue() != 0 && pictureBoxButtons[i][j_search - 1].getValue() == 0)
                    return true;
            }
            return false;
        }
        public bool check_multipleMovesBlackKingRight(int i_intial, int j_initial, int i, int j)
        {
            int i_search = i, j_search = j;
            bool blackPieceInBetween = false;
            bool doubleRedPiece = false;
            while (j_search < 6 && !blackPieceInBetween && !doubleRedPiece)
            {
                j_search++;
                if (pictureBoxButtons[i][j_search].getValue() % 2 == 0 &&
                  pictureBoxButtons[i][j_search].getValue() != 0 &&
                  pictureBoxButtons[i][j_search + 1].getValue() % 2 == 0 &&
                  pictureBoxButtons[i][j_search + 1].getValue() != 0)
                    doubleRedPiece = true;

                if (pictureBoxButtons[i][j_search].getValue() % 2 != 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                    blackPieceInBetween = true;
                if (pictureBoxButtons[i][j_search].getValue() % 2 == 0 && pictureBoxButtons[i][j_search].getValue() != 0 && pictureBoxButtons[i][j_search + 1].getValue() == 0)
                    return true;
            }
            return false;
        }
        public bool check_multipleMovesBlackKingUp(int i_intial, int j_initial, int i, int j)
        {
            int i_search = i, j_search = j;
            bool blackPieceInBetween = false;
            bool doubleRedPiece = false;
            while (i_search > 1 && !blackPieceInBetween && !doubleRedPiece)
            {
                i_search--;
                if (pictureBoxButtons[i_search][j].getValue() % 2 == 0 &&
                   pictureBoxButtons[i_search][j].getValue() != 0 &&
                   pictureBoxButtons[i_search - 1][j].getValue() % 2 == 0 &&
                   pictureBoxButtons[i_search - 1][j].getValue() != 0)
                    doubleRedPiece = true;

                if (pictureBoxButtons[i_search][j].getValue() % 2 != 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                    blackPieceInBetween = true;
                if (pictureBoxButtons[i_search][j].getValue() % 2 == 0 && pictureBoxButtons[i_search][j].getValue() != 0 && pictureBoxButtons[i_search - 1][j].getValue() == 0)
                    return true;
            }
            return false;

        }
        public bool check_multipleMovesBlackKingDown(int i_intial, int j_initial, int i, int j)
        {
            int i_search = i, j_search = j;
            bool blackPieceInBetween = false;
            bool doubleRedPiece = false;
            while (i_search < 6 && !blackPieceInBetween && !doubleRedPiece)
            {
                i_search++;
                if (pictureBoxButtons[i_search][j].getValue() % 2 == 0 &&
                    pictureBoxButtons[i_search][j].getValue() != 0 &&
                    pictureBoxButtons[i_search + 1][j].getValue() % 2 == 0 &&
                    pictureBoxButtons[i_search + 1][j].getValue() != 0)
                    doubleRedPiece = true;

                if (pictureBoxButtons[i_search][j].getValue() % 2 != 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                    blackPieceInBetween = true;
                if (pictureBoxButtons[i_search][j].getValue() % 2 == 0 && pictureBoxButtons[i_search][j].getValue() != 0 && pictureBoxButtons[i_search + 1][j].getValue() == 0)
                    return true;
            }
            return false;
        }

        public bool check_multipleMoves(int i_initial, int j_initial, int i, int j)
        {
            //piesa rosie
            if (pictureBoxButtons[i][j].getValue() == 2)
            {
                if (check_multipleMovesRedPiece(i_initial, j_initial, i, j))
                    return true;
            }
            //piesa neagra
            if (pictureBoxButtons[i][j].getValue() == 1)
            {
                if (check_multipleMovesBlackPiece(i_initial, j_initial, i, j))
                    return true;
            }
            //rege rosu
            if (pictureBoxButtons[i][j].getValue() == 4)
            {
                //nu permitem ca regele sa faca o miscare multipla la 180 de grade, zona din care a venit e falsa
                bool i_up = false;
                bool i_down = false;
                bool j_right = false;
                bool j_left = false;
                if (i != i_initial)
                    if (i - i_initial > 0)
                        i_up = true;
                    else
                        i_down = true;

                if (j != j_initial)
                    if (j - j_initial > 0)
                        j_left = true;
                    else
                        j_right = true;

                if (!j_left)
                    if (check_multipleMovesRedKingLeft(i_initial, j_initial, i, j))
                        return true;
                if (!j_right)
                    if (check_multipleMovesRedKingRight(i_initial, j_initial, i, j))
                        return true;
                if (!i_up)
                    if (check_multipleMovesRedKingUp(i_initial, j_initial, i, j))
                        return true;
                if (!i_down)
                    if (check_multipleMovesRedKingDown(i_initial, j_initial, i, j))
                        return true;

            }
            //rege negru
            if (pictureBoxButtons[i][j].getValue() == 3)
            {
                //nu permitem ca regele sa faca o miscare multipla la 180 de grade, zona din care a venit e falsa
                bool i_up = false;
                bool i_down = false;
                bool j_right = false;
                bool j_left = false;
                if (i != i_initial)
                    if (i - i_initial > 0)
                        i_up = true;
                    else
                        i_down = true;

                if (j != j_initial)
                    if (j - j_initial > 0)
                        j_left = true;
                    else
                        j_right = true;

                if (!j_left)
                    if (check_multipleMovesBlackKingLeft(i_initial, j_initial, i, j))
                        return true;

                if (!j_right)
                    if (check_multipleMovesBlackKingRight(i_initial, j_initial, i, j))
                        return true;
                if (!i_up)
                    if (check_multipleMovesBlackKingUp(i_initial, j_initial, i, j))
                        return true;
                if (!i_down)
                    if (check_multipleMovesBlackKingDown(i_initial, j_initial, i, j))
                        return true;
            }
            return false;
        }
        public void draw_redPieceTrace(int i, int j)
        {
            //spatiu gol
            if (specialProprieties.getMultipleMove() == false)
            {
                if (i > 0 && pictureBoxButtons[i - 1][j].getValue() == 0)
                    pictureBoxButtons[i - 1][j].getPictureBox().BackColor = Color.GreenYellow;
                if (j > 0 && pictureBoxButtons[i][j - 1].getValue() == 0)
                    pictureBoxButtons[i][j - 1].getPictureBox().BackColor = Color.GreenYellow;
                if (j < 7 && pictureBoxButtons[i][j + 1].getValue() == 0)
                    pictureBoxButtons[i][j + 1].getPictureBox().BackColor = Color.GreenYellow;
            }
            //piesa langa
            if (i > 1 && pictureBoxButtons[i - 2][j].getValue() == 0 && pictureBoxButtons[i - 1][j].getValue() % 2 != 0)
                pictureBoxButtons[i - 2][j].getPictureBox().BackColor = Color.GreenYellow;
            if (j > 1 && pictureBoxButtons[i][j - 2].getValue() == 0 && pictureBoxButtons[i][j - 1].getValue() % 2 != 0)
                pictureBoxButtons[i][j - 2].getPictureBox().BackColor = Color.GreenYellow;
            if (j < 6 && pictureBoxButtons[i][j + 2].getValue() == 0 && pictureBoxButtons[i][j + 1].getValue() % 2 != 0)
                pictureBoxButtons[i][j + 2].getPictureBox().BackColor = Color.GreenYellow;
        }
        public void draw_blackPieceTrace(int i, int j)
        {
            //spatiu gol
            if (specialProprieties.getMultipleMove() == false)
            {
                if (i < 7 && pictureBoxButtons[i + 1][j].getValue() == 0)
                    pictureBoxButtons[i + 1][j].getPictureBox().BackColor = Color.GreenYellow;
                if (j < 7 && pictureBoxButtons[i][j + 1].getValue() == 0)
                    pictureBoxButtons[i][j + 1].getPictureBox().BackColor = Color.GreenYellow;
                if (j > 0 && pictureBoxButtons[i][j - 1].getValue() == 0)
                    pictureBoxButtons[i][j - 1].getPictureBox().BackColor = Color.GreenYellow;
            }
            //piesa langa
            if (i < 6 && pictureBoxButtons[i + 2][j].getValue() == 0 && pictureBoxButtons[i + 1][j].getValue() % 2 == 0 && pictureBoxButtons[i + 1][j].getValue() != 0)
                pictureBoxButtons[i + 2][j].getPictureBox().BackColor = Color.GreenYellow;
            if (j < 6 && pictureBoxButtons[i][j + 2].getValue() == 0 && pictureBoxButtons[i][j + 1].getValue() % 2 == 0 && pictureBoxButtons[i][j + 1].getValue() != 0)
                pictureBoxButtons[i][j + 2].getPictureBox().BackColor = Color.GreenYellow;
            if (j > 1 && pictureBoxButtons[i][j - 2].getValue() == 0 && pictureBoxButtons[i][j - 1].getValue() % 2 == 0 && pictureBoxButtons[i][j - 1].getValue() != 0)
                pictureBoxButtons[i][j - 2].getPictureBox().BackColor = Color.GreenYellow;
        }
        public void draw_redKingLeftTrace(int i, int j)
        {
            int i_search = i, j_search = j, contor = 0;
            while (j_search > 0 && contor < 2)
            {
                j_search--;
                if (pictureBoxButtons[i][j_search].getValue() % 2 != 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                    contor++;
                if (pictureBoxButtons[i][j_search].getValue() % 2 == 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                    contor = 2;
                if (pictureBoxButtons[i][j_search].getValue() == 0)
                    pictureBoxButtons[i][j_search].getPictureBox().BackColor = Color.GreenYellow;
            }
        }
        public void draw_redKingRightTrace(int i, int j)
        {
            int i_search = i, j_search = j, contor = 0;
            while (j_search < 7 && contor < 2)
            {
                j_search++;
                if (pictureBoxButtons[i][j_search].getValue() % 2 != 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                    contor++;
                if (pictureBoxButtons[i][j_search].getValue() % 2 == 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                    contor = 2;
                if (pictureBoxButtons[i][j_search].getValue() == 0)
                    pictureBoxButtons[i][j_search].getPictureBox().BackColor = Color.GreenYellow;
            }
        }
        public void draw_redKingUpTrace(int i, int j)
        {
            int i_search = i, j_search = j, contor = 0;
            while (i_search > 0 && contor < 2)
            {
                i_search--;
                if (pictureBoxButtons[i_search][j].getValue() % 2 != 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                    contor++;
                if (pictureBoxButtons[i_search][j].getValue() % 2 == 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                    contor = 2;
                if (pictureBoxButtons[i_search][j].getValue() == 0)
                    pictureBoxButtons[i_search][j].getPictureBox().BackColor = Color.GreenYellow;
            }
        }
        public void draw_redKingDownTrace(int i, int j)
        {
            int i_search = i, j_search = j, contor = 0;
            while (i_search < 7 && contor < 2)
            {
                i_search++;
                if (pictureBoxButtons[i_search][j].getValue() % 2 != 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                    contor++;
                if (pictureBoxButtons[i_search][j].getValue() % 2 == 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                    contor = 2;
                if (pictureBoxButtons[i_search][j].getValue() == 0)
                    pictureBoxButtons[i_search][j].getPictureBox().BackColor = Color.GreenYellow;
            }
        }
        public void draw_blackKingLeftTrace(int i, int j)
        {
            int i_search = i, j_search = j, contor = 0;
            while (j_search > 0 && contor < 2)
            {
                j_search--;
                if (pictureBoxButtons[i][j_search].getValue() % 2 == 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                    contor++;
                if (pictureBoxButtons[i][j_search].getValue() % 2 != 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                    contor = 2;
                if (pictureBoxButtons[i][j_search].getValue() == 0)
                    pictureBoxButtons[i][j_search].getPictureBox().BackColor = Color.GreenYellow;
            }
        }
        public void draw_blackKingRightTrace(int i, int j)
        {
            int i_search = i, j_search = j, contor = 0;
            while (j_search < 7 && contor < 2)
            {
                j_search++;
                if (pictureBoxButtons[i][j_search].getValue() % 2 == 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                    contor++;
                if (pictureBoxButtons[i][j_search].getValue() % 2 != 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                    contor = 2;
                if (pictureBoxButtons[i][j_search].getValue() == 0)
                    pictureBoxButtons[i][j_search].getPictureBox().BackColor = Color.GreenYellow;
            }
        }
        public void draw_blackKingUpTrace(int i, int j)
        {
            int i_search = i, j_search = j, contor = 0;
            while (i_search > 0 && contor < 2)
            {
                i_search--;
                if (pictureBoxButtons[i_search][j].getValue() % 2 == 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                    contor++;
                if (pictureBoxButtons[i_search][j].getValue() % 2 != 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                    contor = 2;
                if (pictureBoxButtons[i_search][j].getValue() == 0)
                    pictureBoxButtons[i_search][j].getPictureBox().BackColor = Color.GreenYellow;

            }
        }
        public void draw_blackKingDownTrace(int i, int j)
        {
            int i_search = i, j_search = j, contor = 0;
            while (i_search < 7 && contor < 2)
            {
                i_search++;
                if (pictureBoxButtons[i_search][j].getValue() % 2 == 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                    contor++;
                if (pictureBoxButtons[i_search][j].getValue() % 2 != 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                    contor = 2;
                if (pictureBoxButtons[i_search][j].getValue() == 0)
                    pictureBoxButtons[i_search][j].getPictureBox().BackColor = Color.GreenYellow;
            }
        }
        public void draw_LegalMovesTraces(int i, int j)
        {

            if (pictureBoxButtons[i][j].getValue() % 2 == 0)
            {
                draw_redPieceTrace(i, j);

                if (pictureBoxButtons[i][j].getValue() == 4)
                {
                    if (specialProprieties.getMultipleMove() == false)
                    {
                        draw_redKingLeftTrace(i, j);
                        draw_redKingRightTrace(i, j);
                        draw_redKingUpTrace(i, j);
                        draw_redKingDownTrace(i, j);
                    }
                    else
                    {
                        int i_initial = specialProprieties.getLastMultipleMoveI();
                        int j_initial = specialProprieties.getLastMultipleMoveJ();
                        bool i_up = false;
                        bool i_down = false;
                        bool j_right = false;
                        bool j_left = false;
                        if (i != i_initial)
                            if (i - i_initial > 0)
                                i_up = true;
                            else
                                i_down = true;

                        if (j != j_initial)
                            if (j - j_initial > 0)
                                j_left = true;
                            else
                                j_right = true;

                        if (!j_left)
                            if (check_multipleMovesRedKingLeft(i_initial, j_initial, i, j))
                                draw_redKingLeftTrace(i, j);
                        if (!j_right)
                            if (check_multipleMovesRedKingRight(i_initial, j_initial, i, j))
                                draw_redKingRightTrace(i, j);
                        if (!i_up)
                            if (check_multipleMovesRedKingUp(i_initial, j_initial, i, j))
                                draw_redKingUpTrace(i, j);
                        if (!i_down)
                            if (check_multipleMovesRedKingDown(i_initial, j_initial, i, j))
                                draw_redKingDownTrace(i, j);
                    }
                }
            }
            if (pictureBoxButtons[i][j].getValue() % 2 != 0)
            {
                draw_blackPieceTrace(i, j);
                if (pictureBoxButtons[i][j].getValue() == 3)
                    if (specialProprieties.getMultipleMove() == false)
                    {
                        draw_blackKingLeftTrace(i, j);
                        draw_blackKingRightTrace(i, j);
                        draw_blackKingUpTrace(i, j);
                        draw_blackKingDownTrace(i, j);
                    }
                    else
                    {
                        int i_initial = specialProprieties.getLastMultipleMoveI();
                        int j_initial = specialProprieties.getLastMultipleMoveJ();
                        bool i_up = false;
                        bool i_down = false;
                        bool j_right = false;
                        bool j_left = false;
                        if (i != i_initial)
                            if (i - i_initial > 0)
                                i_up = true;
                            else
                                i_down = true;

                        if (j != j_initial)
                            if (j - j_initial > 0)
                                j_left = true;
                            else
                                j_right = true;

                        if (!j_left)
                            if (check_multipleMovesBlackKingLeft(i_initial, j_initial, i, j))
                                draw_blackKingLeftTrace(i, j);
                        if (!j_right)
                            if (check_multipleMovesBlackKingRight(i_initial, j_initial, i, j))
                                draw_blackKingRightTrace(i, j);
                        if (!i_up)
                            if (check_multipleMovesBlackKingUp(i_initial, j_initial, i, j))
                                draw_blackKingUpTrace(i, j);
                        if (!i_down)
                            if (check_multipleMovesBlackKingDown(i_initial, j_initial, i, j))
                                draw_blackKingDownTrace(i, j);
                    }
            }
        }
        public bool remove_capturedPieces(int i_initial, int j_initial, int i_final, int j_final)
        {
            if (j_initial > j_final)
            {
                int j_temp = j_final; j_final = j_initial; j_initial = j_temp;
            }
            if (i_initial > i_final)
            {
                int i_temp = i_final; i_final = i_initial; i_initial = i_temp;
            }

            if (j_initial == j_final && i_initial != i_final + 1)
                for (int i = i_initial + 1; i < i_final; i++)
                    if (pictureBoxButtons[i][j_final].getValue() != 0)
                    {
                        pictureBoxButtons[i][j_final].setValue(0);
                        pictureBoxButtons[i][j_final].getPictureBox().BackgroundImage = null;
                        return true;
                    }
            if (i_initial == i_final && j_initial != j_final + 1)
                for (int j = j_initial + 1; j < j_final; j++)
                    if (pictureBoxButtons[i_initial][j].getValue() != 0)
                    {
                        pictureBoxButtons[i_initial][j].setValue(0);
                        pictureBoxButtons[i_initial][j].getPictureBox().BackgroundImage = null;
                        return true;
                    }
            return false;
        }
        public void move_piece(int i_initial, int j_initial, int i_final, int j_final)
        {
            pictureBoxButtons[i_initial][j_initial].getPictureBox().BackColor = Color.Transparent;
            specialProprieties.setPressed(false);
            swap_image(i_initial, j_initial, i_final, j_final);
            swap_value(i_initial, j_initial, i_final, j_final);
            if (remove_capturedPieces(i_initial, j_initial, i_final, j_final))
            {
                remove_capturedPieces(i_initial, j_initial, i_final, j_final);
                if (check_multipleMoves(i_initial, j_initial, i_final, j_final) == false)
                {
                    check_pieceIsKing(i_final, j_final);
                    swap_currentPlayerTurn(specialProprieties.getPlayerTurn());
                    swap_currentPlayerName();
                    specialProprieties.setMultipleMoves(false);
                }
                else
                {
                    specialProprieties.setMultipleMoves(true);
                    specialProprieties.setLastMultipleMoveI(i_initial);
                    specialProprieties.setLastMultipleMoveJ(j_initial);
                    specialProprieties.setCurrentMultipleMoveI(i_final);
                    specialProprieties.setCurrentMultipleMoveJ(j_final);
                    //daca piesa ajunge la final si inca mai poate sari peste alta piesa, sare pestea ea apoi devine rege
                }
            }
            else
            {
                check_pieceIsKing(i_final, j_final);
                swap_currentPlayerTurn(specialProprieties.getPlayerTurn());
                swap_currentPlayerName();
            }
        }
        public bool check_pieceIsKing(int i, int j)
        {
            if (pictureBoxButtons[i][j].getValue() == 1 && i == 7)
            {
                pictureBoxButtons[i][j].setValue(3);
                pictureBoxButtons[i][j].getPictureBox().BackgroundImage = Resources.BlackKing;
                return true;
            }
            if (pictureBoxButtons[i][j].getValue() == 2 && i == 0)
            {
                pictureBoxButtons[i][j].setValue(4);
                pictureBoxButtons[i][j].getPictureBox().BackgroundImage = Resources.RedKing;
                return true;
            }
            return false;
        }

        public void pictureBox_click(object sender)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (sender == pictureBoxButtons[i][j].getPictureBox())
                    {
                        if (specialProprieties.getPressed() == false)
                            check_initialMove(i, j);
                        else
                        {
                            check_finalMove(i_firstMove, j_firstMove, i, j);
                        }
                    }
                }
            }

        }

        public GameBoard(String player1,String player2)
        {
            MaximizeBox = false;

            initStartState();
            //initBtnTabla();
            testTablA();
            InitializeComponent();
            initPlayerNames(player1,player2);
            currentPlayerTextBox.Text = "Rosu muta";
            currentPlayerTextBox.ForeColor = Color.Red;

        }

        private void player1TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


