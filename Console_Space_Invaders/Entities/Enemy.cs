using System.Numerics;
using Console_Space_Invaders.Image;

namespace Console_Space_Invaders.Entities
{
    public class Enemy : Entity
    {
        public Enemy(Vector2 position)
        {
            id = 2;
            image = new Chunk("█▄▄    ▀▀");
            health = 3;
            speed = 1;
            this.position = position;
        }
        public Enemy(int x, int y)
        {
            id = 2;
            image = new Chunk("█▄▄    ▀▀");
            health = 3;
            speed = 1;
            position = new Vector2(x, y);
        }

        public override void Update()
        {
            
        }
    }
}
