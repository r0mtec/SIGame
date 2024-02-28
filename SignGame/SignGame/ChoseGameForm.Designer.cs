namespace SignGame
{
    partial class ChoseGameForm
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
            TempName = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // TempName
            // 
            TempName.AutoSize = true;
            TempName.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point);
            TempName.Location = new Point(273, 125);
            TempName.Name = "TempName";
            TempName.Size = new Size(208, 86);
            TempName.TabIndex = 0;
            TempName.Text = "label1";
            // 
            // button1
            // 
            button1.Location = new Point(273, 263);
            button1.Name = "button1";
            button1.Size = new Size(208, 50);
            button1.TabIndex = 1;
            button1.Text = "Посмотреть имя пользователя";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ChoseGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(TempName);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ChoseGameForm";
            Text = "ChoseGame";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TempName;
        private Button button1;
    }
}