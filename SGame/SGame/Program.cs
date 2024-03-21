using SGame;

namespace SignGame
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
           
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
            SGame.PackClass.GamePackClass game = new SGame.PackClass.GamePackClass();
            game.initGame(new StreamReader("C:\\Users\\busla\\Desktop\\нирсэ\\SGame\\SGame\\PackClass\\Data\\EconomicPack.txt"));
        }
    }
}