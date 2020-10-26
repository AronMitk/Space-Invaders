using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders.Code.Spawners
{
    public abstract class BulletSpawner : Spawner
    {
        public BulletSpawner(ICanvas canvas, IAddable gameObjects) : base (canvas, gameObjects) { }

        public abstract void Spawn(int x, int y);
    }
}
