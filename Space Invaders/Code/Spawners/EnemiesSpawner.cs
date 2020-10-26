using Space_Invaders.Code.Spawners;
using Space_Invaders.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Space_Invaders.Code
{
    public class EnemiesSpawner : CharacterSpawner
    {
        public EnemiesSpawner(ICanvas canvas, IAddable gameObjects) : base(canvas, gameObjects) { }

        public override void Spawn()
        {
            var arr = GetArray();

            int top = 0;
            for (int y = 0; y < arr.GetLength(0); y++)
            {
                int left = 0;
                for (int x = 0; x < arr.GetLength(1); x++)
                {
                    Enemy enemy = new Enemy(left, top, 30, 30)
                    {
                        Lives = arr[y, x]
                    };
                    enemy.SetSkin(BitmapsProcessor.GetEnemy(enemy.Lives));
                    Spawn(enemy);

                    left += 40;
                }
                top += 40;
            }
        }


        private int[,] GetArray()
        {
            return new int[,]{
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
            };
        }
    }
}
