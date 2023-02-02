using System.Numerics;

namespace Console_Space_Invaders.Entities
{
    public class Enemy : Entity
    {
        string direction = "left";

        public Enemy(Vector2 position)
        {
            id = 2;
            image = new Chunk("█▄▄    ▀▀");
            health = 3;
            speed = 0.001;
            this.position = position;
        }
        public Enemy(int x, int y)
        {
            id = 2;
            image = new Chunk("█▄▄    ▀▀");
            health = 3;
            speed = 0.001;
            position = new Vector2(x, y);
        }

        public override void Update()
        {
            switch (direction)
            {
                case "left":
                    position.X += (float)(speed * Program.deltatime / 1000);
                    if (position.X <= 70)
                    {
                        direction = "down";
                    }
                    break;
                case "down":
                    position.Y += 2;
                    direction = "right";
                    break;
                case "right":
                    position.X -= (float)(speed * Program.deltatime / 1000);
                    if (position.X < 1)
                    {
                        position.Y += 2;
                        direction = "left";
                    }
                    break;
            }
        }
    }
}
