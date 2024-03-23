namespace TurkishDraughts
{
    public partial class GameMenu : Form
    {

        public GameMenu()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form f in Application.OpenForms)//verifica elementele deschise din aplicatie
            {
                if (f.Name == "GameBoard")
                {
                    isopen = true;
                    f.BringToFront();//se selecteaza ultimul forms deschis ca principal
                    break;
                }
            }
            if (isopen == false)
            {
                GameBoard gameBoard = new GameBoard();
                gameBoard.Show();
                this.textBox1.ForeColor = Color.Red;

            }
        }

        private void buttonRules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sdaaaaaaaaaaaaaaaaaaaaaaaaaaaa \n aaaaaaaaaa");
        }
    }
}