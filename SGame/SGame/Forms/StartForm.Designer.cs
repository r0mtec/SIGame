﻿namespace SignGame
{
    partial class StartForm
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
            create_button = new Button();
            text_name = new TextBox();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // create_button
            // 
            create_button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            create_button.AutoSize = true;
            create_button.Location = new Point(338, 205);
            create_button.Name = "create_button";
            create_button.Size = new Size(130, 39);
            create_button.TabIndex = 0;
            create_button.Text = "Войти";
            create_button.UseVisualStyleBackColor = true;
            create_button.Click += create_button_Click;
            // 
            // text_name
            // 
            text_name.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            text_name.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point);
            text_name.Location = new Point(338, 147);
            text_name.Name = "text_name";
            text_name.PlaceholderText = "Введите никнейм";
            text_name.Size = new Size(130, 26);
            text_name.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(create_button);
            panel1.Controls.Add(text_name);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "StartForm";
            Text = "Main";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button create_button;
        private TextBox text_name;
        private Panel panel1;
    }
}