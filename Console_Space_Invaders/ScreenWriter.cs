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
        internal Del entityUpdater;
        internal List<Entity> entities = new List<Entity>();

        static Player player = new Player();

        internal ScreenWriter(string fileLocation)
        {
            this.fileLocation = fileLocation;
        }

        internal void SetEntities()
        {
            player.registerEntity(this);
            foreach (var entity in entities)
            {
                entityUpdater += entity.Update;
            }
        }
        internal void Draw()
        {
            /*for (int h = 0; h <= entityMap.GetLength(0); h++)
            {
                for (int v = 0; v <= entityMap.GetLength(1); v++)
                {
                    Console.SetCursorPosition(v+1, h+1);
                }
            }*/
            player.Draw();
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
        }

        int _frames = 0;
        int fps = 0;

        Stopwatch sw = new();
        Random random = new Random();
        public void countFPS()
        {
            if (sw.ElapsedMilliseconds >= 1000)
            {
                fps = _frames;
                _frames = 0;
                sw.Restart();
            }
            Console.SetCursorPosition(0, 0);
            ConsoleFont.SetBackgroundColor(255, 255, 255);
            ConsoleFont.SetForegroundColor(random.Next(255), random.Next(255), random.Next(255));
            Console.Write(fps);
            ConsoleFont.SetForegroundColor(1);
            ConsoleFont.DefaultBackgroundColor();
            _frames++;
        }
    }
}
