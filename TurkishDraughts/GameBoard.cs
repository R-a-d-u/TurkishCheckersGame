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
        private void testTabla()
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

            pictureBoxButtons[0][0].setValue(3);
            pictureBoxButtons[0][2].setValue(2);
            pictureBoxButtons[2][3].setValue(2);
            //pictureBoxButtons[2][3].setValue(1);
            pictureBoxButtons[3][1].setValue(2);
            pictureBoxButtons[1][0].setValue(2);
            pictureBoxButtons[6][0].setValue(2);

            pictureBoxButtons[6][6].setValue(1);

            pictureBoxButtons[4][0].setValue(1);

            pictureBoxButtons[0][0].getPictureBox().BackgroundImage = Resources.BlackKing;

            pictureBoxButtons[0][2].getPictureBox().BackgroundImage = Resources.RedPiece;
            pictureBoxButtons[2][3].getPictureBox().BackgroundImage = Resources.RedPiece;
            //pictureBoxButtons[2][3].getPictureBox().BackgroundImage = Resources.BlackPiece;
            pictureBoxButtons[3][1].getPictureBox().BackgroundImage = Resources.RedPiece;
            pictureBoxButtons[1][0].getPictureBox().BackgroundImage = Resources.RedPiece;
            pictureBoxButtons[6][0].getPictureBox().BackgroundImage = Resources.RedPiece;
            pictureBoxButtons[6][6].getPictureBox().BackgroundImage = Resources.BlackPiece;
            pictureBoxButtons[4][0].getPictureBox().BackgroundImage = Resources.BlackPiece;
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
        private void remove_boardTraces()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    pictureBoxButtons[i][j].getPictureBox().BackColor = Color.Transparent;
                }
        }
        public void swap_currentPlayerName()
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
        public void swap_currentPlayerTurn(bool turn)
        {
            if (turn == false)
                pictureBoxPressed.setPlayerTurn(true);
            else
                pictureBoxPressed.setPlayerTurn(false);
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
            pictureBoxPressed.setPressed(false);
        }
        public void check_initialMove(int i, int j)
        {
            i_firstMove = i;
            j_firstMove = j;
            pictureBoxButtons[i][j].getPictureBox().BackColor = Color.GreenYellow;
            pictureBoxPressed.setPressed(true);
            check_legalMoves(i, j);
        }
        public void check_finalMove(int i_initial, int j_initial, int i_final, int j_final)
        {
            if (pictureBoxPressed.getPressed() == true)
            {

                if (pictureBoxButtons[i_final][j_final].getValue() != 0 ||
                    pictureBoxButtons[i_initial][j_initial].getValue() == 0 ||
                    pictureBoxButtons[i_initial][j_initial].getValue() % 2 != 0 && pictureBoxPressed.getPlayerTurn() == false ||
                    pictureBoxButtons[i_initial][j_initial].getValue() % 2 == 0 && pictureBoxPressed.getPlayerTurn() == true ||
                    pictureBoxButtons[i_final][j_final].getPictureBox().BackColor != Color.GreenYellow
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
        }
        public void check_legalMoves(int i, int j)
        {
            if (pictureBoxButtons[i][j].getValue() != 0)
            {
                draw_LegalMovesTraces(i, j);
            }
        }
        public bool check_multipleMoves(int i, int j)
        {
            //piesa rosie
            if (pictureBoxButtons[i][j].getValue() == 2)
            {
                if (i > 1 && pictureBoxButtons[i - 2][j].getValue() == 0 && pictureBoxButtons[i - 1][j].getValue() % 2 != 0)
                    return true;
                if (j > 1 && pictureBoxButtons[i][j - 2].getValue() == 0 && pictureBoxButtons[i][j - 1].getValue() % 2 != 0)
                    return true;
                if (j < 6 && pictureBoxButtons[i][j + 2].getValue() == 0 && pictureBoxButtons[i][j + 1].getValue() % 2 != 0)
                    return true;
            }
            //piesa neagra
            if (pictureBoxButtons[i][j].getValue() == 1)
            {
                if (i < 6 && pictureBoxButtons[i + 2][j].getValue() == 0 && pictureBoxButtons[i + 1][j].getValue() % 2 == 0 && pictureBoxButtons[i + 1][j].getValue() != 0)
                    return true;
                if (j < 6 && pictureBoxButtons[i][j + 2].getValue() == 0 && pictureBoxButtons[i][j + 1].getValue() % 2 == 0 && pictureBoxButtons[i][j + 1].getValue() != 0)
                    return true;
                if (j > 1 && pictureBoxButtons[i][j - 2].getValue() == 0 && pictureBoxButtons[i][j - 1].getValue() % 2 == 0 && pictureBoxButtons[i][j - 1].getValue() != 0)
                    return true;
            }
            //rege rosu
            if (pictureBoxButtons[i][j].getValue() == 4)
            {
                int i_search = i, j_search = j;
                bool redPieceInBetween = false;
                while (j_search > 1 && !redPieceInBetween)
                {
                    j_search--;
                    if (pictureBoxButtons[i][j_search].getValue() % 2 == 0 && pictureBoxButtons[i][j_search].getValue()!=0)
                        redPieceInBetween = true;
                    if (pictureBoxButtons[i][j_search].getValue() % 2 != 0 && pictureBoxButtons[i][j_search].getValue() != 0 && pictureBoxButtons[i][j_search - 1].getValue() == 0)
                        return true;      
                }
                i_search = i; j_search = j; redPieceInBetween = false;
                while (j_search < 6 && !redPieceInBetween)
                {
                    j_search++;
                    textBox1.Text = redPieceInBetween.ToString();
                    if (pictureBoxButtons[i][j_search].getValue() % 2 == 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                        redPieceInBetween = true;
                    if (pictureBoxButtons[i][j_search].getValue() % 2 != 0 && pictureBoxButtons[i][j_search].getValue() != 0 && pictureBoxButtons[i][j_search + 1].getValue() == 0)
                        return true;
                }
                i_search = i; j_search = j; redPieceInBetween = false;
                while (i_search > 1 && !redPieceInBetween)
                {
                    i_search--;
                    if (pictureBoxButtons[i_search][j].getValue() % 2 == 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                        redPieceInBetween = true;
                    if (pictureBoxButtons[i_search][j].getValue() % 2 != 0 && pictureBoxButtons[i_search][j].getValue() != 0 && pictureBoxButtons[i_search - 1][j].getValue() == 0)
                        return true;
                }
                i_search = i; j_search = j; redPieceInBetween = false;
                while (i_search < 6 && !redPieceInBetween)
                {
                    i_search++;
                    if (pictureBoxButtons[i_search][j].getValue() % 2 == 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                        redPieceInBetween = true;
                    if (pictureBoxButtons[i_search][j].getValue() % 2 != 0 && pictureBoxButtons[i_search][j].getValue() != 0 && pictureBoxButtons[i_search + 1][j].getValue() == 0)
                        return true;
                }
 
            }
            //rege negru
            if (pictureBoxButtons[i][j].getValue() == 3)
            {
                int i_search = i, j_search = j;
                bool blackPieceInBetween = false;
                while (j_search > 1 && !blackPieceInBetween)
                {
                    j_search--;
                    if (pictureBoxButtons[i][j_search].getValue() % 2 != 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                        blackPieceInBetween = true;
                    if (pictureBoxButtons[i][j_search].getValue() % 2 == 0 && pictureBoxButtons[i][j_search].getValue() != 0 && pictureBoxButtons[i][j_search - 1].getValue() == 0)
                        return true;
                }
                i_search = i; j_search = j; blackPieceInBetween = false;
                while (j_search < 6 && !blackPieceInBetween)
                {
                    j_search++;
                    if (pictureBoxButtons[i][j_search].getValue() % 2 != 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                        blackPieceInBetween = true;
                    if (pictureBoxButtons[i][j_search].getValue() % 2 == 0 && pictureBoxButtons[i][j_search].getValue() != 0 && pictureBoxButtons[i][j_search + 1].getValue() == 0)
                        return true;
                }
                i_search = i; j_search = j; blackPieceInBetween = false;
                while (i_search > 1 && !blackPieceInBetween)
                {
                    i_search--;
                    if (pictureBoxButtons[i_search][j].getValue() % 2 != 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                        blackPieceInBetween = true;
                    if (pictureBoxButtons[i_search][j].getValue() % 2 == 0 && pictureBoxButtons[i_search][j].getValue() != 0 && pictureBoxButtons[i_search - 1][j].getValue() == 0)
                        return true;
                }
                i_search = i; j_search = j; blackPieceInBetween = false;
                while (i_search < 6 && !blackPieceInBetween)
                {
                    i_search++;
                    if (pictureBoxButtons[i_search][j].getValue() % 2 != 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                        blackPieceInBetween = true;
                    if (pictureBoxButtons[i_search][j].getValue() % 2 == 0 && pictureBoxButtons[i_search][j].getValue() != 0 && pictureBoxButtons[i_search + 1][j].getValue() == 0)
                        return true;
                }


            }


            return false;

        }
        public void draw_LegalMovesTraces(int i, int j)
        {
            if (pictureBoxButtons[i][j].getValue() % 2 == 0)
            {
                //spatiu gol
                if (i > 0 && pictureBoxButtons[i - 1][j].getValue() == 0)
                    pictureBoxButtons[i - 1][j].getPictureBox().BackColor = Color.GreenYellow;
                if (j > 0 && pictureBoxButtons[i][j - 1].getValue() == 0)
                    pictureBoxButtons[i][j - 1].getPictureBox().BackColor = Color.GreenYellow;
                if (j < 7 && pictureBoxButtons[i][j + 1].getValue() == 0)
                    pictureBoxButtons[i][j + 1].getPictureBox().BackColor = Color.GreenYellow;
                //piesa langa
                if (i > 1 && pictureBoxButtons[i - 2][j].getValue() == 0 && pictureBoxButtons[i - 1][j].getValue() % 2 != 0)
                    pictureBoxButtons[i - 2][j].getPictureBox().BackColor = Color.GreenYellow;
                if (j > 1 && pictureBoxButtons[i][j - 2].getValue() == 0 && pictureBoxButtons[i][j - 1].getValue() % 2 != 0)
                    pictureBoxButtons[i][j - 2].getPictureBox().BackColor = Color.GreenYellow;
                if (j < 6 && pictureBoxButtons[i][j + 2].getValue() == 0 && pictureBoxButtons[i][j + 1].getValue() % 2 != 0)
                    pictureBoxButtons[i][j + 2].getPictureBox().BackColor = Color.GreenYellow;

                //rege rosu - stanga
                if (pictureBoxButtons[i][j].getValue() == 4)
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
                    //rege rosu - dreapta 
                    i_search = i; j_search = j; contor = 0;
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
                    //rege rosu -sus
                    i_search = i; j_search = j; contor = 0;
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
                    //rege rosu -jos
                    i_search = i; j_search = j; contor = 0;
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
            }
            if (pictureBoxButtons[i][j].getValue() % 2 != 0)
            {
                //spatiu gol
                if (i < 7 && pictureBoxButtons[i + 1][j].getValue() == 0)
                    pictureBoxButtons[i + 1][j].getPictureBox().BackColor = Color.GreenYellow;
                if (j < 7 && pictureBoxButtons[i][j + 1].getValue() == 0)
                    pictureBoxButtons[i][j + 1].getPictureBox().BackColor = Color.GreenYellow;
                if (j > 0 && pictureBoxButtons[i][j - 1].getValue() == 0)
                    pictureBoxButtons[i][j - 1].getPictureBox().BackColor = Color.GreenYellow;
                //piesa langa
                if (i < 6 && pictureBoxButtons[i + 2][j].getValue() == 0 && pictureBoxButtons[i + 1][j].getValue() % 2 == 0 && pictureBoxButtons[i + 1][j].getValue() != 0)
                    pictureBoxButtons[i + 2][j].getPictureBox().BackColor = Color.GreenYellow;
                if (j < 6 && pictureBoxButtons[i][j + 2].getValue() == 0 && pictureBoxButtons[i][j + 1].getValue() % 2 == 0 && pictureBoxButtons[i][j + 1].getValue() != 0)
                    pictureBoxButtons[i][j + 2].getPictureBox().BackColor = Color.GreenYellow;
                if (j > 1 && pictureBoxButtons[i][j - 2].getValue() == 0 && pictureBoxButtons[i][j - 1].getValue() % 2 == 0 && pictureBoxButtons[i][j - 1].getValue() != 0)
                    pictureBoxButtons[i][j - 2].getPictureBox().BackColor = Color.GreenYellow;

                //rege negru -stanga
                if (pictureBoxButtons[i][j].getValue() == 3)
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
                    //rege negru-dreapta
                    i_search = i; j_search = j; contor = 0;
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
                    //rege negru-sus
                    i_search = i; j_search = j; contor = 0;
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
                    //rege negru-jos
                    i_search = i; j_search = j; contor = 0;
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
            pictureBoxPressed.setPressed(false);
            swap_image(i_initial, j_initial, i_final, j_final);
            swap_value(i_initial, j_initial, i_final, j_final);
            if (remove_capturedPieces(i_initial, j_initial, i_final, j_final))
            {
                remove_capturedPieces(i_initial, j_initial, i_final, j_final);
                if (check_multipleMoves(i_final, j_final) == false)
                {
                    check_pieceIsKing(i_final, j_final);
                    swap_currentPlayerTurn(pictureBoxPressed.getPlayerTurn());
                    swap_currentPlayerName();
                }
                else
                {
                    //daca piesa ajunge la final si inca mai poate sari peste alta piesa, sare pestea ea apoi devine rege
                }
            }
            else
            {
                check_pieceIsKing(i_final, j_final);
                swap_currentPlayerTurn(pictureBoxPressed.getPlayerTurn());
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
                        if (pictureBoxPressed.getPressed() == false)
                            check_initialMove(i, j);
                        else
                        {
                            check_finalMove(i_firstMove, j_firstMove, i, j);
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
            //initBtnTabla();
            testTabla();
            InitializeComponent();
            currentPlayerTextBox.Text = currentPlayer.getName();
            currentPlayerTextBox.ForeColor = Color.Red;

        }
    }
}


