using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Space_Invaders.Code
{
    public abstract class Bullet : GameObject
    {
        public virtual int Speed { get; set; }
        public Bullet()
        {

        }

        public Bullet(int x, int y, int width, int height) : base(x, y, width, height)
        {
            Rectangle.Fill = Brushes.White;
            Rectangle.Stroke = Brushes.Red;
        }

        public abstract void MoveForward();
    }
}
