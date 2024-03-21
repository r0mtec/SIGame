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
            IpTextBox = new TextBox();
            SuspendLayout();
            // 
            // host_but
            // 
            host_but.Location = new Point(289, 137);
            host_but.Name = "host_but";
            host_but.Size = new Size(208, 50);
            host_but.TabIndex = 1;
            host_but.Text = "Хостануть игру";
            host_but.UseVisualStyleBackColor = true;
            host_but.Click += HostButton_click;
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
            // ChoseGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(IpTextBox);
            Controls.Add(join_but);
            Controls.Add(host_but);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ChoseGameForm";
            Text = "ChoseGame";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button host_but;
        private Button join_but;
        private TextBox IpTextBox;
    }
}