
namespace Space_Invaders.Code.Spawners
{
    public class PlayerBulletSpawner : BulletSpawner
    {
        public PlayerBulletSpawner(ICanvas canvas, IAddable gameObjects) : base(canvas, gameObjects)
        {
            _canvas = canvas;
            _gameObjects = gameObjects;
        }

        public override void Spawn(int x, int y)
        {
            var playerBullet = new PlayerBullet(x, y, 5, 20);
            base.Spawn(playerBullet);
        }
    }
}
