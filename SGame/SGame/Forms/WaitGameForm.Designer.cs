namespace SGame.Forms
{
    partial class WaitGameForm
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
            countPlayersLabel = new Label();
            messageLabel = new Label();
            SuspendLayout();
            // 
            // countPlayersLabel
            // 
            countPlayersLabel.AutoSize = true;
            countPlayersLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            countPlayersLabel.Location = new Point(348, 94);
            countPlayersLabel.Name = "countPlayersLabel";
            countPlayersLabel.Size = new Size(49, 32);
            countPlayersLabel.TabIndex = 0;
            countPlayersLabel.Text = "0/6";
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            messageLabel.Location = new Point(29, 299);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(0, 32);
            messageLabel.TabIndex = 1;
            // 
            // WaitGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 800);
            Controls.Add(messageLabel);
            Controls.Add(countPlayersLabel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "WaitGameForm";
            Text = "WaitGameForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label countPlayersLabel;
        private Label messageLabel;
    }
}