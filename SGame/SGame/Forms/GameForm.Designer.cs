using SGame.PackClass;
using System.Text;

namespace SGame.Forms
{
    partial class GameForm
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
        private void InitializeComponent(RoundClass round)
        {
            panel = new Panel();
            SuspendLayout();
            // 
            // panel
            // 
            panel.BackColor = SystemColors.Highlight;
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(800, 450);
            panel.TabIndex = 0;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GameForm";
            Text = "Game";
            ResumeLayout(false);

            {
                int width = panel.Width, height = panel.Height;
                int numberOfTheme = 0;
                foreach (var theme in round.questionClasses)
                {
                    Label label = new Label();
                    label.Name = "Theme" + numberOfTheme.ToString();
                    label.Location = new Point(0, numberOfTheme * height / round.questionClasses.Count);
                    label.Size = new Size(100, height / round.questionClasses.Count);
                    label.Text = theme.themeName;
                    label.BackColor = Color.DarkBlue;
                    label.Padding = new Padding(6);
                    label.Font = new Font("French Script MT", 18);
                    panel.Controls.Add(label);

                    int numberOfQuestion = 0;
                    foreach (var question in theme.questionClasses)
                    {
                        Button button = new Button();
                        button.Name = "Button" + numberOfTheme.ToString() + numberOfQuestion.ToString();
                        button.Location = new Point(100 + numberOfQuestion * (width - 100) / theme.questionClasses.Count,
                            numberOfTheme * height / round.questionClasses.Count);
                        button.Size = new Size((width - 100) / theme.questionClasses.Count, height / round.questionClasses.Count);
                        button.Text = question.question;
                        button.BackColor = Color.LightBlue;
                        button.Padding = new Padding(6);
                        button.Font = new Font("French Script MT", 18);
                        panel.Controls.Add(button);

                        numberOfQuestion++;
                    }

                    numberOfTheme++;
                }
            }
        }

        #endregion

        private Panel panel;
    }
}