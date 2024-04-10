using System.Windows.Forms;

namespace SGame.Forms
{
    partial class HostForm
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
        private void ipLabel_Click(object sender, EventArgs e)
        {
            Point cursorPos = Cursor.Position;
            string s = "";
            for (int i = 0; i < ipLabel.Text.Length; i++)
            {
                if (ipLabel.Text[i] == ':')
                {
                    s = ipLabel.Text.Substring(i + 2);
                }
            }
            messageLabel.Location = new Point(cursorPos.X + 20, cursorPos.Y);
            messageLabel.Visible = true;
            messageLabel.BringToFront();

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 секунды
            timer.Tick += (s, ev) =>
            {
                messageLabel.Visible = false;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
            Clipboard.SetText(s, TextDataFormat.UnicodeText);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ipLabel = new Label();
            MessageTextBox = new TextBox();
            buttonSendMessage = new Button();
            playersListLabes = new Label();
            buttonStartGame = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            messageLabel = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // ipLabel
            // 
            ipLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ipLabel.AutoSize = true;
            ipLabel.Cursor = Cursors.Hand;
            ipLabel.Font = new Font("Segoe UI", 21.75F);
            ipLabel.Location = new Point(469, 70);
            ipLabel.Margin = new Padding(70);
            ipLabel.Name = "ipLabel";
            ipLabel.Size = new Size(260, 126);
            ipLabel.TabIndex = 0;
            ipLabel.Text = "IP";
            ipLabel.TextAlign = ContentAlignment.MiddleCenter;
            ipLabel.Click += ipLabel_Click;
            // 
            // MessageTextBox
            // 
            MessageTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MessageTextBox.BackColor = SystemColors.ScrollBar;
            MessageTextBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            MessageTextBox.Location = new Point(30, 106);
            MessageTextBox.Margin = new Padding(30, 20, 30, 0);
            MessageTextBox.MinimumSize = new Size(0, 36);
            MessageTextBox.Name = "MessageTextBox";
            MessageTextBox.PlaceholderText = "Введите сообщение для игроков";
            MessageTextBox.Size = new Size(334, 36);
            MessageTextBox.TabIndex = 7;
            MessageTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // buttonSendMessage
            // 
            buttonSendMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonSendMessage.BackColor = Color.Turquoise;
            buttonSendMessage.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonSendMessage.Location = new Point(30, 182);
            buttonSendMessage.Margin = new Padding(30, 10, 30, 10);
            buttonSendMessage.Name = "buttonSendMessage";
            buttonSendMessage.Size = new Size(334, 68);
            buttonSendMessage.TabIndex = 8;
            buttonSendMessage.Text = "Отправить сообщение ";
            buttonSendMessage.UseVisualStyleBackColor = false;
            buttonSendMessage.Click += buttonSendMessage_Click;
            // 
            // playersListLabes
            // 
            playersListLabes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            playersListLabes.AutoEllipsis = true;
            playersListLabes.BackColor = Color.Transparent;
            playersListLabes.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            playersListLabes.ForeColor = SystemColors.ActiveCaptionText;
            playersListLabes.Location = new Point(30, 296);
            playersListLabes.Margin = new Padding(30);
            playersListLabes.Name = "playersListLabes";
            playersListLabes.Size = new Size(339, 206);
            playersListLabes.TabIndex = 9;
            playersListLabes.TextAlign = ContentAlignment.TopCenter;
            // 
            // buttonStartGame
            // 
            buttonStartGame.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonStartGame.BackColor = Color.LightGreen;
            buttonStartGame.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonStartGame.Location = new Point(30, 10);
            buttonStartGame.Margin = new Padding(30, 10, 30, 10);
            buttonStartGame.Name = "buttonStartGame";
            buttonStartGame.Size = new Size(334, 66);
            buttonStartGame.TabIndex = 10;
            buttonStartGame.Text = "Начать игру";
            buttonStartGame.UseVisualStyleBackColor = false;
            buttonStartGame.Click += buttonStartGame_ClickAsync;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.BackColor = SystemColors.ButtonHighlight;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Controls.Add(ipLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(playersListLabes, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(1200, 800);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(MessageTextBox, 0, 1);
            tableLayoutPanel2.Controls.Add(buttonSendMessage, 0, 2);
            tableLayoutPanel2.Controls.Add(buttonStartGame, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(402, 269);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Size = new Size(394, 260);
            tableLayoutPanel2.TabIndex = 12;
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.BackColor = Color.LimeGreen;
            messageLabel.Location = new Point(0, 0);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(104, 15);
            messageLabel.TabIndex = 0;
            messageLabel.Text = "текст скопирован";
            messageLabel.Visible = false;
            // 
            // HostForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1200, 800);
            Controls.Add(messageLabel);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HostForm";
            Text = "HostForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ipLabel;
        private TextBox MessageTextBox;
        private Button buttonSendMessage;
        private Label playersListLabes;
        private Button buttonStartGame;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label messageLabel;
    }
}