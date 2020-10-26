using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace Space_Invaders.Code
{
    public class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public virtual string Tag { get; set; }
        public Rectangle Rectangle { get; set; }


        public GameObject() { }

        public GameObject(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;

            Rectangle = new Rectangle
            {
                Tag = Tag,
                Height = Height,
                Width = Width
            };
        }

        public Rect GetRect()
        {
            return new Rect(X, Y, Width, Height);
        }

        public bool IntersectsWith(GameObject gameObject)
        {
            var a = GetRect();
            var b = gameObject.GetRect();

            return a.IntersectsWith(b);
        }
    }
}
