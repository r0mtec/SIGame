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
using SGame.PackClass;
using System.Reflection;

namespace SGame.Forms
{
    public partial class HostForm : Form
    {
        private List<string> Parse(string otv)
        {
            List<string> words = new List<string>();
            string temp = "";
            otv += " ";
            for (int i = 0; i < otv.Length; i++)
            {
                if (otv[i] == ' ')
                {
                    words.Add(temp);
                    temp = "";
                }
                else if (otv[i] != '\\' && otv[i] != '"') temp += otv[i];
            }
            return words;
        }
        private bool Consist(List<string> words, List<string> wordToFind)
        {
            int count = wordToFind.Count;
            foreach (string word in words)
            {
                foreach (string check in wordToFind)
                {
                    if (word == check)
                    {
                        count--;
                        wordToFind.Remove(check);
                        break;
                    }
                }
            }
            return count == 0;
        }
        List<ConnectedUser> connectedUsers = new List<ConnectedUser>();
        private MainForm? mainForm;
        RoundClass round = new RoundClass();
        public HostForm(MainForm? parrentForm)
        {
            this.mainForm = parrentForm;
            InitializeComponent();
            HostGame();

        }
        private async void HostGame()
        {
            if (mainForm.manageUser == null || mainForm.manageUser.User == null) return;
            string ip = mainForm.manageUser.User.Ip;
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            var tcpListener = new TcpListener(tcpEndPoint);
            tcpListener.Start();


            // Задаем текст для Label
            ipLabel.Text = "Ваш айпи - " + mainForm.manageUser.User.Ip;


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
            var buffer = new byte[65536];
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
                    if(idClient == -1) return;
                    connectedUsers.Remove(connectedUsers[idClient]);
                    tcpClient.Close();
                    refresh_label();
                    break;
                }
                // Строка для хранения данных от клиента
                var data = new StringBuilder();

                try
                {
                    // Читаем данные из потока асинхронно
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));

                    // Десериализуем полученные данные в объект User
                    string jsonAnswer = Encoding.UTF8.GetString(buffer, 0, size);
                    try 
                    {
                        User AnwerUser = JsonConvert.DeserializeObject<User>(jsonAnswer);
                        if (AnwerUser.Name != null)
                        {
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
                                BroadcastMessage(connectedUsers.Count.ToString() + " count");
                            }
                            refresh_label();
                        }
                        
                    }
                    catch{  }; 
                    try
                    {
                        QuestionClass question = JsonConvert.DeserializeObject<QuestionClass>(jsonAnswer);
                        if(question.question != null) 
                        {
                            int idClient = connectedUsers.FindIndex(client => client.Client == tcpClient);
                            if (connectedUsers[idClient].isOtv)
                            {
                                question.isUsed = true;
                                BroadcastMessage(question);
                            }
                        }
                        
                    }
                    catch { };
                    List<string> parseReceivedMessage = Parse(jsonAnswer);
                    if(Consist(parseReceivedMessage, new List<string> {"+"}))
                    {
                        BroadcastMessage("afesersrhrd");
                    }
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
            playersListLabes.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                // Отображаем информацию о клиенте на форме
                playersListLabes.Text = s;
            });
        }

        private async void buttonSendMessage_Click(object sender, EventArgs e)
        {
            if (connectedUsers.Count == 0) return;
            BroadcastMessage(MessageTextBox.Text);
        }

        private async void BroadcastMessage(string message)
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
        private async void BroadcastMessage(RoundClass message)
        {
            string json = JsonConvert.SerializeObject(message);
            byte[] data = Encoding.UTF8.GetBytes(json);

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
        private async void BroadcastMessage(QuestionClass message)
        {
            string json = JsonConvert.SerializeObject(message);
            byte[] data = Encoding.UTF8.GetBytes(json);

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
                    //await client.Client.GetStream().WriteAsync(data, 0, data.Length);
                }
                catch (Exception ex)
                {
                    playersListLabes.Text = "Ошибка при отправке данных";
                }
            }
            refresh_label();
        }
        private async void buttonStartGame_Click(object sender, EventArgs e)
        {
            BroadcastMessage("Start game");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            round.initRound(new StreamReader("C:\\Users\\busla\\OneDrive\\Рабочий стол\\gaam\\SGame\\SGame\\PackClass\\Data\\EconomicPack.txt", 
                Encoding.GetEncoding(1251)));
            //round.initRound(new StreamReader("C:\\Users\\busla\\source\\repos\\SIGame\\SGame\\SGame\\PackClass\\Data\\TestFileQuestionRead.txt",
            //    Encoding.GetEncoding(1251)));
            BroadcastMessage(round);
        }
    }
}
