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
            player1LocalTextBox = new TextBox();
            player2LocalTextBox = new TextBox();
            startGame1Button = new Button();
            playerNetworkTextBox = new TextBox();
            playerVsAITextBox = new TextBox();
            startGame2Button = new Button();
            startGame3Button = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            SuspendLayout();
            // 
            // player1LocalTextBox
            // 
            player1LocalTextBox.BackColor = Color.FromArgb(192, 0, 0);
            player1LocalTextBox.ForeColor = Color.White;
            player1LocalTextBox.Location = new Point(126, 157);
            player1LocalTextBox.Name = "player1LocalTextBox";
            player1LocalTextBox.Size = new Size(100, 23);
            player1LocalTextBox.TabIndex = 5;
            player1LocalTextBox.TabStop = false;
            // 
            // player2LocalTextBox
            // 
            player2LocalTextBox.BackColor = Color.Black;
            player2LocalTextBox.ForeColor = Color.White;
            player2LocalTextBox.Location = new Point(126, 205);
            player2LocalTextBox.Name = "player2LocalTextBox";
            player2LocalTextBox.Size = new Size(100, 23);
            player2LocalTextBox.TabIndex = 6;
            player2LocalTextBox.TabStop = false;
            // 
            // startGame1Button
            // 
            startGame1Button.Location = new Point(60, 275);
            startGame1Button.Name = "startGame1Button";
            startGame1Button.Size = new Size(166, 23);
            startGame1Button.TabIndex = 14;
            startGame1Button.TabStop = false;
            startGame1Button.Text = "Start Game";
            startGame1Button.UseVisualStyleBackColor = true;
            startGame1Button.Click += startGameLocalButton_Click;
            // 
            // playerNetworkTextBox
            // 
            playerNetworkTextBox.Location = new Point(377, 153);
            playerNetworkTextBox.Name = "playerNetworkTextBox";
            playerNetworkTextBox.Size = new Size(114, 23);
            playerNetworkTextBox.TabIndex = 18;
            playerNetworkTextBox.TabStop = false;
            // 
            // playerVsAITextBox
            // 
            playerVsAITextBox.Location = new Point(637, 183);
            playerVsAITextBox.Name = "playerVsAITextBox";
            playerVsAITextBox.Size = new Size(100, 23);
            playerVsAITextBox.TabIndex = 19;
            playerVsAITextBox.TabStop = false;
            // 
            // startGame2Button
            // 
            startGame2Button.Location = new Point(325, 275);
            startGame2Button.Name = "startGame2Button";
            startGame2Button.Size = new Size(166, 23);
            startGame2Button.TabIndex = 20;
            startGame2Button.TabStop = false;
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
            startGame3Button.TabStop = false;
            startGame3Button.Text = "Start Game";
            startGame3Button.UseVisualStyleBackColor = true;
            startGame3Button.Click += startGame3Button_Click;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Black;
            textBox2.ForeColor = Color.White;
            textBox2.Location = new Point(408, 201);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(83, 23);
            textBox2.TabIndex = 22;
            textBox2.TabStop = false;
            textBox2.Text = "Client";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.Red;
            textBox3.ForeColor = Color.White;
            textBox3.Location = new Point(325, 201);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(83, 23);
            textBox3.TabIndex = 23;
            textBox3.TabStop = false;
            textBox3.Text = "Server";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 19F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(303, 35);
            label4.Name = "label4";
            label4.Size = new Size(210, 36);
            label4.TabIndex = 27;
            label4.Text = "Turkish Draughts";
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(60, 113);
            label1.Name = "label1";
            label1.Size = new Size(166, 23);
            label1.TabIndex = 28;
            label1.Text = "Player vs Player (Local)";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(325, 115);
            label2.Name = "label2";
            label2.Size = new Size(166, 21);
            label2.TabIndex = 29;
            label2.Text = "Player vs Player Retea";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(578, 114);
            label3.Name = "label3";
            label3.Size = new Size(166, 21);
            label3.TabIndex = 30;
            label3.Text = "Player vs Robot";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(60, 157);
            label5.Name = "label5";
            label5.Size = new Size(61, 19);
            label5.TabIndex = 31;
            label5.Text = "Player1: ";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(60, 205);
            label6.Name = "label6";
            label6.Size = new Size(61, 19);
            label6.TabIndex = 32;
            label6.Text = "Player2: ";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(325, 157);
            label7.Name = "label7";
            label7.Size = new Size(53, 19);
            label7.TabIndex = 33;
            label7.Text = "Player: ";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(578, 187);
            label8.Name = "label8";
            label8.Size = new Size(53, 19);
            label8.TabIndex = 34;
            label8.Text = "Player: ";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GameMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.MenuBackground;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(startGame3Button);
            Controls.Add(startGame2Button);
            Controls.Add(playerVsAITextBox);
            Controls.Add(playerNetworkTextBox);
            Controls.Add(startGame1Button);
            Controls.Add(player2LocalTextBox);
            Controls.Add(player1LocalTextBox);
            Name = "GameMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox player1LocalTextBox;
        private TextBox player2LocalTextBox;
        private Button startGame1Button;
        private TextBox playerNetworkTextBox;
        private TextBox playerVsAITextBox;
        private Button startGame2Button;
        private Button startGame3Button;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}