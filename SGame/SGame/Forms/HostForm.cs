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
using System.Threading;
using System.Reflection.Emit;
using SignGame;

namespace SGame.Forms
{
    public partial class HostForm : Form
    {
        TcpListener tcpListener;
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
        private SIGame? mainForm;
        RoundClass round = new RoundClass();
        private int numberRound = 0;
        bool roundStart = false;
        SGame.PackClass.GamePackClass game = new SGame.PackClass.GamePackClass();
        public HostForm(SIGame? parrentForm)
        {
            this.mainForm = parrentForm;
            InitializeComponent();
            HostGame();

        }
        private async void HostGame()
        {
            if (mainForm?.manageUser == null || mainForm.manageUser.User == null) return;
            string ip = mainForm.manageUser.User.Ip;
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            tcpListener = new TcpListener(tcpEndPoint);
            tcpListener.Start();


            // Задаем текст для Label
            ipLabel.Text = "Ваш IP-адрес: " + mainForm.manageUser.User.Ip;


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
                    if (idClient == -1) return;
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
                        if (AnwerUser?.Name != null)
                        {
                            // Поиск пользователя в списке
                            int index = connectedUsers.FindIndex(client => client.Client == tcpClient);

                            if (index != -1)
                            {
                                // Элемент найден, изменяем его
                                connectedUsers[index].User = AnwerUser;
                                BroadcastMessage(connectedUsers);

                            }
                            else
                            {
                                connectedUsers.Add(new ConnectedUser(tcpClient, AnwerUser));
                                if (!roundStart)
                                {
                                    BroadcastMessage(connectedUsers.Count.ToString() + " count");
                                }
                                else
                                {
                                    BroadcastMessage(connectedUsers);
                                }
                            }
                            refresh_label();
                        }

                    }
                    catch { };
                    try
                    {
                        QuestionClass question = JsonConvert.DeserializeObject<QuestionClass>(jsonAnswer);
                        if (question?.question != null)
                        {
                            int idClient = connectedUsers.FindIndex(client => client.Client == tcpClient);
                            if (connectedUsers[idClient].isOtv)
                            {
                                foreach (ThemesClass theme in round.themeClasses)
                                {
                                    foreach (var question1 in theme.questionClasses)
                                    {
                                        if (question.question == question1.question)
                                        {
                                            question1.isUsed = true;
                                            break;
                                        }
                                    }
                                }
                                connectedUsers[idClient].isOtv = false;
                                BroadcastMessage(question);
                            }
                        }

                    }
                    catch { };
                    List<string> parseReceivedMessage = Parse(jsonAnswer);
                    if (Consist(parseReceivedMessage, new List<string> { "+", "all" }))
                    {
                        Random random = new Random();
                        connectedUsers[random.Next(connectedUsers.Count)].isOtv = true;
                        BroadcastMessage(connectedUsers);
                        checkAsync();
                    }
                    else if (Consist(parseReceivedMessage, new List<string> { "+" }))
                    {
                        int idClient = connectedUsers.FindIndex(client => client.Client == tcpClient);
                        connectedUsers[idClient].isOtv = true;
                        connectedUsers[idClient].User.Scores += Int32.Parse(parseReceivedMessage[1]);
                        BroadcastMessage(connectedUsers);
                        checkAsync();
                    }
                    else if (Consist(parseReceivedMessage, new List<string> { "-" }))
                    {
                        int idClient = connectedUsers.FindIndex(client => client.Client == tcpClient);
                        connectedUsers[idClient].User.Scores -= Int32.Parse(parseReceivedMessage[1]);
                    }

                }
                catch (Exception)
                {
                    // Обработка и вывод ошибок в текстовое поле
                }
            }
        }
        private void refresh_label()
        {
            string s = "Счет игроков: \n";
            int count = 1;
            foreach (ConnectedUser client in connectedUsers)
            {
                if (client.User == null) s += "Анонимус - -1 ";
                else s += count + ") " + client.User.Name + " - " + client.User.Scores + "\n";
            }
            // Обновляем пользовательский интерфейс (UI) с использованием делегата и метода Invoke
            playersListLabes.Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                // Отображаем информацию о клиенте на форме
                playersListLabes.Text = s;
            });
        }
        async void NextRound()
        {
            if(numberRound == game.roundClasses.Count) 
            {
                BroadcastMessage("end");
                foreach(ConnectedUser client in connectedUsers) 
                {
                    client.Client?.Close();
                }
                tcpListener.Stop();
                mainForm?.ChangeForm(new ChoseGameForm(mainForm));
            }
            else
            {
                await Task.Delay(200);
                round = game.roundClasses[numberRound];
                BroadcastMessage(round);
                await Task.Delay(200);
                BroadcastMessage(connectedUsers);
                await Task.Delay(200);
                numberRound++;
            }
            
        }
        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            if (connectedUsers.Count == 0) return;
            if (MessageTextBox.Text == "skip")
            {
                NextRound();
            }
            else BroadcastMessage(MessageTextBox.Text);
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
                catch (Exception)
                {

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
                catch (Exception)
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
                    await client.Client.GetStream().WriteAsync(data);
                    //await client.Client.GetStream().WriteAsync(data, 0, data.Length);
                }
                catch (Exception)
                {
                    playersListLabes.Text = "Ошибка при отправке данных";
                }
            }
            refresh_label();
        }
        private async void BroadcastMessage(List<ConnectedUser> message)
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
                catch (Exception)
                {
                    playersListLabes.Text = "Ошибка при отправке данных";
                }
            }
            refresh_label();
        }
        private async void checkAsync()
        {
            bool next = true;
            foreach (ThemesClass theme in round.themeClasses)
            {
                foreach (var question1 in theme.questionClasses)
                {
                    if (!question1.isUsed)
                    {
                        next = false;
                    }
                }
            }
            if (next)
            {
                if (numberRound >= game.roundClasses.Count) return;
                NextRound();
            }
        }
        private async void buttonStartGame_ClickAsync(object sender, EventArgs e)
        {
            BroadcastMessage("Start game");

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\Users";
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    game.initGame(reader);
                }
            }
            else return;
            roundStart = true;
            round = game.roundClasses[numberRound];
            numberRound++;
            BroadcastMessage(round);
            while (connectedUsers.Count != 0)
            {
                connectedUsers.RemoveAt(0);
            }
            await Task.Delay(300);
            Random random = new Random();
            connectedUsers[random.Next(connectedUsers.Count)].isOtv = true;
            BroadcastMessage(connectedUsers);

        }

        
    }
}
