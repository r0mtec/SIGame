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
    TcpClient tcpSocket;
    MainForm mainForm;
    List<ConnectedUser> connectedUsers = new List<ConnectedUser>();
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
    public GameForm(MainForm parentForm, TcpClient tcpCl, RoundClass Round)
    {
        tcpSocket = tcpCl;
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
            //List<string> parseReceivedMessage = null;
            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, size);
            try
            {
                QuestionClass question = JsonConvert.DeserializeObject<QuestionClass>(receivedMessage);
                ChooseQuestion(question);
            }
            catch
            {
            };
            try
            {
                List<ConnectedUser> connectedUsers = JsonConvert.DeserializeObject<List<ConnectedUser>>(receivedMessage);
                if (connectedUsers?.Count != 0)
                {
                    DisplayUser(connectedUsers);
                }
                AddControlsToPanel();
            }
            catch { };

        }

        // Завершаем соединение и закрываем сокет
        tcpSocket.Close();
    }

}