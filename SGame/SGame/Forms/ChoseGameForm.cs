using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using SGame.AboutUser;
using SGame;
using SGame.Forms;

namespace SignGame
{
    public partial class ChoseGameForm : Form
    {

        private Rectangle join_butRectangle;

        private Rectangle IpTextBoxRectangle;

        private Rectangle host_butRectangle;

        private Rectangle originalChoseGameSize;

        /// <summary>
        /// Поле-обьект для работы с пользователем
        /// </summary>
        private SIGame? mainForm;
        public ChoseGameForm(SIGame parrentForm)
        {
            InitializeComponent();
            mainForm = parrentForm;

            originalChoseGameSize = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            join_butRectangle = new Rectangle(join_but.Location.X, join_but.Location.Y, join_but.Width, join_but.Height);
            host_butRectangle = new Rectangle(host_but.Location.X, host_but.Location.Y, host_but.Width, host_but.Height);
            IpTextBoxRectangle = new Rectangle(IpTextBox.Location.X, IpTextBox.Location.Y, IpTextBox.Width, IpTextBox.Height);
        }

        /// <summary>
        /// При нажатие на кнопку создается host, запускается асинхронный метод и запускается ожитание ответа
        /// </summary>
        private void HostButton_click(object sender, EventArgs e)
        {
            if (mainForm?.manageUser == null || mainForm == null) return;
            mainForm.ChangeForm(new HostForm(mainForm));
        }
        /*
        private void refresh_label()
        {
            string s = "";
            foreach (User client in UserConnected) s += client.Name + " - " + client.Scores + "\n";
            // Обновляем пользовательский интерфейс (UI) с использованием делегата и метода Invoke
            Vivod.Invoke((MethodInvoker)delegate
            {
                // Отображаем информацию о клиенте на форме
                Vivod.Text = s;
            });
        }

        /// <summary>
        /// При нажатии на кнопку вызывается метод BroadcastMessage
        /// </summary>
        private async void buttonSendMessage_Click(object sender, EventArgs e)
        {
            if (connectedClients.Count == 0) return;
            await BroadcastMessage(MessageTextBox.Text);
        }
        
        /// <summary>
        /// Отправка всем клиетам сообщения
        /// </summary>
        /// <param name="message">cjj,otybt</param>
        private async Task BroadcastMessage(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);

            foreach (TcpClient client in connectedClients)
            {
                try
                {
                    await client.GetStream().WriteAsync(data, 0, data.Length);
                }
                catch (Exception ex)
                {
                    Vivod.Text = "Ошибка при отправке данных";
                }
            }
            refresh_label();
        }
        */




        private void join_but_Click(object sender, EventArgs e)
        {

            // Проверяем, что поле ввода IP-адреса не пустое
            if (IpTextBox.Text == "")
            {
                return;
            }
            mainForm?.ChangeForm(new WaitGameForm(mainForm, IpTextBox.Text));

        }

        protected void resizeControl(Rectangle r, Control c)
        {
            float xRatio = (float)(this.Width) / (float)(originalChoseGameSize.Width);
            float yRatio = (float)(this.Height) / (float)(originalChoseGameSize.Height);

            int newX = (int)(r.Location.X * xRatio);
            int newY = (int)(r.Location.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);



            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        private void ChoseGameForm_SizeChanged(object sender, EventArgs e)
        {
            resizeControl(join_butRectangle, join_but);
            resizeControl(host_butRectangle, host_but);
            resizeControl(IpTextBoxRectangle, IpTextBox);
        }

        private void IpTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                join_but.PerformClick();
                
            }
        }
    }

}
