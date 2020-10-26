using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Space_Invaders.Code
{
    public class GameLoopRunnable
    {
        IRunnable Runnable;
        DispatcherTimer GameTimer = new DispatcherTimer();
        public bool IsRunning { get; private set; }

        public GameLoopRunnable(IRunnable runnable)
        {
            Runnable = runnable;
            IsRunning = false;
        }

        public void Start()
        {
            GameTimer.Tick += Runnable.Run;
            GameTimer.Interval = TimeSpan.FromMilliseconds(20);
            GameTimer.Start();

            IsRunning = true;
        }

        public void Stop()
        {
            GameTimer.Stop();

            IsRunning = false;
        }

    }
}
