using SGame.AboutUser;
using SGame.PackClass;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Media;
using System.Numerics;

namespace SGame.Forms
{

    partial class GameForm
    {
        private CancellationTokenSource cancellationTokenSource;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        SoundPlayer player = new SoundPlayer();

        private bool is_question = false;
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
        static int Distance(string s1, int m, string s2, int n)
        {
            int[,] arr = new int[m + 1, n + 1];

            for (int i = 0; i <= m; ++i)
                arr[i, 0] = i;
            for (int j = 0; j <= n; ++j)
                arr[0, j] = j;

            for (int i = 1; i <= m; ++i)
            {
                for (int j = 1; j <= n; ++j)
                {
                    int cost = (s1[i - 1] != s2[j - 1]) ? 1 : 0;
                    arr[i, j] = Math.Min(Math.Min(arr[i - 1, j] + 1, arr[i, j - 1] + 1), arr[i - 1, j - 1] + cost);
                }
            }

            return arr[m, n];
        }
        private async void StartTimer(int seconds, ColorProgressBar.ColorProgressBar progressBar1)
        {
            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            progressBar1.Minimum = 0;
            progressBar1.ForeColor = Color.Red;
            progressBar1.Maximum = seconds;
            try
            {
                while (seconds != 0 && !cancellationTokenSource.IsCancellationRequested)
                {
                    await Task.Delay(1000, cancellationTokenSource.Token);
                    seconds--;
                    progressBar1.Value = progressBar1.Maximum - seconds;
                }
                if (!cancellationTokenSource.IsCancellationRequested)
                {
                    await Task.Delay(200, cancellationTokenSource.Token);
                    SendHost("+ all");
                }
            }
            catch (Exception) { };
        }
        
        private void AddControlsToPanel()
        {
            panel.Controls.Clear();
            is_question = false;
            int numberOfTheme = 0;
            int width = panel.Width;
            int height = panel.Height;

            foreach (ThemesClass theme in round.themeClasses)
            {
                System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                label.Name = "Theme" + numberOfTheme.ToString();
                label.Location = new Point(0, numberOfTheme * height / round.themeClasses.Count);
                label.Size = new Size(300, height / round.themeClasses.Count);
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
                    button.Location = new Point(300 + numberOfQuestion * (width - 300) / theme.questionClasses.Count, numberOfTheme * height / round.themeClasses.Count);
                    button.Size = new Size((width - 300) / theme.questionClasses.Count, height / round.themeClasses.Count);
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
                System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                label.Name = "Theme" + connectedUsers[i].User.Name;
                label.Location = new Point(i * (panelUsers.Width / connectedUsers.Count) + 10, 10);
                label.Size = new Size(panelUsers.Width/connectedUsers.Count - 20, panelUsers.Height - 20);
                label.Text = connectedUsers[i].User.Name + "\n" + connectedUsers[i].User.Scores;
                if(connectedUsers[i].isOtv)
                {
                    label.BackColor = Color.Red;
                }
                else
                {
                    label.BackColor = Color.LightBlue;
                }
                label.Padding = new Padding(6);
                label.Font = new Font("Arial", 20);
                panelUsers.Controls.Add(label);
            }
        }
        private void ChooseQuestionAsync(QuestionClass question)
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
            
            ColorProgressBar.ColorProgressBar progressBar1 = new ColorProgressBar.ColorProgressBar();

            int time = 10;
            is_question = true;



            panel.Controls.Add(progressBar1);
            if (question.type == QuestionsType.text)
            {
                System.Windows.Forms.Label labelQuestion = new System.Windows.Forms.Label();
                labelQuestion.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
                labelQuestion.Location = new Point(50, 30);
                labelQuestion.Name = "question";
                labelQuestion.Size = new Size(panel.Width - 100, 170);
                labelQuestion.Font = new Font("Arial", 22);
                labelQuestion.ForeColor = Color.White;
                labelQuestion.TabIndex = 0;
                labelQuestion.Text = question.question;
                panel.Controls.Add(labelQuestion);
                RichTextBox textBox = new RichTextBox();
                textBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                textBox.Location = new Point(50, panel.Height - 150);
                textBox.Name = "textBox";
                textBox.Size = new Size(panel.Width - 200, 100);
                textBox.TabIndex = 1;
                textBox.Font = new Font("Arial", 22);

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
                    is_question = true;
                    foreach (Control control in panel.Controls)
                    {
                        if (control is Button)
                        {
                            Button button = (Button)control;
                            button.Enabled = false;
                        }
                    }
                    if (Distance(textBox.Text.ToLower(), textBox.Text.Length, question.answer.ToLower(), question.answer.Length) < Math.Max(Math.Max(textBox.Text.Length, question.answer.Length) / 2, 0))
                    {
                        SendHost("+ " + question.price);
                        cancellationTokenSource?.Cancel();
                    }
                    else SendHost("- " + question.price);
                    
                };

