using Space_Invaders.Code.Spawners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders.Code
{
    public enum Movement
    {
        Stay = 0,
        ToLeft = 1,
        ToRight = 2
    }

    public class PlayerSettings
    {
        public Movement movement { get; set; }

        ICanvas _canvas;
        Player _player;

        public PlayerSettings(ICanvas canvas, Player player)
        {
            _canvas = canvas;
            _player = player;
        }

        public void Move()
        {
            if (movement == Movement.ToLeft && _player.X > 0)
            {
                _player.MoveLeft();
                _canvas.SetPosition(_player);
            }

            if (movement == Movement.ToRight && _player.X + 80 < _canvas.GetCanvasSize()[0])
            {
                _player.MoveRight();
                _canvas.SetPosition(_player);
            }
        }

        public void SpawnBullet(BulletSpawner _playerBulletSpawner)
        {
            var x = _player.X + _player.Width / 2;
            var y = _player.Y - 20;
            _playerBulletSpawner.Spawn(x, y);
        }
    }
}
