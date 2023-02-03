using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Console_Space_Invaders.Entities
{
    public class Projectile
    {
        public Vector2 position;
        public Vector2 direction;
        public float speed;

        char image = '\u0027';
        char image2 = '\u0022';

        private int lastX, lastY;

        private delegate void Del();
        private Del ImpactEvents;

        public Projectile(Vector2 position, Vector2 direction, float speed) 
        {
            this.position = position;
            this.direction = direction;
            this.speed = speed;

            lastX = (int)Math.Floor(this.position.X);
            lastY = (int)Math.Floor(this.position.Y);
        }
        public void AddImpactEvent(Entity entity, Action action)
        {
            void CheckImpact(){if (position == entity.position) { action(); } };
            ImpactEvents += CheckImpact;
        }

        public void Travel()
        {
            position.X += direction.X * speed;
            position.Y += direction.Y * speed;

            ImpactEvents();
        }
        public void Draw()
        {
            int x = (int)Math.Floor(position.X);
            int y = (int)Math.Floor(position.Y);
            if (x != lastX && y != lastY)
            {
                Console.SetCursorPosition(lastX, lastY);
                Console.Write(ScreenWriter.mapData[lastX][lastY]);
                Console.SetCursorPosition(x, y);
                Console.Write(image);
            }
        }
    }
}
