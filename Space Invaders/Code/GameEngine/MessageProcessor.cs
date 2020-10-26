using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace Space_Invaders.Code
{
    public class MessageProcessor
    {
        public static string GameOverMessage()
        {
            return "Game Over!\nYou are killed by the invider!";
        }

        public static string YouWinMessage()
        {
            return "You Win!";
        }

        public static string EnemiesLeft(int? enemies)
        {
            return "Enemies Left: " + enemies;
        }
    }
}
