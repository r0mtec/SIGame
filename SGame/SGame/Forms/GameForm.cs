using Newtonsoft.Json;
using SGame.AboutUser;
using SGame.PackClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SGame.Forms;

public partial class GameForm : Form
{
    private IPEndPoint tcpEndPoint;
    
    MainForm mainForm;
    private List<string> Parse(string otv)
    {
        List<string> words = new List<string>();
        string temp = "";
        for (int i = 0; i < otv.Length; i++)
        {
            if (otv[i] == ' ')
            {
                words.Add(temp);
                temp = "";
            }
            else temp += otv[i];
        }
        words.Add(temp);
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
    public GameForm(MainForm parentForm, IPEndPoint tcpEP)
    {
       
        InitializeComponent();
        tcpEndPoint = tcpEP;
        
        mainForm = parentForm;
        Listener();
    }
    private async void Listener()
    {

        // Создаем новый сокет для обмена данными
        var tcpSocket = new TcpClient();

        // Сериализуем объект пользователя в формат JSON
        string json = JsonConvert.SerializeObject(mainForm.manageUser.User);

        // Преобразуем JSON-строку в массив байт
        var message = Encoding.UTF8.GetBytes(json);

        // Асинхронное подключение к серверу
        await tcpSocket.ConnectAsync(tcpEndPoint);

        // Отправка данных на сервер
        await tcpSocket.GetStream().WriteAsync(message, 0, message.Length);

        // Буфер для приема данных от сервера
        var buffer = new byte[65536];
        var size = 0;

        // Цикл для ожидания новых сообщений от сервера
        while (true)
        {
            // Асинхронное чтение данных от сервера
            try
            {
                size = await tcpSocket.GetStream().ReadAsync(buffer, 0, buffer.Length);
            }
            catch
            {
                break;
            }

            if (size == 0) break;


            // Обработка полученных данных, вывод на форму
            List<string> parseReceivedMessage = null;
            RoundClass Round = null;

            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, size);
            try 
            { 
                Round = JsonConvert.DeserializeObject<RoundClass>(receivedMessage); 
            }
            catch (Exception ex) 
            {
                parseReceivedMessage = Parse(receivedMessage);
            }

            if (Round != null)
            {
                int width = Width, height = Height;
                int numberOfTheme = 0;
                foreach (var theme in Round.questionClasses)
                {
                    Label label = new Label();
                    label.Name = "Theme" + numberOfTheme.ToString();
                    label.Location = new Point(0, numberOfTheme * height / Round.questionClasses.Count);
                    label.Size = new Size(100, height / Round.questionClasses.Count);
                    label.Text = theme.themeName;
                    label.BackColor = Color.DarkBlue;
                    label.Padding = new Padding(6);
                    label.Font = new Font("French Script MT", 18);
                    this.Controls.Add(label);

                    int numberOfQuestion = 0;
                    foreach (var question in theme.questionClasses)
                    {
                        Button button = new Button();
                        button.Name = "Button" + numberOfTheme.ToString() + numberOfQuestion.ToString();
                        button.Location = new Point(100 + numberOfQuestion * (width - 100) / theme.questionClasses.Count, 
                            numberOfTheme * height / Round.questionClasses.Count);
                        label.Size = new Size((width - 100) / theme.questionClasses.Count, height / Round.questionClasses.Count);
                        button.Text = question.question;
                        button.BackColor = Color.LightBlue;
                        button.Padding = new Padding(6);
                        button.Font = new Font("French Script MT", 18);
                        this.Controls.Add(button);

                        numberOfQuestion++;
                    }

                    numberOfTheme++;
                }
            }

            else if (Consist(parseReceivedMessage, new List<string> { "Start", "game" }))
            {
                mainForm.ChangeForm(new GameForm(mainForm, tcpEndPoint));
            }
            else if (receivedMessage == "Прибавить всем баллы")
            {
                mainForm.manageUser.User.ChangeScores(5);
                json = JsonConvert.SerializeObject(mainForm.manageUser.User);
                message = Encoding.UTF8.GetBytes(json);
                await tcpSocket.GetStream().WriteAsync(message, 0, message.Length);

            }
            else
            {
            }
        }

        // Завершаем соединение и закрываем сокет
        tcpSocket.Close();
    }

}
