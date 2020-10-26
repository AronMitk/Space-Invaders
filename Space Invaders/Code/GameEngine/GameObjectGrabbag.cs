using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Space_Invaders.Code
{
    public class GameObjectsGrabbag : IAddable
    {
        List<GameObject> GameObjectsToRemove = new List<GameObject>();

        IRemovable _gameObjects;

        UIOperations Canvas;

        public GameObjectsGrabbag(IRemovable gameObjects, UIOperations canvas)
        {
            _gameObjects = gameObjects;
            Canvas = canvas;
        }


        public void Add(GameObject obj)
        {
            GameObjectsToRemove.Add(obj);
        }

        public bool Contains(GameObject obj)
        {
            return GameObjectsToRemove.Contains(obj);
        }

        public void Collect()
        {
            foreach (GameObject i in GameObjectsToRemove)
            {
                _gameObjects.Remove(i);
                Canvas.RemoveCanvas(i);
            }
        }
    }
}
