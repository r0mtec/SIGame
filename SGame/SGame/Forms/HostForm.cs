using SGame.AboutUser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SGame.Forms
{
    public partial class HostForm : Form
    {
        private ManageUser manageUser;
        List<ConnectedUser> connectedUsers = new List<ConnectedUser>();
        private MainForm? mainForm;
        public HostForm(ManageUser manageUser, MainForm? parrentForm)
        {
            this.manageUser = manageUser;
            this.mainForm = parrentForm;
            InitializeComponent();
            HostGame();

        }
        private async void HostGame()
        {
            if (manageUser == null || manageUser.User == null) return;
            string ip = manageUser.User.Ip;
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            var tcpListener = new TcpListener(tcpEndPoint);
            tcpListener.Start();


            // Задаем текст для Label
            ipLabel.Text = "Ваш айпи - " + manageUser.User.Ip;


            // Цикл для приема новых "клиентов"
            while (true)
            {
                // Ожидаем нового подключения от клиента
                var tcpClient = await tcpListener.AcceptTcpClientAsync();

                // Запускаем асинхронный метод для обработки каждого клиента
                _ = Task.Run(() => HandleClient(tcpClient));
            }
        }
        private async void HandleClient(TcpClient tcpClient)
        {

            // Получаем поток для обмена данными с клиентом
            var stream = tcpClient.GetStream();

            // Буфер для чтения данных
            var buffer = new byte[256];
            var size = 0;

            while (true)
            {
                // Асинхронное чтение данных от сервера
                try
                {
                    size = await stream.ReadAsync(buffer, 0, buffer.Length);
                }
                catch
                {
                    int idClient = connectedUsers.FindIndex(client => client.Client == tcpClient);
                    connectedUsers.Remove(connectedUsers[idClient]);
                    tcpClient.Close();
                }
                // Строка для хранения данных от клиента
                var data = new StringBuilder();

                try
                {
                    // Читаем данные из потока асинхронно
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));

                    // Десериализуем полученные данные в объект User
                    string jsonAnswer = Encoding.UTF8.GetString(buffer, 0, size);
                    User AnwerUser = JsonConvert.DeserializeObject<User>(jsonAnswer);

                    // Поиск пользователя в списке
                    int index = connectedUsers.FindIndex(client => client.Client == tcpClient);

                    if (index != -1)
                    {
                        // Элемент найден, изменяем его
                        connectedUsers[index].User = AnwerUser;

                    }
                    else
                    {
                        connectedUsers.Add(new ConnectedUser(tcpClient, AnwerUser));
                        _ = BroadcastMessage(connectedUsers.Count.ToString() + " count");
                    }
                    refresh_label();
                    // Сериализуем информацию о текущем пользователе и отправляем обратно клиенту
                    var message = "Успех!";

                    var dataM = Encoding.UTF8.GetBytes(message);

                    await stream.WriteAsync(dataM);
                }
                catch (Exception ex)
                {
                    // Обработка и вывод ошибок в текстовое поле
                }
            }
        }
        private void refresh_label()
        {
            string s = "";
            foreach (ConnectedUser client in connectedUsers)
            {
                if (client.User == null) s += "Анонимус - -1 ";
                else s += client.User.Name + " - " + client.User.Scores + "\n";
            }
            // Обновляем пользовательский интерфейс (UI) с использованием делегата и метода Invoke
            playersListLabes.Invoke((MethodInvoker)delegate
            {
                // Отображаем информацию о клиенте на форме
                playersListLabes.Text = s;
            });
        }

        private async void buttonSendMessage_Click(object sender, EventArgs e)
        {
            if (connectedUsers.Count == 0) return;
            await BroadcastMessage(MessageTextBox.Text);
        }

        private async Task BroadcastMessage(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);

            foreach (ConnectedUser client in connectedUsers)
            {
                if (client.Client == null)
                {
                    playersListLabes.Text = "Ошибка, нет пользователя";
                    continue;
                }
                try
                {
                    await client.Client.GetStream().WriteAsync(data, 0, data.Length);
                }
                catch (Exception ex)
                {
                    playersListLabes.Text = "Ошибка при отправке данных";
                }
            }
            refresh_label();
        }
        
    }
}
