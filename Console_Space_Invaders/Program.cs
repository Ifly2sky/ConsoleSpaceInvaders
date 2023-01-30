using Console_Space_Invaders.Entities;
using System.Data;
using ConsoleExtra;

namespace Console_Space_Invaders
{
    internal class Program
    {
        static Thread gameThread = new Thread(new ThreadStart(Update));
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            OnLoad();
            gameThread.Start();
        }

        public static void OnLoad()
        {
            Canvas canvas = new(@"");
            canvas.LoadCanvas("map.txt");

            short fontSize = 16;

            ConsoleFont.SetFontSize(fontSize);
            Console.SetWindowSize(canvas.mapData[0].Length, canvas.mapData.Length);
            ConsoleWindow.RemoveConsoleResize();

            ScreenWriter screenWriter = new();
            Player player = new Player();
            screenWriter.SetEntities(player);
        }
        public static void Update()
        {
            while (gameThread.IsAlive)
            {
                
            }
        }
    }
}