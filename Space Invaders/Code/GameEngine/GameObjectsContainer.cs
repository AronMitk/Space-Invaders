using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders.Code
{
    public class GameObjectsContainer : IRemovable, IAddable
    {
        private List<GameObject> GameObjects { get; set; }

        public GameObjectsContainer()
        {
            GameObjects = new List<GameObject>();
        }

        public void Add(GameObject obj)
        {
            GameObjects.Add(obj);
        }

        public void Remove(GameObject obj)
        {
            GameObjects.Remove(obj);
        }

        public List<J> GetByType<J>()
        {
            return GameObjects.Where(x => x is J).Cast<J>().ToList();
        }

        public int? GetSizeByType<J>()
        {
            return GetByType<J>()?.Count;
        }

        public bool Contains(GameObject obj)
        {
            return GameObjects.Contains(obj);
        }
    }
}
