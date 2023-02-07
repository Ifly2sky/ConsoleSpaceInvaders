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
        public List<Projectile> projectiles = new();

        Stopwatch bulletTimer = new Stopwatch();
        const long bulletTime = 1000;

        public Player()
        {
            id = 1;
            image = new Chunk("█▄▄‾");
            health= 3;
            speed= 0.5f;
            position = new(5, 5);
            bulletTimer.Start();
        }

        public Player(Vector2 startPosition, float speed, int health, string image) 
        {
            id = 1;
            this.image = new Chunk(image);
            this.health = health;
            this.speed = speed;
            position = startPosition;

            bulletTimer.Start();
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
            Debug.WriteLine(health);
        }

        public override void Update()
        {
            for(int projectile = 0; projectile < projectiles.Count; projectile++)
            {
                Projectile proj = projectiles[projectile];

                proj.Travel();
                proj.Draw();
                if (proj.position.Y <= 2)
                {
                    projectiles.Remove(proj);
                    proj.Delete();
                }
            }
        }

        public void MoveLeft()
        {
            if (position.X - speed * (float)Program.deltatime >= 2) 
            {
                position.X -= speed;
            }
        }
        public void MoveRight()
        {
            if (position.X + speed * (float)Program.deltatime <= ScreenWriter.entityMap.GetLength(1)-1)
            {
                position.X += speed;
            }
        }

        public void Shoot()
        {
            if (bulletTimer.ElapsedMilliseconds >= bulletTime)
            {
                projectiles.Add(new Projectile(new(position.X, position.Y - 1), new(0, -1), 4));
                bulletTimer.Restart();     
            }
        }

        public override void Draw()
        {
            ConsoleFont.SetForegroundColor(200, 200, 255);
            base.Draw();
            ConsoleFont.SetForegroundColor(255, 255, 255);
        }
    }
}
