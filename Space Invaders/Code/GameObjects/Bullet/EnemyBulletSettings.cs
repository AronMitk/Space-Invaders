using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders.Code.GameObjects.Bullet
{
    public class EnemyBulletSettings
    {
        private ICanvas _canvas;
        private IAddable _grabbag;

        public EnemyBulletSettings(ICanvas canvas, IAddable grabbag)
        {
            _canvas = canvas;
            _grabbag = grabbag;
        }

        public void MoveBullet(List<EnemyBullet> bullets)
        {
            foreach (var i in bullets)
            {
                i.MoveForward();
                _canvas.SetPosition(i);
                if (i.Y > _canvas.GetCanvasSize()[1])
                {
                    _grabbag.Add(i);
                }
            }
        }

        public bool PlayerInteracs(Player player, List<EnemyBullet> bullets)
        {
            foreach (var i in bullets)
            {
                if (player.IntersectsWith(i))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
