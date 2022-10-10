using System;
using System.Windows.Threading;

namespace Zmeyka2
{
    internal class GameTimer : IGameTimer
    {
        DispatcherTimer _gameTimer;
        Action action;
        public void Init(Action action)
        {
            this.action = action;
            _gameTimer = new DispatcherTimer();
            _gameTimer.Interval = TimeSpan.FromSeconds(0.5);
            _gameTimer.Tick += _gameTimer_Tick; 
            _gameTimer.Start();
        }

        private void _gameTimer_Tick(object sender, EventArgs e)
        {
            action();
        }

        public void Stop()
        {
            _gameTimer.Stop();
            _gameTimer.Tick -= _gameTimer_Tick;
        }

        public void IncreaseSpeed()
        {
            _gameTimer.Interval = _gameTimer.Interval - TimeSpan.FromSeconds(0.1);
        }
    }
}