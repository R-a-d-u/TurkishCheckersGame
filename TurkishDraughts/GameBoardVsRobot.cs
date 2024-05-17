using TurkishDraughts.Properties;

namespace TurkishDraughts
{
    public partial class GameBoardVsRobot : Form
    {
        private PieceClass[][] pictureBoxButtons;
        private PlayerClass player1, player2, currentPlayer;
        private SpecialProprieties specialProprieties;
        private int i_firstMove, j_firstMove;
        private bool playerRobot = false;
        private String playerName;
        private List<Task> allRunningAsyncTasks = new List<Task>();
        List<Tuple<int, int>> redPiecesWhoCanCapture = new List<Tuple<int, int>>();
        List<Tuple<int, int>> blackPiecesWhoCanCapture = new List<Tuple<int, int>>();

        public GameBoardVsRobot(String playerNameForm)
        {
            MaximizeBox = false;
            playerName = playerNameForm;
            initStartState();
            InitializeComponent();
            initBoardButtons();
            blockPictureBox();
            initPlayerNames();
            choseColorButtonBlink();
        }

        private async Task choseColorButtonBlink()
        {
            while (choseColorButton.Enabled == true)
            {
                choseColorButton.BackColor = Color.FromArgb(241, 217, 181);
                await Task.Delay(250);
                choseColorButton.BackColor = Color.FromArgb(181, 136, 99);
                await Task.Delay(250);
            }
        }

        private void initBoardButtons()
        {
            //atribuim o matrice de clase piesa, fiecare legat de picturebox
            int value = 0;
            pictureBoxButtons = new PieceClass[8][];
            for (int i = 0; i < 8; i++)
            {
                pictureBoxButtons[i] = new PieceClass[8];
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    pictureBoxButtons[i][j] = new PieceClass(i, j, value, null, null, this);
                    Controls.Add(pictureBoxButtons[i][j].getPictureBox());
                }
            }

        }

        private void initPlayerNames()
        {
            player1 = new PlayerClass("Red");
            player1TextBox.Text = player1.getName();
            player2 = new PlayerClass("Black");
            player2TextBox.Text = player2.getName();
            currentPlayer = player1;
            currentPlayerTextBox.Text = "Red moves";
            currentPlayerTextBox.ForeColor = Color.Red;
            player2TextBox.BackColor = Color.FromArgb(49, 46, 43);
            player2TextBox.ForeColor = Color.FromArgb(49, 46, 43);
        }

        private void initStartState()
        {
            specialProprieties = new SpecialProprieties(false, false, false, 0, 0, 0, 0);
        }

