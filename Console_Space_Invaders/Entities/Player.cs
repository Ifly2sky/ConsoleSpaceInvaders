using ConsoleExtra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            image = new Chunk("█▄▄‾");
            health= 3;
            speed= 0.1;
            position = new(17, 17);
        }

        public Player(Vector2 startPosition, float speed, int health, string image) 
        {
            id = 1;
            this.image = new Chunk(image);
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

        public override void Update()
        {
            
        }

        public void MoveLeft()
        {
            if (position.X - speed * Program.deltatime >= 2) 
            {
                position.X -= (float)(speed * Program.deltatime);
            }
        }
        public void MoveRight()
        {
            if (position.X + speed * Program.deltatime <= 76)
            {
                position.X += (float)(speed * Program.deltatime);
            }
        }
    }
}
