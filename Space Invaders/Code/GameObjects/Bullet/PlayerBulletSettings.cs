using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders.Code.GameObjects.Bullet
{
    class PlayerBulletSettings
    {
        private ICanvas _canvas;
        private IAddable _grabbag;

        public PlayerBulletSettings(ICanvas canvas, IAddable grabbag)
        {
            _canvas = canvas;
            _grabbag = grabbag;
        }

        public void MoveBullet(List<PlayerBullet> bullets)
        {
            foreach (var i in bullets)
            {
                i.MoveForward();
                _canvas.SetPosition(i);

                if (i.Y < 10) _grabbag.Add(i);
            }
        }

        public void PlayerInteracs(Enemy enemy, List<PlayerBullet> bullets)
        {
            foreach (var bullet in bullets)
            {
                if (bullet.IntersectsWith(enemy) && !_grabbag.Contains(enemy))
                {
                    enemy.Lives -= 1;
                    if (enemy.Lives == 0) _grabbag.Add(enemy);
                    _grabbag.Add(bullet);
                    break;
                }
            }
        }
    }
}
