using Console_Space_Invaders.Entities;
using System.Data;
using ConsoleExtra;
using System.Diagnostics;

namespace Console_Space_Invaders
{
    internal class Program
    {
        static Thread gameThread = new Thread(new ThreadStart(Update));
        static ScreenWriter screenWriter = new("");

        static readonly short fontSize = 16;
        public static double deltatime;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            OnLoad();
            gameThread.Start();
        }

        public static void OnLoad()
        {
            ConsoleFont.SetForegroundColor(255, 255, 255);

            screenWriter.LoadCanvas("map.txt");

            ConsoleFont.SetFontSize(fontSize);
            Console.SetWindowSize(screenWriter.mapData[0].Length, screenWriter.mapData.Length);
            ConsoleWindow.RemoveConsoleResize();

            screenWriter.SetEntities();
        }
        public static void Update()
        {
            Console.CursorVisible = false;
            Stopwatch stopWatch = Stopwatch.StartNew();

            while (gameThread.IsAlive)
            {
                Console.SetCursorPosition(0, 0);

                if (screenWriter.entities.Count != 0)
                {
                    screenWriter.entityUpdater();
                    screenWriter.entityDrawer();
                }
                screenWriter.countFPS();
                screenWriter.GetDeltaTime(out deltatime, stopWatch);

                Thread.Sleep(1);
            }
        }
    }
}