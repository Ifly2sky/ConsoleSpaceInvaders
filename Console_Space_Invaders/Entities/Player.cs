using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Console_Space_Invaders.Entities
{
    public class Player : Entity
    {
        public Player()
        {
            id = 1;
            image = "▄█▄ ‾";
        }
        public Player(Vector2 startPosition, float speed, int health) 
        {
            id = 1;
            image = "▄█▄ ‾";
            this.health = health;
            this.speed = speed;
            position = startPosition;
        }
        public void SetPosition(Vector2 pos)
        {
            position = pos;
        }
        public void SetPosition(float x, float y)
        {
            position = new Vector2(x, y);
        }
        public void SetSpeed(int speed)
        {
            this.speed = speed;
        }
        public void Damage()
        {
            health -= 1;
        }
    }
}
