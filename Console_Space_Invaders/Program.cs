using Console_Space_Invaders.Entities;
using System.Data;

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
            Canvas canvas = new(@"C:\Users\gr275809\source\repos\C# Tehtävät\muut\Console_Space_Invaders\Console_Space_Invaders\Canvas\");
            canvas.LoadCanvas("map.txt");
            ScreenWriter screenWriter = new();
            screenWriter.SetEntities(canvas);

            Player player = new Player();
        }
        public static void Update()
        {
            while (gameThread.IsAlive)
            {

            }
        }
    }
}