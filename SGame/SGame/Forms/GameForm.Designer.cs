using SGame.AboutUser;
using SGame.PackClass;
using System.Text;
using System.Windows.Forms;

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

        private void AddControlsToPanel()
        {
            /*
            while (panel.Controls.Count > 0)
            {
                Control control = panel.Controls[0];
                panel.Controls.Remove(control);
                control.Dispose();
            }*/
            panel.Controls.Clear();

            int numberOfTheme = 0;
            int width = panel.Width;
            int height = panel.Height;

            foreach (ThemesClass theme in round.themeClasses)
            {
                Label label = new Label();
                label.Name = "Theme" + numberOfTheme.ToString();
                label.Location = new Point(0, numberOfTheme * height / round.themeClasses.Count);
                label.Size = new Size(200, height / round.themeClasses.Count);
                label.Text = theme.themeName;
                label.BackColor = Color.Coral;
                label.Padding = new Padding(6);
                label.Font = new Font("Arial", 26);
                panel.Controls.Add(label);

                int numberOfQuestion = 0;
                foreach (var question in theme.questionClasses)
                {
                    Button button = new Button();
                    button.Name = "Button" + numberOfTheme.ToString() + numberOfQuestion.ToString();
                    button.Location = new Point(200 + numberOfQuestion * (width - 200) / theme.questionClasses.Count, numberOfTheme * height / round.themeClasses.Count);
                    button.Size = new Size((width - 200) / theme.questionClasses.Count, height / round.themeClasses.Count);
                    button.Text = question.price.ToString();
                    button.BackColor = Color.LightBlue;
                    button.Padding = new Padding(6);
                    button.Font = new Font("Arial", 18);
                    button.Enabled = !question.isUsed;
                    button.Click += (sender, e) =>
                    {
                        SendHost(question);
                    };

                    panel.Controls.Add(button);

                    numberOfQuestion++;
                }

                numberOfTheme++;
            }
        }
        private void DisplayUser(List<ConnectedUser> connectedUsers)
        {
            panelUsers.Controls.Clear();
            for (int i = 0; i < connectedUsers.Count; i++)
            {
                Label label = new Label();
                label.Name = "Theme" + connectedUsers[i].User.Name;
                label.Location = new Point(i * (panelUsers.Width / connectedUsers.Count) + 10, 10);
                label.Size = new Size(panelUsers.Width/connectedUsers.Count - 20, panelUsers.Height - 20);
                label.Text = connectedUsers[i].User.Name + "\n" + connectedUsers[i].User.Scores;
                label.BackColor = Color.Coral;
                label.Padding = new Padding(6);
                label.Font = new Font("Arial", 20);
                panelUsers.Controls.Add(label);
            }
        }
        private void ChooseQuestion(QuestionClass question)
        {
            foreach (ThemesClass theme in round.themeClasses)
            {
                foreach (var question1 in theme.questionClasses)
                {
                    if (question.question == question1.question)
                    {
                        question1.isUsed = true;
                        break;
                    }
                }
            }
            while (panel.Controls.Count > 0)
            {
                Control control = panel.Controls[0]; 
                panel.Controls.Remove(control); 
                control.Dispose(); 
            }

            Label labelQuestion = new Label();
            labelQuestion.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
            labelQuestion.Location = new Point(50, 30);
            labelQuestion.Name = "question";
            labelQuestion.Size = new Size(panel.Width - 100, 170);
            labelQuestion.Font = new Font("Arial", 22);
            labelQuestion.TabIndex = 0;
            labelQuestion.Text = question.question;
            panel.Controls.Add(labelQuestion);

            if (question.getVariantsAnswer() == null)
            {
                RichTextBox textBox = new RichTextBox();
                textBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                textBox.Location = new Point(50, panel.Height - 150);
                textBox.Name = "textBox";
                textBox.Size = new Size(panel.Width - 200, 100);
                textBox.TabIndex = 1;

                Button button = new Button();
                button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                button.Location = new Point(panel.Width - 150, panel.Height - 150);
                button.Name = "button";
                button.Size = new Size(100, 100);
                button.TabIndex = 2;
                button.Text = "Отправить";
                button.UseVisualStyleBackColor = true;
                button.Click += (sender, e) =>
                {
                    button.Enabled = false;
                    if (textBox.Text == question.answer)
                    {
                        SendHost("+ 200");
                    }
                    else SendHost("+ 200");
                    
                };

                panel.Controls.Add(textBox);
                panel.Controls.Add(button);
            }
            else
            {
                int numberOfVariant = 0;
                foreach (var variant in question.getVariantsAnswer())
                {
                    Button button = new Button();
                    button.Name = "Button" + numberOfVariant.ToString();
                    button.Location = new Point(50 + numberOfVariant * (panel.Width - 100) / question.getVariantsAnswer().Count, 
                        panel.Height - 250);
                    button.Size = new Size((panel.Width - 100) / question.getVariantsAnswer().Count, 200);
                    button.Text = variant;
                    button.BackColor = Color.LightBlue;
                    button.Padding = new Padding(6);
                    button.Font = new Font("Arial", 18);
                    button.Click += (sender, e) =>
                    {
                        button.Enabled = false;
                        if (variant == question.answer)
                        {

                        }
                        AddControlsToPanel();
                    };

                    panel.Controls.Add(button);
                    numberOfVariant++;
                }
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel = new Panel();
            panelUsers = new Panel();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel.BackColor = SystemColors.Highlight;
            panel.Location = new Point(200, 0);
            panel.Name = "panel";
            panel.Size = new Size(1000, 650);
            panel.TabIndex = 0;
            // 
            // panelUsers
            // 
            panelUsers.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panelUsers.BackColor = SystemColors.AppWorkspace;
            panelUsers.Location = new Point(200, 647);
            panelUsers.Name = "panelUsers";
            panelUsers.Size = new Size(1000, 153);
            panelUsers.TabIndex = 1;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 800);
            Controls.Add(panelUsers);
            Controls.Add(panel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GameForm";
            Text = "Game";
            ResumeLayout(false);
        }

        #endregion

        private Panel panel;
        private Panel panelUsers;
    }
}