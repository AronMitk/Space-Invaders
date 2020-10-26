using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Space_Invaders.Code
{
    public class Player : Character
    {
        public double ShootingSpeed { get; set; }
        public override int Speed { get; set; } = 10;
        public override int Lives { get; set; } = 1;
        public override string Tag { get; set; } = "Player";

        public Player(int x, int y, int width, int height) : base(x, y, width, height)
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

        
    }
}
