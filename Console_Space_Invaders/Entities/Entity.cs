using System.Numerics;
using Console_Space_Invaders.Image;

namespace Console_Space_Invaders.Entities
{
    public abstract class Entity
    {
        public struct EntityColor // color of entitites
        {
            public int r, g, b;

            public EntityColor(int r, int g, int b)
            {
                this.r = r;
                this.g = g;
                this.b = b;
            }
        }

        public Chunk image = new Chunk("");

        public Vector2 position;
        public float speed;

        int _lastX, _lastY;//last position on screen
        /// <summary>
        /// draws images and clears last image
        /// </summary>
        public virtual void Draw()//draw new entity image
        {
            //math.floor allows turning float coordinates into console positions
            int entityPosX = (int)Math.Floor(position.X);
            int entityPosY = (int)Math.Floor(position.Y);

            if(entityPosX != _lastX || entityPosY != _lastY) // only draws new frame if something has moved
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
        public void Clear()//remove current entity image
        {
            foreach (Block block in image.blocks)
            {
                if (block.character != ' ' )
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

        public abstract void Update();//update for all entities
    }
}
