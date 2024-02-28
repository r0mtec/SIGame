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
    /// Метод инициализации полей объекта-класса пользователя
    /// </summary>
    /// <param name="name">Никнейм</param>
    /// <param name="scores">Очки</param>
    public void Init(string name, int scores) 
    {
        Name = name;
        Scores = scores;
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
