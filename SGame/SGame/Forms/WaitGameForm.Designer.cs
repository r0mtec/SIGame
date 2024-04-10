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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // countPlayersLabel
            // 
            countPlayersLabel.AutoSize = true;
            countPlayersLabel.Font = new Font("Segoe UI", 18F);
            countPlayersLabel.Location = new Point(403, 60);
            countPlayersLabel.Margin = new Padding(3, 60, 3, 10);
            countPlayersLabel.Name = "countPlayersLabel";
            countPlayersLabel.Size = new Size(366, 64);
            countPlayersLabel.TabIndex = 0;
            countPlayersLabel.Text = "Количество присоединившихся игроков: 0/6";
            countPlayersLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.Font = new Font("Segoe UI", 18F);
            messageLabel.Location = new Point(30, 296);
            messageLabel.Margin = new Padding(30, 30, 3, 3);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(294, 32);
            messageLabel.TabIndex = 1;
            messageLabel.Text = "Сообщения от ведущего:";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.BackColor = SystemColors.ButtonHighlight;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(countPlayersLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(messageLabel, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(1200, 800);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // WaitGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 800);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "WaitGameForm";
            Text = "WaitGameForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label countPlayersLabel;
        private Label messageLabel;
        private TableLayoutPanel tableLayoutPanel1;
    }
}