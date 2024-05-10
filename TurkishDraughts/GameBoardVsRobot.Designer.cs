namespace TurkishDraughts
{
    partial class GameBoardVsRobot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameBoardVsRobot));
            player1TextBox = new TextBox();
            player2TextBox = new TextBox();
            currentPlayerTextBox = new TextBox();
            blackColorButton = new Button();
            redColorButton = new Button();
            choseColorButton = new Button();
            SuspendLayout();
            // 
            // player1TextBox
            // 
            player1TextBox.BackColor = Color.FromArgb(181, 136, 99);
            player1TextBox.BorderStyle = BorderStyle.None;
            player1TextBox.Font = new Font("Segoe UI", 23F, FontStyle.Regular, GraphicsUnit.Point);
            player1TextBox.ForeColor = Color.Black;
            player1TextBox.Location = new Point(22, 717);
            player1TextBox.Name = "player1TextBox";
            player1TextBox.ReadOnly = true;
            player1TextBox.Size = new Size(633, 41);
            player1TextBox.TabIndex = 1;
            player1TextBox.TabStop = false;
            player1TextBox.Text = "00";
            player1TextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // player2TextBox
            // 
            player2TextBox.BackColor = Color.FromArgb(49, 46, 43);
            player2TextBox.BorderStyle = BorderStyle.None;
            player2TextBox.Font = new Font("Segoe UI", 23F, FontStyle.Regular, GraphicsUnit.Point);
            player2TextBox.ForeColor = Color.Black;
            player2TextBox.Location = new Point(22, 16);
            player2TextBox.Name = "player2TextBox";
            player2TextBox.ReadOnly = true;
            player2TextBox.Size = new Size(633, 41);
            player2TextBox.TabIndex = 2;
            player2TextBox.TabStop = false;
            player2TextBox.Text = "00";
            player2TextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // currentPlayerTextBox
            // 
            currentPlayerTextBox.BackColor = Color.FromArgb(241, 217, 181);
            currentPlayerTextBox.BorderStyle = BorderStyle.None;
            currentPlayerTextBox.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            currentPlayerTextBox.Location = new Point(668, 349);
            currentPlayerTextBox.Multiline = true;
            currentPlayerTextBox.Name = "currentPlayerTextBox";
            currentPlayerTextBox.ReadOnly = true;
            currentPlayerTextBox.Size = new Size(100, 75);
            currentPlayerTextBox.TabIndex = 3;
            currentPlayerTextBox.TabStop = false;
            currentPlayerTextBox.Text = "Text";
            currentPlayerTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // blackColorButton
            // 
            blackColorButton.BackColor = Color.FromArgb(241, 217, 181);
            blackColorButton.BackgroundImageLayout = ImageLayout.None;
            blackColorButton.FlatStyle = FlatStyle.Popup;
            blackColorButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            blackColorButton.ForeColor = Color.Black;
            blackColorButton.Location = new Point(663, 106);
            blackColorButton.Name = "blackColorButton";
            blackColorButton.Size = new Size(55, 23);
            blackColorButton.TabIndex = 4;
            blackColorButton.TabStop = false;
            blackColorButton.Text = "Black";
            blackColorButton.UseVisualStyleBackColor = false;
            blackColorButton.Click += blackColorButton_Click;
            // 
            // redColorButton
            // 
            redColorButton.BackColor = Color.FromArgb(241, 217, 181);
            redColorButton.FlatStyle = FlatStyle.Popup;
            redColorButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            redColorButton.ForeColor = Color.Black;
            redColorButton.Location = new Point(718, 106);
            redColorButton.Name = "redColorButton";
            redColorButton.Size = new Size(55, 23);
            redColorButton.TabIndex = 5;
            redColorButton.TabStop = false;
            redColorButton.Text = "Red";
            redColorButton.UseVisualStyleBackColor = false;
            redColorButton.Click += redColorButton_Click;
            // 
            // choseColorButton
            // 
            choseColorButton.BackColor = Color.FromArgb(181, 136, 99);
            choseColorButton.FlatStyle = FlatStyle.Popup;
            choseColorButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            choseColorButton.Location = new Point(663, 77);
            choseColorButton.Name = "choseColorButton";
            choseColorButton.Size = new Size(110, 23);
            choseColorButton.TabIndex = 6;
            choseColorButton.TabStop = false;
            choseColorButton.Text = "Chose color";
            choseColorButton.UseVisualStyleBackColor = false;
            // 
            // GameBoardVsRobot
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Board;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(780, 793);
            Controls.Add(choseColorButton);
            Controls.Add(redColorButton);
            Controls.Add(blackColorButton);
            Controls.Add(currentPlayerTextBox);
            Controls.Add(player2TextBox);
            Controls.Add(player1TextBox);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Location = new Point(796, 832);
            MaximumSize = new Size(796, 832);
            MinimumSize = new Size(796, 832);
            Name = "GameBoardVsRobot";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Turkish Draughts";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox player1TextBox;
        private TextBox player2TextBox;
        private TextBox currentPlayerTextBox;
        private Button blackColorButton;
        private Button redColorButton;
        private Button choseColorButton;
    }
}