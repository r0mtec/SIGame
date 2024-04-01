namespace SignGame
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
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            create_button = new Button();
            text_name = new TextBox();
            fileSystemWatcher1 = new FileSystemWatcher();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.BackgroundImageLayout = ImageLayout.Center;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.MinimumSize = new Size(950, 550);
            panel1.Name = "panel1";
            panel1.Size = new Size(1452, 715);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.MinimumSize = new Size(0, 450);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1452, 715);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(create_button, 0, 1);
            tableLayoutPanel2.Controls.Add(text_name, 0, 0);
            tableLayoutPanel2.Location = new Point(465, 296);
            tableLayoutPanel2.Margin = new Padding(30, 10, 30, 60);
            tableLayoutPanel2.MaximumSize = new Size(520, 220);
            tableLayoutPanel2.MinimumSize = new Size(0, 182);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(520, 216);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // create_button
            // 
            create_button.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            create_button.AutoSize = true;
            create_button.Location = new Point(70, 113);
            create_button.Margin = new Padding(70, 5, 25, 30);
            create_button.MaximumSize = new Size(500, 490);
            create_button.MinimumSize = new Size(130, 80);
            create_button.Name = "create_button";
            create_button.RightToLeft = RightToLeft.Yes;
            create_button.Size = new Size(425, 80);
            create_button.TabIndex = 0;
            create_button.Text = "Войти";
            create_button.UseVisualStyleBackColor = true;
            create_button.Click += create_button_Click;
            // 
            // text_name
            // 
            text_name.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            text_name.Font = new Font("Arial Narrow", 12F);
            text_name.Location = new Point(80, 48);
            text_name.Margin = new Padding(80, 30, 30, 20);
            text_name.MaximumSize = new Size(480, 490);
            text_name.MinimumSize = new Size(120, 40);
            text_name.Name = "text_name";
            text_name.PlaceholderText = "Введите ваш никнейм";
            text_name.Size = new Size(410, 40);
            text_name.TabIndex = 1;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1452, 715);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(1920, 1080);
            MinimumSize = new Size(950, 550);
            Name = "StartForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Main";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private FileSystemWatcher fileSystemWatcher1;
        private TextBox text_name;
        private Button create_button;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
    }
}