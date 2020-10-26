using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders.Code
{
    public class Enemy : Character
    {
        public override string Tag { get; set; } = "Enemy";
        public override int Speed { get; set; } = 5;
        public override int Lives { get; set; } = 1;

        public Enemy(int x, int y, int width, int height) : base(x, y, width, height)
        {
            Rectangle.Tag = Tag;
        }

        public void MoveLeft()
        {
            X -= Speed;
        }

        public void MoveRight()
        {
            X += Speed;
        }

        public void MoveDown()
        {
            Y += Height / 2;
        }

    }
}
