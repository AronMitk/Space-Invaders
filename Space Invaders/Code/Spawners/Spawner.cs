using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders.Code.Spawners
{
    public abstract class Spawner
    {
        protected ICanvas _canvas;
        protected IAddable _gameObjects;

        public Spawner(ICanvas canvas, IAddable gameObjects)
        {
            _canvas = canvas;
            _gameObjects = gameObjects;
        }

        public void Spawn(GameObject gameObject)
        {
            _canvas.SetPosition(gameObject);
            _canvas.AddToCanvas(gameObject);
            _gameObjects.Add(gameObject);
        }
    }
}
