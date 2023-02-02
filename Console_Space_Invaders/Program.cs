using Console_Space_Invaders.Entities;
using System.Data;
using ConsoleExtra;

namespace Console_Space_Invaders
{
    internal class Program
    {
        static Thread gameThread = new Thread(new ThreadStart(Update));
        static ScreenWriter screenWriter = new("");

        static readonly short fontSize = 16;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            OnLoad();
            gameThread.Start();
        }

        public static void OnLoad()
        {
            ConsoleFont.SetForegroundColor(255, 255, 255);
            ConsoleFont.DefaultBackgroundColor();

            screenWriter.LoadCanvas("map.txt");

            ConsoleFont.SetFontSize(fontSize);
            Console.SetWindowSize(screenWriter.mapData[0].Length, screenWriter.mapData.Length);
            ConsoleWindow.RemoveConsoleResize();

            screenWriter.SetEntities();
        }
        public static void Update()
        {
            Console.CursorVisible = false;

            while (gameThread.IsAlive)
            {
                if (screenWriter.entities.Count != 0) 
                    screenWriter.entityUpdater();
                screenWriter.Draw();
                screenWriter.countFPS();
            }
        }
    }
}