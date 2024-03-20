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

    RoundClass round;
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
    public GameForm(MainForm parentForm, IPEndPoint tcpEP, RoundClass Round)
    {
        tcpEndPoint = tcpEP;
        round = Round;
        mainForm = parentForm;
        Listener();
        //InitializeComponent(round);
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

            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, size);
            parseReceivedMessage = Parse(receivedMessage);
        }

        // Завершаем соединение и закрываем сокет
        tcpSocket.Close();
    }
}