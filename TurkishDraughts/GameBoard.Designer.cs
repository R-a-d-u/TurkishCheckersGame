namespace TurkishDraughts
{
    partial class GameBoard
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
            currentPlayerTextBox = new TextBox();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // currentPlayerTextBox
            // 
            currentPlayerTextBox.Location = new Point(668, 324);
            currentPlayerTextBox.Name = "currentPlayerTextBox";
            currentPlayerTextBox.Size = new Size(100, 23);
            currentPlayerTextBox.TabIndex = 0;
            currentPlayerTextBox.TabStop = false;
            currentPlayerTextBox.Text = "Text";
            currentPlayerTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(668, 458);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            textBox1.TabStop = false;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // GameBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Board;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(780, 793);
            Controls.Add(textBox1);
            Controls.Add(currentPlayerTextBox);
            DoubleBuffered = true;
            MaximumSize = new Size(796, 832);
            MinimumSize = new Size(796, 832);
            Name = "GameBoard";
            Text = "GameBoard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox currentPlayerTextBox;
        private TextBox textBox1;
    }
}