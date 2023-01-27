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
        public int id;
        public char[] image;

        public Vector2 position;
        public float speed;
        public int health;
        public Entity() { }

        public void Draw()
        {
            int entityPosX = (int)Math.Floor(position.X);
            int entityPosY = (int)Math.Floor(position.Y);
            Console.SetCursorPosition(entityPosX, entityPosY);
            Console.Write(image[0]);
            try
            {
                Console.SetCursorPosition(entityPosX - 1, entityPosY);
                Console.Write(image[1]);
                Console.SetCursorPosition(entityPosX + 1, entityPosY);
                Console.Write(image[2]);
                Console.SetCursorPosition(entityPosX, entityPosY + 1);
                Console.Write(image[3]);
                Console.SetCursorPosition(entityPosX, entityPosY - 1);
                Console.Write(image[4]);
                Console.SetCursorPosition(entityPosX - 1, entityPosY - 1);
                Console.Write(image[5]);
                Console.SetCursorPosition(entityPosX + 1, entityPosY - 1);
                Console.Write(image[6]);
                Console.SetCursorPosition(entityPosX - 1, entityPosY + 1);
                Console.Write(image[7]);
                Console.SetCursorPosition(entityPosX + 1, entityPosY + 1);
                Console.Write(image[8]);
            }
            catch (Exception) { }
        }
    }
}
