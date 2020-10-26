using Space_Invaders.Code.GameObjects.Bullet;
using Space_Invaders.Code.GameObjects.Players;
using Space_Invaders.Code.Spawners;
using Space_Invaders.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Space_Invaders.Code.GameEngine
{
    public class GameEngine : IRunnable
    {
        GameLoopRunnable _gameLoop { get; set; }
        GameObjectsGrabbag _grabbag { get; set; }
        UIOperations _ui { get; set; }

        GameObjectsContainer _gameObjectsCollection = new GameObjectsContainer();
        
        BulletSpawner _playerBulletSpawner, _enemyBulletSpawner;

        EnemySettings _enemySettings { get; set; }
        EnemyBulletSettings _enemyBulletSettings { get; set; }
        PlayerBulletSettings _playerBulletSettings { get; set; }
        PlayerSettings _playerController { get; set; }
        IRestartable _restartable;

        public GameEngine(ContentControl EndLabel, ContentControl EnemiesLeftLabel, Canvas MainCanvas, IRestartable Restartable)
        {
            _restartable = Restartable;

            _ui = new UIOperations(MainCanvas, EndLabel, EnemiesLeftLabel);
            _grabbag = new GameObjectsGrabbag(_gameObjectsCollection, _ui);
            _gameLoop = new GameLoopRunnable(this);

            SpawnersInit();

            _enemyBulletSettings = new EnemyBulletSettings(_ui, _grabbag);
            _playerBulletSettings = new PlayerBulletSettings(_ui, _grabbag);

            _playerController = new PlayerSettings(_ui, _gameObjectsCollection.GetByType<Player>().First());
            
            _enemySettings = new EnemySettings();

            _gameLoop.Start();
        }

        public void SpawnersInit()
        {
            var spawner = (CharacterSpawner) new PlayerSpawner(_ui, _gameObjectsCollection);
            spawner.Spawn();
            spawner = new EnemiesSpawner(_ui, _gameObjectsCollection);
            spawner.Spawn();

            _playerBulletSpawner = new PlayerBulletSpawner(_ui, _gameObjectsCollection);
            _enemyBulletSpawner = new EnemyBulletSpawner(_ui, _gameObjectsCollection);
        }

        public void Canvas_KeyUp(Key e)
        {
            switch (e)
            {
                case Key.Space:
                    _playerController.SpawnBullet(_playerBulletSpawner);
                    break;
                case Key.Enter:
                    if (!_gameLoop.IsRunning) _restartable.Restart();
                    break;
                default:
                    _playerController.movement = Movement.Stay;
                    break;
            }

        }


        public void Canvas_KeyDown(Key e)
        {
            switch (e)
            {
                case Key.Left:
                case Key.A:
                    _playerController.movement = Movement.ToLeft;
                    break;
                case Key.Right:
                case Key.D:
                    _playerController.movement = Movement.ToRight;
                    break;
                default:
                    break;
            }
        }


        public void Run(object sender, EventArgs e)
        {
            var enemies = _gameObjectsCollection.GetByType<Enemy>();
            var playerBullets = _gameObjectsCollection.GetByType<PlayerBullet>();
            var enemiesBullets = _gameObjectsCollection.GetByType<EnemyBullet>();
            var player = _gameObjectsCollection.GetByType<Player>().First();

            _playerController.Move();
            _playerBulletSettings.MoveBullet(playerBullets);
            _enemyBulletSettings.MoveBullet(enemiesBullets);

            _enemyBulletSpawner.Spawn(player.X + 20, 10);
            enemies.ForEach(x => _playerBulletSettings.PlayerInteracs(x, playerBullets));
            _enemySettings.MoveToSides(enemies, _ui);
            _enemySettings.ModeDown(enemies, _ui);

            //Interation
            if (_enemySettings.PlayerInteracs(player, enemies)) GameEnd(true);
            if (_enemyBulletSettings.PlayerInteracs(player, enemiesBullets)) GameEnd(true);

            //Clean
            _grabbag.Collect();

            _ui.ShowEnemiesLeftLabel(MessageProcessor.EnemiesLeft(_gameObjectsCollection.GetSizeByType<Enemy>()));

            //Check if not end
            if (_gameObjectsCollection.GetSizeByType<Enemy>() < 1) GameEnd(false);
        }

        private void GameEnd(bool isLost)
        {
            string message;
            if (isLost) message = MessageProcessor.GameOverMessage();
            else message = MessageProcessor.YouWinMessage();

            _ui.ShowEndLabel(message);
            _gameLoop.Stop();
        }
    }
}
