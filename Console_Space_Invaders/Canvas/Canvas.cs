using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Space_Invaders
{
    internal class Canvas
    {
        string fileLocation;
        internal Canvas(string fileLocation)
        {
            this.fileLocation = fileLocation;
        }

        public void LoadCanvas(string file)
        {
            string map = File.ReadAllText(fileLocation + file);
            Console.Write(map);
        }
    }
}
