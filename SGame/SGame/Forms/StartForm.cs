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

        private Rectangle buttonStartRectangle;


        private Rectangle text_nameRectangle;

        private Rectangle originalStartFormSize;

        /// <summary>
        /// Инициализация формы
        /// </summary>
        public StartForm(SIGame parrentForm)
        {

            
            InitializeComponent();
            mainForm = parrentForm;

            originalStartFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            buttonStartRectangle = new Rectangle(create_button.Location.X, create_button.Location.Y, create_button.Width, create_button.Height);
            text_nameRectangle = new Rectangle(text_name.Location.X, text_name.Location.Y, text_name.Width, text_name.Height);


         

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

        private void StartForm_SizeChanged(object sender, EventArgs e)
        {

            //create_button.Left = (this.ClientSize.Width - create_button.Width) / 2;
            //create_button.Top = (this.ClientSize.Height - create_button.Height) / 2;

            //text_name.Left = (this.ClientSize.Width - text_name.Width) / 2;
            //text_name.Top = (this.ClientSize.Height - text_name.Height) / 2;


            resizeControl(buttonStartRectangle, create_button);
            resizeControl(text_nameRectangle, text_name);
        }

        protected void resizeControl(Rectangle r, Control c)
        {
            float xRatio = (float)(this.Width) / (float)(originalStartFormSize.Width);
            float yRatio = (float)(this.Height) / (float)(originalStartFormSize.Height);

            int newX = (int)(r.Location.X * xRatio);
            int newY = (int)(r.Location.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);



            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

    }
}
