using System.Drawing;
using System.Numerics;
using Console_Space_Invaders.Image;
using ConsoleExtra;

namespace Console_Space_Invaders.Entities
{
    public class Enemy : Entity
    {
        ScreenWriter screenWriter;
        EntityColor color;

        internal Enemy(Vector2 position, ScreenWriter screenWriter)
        {
            id = 2;
            image = new Chunk("█▄▄    ▀▀");
            health = 3;
            speed = 1;
            this.position = position;

            this.screenWriter = screenWriter;
        }
        internal Enemy(int x, int y, ScreenWriter screenWriter)
        {
            id = 2;
            image = new Chunk("█▄▄    ▀▀");
            health = 3;
            speed = 1;
            position = new Vector2(x, y);

            this.screenWriter = screenWriter;
        }
        internal Enemy(Vector2 position, EntityColor color, ScreenWriter screenWriter)
        {
            id = 2;
            image = new Chunk("█▄▄    ▀▀");
            health = 3;
            speed = 1;
            this.position = position;
            this.color = color;

            this.screenWriter = screenWriter;
        }
        internal Enemy(int x, int y, EntityColor color, ScreenWriter screenWriter)
        {
            id = 2;
            image = new Chunk("█▄▄    ▀▀");
            health = 3;
            speed = 1;
            position = new Vector2(x, y);
            this.color = color;

            this.screenWriter = screenWriter;
        }


        public override void Update()
        {
            for (int projectileNum = 0; projectileNum < ScreenWriter.player.projectiles.Count-1; projectileNum++)
            {
                Projectile proj = ScreenWriter.player.projectiles[projectileNum];

                double projPosX = Math.Floor(proj.position.X);
                double projPosY = Math.Floor(proj.position.Y);

                double thisPosX = Math.Floor(position.X);
                double thisPosY = Math.Floor(position.Y);

                if (proj != null && thisPosX-1 <= projPosX && projPosX <= thisPosX+1 && thisPosY-1 <= projPosY && projPosY <= thisPosY + 1)
                {
                    this.Clear();
                    UnregisterEntity(screenWriter);
                    screenWriter.entityDrawer -= Draw;
                    screenWriter.entityUpdater -= Update;

                    proj.Delete();
                    ScreenWriter.player.projectiles.Remove(proj);
                }
            }
        }

        public override void Draw()
        {
            ConsoleFont.SetForegroundColor(color.r, color.g, color.b);
            base.Draw();
            ConsoleFont.SetForegroundColor(255, 255, 255);
        }
    }
}
