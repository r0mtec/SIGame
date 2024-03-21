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
            SuspendLayout();
            // 
            // ipLabel
            // 
            ipLabel.AutoSize = true;
            ipLabel.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            ipLabel.Location = new Point(254, 58);
            ipLabel.Name = "ipLabel";
            ipLabel.Size = new Size(41, 40);
            ipLabel.TabIndex = 0;
            ipLabel.Text = "ip";
            // 
            // MessageTextBox
            // 
            MessageTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            MessageTextBox.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MessageTextBox.Location = new Point(211, 199);
            MessageTextBox.Name = "MessageTextBox";
            MessageTextBox.PlaceholderText = "Введите сообщение";
            MessageTextBox.Size = new Size(162, 26);
            MessageTextBox.TabIndex = 7;
            // 
            // buttonSendMessage
            // 
            buttonSendMessage.Location = new Point(421, 199);
            buttonSendMessage.Name = "buttonSendMessage";
            buttonSendMessage.Size = new Size(181, 26);
            buttonSendMessage.TabIndex = 8;
            buttonSendMessage.Text = "Отправить всем сообщение";
            buttonSendMessage.UseVisualStyleBackColor = true;
            buttonSendMessage.Click += buttonSendMessage_Click;
            // 
            // playersListLabes
            // 
            playersListLabes.AutoEllipsis = true;
            playersListLabes.BackColor = Color.Transparent;
            playersListLabes.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            playersListLabes.ForeColor = SystemColors.ActiveCaptionText;
            playersListLabes.Location = new Point(93, 249);
            playersListLabes.Name = "playersListLabes";
            playersListLabes.Size = new Size(612, 164);
            playersListLabes.TabIndex = 9;
            // 
            // buttonStartGame
            // 
            buttonStartGame.Location = new Point(317, 150);
            buttonStartGame.Name = "buttonStartGame";
            buttonStartGame.Size = new Size(154, 43);
            buttonStartGame.TabIndex = 10;
            buttonStartGame.Text = "Start game";
            buttonStartGame.UseVisualStyleBackColor = true;
            buttonStartGame.Click += buttonStartGame_ClickAsync;
            // 
            // HostForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 800);
            Controls.Add(buttonStartGame);
            Controls.Add(playersListLabes);
            Controls.Add(buttonSendMessage);
            Controls.Add(MessageTextBox);
            Controls.Add(ipLabel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HostForm";
            Text = "HostForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ipLabel;
        private TextBox MessageTextBox;
        private Button buttonSendMessage;
        private Label playersListLabes;
        private Button buttonStartGame;
    }
}