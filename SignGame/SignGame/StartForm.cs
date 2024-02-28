using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignGame
{
    public partial class StartForm : Form
    {
        /// <summary>
        /// Поле-объект для управления пользователем
        /// </summary>
        public ManageUser? manageUser;
        /// <summary>
        /// Поле для подключение другой формы
        /// </summary>
        private Form? ChoseGameForm;
        /// <summary>
        /// Инициализация формы
        /// </summary>
        public StartForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Создание пользователя при нажатии на кнопку
        /// </summary>
        private void create_button_Click(object sender, EventArgs e)
        {
            string nickname = text_name.Text;
            manageUser = new ManageUser();
            manageUser.Init(nickname, 0);
            PanelForm(new ChoseGameForm(manageUser));

        }
        /// <summary>
        /// Создание и открытие новый формы
        /// </summary>
        /// <param name="fm">Новая форма</param>
        private void PanelForm(Form fm)
        {
            if (ChoseGameForm != null)
            {
                ChoseGameForm.Close();
            }
            ChoseGameForm = fm;
            fm.TopLevel = false;
            fm.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(fm);
            this.panel1.Tag = fm;
            fm.BringToFront();
            fm.Show();

        }

    }
}
