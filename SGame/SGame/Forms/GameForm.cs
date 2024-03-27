using Newtonsoft.Json;
using SGame.AboutUser;
using SGame.PackClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SGame.Forms;

public partial class GameForm : Form
{
    IPEndPoint tcpEndPoint;
    MainForm mainForm;
    TcpClient tcpSocket;

    List<ConnectedUser> connectedUsersOwn = new List<ConnectedUser>();
    RoundClass round;
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
            else temp += otv[i];
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
    public GameForm(MainForm parentForm, IPEndPoint tcpEP, RoundClass Round)
    {
        tcpEndPoint = tcpEP;
        round = Round;
        mainForm = parentForm;


        InitializeComponent();
        Listener();
    }
    private void SendHost(QuestionClass message)
    {
        string json = JsonConvert.SerializeObject(message);
        byte[] data = Encoding.UTF8.GetBytes(json);
        tcpSocket.GetStream().WriteAsync(data, 0, data.Length);
    }
    private void SendHost(String str)
    {
        string json = JsonConvert.SerializeObject(str);
        byte[] data = Encoding.UTF8.GetBytes(json);
        tcpSocket.GetStream().WriteAsync(data, 0, data.Length);
    }
    private async void Listener()
    {
        tcpSocket = new TcpClient();
        await tcpSocket.ConnectAsync(tcpEndPoint);

        string json = JsonConvert.SerializeObject(mainForm.manageUser.User);

        // Преобразуем JSON-строку в массив байт
        var message = Encoding.UTF8.GetBytes(json);

        await tcpSocket.GetStream().WriteAsync(message, 0, message.Length);
        // Буфер для приема данных от сервера
        var buffer = new byte[65536];
        var size = 0;

        // Цикл для ожидания новых сообщений от сервера
        while (true)
        {
            var rreceivedMessage = new StringBuilder();
            try
            {
                do
                {
                    size = await tcpSocket.GetStream().ReadAsync(buffer, 0, buffer.Length);
                    rreceivedMessage.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (tcpSocket.Available > 0);

            }
            catch
            {
                break;
            }

            if (size == 0) break;
            string receivedMessage = rreceivedMessage.ToString();
            try
            {
                RoundClass rround = JsonConvert.DeserializeObject<RoundClass>(receivedMessage);
                if (rround != null && rround?.themeClasses.Count != 0)
                {
                    round = rround;
                    AddControlsToPanel();
                    continue;
                }

            }
            catch { };
            try
            {
                QuestionClass question = JsonConvert.DeserializeObject<QuestionClass>(receivedMessage);
                if (question != null)
                {
                    ChooseQuestionAsync(question);
                    continue;
                }
            }
            catch
            {
            };
            try
            {
                List<ConnectedUser> connectedUsers = JsonConvert.DeserializeObject<List<ConnectedUser>>(receivedMessage);
                if (connectedUsers != null && connectedUsers?.Count != 0)
                {
                    connectedUsersOwn = connectedUsers;
                    DisplayUser(connectedUsers);
                    cancellationTokenSource?.Cancel();
                    AddControlsToPanel();
                    continue;
                }
            }
            catch { };


        }

        // Завершаем соединение и закрываем сокет
        tcpSocket.Close();
    }
}