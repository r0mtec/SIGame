using SignGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGame
{
    public partial class MainForm : Form
    {
        public Form? currentForm;
        public void ChangeForm(Form newForm)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = newForm;
            newForm.TopLevel = false;
            newForm.Dock = DockStyle.Fill;
            this.panel.Controls.Add(newForm);
            this.panel.Tag = newForm;
            newForm.BringToFront();
            newForm.Show();
        }
        public MainForm()
        {
            InitializeComponent();
            ChangeForm(new StartForm(this));
        }
    }
}
