using System.Net;
namespace SignGame;
public class User
{
    /// <summary>
    /// Никнейм пользователя
    /// </summary>
    public string? Name { get; private set; }
    /// <summary>
    /// Количество очков пользователя
    /// </summary>
    public int Scores { get; private set; }
    /// <summary>
    /// Айпи пользователя
    /// </summary>
    public string Ip { get; private set; }
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name">Никнейм</param>
    /// <param name="scores">Очки</param>
    public User(string name, int scores) 
    {
        Name = name;
        Scores = scores;
        Ip = Dns.GetHostAddresses(Dns.GetHostName())[4].ToString();
    }
    /// <summary>
    /// Изменение очков у пользователя
    /// </summary>
    /// <param name="change">Сумма изменения очков</param>
    public void ChangeScores(int change) 
    {
        Scores += change;
    }
}
