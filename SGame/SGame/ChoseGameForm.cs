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

namespace SignGame
{
    public partial class ChoseGameForm : Form
    {
        /// <summary>
        /// Поле-обьект для работы с пользователем
        /// </summary>
        private ManageUser manageUser;
        /// <summary>
        /// Список со всеми подключенными клиентами
        /// </summary>
        private List<TcpClient> connectedClients = new List<TcpClient>();
        private List<User> UserConnected = new List<User>();
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
        /// При нажатие на кнопку создается host, запускается асинхронный метод и запускается ожитание ответа
        /// </summary>
        private async void host_but_Click(object sender, EventArgs e)
        {
            if (manageUser == null || manageUser.User == null) return;
            string ip = manageUser.User.Ip;
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            var tcpListener = new TcpListener(tcpEndPoint);
            tcpListener.Start();



            ///создание Label
            Label newLabel = new Label();

            // Задаем уникальное имя для Label
            newLabel.Name = "IPlabel";

            // Задаем координаты и размер Label
            newLabel.Location = new Point(330, 100);
            newLabel.Size = new Size(200, 20);

            // Задаем текст для Label
            newLabel.Text = "Ваш айпи - " + manageUser.User.Ip;

            // Добавляем Label на форму
            this.Controls.Add(newLabel);
            ///


            // Цикл для приема новых "клиентов"
            while (true)
            {
                // Ожидаем нового подключения от клиента
                var tcpClient = await tcpListener.AcceptTcpClientAsync();

                // Добавляем нового клиента в список подключенных клиентов
                connectedClients.Add(tcpClient);

                // Запускаем асинхронный метод для обработки каждого клиента
                _ = Task.Run(() => HandleClient(tcpClient));
            }
        }

        /// <summary>
        /// Асинхронный метод для работы с пользователями
        /// </summary>
        private async void HandleClient(TcpClient tcpClient)
        {
            // Получаем поток для обмена данными с клиентом
            var stream = tcpClient.GetStream();

            // Буфер для чтения данных
            var buffer = new byte[256];
            var size = 0;

            // Строка для хранения данных от клиента
            var data = new StringBuilder();

            try
            {
                // Читаем данные из потока асинхронно
                do
                {
                    size = await stream.ReadAsync(buffer, 0, buffer.Length);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));

                } while (stream.DataAvailable);

                // Десериализуем полученные данные в объект User
                string jsonAnswer = Encoding.UTF8.GetString(buffer, 0, size); 
                User AnwerUser = JsonConvert.DeserializeObject<User>(jsonAnswer);

                // Поиск пользователя в списке
                User existingUser = UserConnected.Find(client => client.Ip == AnwerUser.Ip);
                if (existingUser != null)
                {
                    existingUser = AnwerUser;
                }
                else UserConnected.Add(AnwerUser); 
                refresh_label();
                

                // Сериализуем информацию о текущем пользователе и отправляем обратно клиенту
                var message = "Успех!";

                var dataM = Encoding.UTF8.GetBytes(message);

                await stream.WriteAsync(dataM);
            }
            catch (Exception ex)
            {
                // Обработка и вывод ошибок в текстовое поле
                Vivod.Text = ex.ToString();
            }
            
        }
        private void refresh_label()
        {
            // Обновляем пользовательский интерфейс (UI) с использованием делегата и метода Invoke
            Vivod.Invoke((MethodInvoker)delegate
            {
                string s = "";
                foreach (User client in UserConnected)
                {
                    s += client.Name + " - " + client.Scores + "\n";
                }
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
            await BroadcastMessage("Прибавить всем баллы");
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

        private async void join_but_Click(object sender, EventArgs e)
        {
            if (manageUser == null || manageUser.User == null) return;

            // Проверяем, что поле ввода IP-адреса не пустое
            if (IpTextBox.Text == "")
            {
                Vivod.Text = "Вы забыли ввести IP-адрес";
                return;
            }

            // Получаем IP-адрес из текстового поля
            string ip = IpTextBox.Text;
            const int port = 8080;

            // Создаем конечную точку для подключения (по умолчанию используем IP пользователя из manageUser)
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(manageUser.User.Ip), port);

            try
            {
                // Попытка использовать введенный IP-адрес, если он корректен
                tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            }
            catch (Exception ex)
            {
                // Выводим сообщение об ошибке при некорректном вводе IP-адреса
                Vivod.Text = "Вы ввели неправильный IP-адрес";
                return;
            }

            // Создаем новый сокет для обмена данными
            var tcpSocket = new TcpClient();

            // Сериализуем объект пользователя в формат JSON
            string json = JsonConvert.SerializeObject(manageUser.User);

            // Преобразуем JSON-строку в массив байт
            var message = Encoding.UTF8.GetBytes(json);

            // Асинхронное подключение к серверу
            await tcpSocket.ConnectAsync(tcpEndPoint);

            // Отправка данных на сервер
            await tcpSocket.GetStream().WriteAsync(message, 0, message.Length);

            // Буфер для приема данных от сервера
            var buffer = new byte[256];
            var size = 0;

            // Цикл для ожидания новых сообщений от сервера
            while (true)
            {
                // Асинхронное чтение данных от сервера
                size = await tcpSocket.GetStream().ReadAsync(buffer, 0, buffer.Length);
                if(size == 0) break;
      

                // Обработка полученных данных, например, вывод на форму
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, size);
                if(receivedMessage != "Прибавить всем баллы") 
                {
                    Vivod.Invoke((MethodInvoker)delegate
                    {
                        Vivod.Text = receivedMessage;
                    });
                }
                else 
                {
                    manageUser.User.ChangeScores(5);
                    json = JsonConvert.SerializeObject(manageUser.User);
                    message = Encoding.UTF8.GetBytes(json);
                    await tcpSocket.GetStream().WriteAsync(message, 0, message.Length);
                }
            }

            // Завершаем соединение и закрываем сокет
            tcpSocket.Close();
        }
    }
}
