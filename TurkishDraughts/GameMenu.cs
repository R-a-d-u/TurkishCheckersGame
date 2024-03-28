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
                String name1, name2;
                name1 = player1LocalTextBox.Text;
                name2 = player2LocalTextBox.Text;
                GameBoard gameBoard = new GameBoard(name1,name2);
                gameBoard.Show();

                this.textBox1.ForeColor = Color.Red;

            }
        }

        private void buttonRules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Regulile Jocului: \n " +
                "*Tabla are 8x8 pozitii, piesele sunt asezate pe randurile 2,3 respectiv 6,7 \n" +
                "*Piesele obisnuite pot muta o pozitie in fata sau lateral, dar nu in spate sau in diagonala \n" +
                "*Piesele obisnuite pot captura (sari peste o piesa inamica) in fata sau lateral, dar nu in spate sau in diagonala \n" +
                "*Daca o piesa ajunge pe randul final opus culorii lui, acesta se transforma in rege \n" +
                "*Regele poate muta sau captura pe toata lungimea si latimea tablei,dar nu in diagonala \n" +
                "*Daca orice piesa captureaza o piesa a inamicului si poate captura o alta succesiv, este oblicata sa o faca \n" +
                ""
                );
        }
    }
}