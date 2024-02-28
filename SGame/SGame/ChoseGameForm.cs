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
            newLabel.Location = new Point(100, 50);
            newLabel.Size = new Size(200, 20);

            // Задаем текст для Label
            newLabel.Text = manageUser.User.Ip;

            // Добавляем Label на форму
            this.Controls.Add(newLabel);

            ///




            while (true)
            {
                var tcpClient = await tcpListener.AcceptTcpClientAsync();
                await Task.Run(() => HandleClient(tcpClient));
            }
        }

        private async void HandleClient(TcpClient tcpClient)
        {
            var stream = tcpClient.GetStream();

            var buffer = new byte[256];
            var size = 0;
            var data = new StringBuilder();

            try
            {
                do
                {
                    size = await stream.ReadAsync(buffer, 0, buffer.Length);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));

                } while (stream.DataAvailable);


                Vivod.Invoke((MethodInvoker)delegate
                {
                    Vivod.Text = data.ToString();
                });

                string json = JsonConvert.SerializeObject(manageUser.User);

                var response = Encoding.UTF8.GetBytes(json);
                await stream.WriteAsync(response, 0, response.Length);
            }
            catch (Exception ex)
            {
                Vivod.Text = ex.ToString();
            }
            finally
            {
                tcpClient.Close();
            }
        }

        private async void join_but_Click(object sender, EventArgs e)
        {
            if (manageUser == null || manageUser.User == null) return;
            if(IpTextBox.Text == "") 
            {
                Vivod.Text = "Вы забыли ввести ip";
                return;
            }
            string ip = IpTextBox.Text;
            const int port = 8080;
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(manageUser.User.Ip), port);
            try
            {
                tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            }
            catch (Exception ex) 
            {
                Vivod.Text = "Вы ввели неправильный айпи";
                return;
            }

            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            var message = manageUser.User.Name;

            var data = Encoding.UTF8.GetBytes(message);

            await tcpSocket.ConnectAsync(tcpEndPoint);
            await tcpSocket.SendAsync(new ArraySegment<byte>(data), SocketFlags.None);

            var buffer = new byte[256];
            var size = 0;
            var answer = new StringBuilder();

            do
            {
                size = await tcpSocket.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));

            } while (tcpSocket.Available > 0);

            string jsonReceived = Encoding.UTF8.GetString(buffer, 0, size);
            User receivedUser = JsonConvert.DeserializeObject<User>(jsonReceived);

            Vivod.Text = receivedUser.Name;
            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();
        }
    }
}