                panel.Controls.Add(textBox);
                panel.Controls.Add(button);
            }
            else if (question.type == QuestionsType.selection)
            {
                System.Windows.Forms.Label labelQuestion = new System.Windows.Forms.Label();
                labelQuestion.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
                labelQuestion.Location = new Point(50, 30);
                labelQuestion.Name = "question";
                labelQuestion.Size = new Size(panel.Width - 100, 170);
                labelQuestion.Font = new Font("Arial", 22);
                labelQuestion.ForeColor = Color.White;
                labelQuestion.TabIndex = 0;
                labelQuestion.Text = question.question;
                panel.Controls.Add(labelQuestion);
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
                        foreach (Control control in panel.Controls)
                        {
                            if (control is Button)
                            {
                                Button button = (Button)control;
                                button.Enabled = false;
                            }
                        }
                        if (variant == question.answer)
                        {
                            SendHost("+ " + question.price);
                            cancellationTokenSource?.Cancel();
                        }
                        else SendHost("- " + question.price);
                    };

                    panel.Controls.Add(button);
                    numberOfVariant++;
                }
            }
            else if (question.type == QuestionsType.photo)
            {
                time = 20;
                System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                label.Name = "Theme1";
                label.Location = new Point(10, 10);
                label.Size = new Size(panel.Width/4, panel.Height - 170);
                label.Font = new Font("Arial", 16);
                label.ForeColor = Color.White;
                label.Text = question.question;
                label.TabIndex = 3;

                PictureBox pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
                pictureBox.Location = new Point(10, 15);
                pictureBox.Size = new Size(panel.Width, panel.Height - 170);
                pictureBox.Name = "question";
                


                pictureBox.TabIndex = 2;

                pictureBox.Image = Image.FromFile(question.link);

                panel.Controls.Add(label);
                panel.Controls.Add(pictureBox);
                
                RichTextBox textBox = new RichTextBox();
                textBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                textBox.Location = new Point(50, panel.Height - 150);
                textBox.Name = "textBox";
                textBox.Text = "Имя + Фамилия";
                textBox.Size = new Size(panel.Width - 200, 100);
                textBox.TabIndex = 1;
                textBox.Font = new Font("Arial", 22);
                textBox.Click += (sender, e) =>
                {
                    if (textBox.Text == "Имя + Фамилия") textBox.Text = "";
                };

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
                    is_question = true;
                    button.Enabled = false;
                    if (Distance(textBox.Text.ToLower(), textBox.Text.Length, question.answer.ToLower(), question.answer.Length) < Math.Max(Math.Max(textBox.Text.Length, question.answer.Length) / 2, 0))
                    {
                        SendHost("+ " + question.price);
                        cancellationTokenSource?.Cancel();
                    }
                    else SendHost("- " + question.price);

                };

                panel.Controls.Add(textBox);
                panel.Controls.Add(button);
            }
            else if (question.type == QuestionsType.audio)
            {
                time = 20;
                System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                label.Name = "Theme1";
                label.Location = new Point(10, 10);
                label.Size = new Size(panel.Width / 4, panel.Height - 170);
                label.Font = new Font("Arial", 22);
                label.ForeColor = Color.White;
                label.Text = "Кто произносит эту речь?";
                label.TabIndex = 3;

                
                player.SoundLocation = question.question;
                player.Play();

                RichTextBox textBox = new RichTextBox();
                textBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                textBox.Location = new Point(50, panel.Height - 150);
                textBox.Name = "textBox";
                textBox.Text = "Имя + Фамилия";
                textBox.Size = new Size(panel.Width - 200, 100);
                textBox.TabIndex = 1;
                textBox.Font = new Font("Arial", 22);
                textBox.Click += (sender, e) =>
                {
                    if (textBox.Text == "Имя + Фамилия") textBox.Text = "";
                };
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
                    is_question = true;
                    if (Distance(textBox.Text.ToLower(), textBox.Text.Length, question.answer.ToLower(), question.answer.Length) < Math.Max(Math.Max(textBox.Text.Length, question.answer.Length) / 2, 0))
                    {
                        
                        SendHost("+ " + question.price);
                        cancellationTokenSource?.Cancel();
                    }
                    else SendHost("- " + question.price);
                };
                panel.Controls.Add(label);
                panel.Controls.Add(textBox);
                panel.Controls.Add(button);
            }
            progressBar1.Minimum = 0;
            progressBar1.Maximum = time;
            progressBar1.Value = 0;
            progressBar1.ForeColor = Color.Red;
            progressBar1.Size = new Size(panel.Width, 30);
            progressBar1.Location = new Point(0, panel.Height - 30);
            StartTimer(time, progressBar1);
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
            panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel.BackColor = Color.FromArgb(40, 86, 182);
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(1200, 604);
            panel.TabIndex = 0;
            // 
            // panelUsers
            // 
            panelUsers.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelUsers.BackColor = Color.FromArgb(235, 239, 241);
            panelUsers.Location = new Point(0, 602);
            panelUsers.Name = "panelUsers";
            panelUsers.Size = new Size(1200, 198);
            panelUsers.TabIndex = 1;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1200, 800);
            Controls.Add(panelUsers);
            Controls.Add(panel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GameForm";
            Text = "Game";
            Resize += GameForm_Resize;
            ResumeLayout(false);
        }

        private void GameForm_Resize(object sender, EventArgs e)
        {
            if (!is_question)
            {
                AddControlsToPanel();
                DisplayUser(connectedUsersOwn);
            }
            
        }

        #endregion

        private Panel panel;
        private Panel panelUsers;
    }
}