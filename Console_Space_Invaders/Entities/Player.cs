using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Console_Space_Invaders.Entities
{
    public class Player : Entity
    {
        public Player() 
        {
            Id = 1;
            image = "▄█▄ ‾☠";
        }
    }
}
