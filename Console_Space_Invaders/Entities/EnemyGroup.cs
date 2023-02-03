using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Console_Space_Invaders.Entities
{
    internal class EnemyGroup
    {
        internal List<Enemy> enemies = new List<Enemy>();

        private string direction = "left";

        internal void AddEnemy(Enemy enemy)
        {
            enemies.Add(enemy);
        }

        internal void OnUpdate()
        {
            switch (direction)
            {
                case "left":
                    foreach (Enemy enemy in enemies)
                    {
                        enemy.position.X += (float)(enemy.speed * Program.deltatime);
                    }
                    if (enemies[ScreenWriter.enemyCols-1].position.X >= ScreenWriter.entityMap.GetLength(1)-1)
                    {
                        foreach (Enemy enemy in enemies)
                        {
                            enemy.position.Y += 2;
                            direction = "right";
                        }
                    }
                    break;
                case "right":
                    foreach (Enemy enemy in enemies) 
                    { 
                        enemy.position.X -= (float)(enemy.speed * Program.deltatime); 
                    }
                    if (enemies[0].position.X <= 4)
                    {
                        foreach (Enemy enemy in enemies)
                        {
                            enemy.position.Y += 2;
                            direction = "left";
                        }
                    }
                    break;
            }
        }
    }
}
