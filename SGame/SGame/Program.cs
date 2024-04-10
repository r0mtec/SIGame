using SGame;
using SGame.PackClass;

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
            Application.Run(new SIGame());
            SGame.PackClass.GamePackClass game = new SGame.PackClass.GamePackClass();
            //game.initGame(new StreamReader("C:\\Users\\busla\\Desktop\\íèðñý\\SGame\\SGame\\PackClass\\Data\\EconomicPack.txt"));
        }
    }
}