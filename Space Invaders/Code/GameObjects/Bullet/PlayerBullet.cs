using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Space_Invaders.Code
{
    public class PlayerBullet : Bullet
    {
        public override int Speed { get; set; } = 20;
        public override string Tag { get; set; } = "PlayerBullet";
        
        public PlayerBullet() { }
        public PlayerBullet(int x, int y, int width, int height) : base(x, y, width, height) 
        {
            Rectangle.Tag = Tag;
            Rectangle.Fill = Brushes.White;
            Rectangle.Stroke = Brushes.Red;
        }

        public override void MoveForward()
        {
            Y -= Speed;
        }
    }
}
