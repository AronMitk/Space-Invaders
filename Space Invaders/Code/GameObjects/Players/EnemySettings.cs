using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders.Code.GameObjects.Players
{
    public class EnemySettings
    {
        bool toRight = true;
        int defaultCollisions = 1;
        int collisions = 1;

        public void MoveToSides(List<Enemy> enemies, UIOperations canvas)
        {
            int Max = enemies.Max(x => x.X + x.Width);
            int Min = enemies.Min(x => x.X);

            if (toRight && Max >= canvas.GetCanvasSize()[0])
            {
                toRight = false;
                collisions--;
            }
            else if (!toRight && Min <= 0)
            {
                toRight = true;
                collisions--;
            }

            foreach (var i in enemies)
            {
                if (toRight)
                {
                    i.MoveRight();
                    canvas.SetPosition(i);
                }
                else
                {
                    i.MoveLeft();
                    canvas.SetPosition(i);
                }
            }

        }

        public void ModeDown(List<Enemy> enemies, UIOperations canvas)
        {
            if (collisions == 0)
            {
                foreach (var i in enemies)
                {
                    i.MoveDown();
                    canvas.SetPosition(i);
                }
                collisions = defaultCollisions;
            }
        }

        public bool PlayerInteracs(Player player, List<Enemy> enemies)
        {
            foreach (var i in enemies)
                if (player.IntersectsWith(i)) return true;

            return false;
        }
    }
}
