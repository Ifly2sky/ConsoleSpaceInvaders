using ConsoleExtra;
using System.Diagnostics;
using System.Numerics;
using Console_Space_Invaders.Image;

namespace Console_Space_Invaders.Entities
{
    public class Player : Entity
    {
        //all projectiles
        public List<Projectile> projectiles = new();

        //cooldown for shooting
        Stopwatch bulletTimer = new Stopwatch();
        const long bulletTime = 1000;

        //travel speed of projectiles
        int projectileSpeed = 6;

        public Player()
        {
            image = new Chunk("█▄▄‾");
            speed= 0.5f;
            position = new(5, 5);
            bulletTimer.Start();
        }
        public void SetPosition(float x, float y)
        {
            position = new Vector2(x, y);
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

        public void Shoot() //called by keyhandler. adds a new projectile to list and restarts cooldown
        {
            if (bulletTimer.ElapsedMilliseconds >= bulletTime)
            {
                projectiles.Add(new Projectile(new(position.X, position.Y - 1), new(0, -1), projectileSpeed));
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
