using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Console_Space_Invaders.Entities
{
    public class Projectile
    {

        struct Impact
        {
            internal Entity entity { get; set; }
            internal Action action { get; set; }

            internal bool happened { get; set; }

            internal Impact(Entity entity, Action action)
            {
                this.entity = entity;
                this.action = action;
                this.happened = false;
            }
        }

        public Vector2 position;
        public Vector2 direction;
        public float speed;

        char image = '\u0027';
        //char image2 = '\u0022'; = "

        private int _lastX = 0, _lastY = 0;

        private delegate void Del();
        private Del ImpactEvents;

        List<Impact> impactEvents = new();

        public Projectile(Vector2 position, Vector2 direction, float speed) 
        {
            this.position = position;
            this.direction = direction;
            this.speed = speed;

            _lastX = (int)Math.Floor(this.position.X);
            _lastY = (int)Math.Floor(this.position.Y);
        }

        public void AddImpactEvent(Entity entity, Action action)
        {
            impactEvents.Add(new(entity, action));
        }

        void CheckEvents()
        {
            double thisPosX = Math.Floor(position.X);
            double thisPosY = Math.Floor(position.Y);

            foreach (Impact impact in impactEvents)
            {
                if (thisPosX == Math.Floor(impact.entity.position.X) && thisPosY == Math.Floor(impact.entity.position.Y))
                {
                    impact.action.Invoke();
                }
            }
        }

        public void Travel()
        {
            position.X += direction.X * speed * (float)Program.deltatime;
            position.Y += direction.Y * speed * (float)Program.deltatime;

            CheckEvents();
        }
        public void Draw()
        {
            int x = (int)Math.Floor(position.X);
            int y = (int)Math.Floor(position.Y);
            if (x != _lastX || y != _lastY)
            {
                Console.SetCursorPosition(_lastX, _lastY);
                Console.Write(' ');
                Console.SetCursorPosition(x, y);
                Console.Write(image);
            }
            _lastX = x;
            _lastY = y;
        }

        public void Delete()
        {
            Console.SetCursorPosition((int)Math.Floor(position.X), (int)Math.Floor(position.Y));
            Console.Write(' ');
        }
    }
}
