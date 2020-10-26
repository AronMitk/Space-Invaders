using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Space_Invaders.Code
{
    public class Character : GameObject
    {
        public virtual int Lives { get; set; }
        public virtual int Speed { get; set; }

        public Character(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        public void SetSkin(BitmapImage image)
        {
            ImageBrush PlayerSkin = new ImageBrush
            {
                ImageSource = image
            };

            Rectangle.Fill = PlayerSkin;
        }
    }
}
