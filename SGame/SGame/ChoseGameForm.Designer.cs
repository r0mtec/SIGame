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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoseGameForm));
            host_but = new Button();
            join_but = new Button();
            Vivod = new Label();
            IpTextBox = new TextBox();
            buttonSendMessage = new Button();
            MessageTextBox = new TextBox();
            SuspendLayout();
            // 
            // host_but
            // 
            host_but.Location = new Point(289, 123);
            host_but.Name = "host_but";
            host_but.Size = new Size(208, 50);
            host_but.TabIndex = 1;
            host_but.Text = "Хостануть игру";
            host_but.UseVisualStyleBackColor = true;
            host_but.Click += host_but_Click;
            // 
            // join_but
            // 
            join_but.Location = new Point(289, 310);
            join_but.Name = "join_but";
            join_but.Size = new Size(208, 50);
            join_but.TabIndex = 2;
            join_but.Text = "Присоединаться к игре";
            join_but.UseVisualStyleBackColor = true;
            join_but.Click += join_but_Click;
            // 
            // Vivod
            // 
            Vivod.AutoEllipsis = true;
            Vivod.BackColor = Color.Transparent;
            Vivod.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Vivod.ForeColor = SystemColors.Control;
            Vivod.Location = new Point(12, 9);
            Vivod.Name = "Vivod";
            Vivod.Size = new Size(237, 164);
            Vivod.TabIndex = 3;
            // 
            // IpTextBox
            // 
            IpTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            IpTextBox.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point);
            IpTextBox.Location = new Point(330, 366);
            IpTextBox.Name = "IpTextBox";
            IpTextBox.PlaceholderText = "Введите ip";
            IpTextBox.Size = new Size(130, 26);
            IpTextBox.TabIndex = 4;
            // 
            // buttonSendMessage
            // 
            buttonSendMessage.Location = new Point(393, 176);
            buttonSendMessage.Name = "buttonSendMessage";
            buttonSendMessage.Size = new Size(181, 26);
            buttonSendMessage.TabIndex = 5;
            buttonSendMessage.Text = "Отправить всем сообщение";
            buttonSendMessage.UseVisualStyleBackColor = true;
            buttonSendMessage.Click += buttonSendMessage_Click;
            // 
            // MessageTextBox
            // 
            MessageTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            MessageTextBox.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MessageTextBox.Location = new Point(225, 176);
            MessageTextBox.Name = "MessageTextBox";
            MessageTextBox.PlaceholderText = "Введите сообщение";
            MessageTextBox.Size = new Size(162, 26);
            MessageTextBox.TabIndex = 6;
            // 
            // ChoseGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(MessageTextBox);
            Controls.Add(buttonSendMessage);
            Controls.Add(IpTextBox);
            Controls.Add(Vivod);
            Controls.Add(join_but);
            Controls.Add(host_but);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ChoseGameForm";
            Text = "ChoseGame";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TempName;
        private Button host_but;
        private Button join_but;
        private Label Vivod;
        private TextBox IpTextBox;
        private Button buttonSendMessage;
        private TextBox MessageTextBox;
    }
}