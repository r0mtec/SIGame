using System.Windows.Forms;

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
            host_but = new Button();
            join_but = new Button();
            IpTextBox = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // host_but
            // 
            host_but.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            host_but.AutoSize = true;
            host_but.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            host_but.Location = new Point(3, 105);
            host_but.Name = "host_but";
            host_but.Size = new Size(287, 45);
            host_but.TabIndex = 1;
            host_but.Text = "Создать игровую сессию";
            host_but.UseVisualStyleBackColor = true;
            host_but.Click += HostButton_click;
            // 
            // join_but
            // 
            join_but.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            join_but.AutoSize = true;
            join_but.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            join_but.Location = new Point(3, 54);
            join_but.Name = "join_but";
            join_but.Size = new Size(287, 45);
            join_but.TabIndex = 2;
            join_but.Text = "Присоединаться к игре";
            join_but.UseVisualStyleBackColor = true;
            join_but.Click += join_but_Click;
            // 
            // IpTextBox
            // 
            IpTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            IpTextBox.Font = new Font("Arial Narrow", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            IpTextBox.Location = new Point(25, 15);
            IpTextBox.Margin = new Padding(25, 15, 3, 0);
            IpTextBox.MaximumSize = new Size(540, 40);
            IpTextBox.MinimumSize = new Size(120, 20);
            IpTextBox.Name = "IpTextBox";
            IpTextBox.PlaceholderText = "Введите IP-адрес сессии";
            IpTextBox.Size = new Size(265, 32);
            IpTextBox.TabIndex = 4;
            IpTextBox.KeyDown += IpTextBox_KeyDown;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ButtonFace;
            tableLayoutPanel1.BackgroundImage = SGame.Properties.Resources.background;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.MinimumSize = new Size(0, 670);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3444481F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3444481F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3111076F));
            tableLayoutPanel1.Size = new Size(1060, 670);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.BackgroundImageLayout = ImageLayout.None;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(host_but, 0, 2);
            tableLayoutPanel2.Controls.Add(IpTextBox, 0, 0);
            tableLayoutPanel2.Controls.Add(join_but, 0, 1);
            tableLayoutPanel2.Location = new Point(383, 233);
            tableLayoutPanel2.Margin = new Padding(30, 10, 30, 60);
            tableLayoutPanel2.MinimumSize = new Size(0, 150);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Size = new Size(293, 153);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // ChoseGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Highlight;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1060, 665);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ChoseGameForm";
            StartPosition = FormStartPosition.Manual;
            Text = "ChoseGame";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button host_but;
        private Button join_but;
        private TextBox IpTextBox;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
    }
}