namespace TurkishDraughts
{
    partial class GameMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            buttonRules = new Button();
            player1LocalTextBox = new TextBox();
            player2LocalTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            startGame1Button = new Button();
            label3 = new Label();
            label5 = new Label();
            playerNetworkTextBox = new TextBox();
            playerVsAITextBox = new TextBox();
            startGame2Button = new Button();
            startGame3Button = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            textBox1.Text = "Turkish Draughts";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(41, 101);
            button1.Name = "button1";
            button1.Size = new Size(166, 23);
            button1.TabIndex = 1;
            button1.Text = "Player vs Player (Local)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(302, 101);
            button2.Name = "button2";
            button2.Size = new Size(166, 23);
            button2.TabIndex = 2;
            button2.Text = "Player vs Player Retea";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(578, 101);
            button3.Name = "button3";
            button3.Size = new Size(166, 23);
            button3.TabIndex = 3;
            button3.Text = "Player vs Robot";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // buttonRules
            // 
            buttonRules.Location = new Point(92, 376);
            buttonRules.Name = "buttonRules";
            buttonRules.Size = new Size(590, 23);
            buttonRules.TabIndex = 4;
            buttonRules.Text = "Regulile Jocului";
            buttonRules.UseVisualStyleBackColor = true;
            buttonRules.Click += buttonRules_Click;
            // 
            // player1LocalTextBox
            // 
            player1LocalTextBox.Location = new Point(107, 153);
            player1LocalTextBox.Name = "player1LocalTextBox";
            player1LocalTextBox.Size = new Size(100, 23);
            player1LocalTextBox.TabIndex = 5;
            // 
            // player2LocalTextBox
            // 
            player2LocalTextBox.Location = new Point(107, 196);
            player2LocalTextBox.Name = "player2LocalTextBox";
            player2LocalTextBox.Size = new Size(100, 23);
            player2LocalTextBox.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 156);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 7;
            label1.Text = "Player 1:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 204);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 8;
            label2.Text = "Player 2:";
            // 
            // startGame1Button
            // 
            startGame1Button.Location = new Point(41, 275);
            startGame1Button.Name = "startGame1Button";
            startGame1Button.Size = new Size(166, 23);
            startGame1Button.TabIndex = 14;
            startGame1Button.Text = "Start Game";
            startGame1Button.UseVisualStyleBackColor = true;
            startGame1Button.Click += startGameLocalButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(311, 181);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 15;
            label3.Text = "Player:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(587, 181);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 17;
            label5.Text = "Player:";
            // 
            // playerNetworkTextBox
            // 
            playerNetworkTextBox.Location = new Point(359, 178);
            playerNetworkTextBox.Name = "playerNetworkTextBox";
            playerNetworkTextBox.Size = new Size(100, 23);
            playerNetworkTextBox.TabIndex = 18;
            // 
            // playerVsAITextBox
            // 
            playerVsAITextBox.Location = new Point(635, 178);
            playerVsAITextBox.Name = "playerVsAITextBox";
            playerVsAITextBox.Size = new Size(100, 23);
            playerVsAITextBox.TabIndex = 19;
            // 
            // startGame2Button
            // 
            startGame2Button.Location = new Point(302, 275);
            startGame2Button.Name = "startGame2Button";
            startGame2Button.Size = new Size(166, 23);
            startGame2Button.TabIndex = 20;
            startGame2Button.Text = "Start Game";
            startGame2Button.UseVisualStyleBackColor = true;
            startGame2Button.Click += startGame2Button_Click;
            // 
            // startGame3Button
            // 
            startGame3Button.Location = new Point(578, 275);
            startGame3Button.Name = "startGame3Button";
            startGame3Button.Size = new Size(166, 23);
            startGame3Button.TabIndex = 21;
            startGame3Button.Text = "Start Game";
            startGame3Button.UseVisualStyleBackColor = true;
            startGame3Button.Click += startGame3Button_Click;
            // 
            // GameMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(startGame3Button);
            Controls.Add(startGame2Button);
            Controls.Add(playerVsAITextBox);
            Controls.Add(playerNetworkTextBox);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(startGame1Button);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(player2LocalTextBox);
            Controls.Add(player1LocalTextBox);
            Controls.Add(buttonRules);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "GameMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button buttonRules;
        private TextBox player1LocalTextBox;
        private TextBox player2LocalTextBox;
        private Label label1;
        private Label label2;
        private Button startGame1Button;
        private Label label3;
        private Label label5;
        private TextBox playerNetworkTextBox;
        private TextBox playerVsAITextBox;
        private Button startGame2Button;
        private Button startGame3Button;
    }
}