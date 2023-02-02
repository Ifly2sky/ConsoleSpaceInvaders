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
        string fileLocation;
        internal char[][] mapData = new char[12][];

        int[,] entityMap = new int[12,40];

        internal delegate void Del();
        internal Del? entityUpdater;
        internal Del? entityDrawer;
        internal List<Entity> entities = new List<Entity>();

        static Player player = new Player();
        KeyHandler keyHandler = new KeyHandler();

        internal ScreenWriter(string fileLocation)
        {
            this.fileLocation = fileLocation;
        }

        internal void SetEntities()
        {
            player.registerEntity(this);

            for(int i = 1; i < 15; i++)
            {
                Enemy newEnemy = new(i*5, 3);
                newEnemy.registerEntity(this);
            }

            foreach (var entity in entities)
            {
                entityUpdater += entity.Update;
            }
            foreach (var entity in entities)
            {
                entityDrawer += entity.Draw;
            }
        }
        internal void LoadCanvas(string file)
        {
            string[] map = File.ReadAllLines(fileLocation + file);
            mapData = new char[map.Length][];
            int row = 0;
            foreach (string line in map)
            {
                mapData[row] = line.ToCharArray();
                row++;
                Console.WriteLine(line);
            }
            entityMap = new int[mapData.GetLength(0) - 2, mapData[0].Length - 2];
            sw.Start();

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

        //gets deltatime
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

            deltatime = currentFrame - lastFrame;

            lastFrame = ts.TotalMilliseconds;
        }
    }
}
