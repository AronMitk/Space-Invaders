using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Space_Invaders.Code.Utils
{
    public class BitmapsProcessor
    {
        public static BitmapImage GetEnemy(int live)
        {
            return new BitmapImage(new Uri($"pack://application:,,,/Assets/Images/invader{live}.gif"));
        }

        public static BitmapImage GetPlayer()
        {
            return new BitmapImage(new Uri("pack://application:,,,/Assets/Images/player.png"));
        }
    }
}
