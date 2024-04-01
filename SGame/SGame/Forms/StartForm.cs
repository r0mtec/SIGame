using SGame;
using SGame.AboutUser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
//using System.Drawing.Drawing2D.LinearGradientBrush;
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
        /// Поле для подключения формы родителя
        /// </summary>
        private SIGame? mainForm;


        /// <summary>
        /// Инициализация формы
        /// </summary>
        public StartForm(SIGame parrentForm)
        {

            
            InitializeComponent();
            mainForm = parrentForm;

           


         

        }
        /// <summary>
        /// Создание пользователя при нажатии на кнопку
        /// </summary>
        private void create_button_Click(object sender, EventArgs e)
        {
            if (mainForm == null) return;
            string nickname = text_name.Text;
            manageUser = new ManageUser();
            manageUser.Init(nickname, 0);
            mainForm.manageUser = manageUser;
            mainForm.ChangeForm(new ChoseGameForm(mainForm));
            //PanelForm(new ChoseGameForm(manageUser));

        }
        /// <summary>
        /// Создание и открытие новый формы
        /// </summary>
        /// <param name="fm">Новая форма</param>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                               Color.FromArgb(192, 192, 192),
                                                               Color.FromArgb(0, 19, 127),
                                                               100F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

       

        

    }
}
