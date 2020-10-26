using Space_Invaders.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders.Code.Spawners
{
    public class PlayerSpawner : CharacterSpawner
    {
        public PlayerSpawner(ICanvas canvas, IAddable gameObjects) : base(canvas, gameObjects)
        {

        }

        public override void Spawn()
        {
            var _player = new Player(408, 396, 65, 55);
            _player.SetSkin(BitmapsProcessor.GetPlayer());
            Spawn(_player);
        }
    }
}
