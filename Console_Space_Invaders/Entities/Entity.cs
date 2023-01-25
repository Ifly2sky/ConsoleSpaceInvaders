using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Console_Space_Invaders.Entities
{
    public abstract class Entity
    {
        public int Id;
        public string image;

        public Vector2 position;
        public int speed;
        public int health;
        public Entity() { }
    }
}
