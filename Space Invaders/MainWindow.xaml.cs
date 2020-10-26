using Space_Invaders.Code;
using Space_Invaders.Code.GameEngine;
using Space_Invaders.Code.GameObjects.Bullet;
using Space_Invaders.Code.Spawners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Space_Invaders
{

    public interface IRestartable
    {
        void Restart();
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IRestartable
    {
        private GameEngine GameEngine { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            GameEngine = new GameEngine(EndLabel, EnemiesLeftLabel, MainCanvas, this);
            MainCanvas.Focus();
        }

        private void Canvas_KeyUp(object sender, KeyEventArgs e)
        {
            GameEngine.Canvas_KeyUp(e.Key);
        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            GameEngine.Canvas_KeyDown(e.Key);
        }

        public void Restart()
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

    }
}
