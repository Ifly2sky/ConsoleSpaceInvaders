using ConsoleExtra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Console_Space_Invaders.Image;

namespace Console_Space_Invaders.Entities
{
    
    public class Player : Entity
    {
        Projectile projectile;

        public Player()
        {
            id = 1;
            image = new Chunk("█▄▄‾");
            health= 3;
            speed= 75;
            position = new(5, 5);

            projectile = new Projectile(new(position.X, position.Y+2), new(0,1), 10);
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
            if (position.X + speed * Program.deltatime <= ScreenWriter.entityMap.GetLength(1))
            {
                position.X += (float)(speed * Program.deltatime);
            }
        }
    }
}
