
namespace Space_Invaders.Code.Spawners
{
    public class EnemyBulletSpawner : BulletSpawner
    {
        public int BulletSpawnRate { get; set; } = 40;
        private int BulletTimer { get; set; }

        public EnemyBulletSpawner(ICanvas canvas, IAddable gameObjects) : base(canvas, gameObjects)
        {
            BulletTimer = BulletSpawnRate;
        }

        public override void Spawn(int x, int y)
        {
            BulletTimer -= 1;

            if (BulletTimer == 0)
            {
                var enemyBullet = new EnemyBullet(x, y, 15, 40);

                base.Spawn(enemyBullet);

                BulletTimer = BulletSpawnRate;
            }
        }
    }
}
