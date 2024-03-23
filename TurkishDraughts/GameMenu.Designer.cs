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
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(323, 53);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            textBox1.Text = "Turkish Draughts";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(247, 126);
            button1.Name = "button1";
            button1.Size = new Size(270, 23);
            button1.TabIndex = 1;
            button1.Text = "Player vs Player (Local)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(247, 204);
            button2.Name = "button2";
            button2.Size = new Size(270, 23);
            button2.TabIndex = 2;
            button2.Text = "Player vs Player Retea";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(247, 283);
            button3.Name = "button3";
            button3.Size = new Size(270, 23);
            button3.TabIndex = 3;
            button3.Text = "Player vs Robot";
            button3.UseVisualStyleBackColor = true;
            // 
            // buttonRules
            // 
            buttonRules.Location = new Point(82, 375);
            buttonRules.Name = "buttonRules";
            buttonRules.Size = new Size(590, 23);
            buttonRules.TabIndex = 4;
            buttonRules.Text = "Regulile Jocului";
            buttonRules.UseVisualStyleBackColor = true;
            buttonRules.Click += buttonRules_Click;
            // 
            // GameMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonRules);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "GameMenu";
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
    }
}