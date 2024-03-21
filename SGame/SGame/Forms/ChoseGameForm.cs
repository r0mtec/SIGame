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
        /// <summary>
        /// Поле-обьект для работы с пользователем
        /// </summary>
        private MainForm? mainForm;
        public ChoseGameForm(MainForm parrentForm)
        {
            InitializeComponent();
            mainForm = parrentForm;
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
    }
       
}
