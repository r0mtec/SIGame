using SGame.AboutUser;
using SignGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGame
{
    public partial class SIGame : Form
    {
        public Form? currentForm;
        public ManageUser manageUser;


      

        public void ChangeForm(Form newForm)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }

            //Установка созданной формы в позицию в центр экрана
            this.StartPosition = FormStartPosition.CenterScreen;

            //Установка созданной формы в позицию 0,0
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(0, 0);

            //Вывод формы на передний план
            this.TopMost = false;

            //Вывод формы в максимально указанной размерности
            this.WindowState = FormWindowState.Maximized;

            currentForm = newForm;
            newForm.TopLevel = false;
            newForm.Dock = DockStyle.Fill;
            this.panel.Controls.Add(newForm);
            this.panel.Tag = newForm;
            newForm.BringToFront();
            newForm.Show();
        }

        public SIGame()
        {
            InitializeComponent();
            ChangeForm(new StartForm(this));
            this.SuspendLayout();
            this.ResumeLayout(false);
        }

        
    }
}
