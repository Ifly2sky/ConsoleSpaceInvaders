using Console_Space_Invaders.Entities;
using ConsoleExtra;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Space_Invaders
{
    internal class ScreenWriter
    {
        public const int enemyRows = 4;
        public const int enemyCols = 12;
        public const int spacing = 3;


        string fileLocation;
        internal static char[][] mapData = new char[12][];

        public static int[,] entityMap = new int[12,40];

        //entity updaters and drawers
        internal delegate void Del();
        internal Del? entityUpdater;
        internal Del? entityDrawer;

        //entities list, player and enemygroup
        internal List<Entity> entities = new List<Entity>();
        static Player player = new Player();
        static EnemyGroup enemyGroup = new EnemyGroup();

        //handles buttom presses independetly from main loop
        KeyHandler keyHandler = new KeyHandler();

        internal ScreenWriter(string fileLocation)
        {
            this.fileLocation = fileLocation;
        }

        //loads every entity
        internal void SetEntities() //sets all entities
        {
            player.registerEntity(this);
            player.SetPosition(2, mapData.Length - 3);

            int row = 2;
            int cols = enemyCols+1;
            for (int col = 1; col < cols; col++)//adds enemies for every row and column
            {
                Enemy newEnemy = new(col*5, row);
                newEnemy.registerEntity(this);
                if(col >= cols-1 && row <= (enemyRows-1)*spacing)
                {
                    col = 0;
                    row += spacing;
                }
            }

            foreach (var entity in entities)
            {
                entityUpdater += entity.Update;
            }
            foreach (var entity in entities)
            {
                entityDrawer += entity.Draw;
            }
            foreach(Enemy enemy in entities.OfType<Enemy>())
            {
                enemyGroup.AddEnemy(enemy);
            }

            entityUpdater += enemyGroup.OnUpdate;

        }
        internal void Load(string file) //loads a map from file and loads game
        {
            string[] map = File.ReadAllLines(fileLocation + file);
            mapData = new char[map.Length][];
            int row = 0;
            foreach (string line in map)//adds file lines to mapData array
            {
                mapData[row] = line.ToCharArray();
                row++;
                Console.WriteLine(line);
            }
            entityMap = new int[mapData.GetLength(0) - 2, mapData[0].Length - 2];//sets entity movement area

            sw.Start();//starts fps calculation timer

            //sets movement keys
            keyHandler.ListenToKey(ConsoleKey.D, player.MoveRight);
            keyHandler.ListenToKey(ConsoleKey.A, player.MoveLeft);
        }

        int _frames = 0;
        int fps = 0;

        Stopwatch sw = new();

        //counts frames and displays their count at every second
        public void countFPS()
        {
            if (sw.ElapsedMilliseconds >= 1000)
            {
                fps = _frames;
                _frames = 0;

                Console.SetCursorPosition(0, 0);
                ConsoleFont.SetBackgroundColor(255, 255, 255);
                ConsoleFont.SetForegroundColor(0, 0, 0);
                Console.Write(fps);
                ConsoleFont.SetForegroundColor(0);
                ConsoleFont.SetBackgroundColor(0);

                sw.Restart();
            }
            _frames++;
        }

        //gets deltatime, -TODO fix deltatime
        double lastFrame;
        TimeSpan ts;
        public void GetDeltaTime(out double deltatime, Stopwatch stopWatch)
        {
            if (stopWatch.ElapsedMilliseconds > 500)
            {
                ts = stopWatch.Elapsed;
            }
            else
            {
                ts = stopWatch.Elapsed;
            }

            double currentFrame = ts.TotalMilliseconds;

            deltatime = (currentFrame - lastFrame)/1000;

            lastFrame = ts.TotalMilliseconds;

            Console.SetCursorPosition(10, 0);
            Console.Write(deltatime);
        }
    }
}
