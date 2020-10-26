using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Space_Invaders.Code
{
    public class UIOperations : ICanvas
    {
        private Canvas _canvas;
        private ContentControl _endLabel, _enemiesLeftLabel;

        public UIOperations(Canvas canvas)
        {
            _canvas = canvas;
        }

        public UIOperations(Canvas canvas, ContentControl endLabel, ContentControl enemiesLeftLabel)
        {
            _canvas = canvas;
            _endLabel = endLabel;
            _enemiesLeftLabel = enemiesLeftLabel;
        }


        public double[] GetCanvasSize()
        {
            return new double[] { _canvas.ActualWidth, _canvas.ActualHeight };
        }

        public void SetPosition(GameObject gameObject)
        {
            var item = gameObject.Rectangle;
            Canvas.SetTop(item, gameObject.Y);
            Canvas.SetLeft(item, gameObject.X);
        }

        public void AddToCanvas(GameObject gameObject)
        {
            _canvas.Children.Add(gameObject.Rectangle);
        }

        public void RemoveCanvas(GameObject gameObject)
        {
            _canvas.Children.Remove(gameObject.Rectangle);
        }


        public void ShowEndLabel(string message)
        {
            _endLabel.Content = message;
            _endLabel.Visibility = Visibility.Visible;
        }

        public void ShowEnemiesLeftLabel(string message)
        {
            _enemiesLeftLabel.Content = message;
        }
    }
}
