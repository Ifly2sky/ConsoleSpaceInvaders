using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Console_Space_Invaders.Image;

namespace Console_Space_Invaders.Entities
{
    public abstract class Entity
    {
        public struct EntityColor
        {
            public int r, g, b;

            public EntityColor(int r, int g, int b)
            {
                this.r = r;
                this.g = g;
                this.b = b;
            }
        }

        public int id;
        public Chunk image = new Chunk("");

        public Vector2 position;
        public float speed;
        public int health;

        int _lastX, _lastY;
        /// <summary>
        /// draws images and clears last image
        /// </summary>
        public virtual void Draw()
        {
            int entityPosX = (int)Math.Floor(position.X);
            int entityPosY = (int)Math.Floor(position.Y);

            if(entityPosX != _lastX || entityPosY != _lastY)
            {
                try 
                { 
                    Clear(); 
                }catch(Exception) { }

                foreach (Block block in image.blocks)
                {
                    if (block.character != ' ' )//|| block.character != null)
                    {
                        Console.SetCursorPosition(entityPosX + block.x, entityPosY + block.y);
                        Console.Write(block.character);
                    }
                }
            }

            _lastX = entityPosX;
            _lastY = entityPosY;
        }
        public void Clear()
        {
            foreach (Block block in image.blocks)
            {
                if (block.character != ' ' )//|| block.character != null)
                {
                    Console.SetCursorPosition(_lastX + block.x, _lastY + block.y);
                    Console.Write(' ');
                }
            }
        }

        internal void RegisterEntity(ScreenWriter writer)
        {
            writer.entities.Add(this);
        }
        internal void UnregisterEntity(ScreenWriter writer)
        {
            writer.entities.Remove(this);
        }

        public abstract void Update();
    }
}
