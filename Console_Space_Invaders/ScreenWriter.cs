using Console_Space_Invaders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Space_Invaders
{
    internal class ScreenWriter
    {
        int[,] map = new int[11, 39];

        internal void SetEntities(Player player, Enemy enemy)
        {
            player.Draw();
            enemy.Draw();
        }
        internal void UpdateScreen()
        {
            
        }
    }
}