        private void removeBoardTraces()
        {
            //sterge casutele verzi,marcheaza tuplul de miscari de capturare
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (!specialProprieties.getPlayerTurn())
                    {
                        if (!redPiecesWhoCanCapture.Any(tuple => tuple.Item1 == i && tuple.Item2 == j))
                            pictureBoxButtons[i][j].getPictureBox().BackColor = Color.Transparent;
                        else
                            pictureBoxButtons[i][j].getPictureBox().BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        if (!blackPiecesWhoCanCapture.Any(tuple => tuple.Item1 == i && tuple.Item2 == j))
                            pictureBoxButtons[i][j].getPictureBox().BackColor = Color.Transparent;
                        else
                            pictureBoxButtons[i][j].getPictureBox().BackColor = Color.GreenYellow;
                    }
                }
            if (specialProprieties.getPieceCanDoAMultipleMove())
                pictureBoxButtons[specialProprieties.getCurrentMultipleMovePositionI()][specialProprieties.getCurrentMultipleMovePositionJ()].getPictureBox().BackColor = Color.GreenYellow;
        }

        private void blockPictureBox()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    pictureBoxButtons[i][j].getPictureBox().Enabled = false;
                }
            }
            removeBoardTraces();
        }

        private void unblockPictureBox()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    pictureBoxButtons[i][j].getPictureBox().Enabled = true;
                }
            }
            removeBoardTraces();
        }
        private bool checkIfFirstRedPieceCanCapture()
        {
            redPiecesWhoCanCapture.Clear();
            bool moveFound = false;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (checkMultipleMoves(i, j, i, j) && pictureBoxButtons[i][j].getValue() % 2 == 0 && pictureBoxButtons[i][j].getValue() != 0)
                    {
                        moveFound = true;
                        redPiecesWhoCanCapture.Add(Tuple.Create(i, j));
                    }
                }
            if (moveFound)
                return true;
            return false;
        }
        private bool checkIfFirstBlackPieceCanCapture()
        {
            blackPiecesWhoCanCapture.Clear();
            bool moveFound = false;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (checkMultipleMoves(i, j, i, j) && pictureBoxButtons[i][j].getValue() % 2 != 0 && pictureBoxButtons[i][j].getValue() != 0)
                    {
                        moveFound = true;
                        blackPiecesWhoCanCapture.Add(Tuple.Create(i, j));
                    }
                }
            if (moveFound)
                return true;
            return false;
        }

        private async Task checkGameOver(PlayerClass player1, PlayerClass player2)
        {
            await Task.WhenAll(allRunningAsyncTasks);
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
                    currentPlayerTextBox.Text = "Game over";
                    currentPlayerTextBox.ForeColor = Color.Blue;
                    currentPlayer.setName(player1.getName());
                    GameOverForm gameOverForm = new GameOverForm("Game over.\n" + player1.getName() + " wins!");
                    gameOverForm.Show();
                }
                if (counterRed == 0)
                {
                    player1TextBox.BackColor = Color.FromArgb(49, 46, 43);
                    player2TextBox.BackColor = Color.FromArgb(49, 46, 43);
                    currentPlayerTextBox.Text = "Game over";
                    currentPlayerTextBox.ForeColor = Color.Blue;
                    currentPlayer.setName(player2.getName());
                    GameOverForm gameOverForm = new GameOverForm("Game over.\n" + player2.getName() + " wins!");
                    gameOverForm.Show();
                }

                blockPictureBox();
                removeBoardTraces();
            }
            if (counterBlack == 1 && counterRed == 1 && specialProprieties.getPieceCanDoAMultipleMove() == false)
            {
                player1TextBox.BackColor = Color.FromArgb(49, 46, 43);
                player2TextBox.BackColor = Color.FromArgb(49, 46, 43);
                currentPlayerTextBox.Text = "Game over";
                currentPlayerTextBox.ForeColor = Color.Blue;
                GameOverForm gameOverForm = new GameOverForm("Game over.\n" + "It's a draw!");
                gameOverForm.Show();
                blockPictureBox();
                removeBoardTraces();
            }
        }

        public void swapCurrentPlayerName()
        {
            if (specialProprieties.getPlayerTurn() == false)
            {
                checkIfFirstRedPieceCanCapture();
                currentPlayerTextBox.Text = "Red moves";
                currentPlayerTextBox.ForeColor = Color.Red;
                player1TextBox.BackColor = Color.FromArgb(181, 136, 99);

                player2TextBox.BackColor = Color.FromArgb(49, 46, 43);
                player2TextBox.ForeColor = Color.FromArgb(49, 46, 43);
            }
            else
            {
                checkIfFirstBlackPieceCanCapture();
                currentPlayerTextBox.Text = "Black moves";
                currentPlayerTextBox.ForeColor = Color.Black;
                player2TextBox.BackColor = Color.FromArgb(181, 136, 99);
                player1TextBox.BackColor = Color.FromArgb(49, 46, 43);
                player1TextBox.ForeColor = Color.FromArgb(49, 46, 43);
            }
        }

        public void swapCurrentPlayerTurn(bool turn)
        {
            if (turn == false)
                specialProprieties.setPlayerTurn(true);
            else
                specialProprieties.setPlayerTurn(false);
        }

        public void swapImage(int i_initial, int j_initial, int i_final, int j_final)
        {
            pictureBoxButtons[i_final][j_final].getPictureBox().BackgroundImage = pictureBoxButtons[i_initial][j_initial].getPictureBox().BackgroundImage;
            pictureBoxButtons[i_initial][j_initial].getPictureBox().BackgroundImage = null;
        }

        public void swapValue(int i_initial, int j_initial, int i_final, int j_final)
        {
            pictureBoxButtons[i_final][j_final].setValue(pictureBoxButtons[i_initial][j_initial].getValue());
            pictureBoxButtons[i_initial][j_initial].setValue(0);
        }

        public void resetPictureboxPressed(int i_initial, int j_initial, int i_final, int j_final)
        {
            pictureBoxButtons[i_initial][j_initial].getPictureBox().BackColor = Color.Transparent;
            specialProprieties.setPressed(false);
        }

        public void checkInitialMove(int i, int j)
        {
            i_firstMove = i;
            j_firstMove = j;
            pictureBoxButtons[i][j].getPictureBox().BackColor = Color.GreenYellow;
            specialProprieties.setPressed(true);
            checkLegalMoves(i, j);
        }

        public async Task checkFinalMove(int i_initial, int j_initial, int i_final, int j_final)
        {
            //verificam daca locul unde vrem sa mutam e permis, da->muta, nu->reseteaza miscare
            if (specialProprieties.getPressed() == true)
            {
                if (pictureBoxButtons[i_final][j_final].getValue() != 0 ||
                    pictureBoxButtons[i_initial][j_initial].getValue() == 0 ||
                    pictureBoxButtons[i_initial][j_initial].getValue() % 2 != 0 && specialProprieties.getPlayerTurn() == false ||
                    pictureBoxButtons[i_initial][j_initial].getValue() % 2 == 0 && specialProprieties.getPlayerTurn() == true ||
                    pictureBoxButtons[i_final][j_final].getPictureBox().BackColor != Color.GreenYellow ||
                    (specialProprieties.getPieceCanDoAMultipleMove() == true &&
                    (specialProprieties.getCurrentMultipleMovePositionI() != i_initial || specialProprieties.getCurrentMultipleMovePositionJ() != j_initial))
                    )
                {
                    resetPictureboxPressed(i_initial, j_initial, i_final, j_final);
                    removeBoardTraces();
                }
                else
                {
                    redPiecesWhoCanCapture.Clear();
                    blackPiecesWhoCanCapture.Clear();
                    movePiece(i_initial, j_initial, i_final, j_final);

                    //delay 0.3 sec intre mutare jucator si robot
                    await Task.Delay(300);

                    if (specialProprieties.getPlayerTurn() == !playerRobot)
                        computerAIMoveSteps(playerRobot, false);

                }
                removeBoardTraces();
            }

            checkGameOver(player1, player2);
        }

        public void checkLegalMoves(int i, int j)
        {
            if (pictureBoxButtons[i][j].getValue() != 0)
            {
                drawLegalMovesTraces(i, j);
            }
        }

        public bool checkMultipleMovesBlackPiece(int i, int j)
        {
            if (i < 6 && pictureBoxButtons[i + 2][j].getValue() == 0 && pictureBoxButtons[i + 1][j].getValue() % 2 == 0 && pictureBoxButtons[i + 1][j].getValue() != 0)
                return true;
            if (j < 6 && pictureBoxButtons[i][j + 2].getValue() == 0 && pictureBoxButtons[i][j + 1].getValue() % 2 == 0 && pictureBoxButtons[i][j + 1].getValue() != 0)
                return true;
            if (j > 1 && pictureBoxButtons[i][j - 2].getValue() == 0 && pictureBoxButtons[i][j - 1].getValue() % 2 == 0 && pictureBoxButtons[i][j - 1].getValue() != 0)
                return true;
            return false;
        }

        public bool checkMultipleMovesRedPiece(int i, int j)
        {
            if (i > 1 && pictureBoxButtons[i - 2][j].getValue() == 0 && pictureBoxButtons[i - 1][j].getValue() % 2 != 0)
                return true;
            if (j > 1 && pictureBoxButtons[i][j - 2].getValue() == 0 && pictureBoxButtons[i][j - 1].getValue() % 2 != 0)
                return true;
            if (j < 6 && pictureBoxButtons[i][j + 2].getValue() == 0 && pictureBoxButtons[i][j + 1].getValue() % 2 != 0)
                return true;
            return false;
        }

        public bool checkMultipleMovesRedKingLeft(int i_intial, int j_initial, int i, int j)
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

        public bool checkMultipleMovesRedKingRight(int i_intial, int j_initial, int i, int j)
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

        public bool checkMultipleMovesRedKingUp(int i_intial, int j_initial, int i, int j)
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

        public bool checkMultipleMovesRedKingDown(int i_intial, int j_initial, int i, int j)
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

        public bool checkMultipleMovesBlackKingLeft(int i_intial, int j_initial, int i, int j)
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

        public bool checkMultipleMovesBlackKingRight(int i_intial, int j_initial, int i, int j)
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

        public bool checkMultipleMovesBlackKingUp(int i_intial, int j_initial, int i, int j)
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

        public bool checkMultipleMovesBlackKingDown(int i_intial, int j_initial, int i, int j)
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

        public bool checkMultipleMoves(int i_initial, int j_initial, int i, int j)
        {
            //piesa rosie
            if (pictureBoxButtons[i][j].getValue() == 2)
            {
                if (checkMultipleMovesRedPiece(i, j))
                    return true;
            }
            //piesa neagra
            if (pictureBoxButtons[i][j].getValue() == 1)
            {
                if (checkMultipleMovesBlackPiece(i, j))
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

                //verifica miscari legale in toate directiile cu exceptia locului de unde a venit
                if (!j_left)
                    if (checkMultipleMovesRedKingLeft(i_initial, j_initial, i, j))
                        return true;
                if (!j_right)
                    if (checkMultipleMovesRedKingRight(i_initial, j_initial, i, j))
                        return true;
                if (!i_up)
                    if (checkMultipleMovesRedKingUp(i_initial, j_initial, i, j))
                        return true;
                if (!i_down)
                    if (checkMultipleMovesRedKingDown(i_initial, j_initial, i, j))
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
                    if (checkMultipleMovesBlackKingLeft(i_initial, j_initial, i, j))
                        return true;

                if (!j_right)
                    if (checkMultipleMovesBlackKingRight(i_initial, j_initial, i, j))
                        return true;
                if (!i_up)
                    if (checkMultipleMovesBlackKingUp(i_initial, j_initial, i, j))
                        return true;
                if (!i_down)
                    if (checkMultipleMovesBlackKingDown(i_initial, j_initial, i, j))
                        return true;
            }
            return false;
        }

        public void drawRedPieceTrace(int i, int j)
        {
            //spatiul gol
            if (specialProprieties.getPieceCanDoAMultipleMove() == false && !checkIfFirstRedPieceCanCapture())
            {
                if (i > 0 && pictureBoxButtons[i - 1][j].getValue() == 0)
                    pictureBoxButtons[i - 1][j].getPictureBox().BackColor = Color.GreenYellow;
                if (j > 0 && pictureBoxButtons[i][j - 1].getValue() == 0)
                    pictureBoxButtons[i][j - 1].getPictureBox().BackColor = Color.GreenYellow;
                if (j < 7 && pictureBoxButtons[i][j + 1].getValue() == 0)
                    pictureBoxButtons[i][j + 1].getPictureBox().BackColor = Color.GreenYellow;
            }
            //spatiul sariturii peste piesa ce poate fi capturata
            if (i > 1 && pictureBoxButtons[i - 2][j].getValue() == 0 && pictureBoxButtons[i - 1][j].getValue() % 2 != 0)
                pictureBoxButtons[i - 2][j].getPictureBox().BackColor = Color.GreenYellow;
            if (j > 1 && pictureBoxButtons[i][j - 2].getValue() == 0 && pictureBoxButtons[i][j - 1].getValue() % 2 != 0)
                pictureBoxButtons[i][j - 2].getPictureBox().BackColor = Color.GreenYellow;
            if (j < 6 && pictureBoxButtons[i][j + 2].getValue() == 0 && pictureBoxButtons[i][j + 1].getValue() % 2 != 0)
                pictureBoxButtons[i][j + 2].getPictureBox().BackColor = Color.GreenYellow;

            if ((specialProprieties.getCurrentMultipleMovePositionI() != i ||
           specialProprieties.getCurrentMultipleMovePositionJ() != j) &&
           specialProprieties.getPieceCanDoAMultipleMove())
                removeBoardTraces();
        }

        public void drawBlackPieceTrace(int i, int j)
        {
            //spatiul gol
            if (specialProprieties.getPieceCanDoAMultipleMove() == false && !checkIfFirstBlackPieceCanCapture())
            {
                if (i < 7 && pictureBoxButtons[i + 1][j].getValue() == 0)
                    pictureBoxButtons[i + 1][j].getPictureBox().BackColor = Color.GreenYellow;
                if (j < 7 && pictureBoxButtons[i][j + 1].getValue() == 0)
                    pictureBoxButtons[i][j + 1].getPictureBox().BackColor = Color.GreenYellow;
                if (j > 0 && pictureBoxButtons[i][j - 1].getValue() == 0)
                    pictureBoxButtons[i][j - 1].getPictureBox().BackColor = Color.GreenYellow;
            }
            //spatiul sariturii peste piesa ce poate fi capturata
            if (i < 6 && pictureBoxButtons[i + 2][j].getValue() == 0 && pictureBoxButtons[i + 1][j].getValue() % 2 == 0 && pictureBoxButtons[i + 1][j].getValue() != 0)
                pictureBoxButtons[i + 2][j].getPictureBox().BackColor = Color.GreenYellow;
            if (j < 6 && pictureBoxButtons[i][j + 2].getValue() == 0 && pictureBoxButtons[i][j + 1].getValue() % 2 == 0 && pictureBoxButtons[i][j + 1].getValue() != 0)
                pictureBoxButtons[i][j + 2].getPictureBox().BackColor = Color.GreenYellow;
            if (j > 1 && pictureBoxButtons[i][j - 2].getValue() == 0 && pictureBoxButtons[i][j - 1].getValue() % 2 == 0 && pictureBoxButtons[i][j - 1].getValue() != 0)
                pictureBoxButtons[i][j - 2].getPictureBox().BackColor = Color.GreenYellow;

            if ((specialProprieties.getCurrentMultipleMovePositionI() != i ||
            specialProprieties.getCurrentMultipleMovePositionJ() != j) &&
            specialProprieties.getPieceCanDoAMultipleMove())
                removeBoardTraces();
        }

        public List<Tuple<int, int, int>> drawRedKingLeftTrace(int i, int j)
        {
            List<Tuple<int, int, int>> greenYellowPositions = new List<Tuple<int, int, int>>();
            int i_search = i, j_search = j, contor = 0;
            while (j_search > 0 && contor < 2)
            {
                j_search--;
                if (pictureBoxButtons[i][j_search].getValue() % 2 != 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                    contor++;
                if (pictureBoxButtons[i][j_search].getValue() % 2 == 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                    contor = 2;
                if (pictureBoxButtons[i][j_search].getValue() == 0)
                {
                    pictureBoxButtons[i][j_search].getPictureBox().BackColor = Color.GreenYellow;
                    if ((specialProprieties.getPieceCanDoAMultipleMove() && contor == 0) || (checkIfFirstRedPieceCanCapture() && contor == 0))
                        pictureBoxButtons[i][j_search].getPictureBox().BackColor = Color.Transparent;
                    greenYellowPositions.Add(Tuple.Create(i, j_search, contor));
                }
            }
            return greenYellowPositions;
        }

        public List<Tuple<int, int, int>> drawRedKingRightTrace(int i, int j)
        {
            List<Tuple<int, int, int>> greenYellowPositions = new List<Tuple<int, int, int>>();
            int i_search = i, j_search = j, contor = 0;
            while (j_search < 7 && contor < 2)
            {
                j_search++;
                if (pictureBoxButtons[i][j_search].getValue() % 2 != 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                    contor++;
                if (pictureBoxButtons[i][j_search].getValue() % 2 == 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                    contor = 2;
                if (pictureBoxButtons[i][j_search].getValue() == 0)
                {
                    pictureBoxButtons[i][j_search].getPictureBox().BackColor = Color.GreenYellow;
                    if ((specialProprieties.getPieceCanDoAMultipleMove() && contor == 0) || (checkIfFirstRedPieceCanCapture() && contor == 0))
                        pictureBoxButtons[i][j_search].getPictureBox().BackColor = Color.Transparent;

                    greenYellowPositions.Add(Tuple.Create(i, j_search, contor));
                }
            }
            return greenYellowPositions;
        }

        public List<Tuple<int, int, int>> drawRedKingUpTrace(int i, int j)
        {
            List<Tuple<int, int, int>> greenYellowPositions = new List<Tuple<int, int, int>>();
            int i_search = i, j_search = j, contor = 0;
            while (i_search > 0 && contor < 2)
            {
                i_search--;
                if (pictureBoxButtons[i_search][j].getValue() % 2 != 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                    contor++;
                if (pictureBoxButtons[i_search][j].getValue() % 2 == 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                    contor = 2;
                if (pictureBoxButtons[i_search][j].getValue() == 0)
                {
                    pictureBoxButtons[i_search][j].getPictureBox().BackColor = Color.GreenYellow;
                    if ((specialProprieties.getPieceCanDoAMultipleMove() && contor == 0) || (checkIfFirstRedPieceCanCapture() && contor == 0))
                        pictureBoxButtons[i_search][j].getPictureBox().BackColor = Color.Transparent;

                    greenYellowPositions.Add(Tuple.Create(i_search, j, contor));
                }
            }
            return greenYellowPositions;
        }

        public List<Tuple<int, int, int>> drawRedKingDownTrace(int i, int j)
        {
            List<Tuple<int, int, int>> greenYellowPositions = new List<Tuple<int, int, int>>();
            int i_search = i, j_search = j, contor = 0;
            while (i_search < 7 && contor < 2)
            {
                i_search++;
                if (pictureBoxButtons[i_search][j].getValue() % 2 != 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                    contor++;
                if (pictureBoxButtons[i_search][j].getValue() % 2 == 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                    contor = 2;
                if (pictureBoxButtons[i_search][j].getValue() == 0)
                {
                    pictureBoxButtons[i_search][j].getPictureBox().BackColor = Color.GreenYellow;
                    if ((specialProprieties.getPieceCanDoAMultipleMove() && contor == 0) || (checkIfFirstRedPieceCanCapture() && contor == 0))
                        pictureBoxButtons[i_search][j].getPictureBox().BackColor = Color.Transparent;

                    greenYellowPositions.Add(Tuple.Create(i_search, j, contor));
                }
            }
            return greenYellowPositions;
        }

        public List<Tuple<int, int, int>> drawBlackKingLeftTrace(int i, int j)
        {
            List<Tuple<int, int, int>> greenYellowPositions = new List<Tuple<int, int, int>>();
            int i_search = i, j_search = j, contor = 0;
            while (j_search > 0 && contor < 2)
            {
                j_search--;
                if (pictureBoxButtons[i][j_search].getValue() % 2 == 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                    contor++;
                if (pictureBoxButtons[i][j_search].getValue() % 2 != 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                    contor = 2;
                if (pictureBoxButtons[i][j_search].getValue() == 0)
                {
                    pictureBoxButtons[i][j_search].getPictureBox().BackColor = Color.GreenYellow;
                    if ((specialProprieties.getPieceCanDoAMultipleMove() && contor == 0) || (checkIfFirstBlackPieceCanCapture() && contor == 0))
                        pictureBoxButtons[i][j_search].getPictureBox().BackColor = Color.Transparent;

                    greenYellowPositions.Add(Tuple.Create(i, j_search, contor));
                }
            }
            return greenYellowPositions;
        }

        public List<Tuple<int, int, int>> drawBlackKingRightTrace(int i, int j)
        {
            List<Tuple<int, int, int>> greenYellowPositions = new List<Tuple<int, int, int>>();
            int i_search = i, j_search = j, contor = 0;
            while (j_search < 7 && contor < 2)
            {
                j_search++;
                if (pictureBoxButtons[i][j_search].getValue() % 2 == 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                    contor++;
                if (pictureBoxButtons[i][j_search].getValue() % 2 != 0 && pictureBoxButtons[i][j_search].getValue() != 0)
                    contor = 2;
                if (pictureBoxButtons[i][j_search].getValue() == 0)
                {
                    pictureBoxButtons[i][j_search].getPictureBox().BackColor = Color.GreenYellow;
                    if ((specialProprieties.getPieceCanDoAMultipleMove() && contor == 0) || (checkIfFirstBlackPieceCanCapture() && contor == 0))
                        pictureBoxButtons[i][j_search].getPictureBox().BackColor = Color.Transparent;

                    greenYellowPositions.Add(Tuple.Create(i, j_search, contor));
                }
            }
            return greenYellowPositions;
        }

        public List<Tuple<int, int, int>> drawBlackKingUpTrace(int i, int j)
        {
            List<Tuple<int, int, int>> greenYellowPositions = new List<Tuple<int, int, int>>();
            int i_search = i, j_search = j, contor = 0;
            while (i_search > 0 && contor < 2)
            {
                i_search--;
                if (pictureBoxButtons[i_search][j].getValue() % 2 == 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                    contor++;
                if (pictureBoxButtons[i_search][j].getValue() % 2 != 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                    contor = 2;
                if (pictureBoxButtons[i_search][j].getValue() == 0)
                {
                    pictureBoxButtons[i_search][j].getPictureBox().BackColor = Color.GreenYellow;
                    if ((specialProprieties.getPieceCanDoAMultipleMove() && contor == 0) || (checkIfFirstBlackPieceCanCapture() && contor == 0))
                        pictureBoxButtons[i_search][j].getPictureBox().BackColor = Color.Transparent;

                    greenYellowPositions.Add(Tuple.Create(i_search, j, contor));
                }
            }
            return greenYellowPositions;
        }

        public List<Tuple<int, int, int>> drawBlackKingDownTrace(int i, int j)
        {
            List<Tuple<int, int, int>> greenYellowPositions = new List<Tuple<int, int, int>>();
            int i_search = i, j_search = j, contor = 0;
            while (i_search < 7 && contor < 2)
            {
                i_search++;
                if (pictureBoxButtons[i_search][j].getValue() % 2 == 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                    contor++;
                if (pictureBoxButtons[i_search][j].getValue() % 2 != 0 && pictureBoxButtons[i_search][j].getValue() != 0)
                    contor = 2;
                if (pictureBoxButtons[i_search][j].getValue() == 0)
                {
                    pictureBoxButtons[i_search][j].getPictureBox().BackColor = Color.GreenYellow;
                    if ((specialProprieties.getPieceCanDoAMultipleMove() && contor == 0) || (checkIfFirstBlackPieceCanCapture() && contor == 0))
                        pictureBoxButtons[i_search][j].getPictureBox().BackColor = Color.Transparent;

                    greenYellowPositions.Add(Tuple.Create(i_search, j, contor));
                }
            }
            return greenYellowPositions;
        }

        public void drawLegalMovesTraces(int i, int j)
        {
            //piese rosii
            if (pictureBoxButtons[i][j].getValue() % 2 == 0)
            {
                drawRedPieceTrace(i, j);

                if (checkIfFirstRedPieceCanCapture())
                {
                    if (!redPiecesWhoCanCapture.Any(tuple => tuple.Item1 == i && tuple.Item2 == j))
                        removeBoardTraces();
                }

                if (pictureBoxButtons[i][j].getValue() == 4)
                {
                    if (specialProprieties.getPieceCanDoAMultipleMove() == false)
                    {
                        if (!checkIfFirstRedPieceCanCapture())
                        {
                            drawRedKingLeftTrace(i, j);
                            drawRedKingRightTrace(i, j);
                            drawRedKingUpTrace(i, j);
                            drawRedKingDownTrace(i, j);
                        }
                        else
                        {
                            if (!redPiecesWhoCanCapture.Any(tuple => tuple.Item1 == i && tuple.Item2 == j))
                                removeBoardTraces();
                            if (checkMultipleMovesRedKingLeft(i, j, i, j))
                                drawRedKingLeftTrace(i, j);
                            if (checkMultipleMovesRedKingRight(i, j, i, j))
                                drawRedKingRightTrace(i, j);
                            if (checkMultipleMovesRedKingUp(i, j, i, j))
                                drawRedKingUpTrace(i, j);
                            if (checkMultipleMovesRedKingDown(i, j, i, j))
                                drawRedKingDownTrace(i, j);
                        }
                    }
                    else
                    {
                        int i_initial = specialProprieties.getLastMultipleMovePositionI();
                        int j_initial = specialProprieties.getLastMultipleMovePositionJ();
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
                            if (checkMultipleMovesRedKingLeft(i_initial, j_initial, i, j))
                                drawRedKingLeftTrace(i, j);
                        if (!j_right)
                            if (checkMultipleMovesRedKingRight(i_initial, j_initial, i, j))
                                drawRedKingRightTrace(i, j);
                        if (!i_up)
                            if (checkMultipleMovesRedKingUp(i_initial, j_initial, i, j))
                                drawRedKingUpTrace(i, j);
                        if (!i_down)
                            if (checkMultipleMovesRedKingDown(i_initial, j_initial, i, j))
                                drawRedKingDownTrace(i, j);

                        if (specialProprieties.getPieceCanDoAMultipleMove())
                        {
                            if ((specialProprieties.getCurrentMultipleMovePositionI() != i || specialProprieties.getCurrentMultipleMovePositionJ() != j))
                                removeBoardTraces();
                        }
                    }
                }
            }
            //piese negre
            if (pictureBoxButtons[i][j].getValue() % 2 != 0)
            {
                drawBlackPieceTrace(i, j);

                if (checkIfFirstBlackPieceCanCapture())
                {
                    if (!blackPiecesWhoCanCapture.Any(tuple => tuple.Item1 == i && tuple.Item2 == j))
                        removeBoardTraces();
                }

                if (pictureBoxButtons[i][j].getValue() == 3)
                    if (specialProprieties.getPieceCanDoAMultipleMove() == false)
                    {
                        if (!checkIfFirstBlackPieceCanCapture())
                        {
                            drawBlackKingLeftTrace(i, j);
                            drawBlackKingRightTrace(i, j);
                            drawBlackKingUpTrace(i, j);
                            drawBlackKingDownTrace(i, j);
                        }
                        else
                        {
                            if (!blackPiecesWhoCanCapture.Any(tuple => tuple.Item1 == i && tuple.Item2 == j))
                                removeBoardTraces();

                            if (checkMultipleMovesBlackKingLeft(i, j, i, j))
                                drawBlackKingLeftTrace(i, j);

                            if (checkMultipleMovesBlackKingRight(i, j, i, j))
                                drawBlackKingRightTrace(i, j);

                            if (checkMultipleMovesBlackKingUp(i, j, i, j))
                                drawBlackKingUpTrace(i, j);

                            if (checkMultipleMovesBlackKingDown(i, j, i, j))
                                drawBlackKingDownTrace(i, j);
                        }
                    }
                    else
                    {
                        int i_initial = specialProprieties.getLastMultipleMovePositionI();
                        int j_initial = specialProprieties.getLastMultipleMovePositionJ();
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
                            if (checkMultipleMovesBlackKingLeft(i_initial, j_initial, i, j))
                                drawBlackKingLeftTrace(i, j);
                        if (!j_right)
                            if (checkMultipleMovesBlackKingRight(i_initial, j_initial, i, j))
                                drawBlackKingRightTrace(i, j);
                        if (!i_up)
                            if (checkMultipleMovesBlackKingUp(i_initial, j_initial, i, j))
                                drawBlackKingUpTrace(i, j);
                        if (!i_down)
                            if (checkMultipleMovesBlackKingDown(i_initial, j_initial, i, j))
                                drawBlackKingDownTrace(i, j);

                        if (specialProprieties.getPieceCanDoAMultipleMove())
                        {
                            if ((specialProprieties.getCurrentMultipleMovePositionI() != i || specialProprieties.getCurrentMultipleMovePositionJ() != j))
                                removeBoardTraces();
                        }
                    }
            }
        }

        public bool removeCapturedPieces(int i_initial, int j_initial, int i_final, int j_final)
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

        public bool AIremoveCapturedPieces(int i_initial, int j_initial, int i_final, int j_final, int[,] valuesMatrix)
        {
            if (j_initial > j_final)
            {
                int j_temp = j_final;
                j_final = j_initial;
                j_initial = j_temp;
            }
            if (i_initial > i_final)
            {
                int i_temp = i_final;
                i_final = i_initial;
                i_initial = i_temp;
            }

            if (j_initial == j_final && i_initial != i_final + 1)
            {
                for (int i = i_initial + 1; i < i_final; i++)
                {
                    if (valuesMatrix[i, j_final] != 0)
                    {
                        valuesMatrix[i, j_final] = 0;
                        return true;
                    }
                }
            }

            if (i_initial == i_final && j_initial != j_final + 1)
            {
                for (int j = j_initial + 1; j < j_final; j++)
                {
                    if (valuesMatrix[i_initial, j] != 0)
                    {
                        valuesMatrix[i_initial, j] = 0;
                        return true;
                    }
                }
            }
            return false;
        }

        public void movePiece(int i_initial, int j_initial, int i_final, int j_final)
        {
            pictureBoxButtons[i_initial][j_initial].getPictureBox().BackColor = Color.Transparent;
            specialProprieties.setPressed(false);
            swapImage(i_initial, j_initial, i_final, j_final);
            swapValue(i_initial, j_initial, i_final, j_final);
            if (removeCapturedPieces(i_initial, j_initial, i_final, j_final))
            {
                removeCapturedPieces(i_initial, j_initial, i_final, j_final);
                if (checkMultipleMoves(i_initial, j_initial, i_final, j_final) == false)
                {
                    checkIfPieceIsKing(i_final, j_final);
                    swapCurrentPlayerTurn(specialProprieties.getPlayerTurn());
                    swapCurrentPlayerName();
                    specialProprieties.setPieceCanDoAMultipleMove(false);
                }
                else
                {
                    specialProprieties.setPieceCanDoAMultipleMove(true);
                    specialProprieties.setLastMultipleMovePositionI(i_initial);
                    specialProprieties.setLastMultipleMovePositionJ(j_initial);
                    specialProprieties.setCurrentMultipleMovePositionI(i_final);
                    specialProprieties.setCurrentMultipleMovePositionJ(j_final);
                }
            }
            else
            {
                checkIfPieceIsKing(i_final, j_final);
                swapCurrentPlayerTurn(specialProprieties.getPlayerTurn());
                swapCurrentPlayerName();
            }
            removeBoardTraces();
        }

        public bool checkIfPieceIsKing(int i, int j)
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

        public void pictureBoxClick(object sender)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (sender == pictureBoxButtons[i][j].getPictureBox())
                    {
                        if (specialProprieties.getPressed() == false)
                            checkInitialMove(i, j);
                        else
                        {
                            checkFinalMove(i_firstMove, j_firstMove, i, j);
                        }
                    }
                }
            }
        }

        private async Task computerBlackPieceCapture(int i, int j)
        {
            while (checkMultipleMoves(specialProprieties.getCurrentMultipleMovePositionI(), specialProprieties.getCurrentMultipleMovePositionJ(), i, j))
            {
                redPiecesWhoCanCapture.Clear();
                blackPiecesWhoCanCapture.Clear();
                if (j < 6)
                    if (pictureBoxButtons[i][j + 1].getValue() % 2 == 0 && pictureBoxButtons[i][j + 1].getValue() != 0 && pictureBoxButtons[i][j + 2].getValue() == 0)
                    {
                        computerMove(i, j, i, j + 2);
                        j = j + 2;
                        await Task.Delay(300);
                        continue;
                    }
                if (j > 1)
                    if (pictureBoxButtons[i][j - 1].getValue() % 2 == 0 && pictureBoxButtons[i][j - 1].getValue() != 0 && pictureBoxButtons[i][j - 2].getValue() == 0)
                    {
                        computerMove(i, j, i, j - 2);
                        j = j - 2;
                        await Task.Delay(300);
                        continue;
                    }
                if (i < 6)
                    if (pictureBoxButtons[i + 1][j].getValue() % 2 == 0 && pictureBoxButtons[i + 1][j].getValue() != 0 && pictureBoxButtons[i + 2][j].getValue() == 0)
                    {
                        computerMove(i, j, i + 2, j);
                        i = i + 2;
                        await Task.Delay(300);
                        continue;
                    }
            }
            specialProprieties.setPieceCanDoAMultipleMove(false);
            checkIfPieceIsKing(i, j);
            pictureBoxButtons[i][j].getPictureBox().BackColor = Color.Transparent;
            swapCurrentPlayerTurn(specialProprieties.getPlayerTurn());
            swapCurrentPlayerName();
            checkIfFirstRedPieceCanCapture();
        }

        private async Task computerRedPieceCapture(int i, int j)
        {
            while (checkMultipleMoves(specialProprieties.getCurrentMultipleMovePositionI(), specialProprieties.getCurrentMultipleMovePositionJ(), i, j))
            {
                redPiecesWhoCanCapture.Clear();
                blackPiecesWhoCanCapture.Clear();
                if (j < 6)
                    if (pictureBoxButtons[i][j + 1].getValue() % 2 != 0 && pictureBoxButtons[i][j + 1].getValue() != 0 && pictureBoxButtons[i][j + 2].getValue() == 0)
                    {
                        computerMove(i, j, i, j + 2);
                        j = j + 2;
                        await Task.Delay(300);
                        continue;
                    }
                if (j > 1)
                    if (pictureBoxButtons[i][j - 1].getValue() % 2 != 0 && pictureBoxButtons[i][j - 1].getValue() != 0 && pictureBoxButtons[i][j - 2].getValue() == 0)
                    {
                        computerMove(i, j, i, j - 2);
                        j = j - 2;
                        await Task.Delay(300);
                        continue;
                    }
                if (i > 1)
                    if (pictureBoxButtons[i - 1][j].getValue() % 2 != 0 && pictureBoxButtons[i - 1][j].getValue() != 0 && pictureBoxButtons[i - 2][j].getValue() == 0)
                    {
                        computerMove(i, j, i - 2, j);
                        i = i - 2;
                        await Task.Delay(300);
                        continue;
                    }
            }
            specialProprieties.setPieceCanDoAMultipleMove(false);
            checkIfPieceIsKing(i, j);
            pictureBoxButtons[i][j].getPictureBox().BackColor = Color.Transparent;
            swapCurrentPlayerTurn(specialProprieties.getPlayerTurn());
            swapCurrentPlayerName();
            removeBoardTraces();
            checkIfFirstBlackPieceCanCapture();
        }

        private async Task computerBlackKingCapture(int i, int j)
        {
            bool firstLoop = true;
            int i_initial = i;
            int j_initial = j;
            //
            while (checkMultipleMoves(i_initial, j_initial, i, j))
            {
                redPiecesWhoCanCapture.Clear();
                blackPiecesWhoCanCapture.Clear();
                List<Tuple<int, int, int>> captureMoves = new List<Tuple<int, int, int>>();
                bool i_up = false;
                bool i_down = false;
                bool j_right = false;
                bool j_left = false;

                if (!firstLoop)
                {
                    i_initial = specialProprieties.getLastMultipleMovePositionI();
                    j_initial = specialProprieties.getLastMultipleMovePositionJ();
                }
                firstLoop = false;

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
                    if (checkMultipleMovesBlackKingLeft(i_initial, j_initial, i, j))
                    {
                        captureMoves = drawBlackKingLeftTrace(i, j);
                        foreach (var move in captureMoves)
                        {
                            int contor = move.Item3;
                            if (contor != 1)
                                continue;
                            int i_capture = move.Item1;
                            int j_capture = move.Item2;

                            pictureBoxButtons[i_capture][j_capture].setValue(3);
                            if (checkMultipleMoves(i, j, i_capture, j_capture))
                            {
                                pictureBoxButtons[i_capture][j_capture].setValue(0);
                                computerMove(i, j, i_capture, j_capture);
                                specialProprieties.setLastMultipleMovePositionI(i);
                                specialProprieties.setLastMultipleMovePositionJ(j);
                                i = i_capture; j = j_capture;
                                i_initial = specialProprieties.getLastMultipleMovePositionI();
                                j_initial = specialProprieties.getLastMultipleMovePositionJ();
                                await Task.Delay(300);
                                goto continueWhile;
                            }
                            if (move == captureMoves.LastOrDefault())
                            {
                                pictureBoxButtons[i_capture][j_capture].setValue(0);
                                computerMove(i, j, i_capture, j_capture);
                                i = i_capture; j = j_capture;
                                await Task.Delay(300);
                                goto continueWhile;
                            }
                            pictureBoxButtons[i_capture][j_capture].setValue(0);
                        }
                    }
                if (!j_right)
                    if (checkMultipleMovesBlackKingRight(i_initial, j_initial, i, j))
                    {
                        captureMoves = drawBlackKingRightTrace(i, j);
                        foreach (var move in captureMoves)
                        {
                            int contor = move.Item3;
                            if (contor != 1)
                                continue;
                            int i_capture = move.Item1;
                            int j_capture = move.Item2;
                            pictureBoxButtons[i_capture][j_capture].setValue(3);
                            if (checkMultipleMoves(i, j, i_capture, j_capture))
                            {
                                pictureBoxButtons[i_capture][j_capture].setValue(0);
                                computerMove(i, j, i_capture, j_capture);
                                specialProprieties.setLastMultipleMovePositionI(i);
                                specialProprieties.setLastMultipleMovePositionJ(j);
                                i = i_capture; j = j_capture;
                                i_initial = specialProprieties.getLastMultipleMovePositionI();
                                j_initial = specialProprieties.getLastMultipleMovePositionJ();
                                await Task.Delay(300);
                                goto continueWhile;
                            }
                            if (move == captureMoves.LastOrDefault())
                            {
                                pictureBoxButtons[i_capture][j_capture].setValue(0);
                                computerMove(i, j, i_capture, j_capture);
                                i = i_capture; j = j_capture;
                                await Task.Delay(300);
                                goto continueWhile;
                            }
                            pictureBoxButtons[i_capture][j_capture].setValue(0);
                        }
                    }
                if (!i_up)
                    if (checkMultipleMovesBlackKingUp(i_initial, j_initial, i, j))
                    {
                        captureMoves = drawBlackKingUpTrace(i, j);
                        foreach (var move in captureMoves)
                        {
                            int contor = move.Item3;
                            if (contor != 1)
                                continue;
                            int i_capture = move.Item1;
                            int j_capture = move.Item2;
                            pictureBoxButtons[i_capture][j_capture].setValue(3);
                            if (checkMultipleMoves(i, j, i_capture, j_capture))
                            {
                                pictureBoxButtons[i_capture][j_capture].setValue(0);
                                computerMove(i, j, i_capture, j_capture);
                                specialProprieties.setLastMultipleMovePositionI(i);
                                specialProprieties.setLastMultipleMovePositionJ(j);
                                i = i_capture; j = j_capture;
                                i_initial = specialProprieties.getLastMultipleMovePositionI();
                                j_initial = specialProprieties.getLastMultipleMovePositionJ();
                                await Task.Delay(300);
                                goto continueWhile;
                            }
                            if (move == captureMoves.LastOrDefault())
                            {
                                pictureBoxButtons[i_capture][j_capture].setValue(0);
                                computerMove(i, j, i_capture, j_capture);
                                i = i_capture; j = j_capture;
                                await Task.Delay(300);
                                goto continueWhile;
                            }
                            pictureBoxButtons[i_capture][j_capture].setValue(0);
                        }
                    }
                if (!i_down)
                    if (checkMultipleMovesBlackKingDown(i_initial, j_initial, i, j))
                    {
                        captureMoves = drawBlackKingDownTrace(i, j);
                        foreach (var move in captureMoves)
                        {
                            int contor = move.Item3;
                            if (contor != 1)
                                continue;
                            int i_capture = move.Item1;
                            int j_capture = move.Item2;
                            pictureBoxButtons[i_capture][j_capture].setValue(3);
                            if (checkMultipleMoves(i, j, i_capture, j_capture))
                            {
                                pictureBoxButtons[i_capture][j_capture].setValue(0);
                                computerMove(i, j, i_capture, j_capture);
                                specialProprieties.setLastMultipleMovePositionI(i);
                                specialProprieties.setLastMultipleMovePositionJ(j);
                                i = i_capture; j = j_capture;
                                i_initial = specialProprieties.getLastMultipleMovePositionI();
                                j_initial = specialProprieties.getLastMultipleMovePositionJ();
                                await Task.Delay(300);
                                goto continueWhile;
                            }
                            if (move == captureMoves.LastOrDefault())
                            {
                                pictureBoxButtons[i_capture][j_capture].setValue(0);
                                computerMove(i, j, i_capture, j_capture);
                                i = i_capture; j = j_capture;
                                await Task.Delay(300);
                                goto continueWhile;
                            }
                            pictureBoxButtons[i_capture][j_capture].setValue(0);
                        }
                    }

                continueWhile: continue;

            }
            specialProprieties.setPieceCanDoAMultipleMove(false);
            checkIfPieceIsKing(i, j);
            pictureBoxButtons[i][j].getPictureBox().BackColor = Color.Transparent;
            swapCurrentPlayerTurn(specialProprieties.getPlayerTurn());
            swapCurrentPlayerName();
            redPiecesWhoCanCapture.Clear();
            blackPiecesWhoCanCapture.Clear();
            removeBoardTraces();
            checkIfFirstRedPieceCanCapture();
        }

        private async Task computerRedKingCapture(int i, int j)
        {
            bool firstLoop = true;
            int i_initial = i;
            int j_initial = j;

            while (checkMultipleMoves(i_initial, j_initial, i, j))
            {
                redPiecesWhoCanCapture.Clear();
                blackPiecesWhoCanCapture.Clear();
                List<Tuple<int, int, int>> captureMoves = new List<Tuple<int, int, int>>();
                bool i_up = false;
                bool i_down = false;
                bool j_right = false;
                bool j_left = false;

                if (!firstLoop)
                {
                    i_initial = specialProprieties.getLastMultipleMovePositionI();
                    j_initial = specialProprieties.getLastMultipleMovePositionJ();
                }
                firstLoop = false;
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
                    if (checkMultipleMovesRedKingLeft(i_initial, j_initial, i, j))
                    {
                        captureMoves = drawRedKingLeftTrace(i, j);
                        foreach (var move in captureMoves)
                        {
                            int contor = move.Item3;
                            if (contor != 1)
                                continue;
                            int i_capture = move.Item1;
                            int j_capture = move.Item2;

                            pictureBoxButtons[i_capture][j_capture].setValue(4);
                            if (checkMultipleMoves(i, j, i_capture, j_capture))
                            {
                                pictureBoxButtons[i_capture][j_capture].setValue(0);
                                computerMove(i, j, i_capture, j_capture);
                                specialProprieties.setLastMultipleMovePositionI(i);
                                specialProprieties.setLastMultipleMovePositionJ(j);
                                i = i_capture; j = j_capture;
                                i_initial = specialProprieties.getLastMultipleMovePositionI();
                                j_initial = specialProprieties.getLastMultipleMovePositionJ();
                                await Task.Delay(300);
                                goto continueWhile;
                            }
                            if (move == captureMoves.LastOrDefault())
                            {
                                pictureBoxButtons[i_capture][j_capture].setValue(0);
                                computerMove(i, j, i_capture, j_capture);
                                i = i_capture; j = j_capture;
                                await Task.Delay(300);
                                goto continueWhile;
                            }
                            pictureBoxButtons[i_capture][j_capture].setValue(0);
                        }
                    }
                if (!j_right)
                    if (checkMultipleMovesRedKingRight(i_initial, j_initial, i, j))
                    {
                        captureMoves = drawRedKingRightTrace(i, j);
                        foreach (var move in captureMoves)
                        {
                            int contor = move.Item3;
                            if (contor != 1)
                                continue;
                            int i_capture = move.Item1;
                            int j_capture = move.Item2;
                            pictureBoxButtons[i_capture][j_capture].setValue(4);
                            if (checkMultipleMoves(i, j, i_capture, j_capture))
                            {
                                pictureBoxButtons[i_capture][j_capture].setValue(0);
                                computerMove(i, j, i_capture, j_capture);
                                specialProprieties.setLastMultipleMovePositionI(i);
                                specialProprieties.setLastMultipleMovePositionJ(j);
                                i = i_capture; j = j_capture;
                                i_initial = specialProprieties.getLastMultipleMovePositionI();
                                j_initial = specialProprieties.getLastMultipleMovePositionJ();
                                await Task.Delay(300);
                                goto continueWhile;
                            }
                            if (move == captureMoves.LastOrDefault())
                            {
                                pictureBoxButtons[i_capture][j_capture].setValue(0);
                                computerMove(i, j, i_capture, j_capture);
                                i = i_capture; j = j_capture;
                                await Task.Delay(300);
                                goto continueWhile;
                            }
                            pictureBoxButtons[i_capture][j_capture].setValue(0);
                        }
                    }
                if (!i_up)
                    if (checkMultipleMovesRedKingUp(i_initial, j_initial, i, j))
                    {
                        captureMoves = drawRedKingUpTrace(i, j);
                        foreach (var move in captureMoves)
                        {
                            int contor = move.Item3;
                            if (contor != 1)
                                continue;
                            int i_capture = move.Item1;
                            int j_capture = move.Item2;
                            pictureBoxButtons[i_capture][j_capture].setValue(4);
                            if (checkMultipleMoves(i, j, i_capture, j_capture))
                            {
                                pictureBoxButtons[i_capture][j_capture].setValue(0);
                                computerMove(i, j, i_capture, j_capture);
                                specialProprieties.setLastMultipleMovePositionI(i);
                                specialProprieties.setLastMultipleMovePositionJ(j);
                                i = i_capture; j = j_capture;
                                i_initial = specialProprieties.getLastMultipleMovePositionI();
                                j_initial = specialProprieties.getLastMultipleMovePositionJ();
                                await Task.Delay(300);
                                goto continueWhile;
                            }
                            if (move == captureMoves.LastOrDefault())
                            {
                                pictureBoxButtons[i_capture][j_capture].setValue(0);
                                computerMove(i, j, i_capture, j_capture);
                                i = i_capture; j = j_capture;
                                await Task.Delay(300);
                                goto continueWhile;
                            }
                            pictureBoxButtons[i_capture][j_capture].setValue(0);
                        }
                    }
                if (!i_down)
                    if (checkMultipleMovesRedKingDown(i_initial, j_initial, i, j))
                    {
                        captureMoves = drawRedKingDownTrace(i, j);
                        foreach (var move in captureMoves)
                        {
                            int contor = move.Item3;
                            if (contor != 1)
                                continue;
                            int i_capture = move.Item1;
                            int j_capture = move.Item2;
                            pictureBoxButtons[i_capture][j_capture].setValue(4);
                            if (checkMultipleMoves(i, j, i_capture, j_capture))
                            {
                                pictureBoxButtons[i_capture][j_capture].setValue(0);
                                computerMove(i, j, i_capture, j_capture);
                                specialProprieties.setLastMultipleMovePositionI(i);
                                specialProprieties.setLastMultipleMovePositionJ(j);
                                i = i_capture; j = j_capture;
                                i_initial = specialProprieties.getLastMultipleMovePositionI();
                                j_initial = specialProprieties.getLastMultipleMovePositionJ();
                                await Task.Delay(300);
                                goto continueWhile;
                            }
                            if (move == captureMoves.LastOrDefault())
                            {
                                pictureBoxButtons[i_capture][j_capture].setValue(0);
                                computerMove(i, j, i_capture, j_capture);
                                i = i_capture; j = j_capture;
                                await Task.Delay(300);
                                goto continueWhile;
                            }
                            pictureBoxButtons[i_capture][j_capture].setValue(0);
                        }
                    }

                continueWhile: continue;
            }
            specialProprieties.setPieceCanDoAMultipleMove(false);
            checkIfPieceIsKing(i, j);
            pictureBoxButtons[i][j].getPictureBox().BackColor = Color.Transparent;
            swapCurrentPlayerTurn(specialProprieties.getPlayerTurn());
            swapCurrentPlayerName();
            redPiecesWhoCanCapture.Clear();
            blackPiecesWhoCanCapture.Clear();
            removeBoardTraces();
            checkIfFirstBlackPieceCanCapture();
        }

        private async Task computerBlackKingChangePosition()
        {
            await Task.Delay(0);
            int temp_i, temp_j, move_j = 0;
            bool findFutureCapture = false;
            bool findLastKingPosition = false;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (pictureBoxButtons[i][j].getValue() == 3 && (i == 7))
                    {
                        List<Tuple<int, int, int>> allMoves = new List<Tuple<int, int, int>>();
                        allMoves.AddRange(drawBlackKingLeftTrace(i, j));
                        allMoves.AddRange(drawBlackKingRightTrace(i, j));
                        foreach (var move in allMoves)
                        {
                            temp_i = move.Item1;
                            temp_j = move.Item2;
                            pictureBoxButtons[temp_i][temp_j].setValue(3);
                            if (checkMultipleMoves(temp_i, temp_j, temp_i, temp_j))
                            {
                                pictureBoxButtons[temp_i][temp_j].setValue(0);
                                computerMove(i, j, temp_i, temp_j);
                                i = temp_i; j = temp_j;
                                findFutureCapture = true;
                                await Task.Delay(300);
                                specialProprieties.setPieceCanDoAMultipleMove(false);
                                pictureBoxButtons[i][j].getPictureBox().BackColor = Color.Transparent;
                                swapCurrentPlayerTurn(specialProprieties.getPlayerTurn());
                                swapCurrentPlayerName();
                                return;
                            }
                            else
                            {
                                pictureBoxButtons[temp_i][temp_j].setValue(0);
                            }
                        }
                    }
                }
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (pictureBoxButtons[i][j].getValue() == 3)
                    {
                        List<Tuple<int, int, int>> allMoves = new List<Tuple<int, int, int>>();
                        allMoves.AddRange(drawBlackKingDownTrace(i, j));
                        if (allMoves.Any())
                        {
                            Tuple<int, int, int> lastMove = allMoves.Last();
                            if (lastMove.Item1 == 7)
                            {
                                pictureBoxButtons[lastMove.Item1][lastMove.Item2].setValue(3);
                                if (!checkMultipleMoves(lastMove.Item1, lastMove.Item2, lastMove.Item1, lastMove.Item2))
                                {
                                    pictureBoxButtons[lastMove.Item1][lastMove.Item2].setValue(0);
                                    computerMove(i, j, lastMove.Item1, lastMove.Item2);
                                    i = lastMove.Item1; j = lastMove.Item2;
                                    await Task.Delay(300);
                                    specialProprieties.setPieceCanDoAMultipleMove(false);
                                    pictureBoxButtons[i][j].getPictureBox().BackColor = Color.Transparent;
                                    swapCurrentPlayerTurn(specialProprieties.getPlayerTurn());
                                    swapCurrentPlayerName();
                                    findLastKingPosition = true;
                                    return;
                                }
                                else
                                {
                                    pictureBoxButtons[lastMove.Item1][lastMove.Item2].setValue(0);
                                }
                            }
                        }
                    }
                }

            if (findFutureCapture || findLastKingPosition)
            {
                checkIfFirstRedPieceCanCapture();
            }
            else
            {
                computerAIMoveSteps(playerRobot, true);
            }
        }

        private async Task computerRedKingChangePosition()
        {
            await Task.Delay(0);
            int temp_i, temp_j;
            bool findFutureCapture = false;
            bool findLastKingPosition = false;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (pictureBoxButtons[i][j].getValue() == 4 && (i == 0))
                    {
                        List<Tuple<int, int, int>> allMoves = new List<Tuple<int, int, int>>();
                        allMoves.AddRange(drawRedKingLeftTrace(i, j));
                        allMoves.AddRange(drawRedKingRightTrace(i, j));
                        foreach (var move in allMoves)
                        {
                            temp_i = move.Item1;
                            temp_j = move.Item2;
                            pictureBoxButtons[temp_i][temp_j].setValue(4);
                            if (checkMultipleMoves(temp_i, temp_j, temp_i, temp_j))
                            {
                                pictureBoxButtons[temp_i][temp_j].setValue(0);
                                computerMove(i, j, temp_i, temp_j);
                                i = temp_i; j = temp_j;
                                findFutureCapture = true;
                                await Task.Delay(300);
                                specialProprieties.setPieceCanDoAMultipleMove(false);
                                pictureBoxButtons[i][j].getPictureBox().BackColor = Color.Transparent;
                                swapCurrentPlayerTurn(specialProprieties.getPlayerTurn());
                                swapCurrentPlayerName();
                                return;
                            }
                            else
                            {
                                pictureBoxButtons[temp_i][temp_j].setValue(0);
                            }
                        }
                    }
                }
            for (int i = 1; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (pictureBoxButtons[i][j].getValue() == 4)
                    {
                        List<Tuple<int, int, int>> allMoves = new List<Tuple<int, int, int>>();
                        allMoves.AddRange(drawRedKingUpTrace(i, j));
                        if (allMoves.Any())
                        {
                            Tuple<int, int, int> lastMove = allMoves.Last();
                            if (lastMove.Item1 == 0)
                            {
                                pictureBoxButtons[lastMove.Item1][lastMove.Item2].setValue(4);
                                if (!checkMultipleMoves(lastMove.Item1, lastMove.Item2, lastMove.Item1, lastMove.Item2))
                                {
                                    pictureBoxButtons[lastMove.Item1][lastMove.Item2].setValue(0);
                                    computerMove(i, j, lastMove.Item1, lastMove.Item2);
                                    i = lastMove.Item1; j = lastMove.Item2;
                                    await Task.Delay(300);
                                    specialProprieties.setPieceCanDoAMultipleMove(false);
                                    pictureBoxButtons[i][j].getPictureBox().BackColor = Color.Transparent;
                                    swapCurrentPlayerTurn(specialProprieties.getPlayerTurn());
                                    swapCurrentPlayerName();
                                    findLastKingPosition = true;
                                    return;
                                }
                                else
                                {
                                    pictureBoxButtons[lastMove.Item1][lastMove.Item2].setValue(0);
                                }
                            }
                        }
                    }
                }
            if (findFutureCapture || findLastKingPosition)
            {
                checkIfFirstBlackPieceCanCapture();
            }
            else
            {
                computerAIMoveSteps(playerRobot, false);
            }
        }

        private void computerMove(int i_initial, int j_initial, int i_final, int j_final)
        {
            pictureBoxButtons[i_initial][j_initial].getPictureBox().BackColor = Color.Transparent;
            swapImage(i_initial, j_initial, i_final, j_final);
            swapValue(i_initial, j_initial, i_final, j_final);
            removeCapturedPieces(i_initial, j_initial, i_final, j_final);
            specialProprieties.setPieceCanDoAMultipleMove(true);
            specialProprieties.setLastMultipleMovePositionI(i_initial);
            specialProprieties.setLastMultipleMovePositionJ(j_initial);
            specialProprieties.setCurrentMultipleMovePositionI(i_final);
            specialProprieties.setCurrentMultipleMovePositionJ(j_final);
            removeBoardTraces();
        }

        private async Task<int> computerAIMoveSteps(bool playerColor, bool startWithStep5)
        {
            redPiecesWhoCanCapture.Clear();
            blackPiecesWhoCanCapture.Clear();
            allRunningAsyncTasks.Clear();

            //playerColor false-negru, true-rosu
            int computerPieceColorIndex;
            if (playerColor)
            {
                computerPieceColorIndex = 2;
            }
            else
            {
                computerPieceColorIndex = 1;
            }
            //sarim la pasul 5 daca regele nu isi poate schimba pozitia de pe ultimul rand
            if (startWithStep5)
            {
                goto Step5;
            }

            //regele cauta cat mai multe capturi posibile 
            //Step1:
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (pictureBoxButtons[i][j].getValue() == (computerPieceColorIndex + 2))
                    {
                        if (checkMultipleMoves(i, j, i, j))
                        {
                            if (computerPieceColorIndex == 1)
                            {
                                Task tempAsyncFunction = computerBlackKingCapture(i, j);
                                allRunningAsyncTasks.Add(tempAsyncFunction);
                                await tempAsyncFunction;
                            }
                            if (computerPieceColorIndex == 2)
                            {
                                Task tempAsyncFunction = computerRedKingCapture(i, j);
                                allRunningAsyncTasks.Add(tempAsyncFunction);
                                await tempAsyncFunction;
                            }
                            return 0;
                        }
                    }
                }

            //piesa cauta cat mai multe capturi posibile
            //Step2:
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (pictureBoxButtons[i][j].getValue() == computerPieceColorIndex)
                    {
                        if (checkMultipleMoves(specialProprieties.getCurrentMultipleMovePositionI(), specialProprieties.getCurrentMultipleMovePositionJ(), i, j))
                        {
                            if (computerPieceColorIndex == 1)
                            {
                                Task tempAsyncFunction = computerBlackPieceCapture(i, j);
                                allRunningAsyncTasks.Add(tempAsyncFunction);
                                await tempAsyncFunction;
                            }
                            if (computerPieceColorIndex == 2)
                            {
                                Task tempAsyncFunction = computerRedPieceCapture(i, j);
                                allRunningAsyncTasks.Add(tempAsyncFunction);
                                await tempAsyncFunction;

                            }
                            return 0;
                        }
                    }
                }

            //mergi in fata daca piesa e penultimul rand pt. a deveni rege
            //Step3:
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (pictureBoxButtons[i][j].getValue() == computerPieceColorIndex)
                    {
                        if (pictureBoxButtons[i + 1][j].getValue() == 0 && i == 6 && computerPieceColorIndex == 1)
                        {
                            movePiece(i, j, i + 1, j);
                            return 0;
                        }
                        if (pictureBoxButtons[i - 1][j].getValue() == 0 && i == 1 && computerPieceColorIndex == 2)
                        {
                            movePiece(i, j, i - 1, j);
                            return 0;
                        }
                    }
                }

            //regele isi schimba pozitia pt captura daca e ultimul rand sau se muta pe ultimul rand
            //Step4:
            if (!startWithStep5)
            {
                if (computerPieceColorIndex == 1)
                {
                    Task tempAsyncFunction = computerBlackKingChangePosition();
                    allRunningAsyncTasks.Add(tempAsyncFunction);
                    await tempAsyncFunction;
                }
                if (computerPieceColorIndex == 2)
                {
                    Task tempAsyncFunction = computerRedKingChangePosition();
                    allRunningAsyncTasks.Add(tempAsyncFunction);
                    await tempAsyncFunction;
                }
                return 0;
            }


        //piesa misca in fata daca exista spatiu liber si nu e atacata
        Step5:
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (pictureBoxButtons[i][j].getValue() == computerPieceColorIndex)
                    {
                        if (i < 6 && computerPieceColorIndex == 1)
                            if (pictureBoxButtons[i + 1][j].getValue() == 0 && (pictureBoxButtons[i + 2][j].getValue() % 2 == 1 || pictureBoxButtons[i + 2][j].getValue() == 0))
                            {
                                movePiece(i, j, i + 1, j);
                                return 0;
                            }
                        if (i > 1 && computerPieceColorIndex == 2)
                            if (pictureBoxButtons[i - 1][j].getValue() == 0 && (pictureBoxButtons[i - 2][j].getValue() % 2 == 0 || pictureBoxButtons[i - 2][j].getValue() == 0))
                            {
                                movePiece(i, j, i - 1, j);
                                return 0;
                            }
                    }
                }
            //piesa misca in lateral daca exista spatiu liber si nu e atacata
            //Step6:
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (pictureBoxButtons[i][j].getValue() == computerPieceColorIndex && j < 6)
                    {
                        if (pictureBoxButtons[i][j + 1].getValue() == 0 && pictureBoxButtons[i][j + 2].getValue() == 0)
                        {
                            movePiece(i, j, i, j + 1);
                            return 0;
                        }
                    }
                    if (pictureBoxButtons[i][j].getValue() == computerPieceColorIndex && j > 1)
                        if (pictureBoxButtons[i][j - 1].getValue() == 0 && pictureBoxButtons[i][j - 2].getValue() == 0)
                        {
                            movePiece(i, j, i, j - 1);
                            return 0;
                        }
                }
            //miscare in fata chiar daca piesa va fi atacata
            //Step7:
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (pictureBoxButtons[i][j].getValue() == computerPieceColorIndex)
                    {
                        if (pictureBoxButtons[i + 1][j].getValue() == 0 && computerPieceColorIndex == 1 && i < 7)
                        {
                            movePiece(i, j, i + 1, j);
                            return 0;
                        }
                        if (pictureBoxButtons[i - 1][j].getValue() == 0 && computerPieceColorIndex == 2 && i > 0)
                        {
                            movePiece(i, j, i - 1, j);
                            return 0;
                        }
                    }
                }
            //miscare lateral chiar daca piesa va fi atacata
            //Step8:
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (pictureBoxButtons[i][j].getValue() == computerPieceColorIndex)
                    {
                        if (pictureBoxButtons[i][j + 1].getValue() == 0 && j < 7)
                        {
                            movePiece(i, j, i, j + 1);
                            return 0;
                        }
                    }
                    if (pictureBoxButtons[i][j].getValue() == computerPieceColorIndex && j > 0)
                        if (pictureBoxButtons[i][j - 1].getValue() == 0)
                        {
                            movePiece(i, j, i, j - 1);
                            return 0;
                        }

                    if (pictureBoxButtons[i][j].getValue() == computerPieceColorIndex + 2 && j < 7)
                    {
                        if (pictureBoxButtons[i][j + 1].getValue() == 0)
                        {
                            movePiece(i, j, i, j + 1);
                            return 0;
                        }
                    }
                    if (pictureBoxButtons[i][j].getValue() == computerPieceColorIndex + 2 && j > 0)
                        if (pictureBoxButtons[i][j - 1].getValue() == 0)
                        {
                            movePiece(i, j, i, j - 1);
                            return 0;
                        }
                }
            return 0;
        }

        private void blackColorButton_Click(object sender, EventArgs e)
        {
            playerRobot = true;
            blackColorButton.Enabled = false;
            choseColorButton.Enabled = false;
            choseColorButton.Text = "Your color is";

            Controls.Remove(redColorButton);
            redColorButton.Dispose();
            blackColorButton.ForeColor = Color.White;
            blackColorButton.Width = 110;

            unblockPictureBox();
            computerAIMoveSteps(playerRobot, true);
            player1.setName("Computer");
            player2.setName(playerName);
            player1TextBox.Text = player1.getName();
            player2TextBox.Text = player2.getName();
        }

        private void redColorButton_Click(object sender, EventArgs e)
        {
            playerRobot = false;
            redColorButton.Enabled = false;
            choseColorButton.Enabled = false;
            choseColorButton.Text = "Your color is";

            Controls.Remove(blackColorButton);
            blackColorButton.Dispose();
            redColorButton.Location = new Point(663, 106);
            redColorButton.Width = 110;

            unblockPictureBox();
            player1.setName(playerName);
            player2.setName("Computer");
            player1TextBox.Text = player1.getName();
            player2TextBox.Text = player2.getName();
        }


    }
}