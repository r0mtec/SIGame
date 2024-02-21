using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SignGame
{
    public partial class ChoseGameForm : Form
    {
        /// <summary>
        /// Поле-обьект для работы с пользователем
        /// </summary>
        private ManageUser manageUser;

        /// <summary>
        /// Инициализация формы и поля-объекта
        /// </summary>
        /// <param name="manageUser">поле-объект</param>
        public ChoseGameForm(ManageUser manageUser)
        {
            InitializeComponent();
            this.manageUser = manageUser;
        }

        /// <summary>
        /// При нажатии на кнопку изменяется имя Labal
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            TempName.Text = manageUser.User?.Name;
        }
    }
}
