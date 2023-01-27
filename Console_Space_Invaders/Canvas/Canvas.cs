using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Console_Space_Invaders
{
    internal class Canvas
    {
        string fileLocation;
        /// <summary>
        /// mapData is a jagged array
        /// </summary>
        public char[][] mapData = new char[12][];
        internal Canvas(string fileLocation)
        {
            this.fileLocation = fileLocation;
        }

        public void LoadCanvas(string file)
        {
            string[] map = File.ReadAllLines(fileLocation + file);
            mapData = new char[map.Length][];
            int row = 0;
            foreach(string line in map)
            {
                mapData[row] = line.ToCharArray();
                row++;
                Console.WriteLine(line);
            }
        }
    }
}
