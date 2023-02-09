using Console_Space_Invaders.Entities;
using ConsoleExtra;
using System.Diagnostics;

namespace Console_Space_Invaders
{
    internal class ScreenWriter //writes on the screen
    {
        public const int enemyRows = 4;
        public const int enemyCols = 12;
        public const int spacing = 3; // amount of rows inbetween enemies


        string fileLocation;

        internal static char[][] mapData = new char[12][];//map imformation

        public static int[,] entityMap = new int[12,40];// entity information

        //entity updaters and drawers
        internal delegate void Del();
        internal Del? entityUpdater; // contains all functions for updating
        internal Del? entityDrawer; // contains all functions for drawing

        //entities list, player and enemygroup
        public static Player player = new Player();
        internal List<Entity> entities = new List<Entity>(); 
        public static EnemyGroup enemyGroup = new EnemyGroup(); 

        //handles buttom presses independetly from main loop
        KeyHandler keyHandler = new KeyHandler();

        Stopwatch sw = new(); //stopwatch for fps calculation

        internal ScreenWriter(string fileLocation)
        {
            this.fileLocation = fileLocation;
        }

        Random randomColor = new Random();
        internal void SetEntities() //sets all entities
        {
            player.RegisterEntity(this);
            player.SetPosition(2, mapData.Length - 3);

            Entity.EntityColor color = new(randomColor.Next(255), randomColor.Next(255), randomColor.Next(255));

            int row = 2;
            int cols = enemyCols+1;
            for (int col = 1; col < cols; col++)//adds enemies for every row and column
            {
                Enemy newEnemy = new(col*5, row, color, this);
                newEnemy.RegisterEntity(this);
                if(col >= cols-1 && row <= (enemyRows-1)*spacing)
                {
                    col = 0;
                    row += spacing;
                    color = new(randomColor.Next(255), randomColor.Next(255), randomColor.Next(255));//enemy color is random based on the row it is on
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

            //sets movement 
            keyHandler.ListenToKey(ConsoleKey.Spacebar, player.Shoot);
            keyHandler.ListenToKey(ConsoleKey.D, player.MoveRight);
            keyHandler.ListenToKey(ConsoleKey.A, player.MoveLeft);
        }
        internal void Load(string file) //loads a map from a file and loads game
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

        }

        int _frames = 0;
        int fps = 0;

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
                ConsoleFont.SetForegroundColor(255, 255, 255);
                ConsoleFont.SetBackgroundColor(0, 0, 0);

                sw.Restart();
            }
            _frames++;
        }

        double lastFrame; // time before updates
        TimeSpan timeSpan; // timespan fordeltatime
        public void GetDeltaTime(out double deltatime, Stopwatch stopWatch) //gets deltatime
        {
            if (stopWatch.ElapsedMilliseconds > 500)
            {
                timeSpan = stopWatch.Elapsed;
            }
            else
            {
                timeSpan = stopWatch.Elapsed;
            }

            double currentFrame = timeSpan.TotalMilliseconds;

            deltatime = (currentFrame - lastFrame)/1000;

            lastFrame = timeSpan.TotalMilliseconds;
        }
    }
}
