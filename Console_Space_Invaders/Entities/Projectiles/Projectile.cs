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
            internal Entity? Entity { get; set; }
            internal List<Entity>? EntityList { get; set; }
            internal Action Action { get; set; }

            internal bool Happened { get; set; }

            internal Impact(Entity entity, Action action)
            {
                this.Entity = entity;
                this.Action = action;
                this.Happened = false;
                this.EntityList = null;
            }
            internal Impact(List<Entity> entityList, Action action)
            {
                this.EntityList = entityList;
                this.Action = action;
                this.Happened = false;
                this.Entity = null;
            }
        }

        public Vector2 position;
        public Vector2 direction;
        public float speed;

        readonly Stopwatch iframes = new();

        readonly char image = '\u0027';
        //char image2 = '\u0022'; = "

        private int _lastX = 0, _lastY = 0;

        public Projectile(Vector2 position, Vector2 direction, float speed) 
        {
            this.position = position;
            this.direction = direction;
            this.speed = speed;

            _lastX = (int)Math.Floor(this.position.X);
            _lastY = (int)Math.Floor(this.position.Y);

            iframes.Start();
        }

        public void Travel()
        {
            position.X += direction.X * speed * (float)Program.deltatime;
            position.Y += direction.Y * speed * (float)Program.deltatime;

            //CheckEvents();
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
