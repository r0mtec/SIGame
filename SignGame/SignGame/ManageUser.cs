namespace SignGame
{
    public class ManageUser
    {
        /// <summary>
        /// Класс сущность
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Инициализация пользователя
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="scores">Очки</param>
        public void Init(string name, int scores)
        {
            User = new User();
            User.Init(name, scores);
        }
    }
}
