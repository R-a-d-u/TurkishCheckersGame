namespace TurkishDraughts
{
    public partial class GameMenu : Form
    {
        public GameMenu()
        {
            InitializeComponent();

            MaximizeBox = false;
        }

        private void startGameLocalButton_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form f in Application.OpenForms)//verifica elementele deschise din aplicatie
            {
                if (f.Name == "GameBoard" || f.Name == "GameBoardNetwork" || f.Name == "GameBoardVsRobot")
                {
                    isopen = true;
                    f.BringToFront();//se selecteaza ultimul forms deschis ca principal
                    break;
                }
            }
            if (isopen == false)
            {
                String name1, name2;
                name1 = player1LocalTextBox.Text;
                name2 = player2LocalTextBox.Text;
                if (name1 != "" && name2 != "")
                {
                    GameBoard gameBoard = new GameBoard(name1, name2);
                    gameBoard.Show();
                }
            }
        }

        private void startGame2Button_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form f in Application.OpenForms)//verifica elementele deschise din aplicatie
            {
                if (f.Name == "GameBoard" || f.Name == "GameBoardNetwork" || f.Name == "GameBoardVsRobot")
                {
                    isopen = true;
                    f.BringToFront();//se selecteaza ultimul forms deschis ca principal
                    break;
                }
            }
            if (isopen == false)
            {
                String name1;
                name1 = playerNetworkTextBox.Text;
                if (name1 != "")
                {
                    GameBoardNetwork gameBoardNetwork = new GameBoardNetwork(name1);
                    gameBoardNetwork.Show();
                }
            }
        }

        private void startGame3Button_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form f in Application.OpenForms)//verifica elementele deschise din aplicatie
            {
                if (f.Name == "GameBoard" || f.Name == "GameBoardNetwork" || f.Name == "GameBoardVsRobot")
                {
                    isopen = true;
                    f.BringToFront();//se selecteaza ultimul forms deschis ca principal
                    break;
                }
            }
            if (isopen == false)
            {
                String name1;
                name1 = playerVsAITextBox.Text;
                if (name1 != "")
                {
                    GameBoardVsRobot gameBoardVsRobot = new GameBoardVsRobot(name1);
                    gameBoardVsRobot.Show();
                }
            }
        }
    }
}