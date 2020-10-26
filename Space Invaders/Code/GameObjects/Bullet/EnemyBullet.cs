using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Space_Invaders.Code
{
    public class EnemyBullet : Bullet
    {
        public override int Speed { get; set; } = 10;
        public override string Tag { get; set; } = "EnemyBullet";

        public EnemyBullet() { }
        public EnemyBullet(int x, int y, int width, int height) : base(x, y, width, height)
        {
            Rectangle.Tag = Tag;
            Rectangle.Fill = Brushes.Yellow;
            Rectangle.Stroke = Brushes.Black;
            Rectangle.StrokeThickness = 5;
        }

        public override void MoveForward()
        {
            Y += Speed;
        }
    }
}
