using Console_Space_Invaders.Entities;
using System;
using System.Collections.Generic;
using System.Data;
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

        internal ScreenWriter(string fileLocation)
        {
            this.fileLocation = fileLocation;
        }

        internal void SetEntities()
        {
            foreach (var entity in entities)
            {
                entityUpdater += entity.Update;
            }
        }
        internal void Draw()
        {
            for (int h = 0; h <= entityMap.GetLength(0); h++)
            {
                for (int v = 0; v <= entityMap.GetLength(1); v++)
                {
                    Console.SetCursorPosition(v+1, h+1);
                }
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
        }
    }
}
