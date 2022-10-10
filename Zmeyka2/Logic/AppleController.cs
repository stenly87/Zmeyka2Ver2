using System;

namespace Zmeyka2
{
    internal class AppleController : IAppleController
    {
        public event EventHandler<Point> OnAppleRemove;
        public event EventHandler<Point> OnAppleSpawn;
        Random _randoTron;
        Point _position;
        int countRows;
        int countColumns;
        public bool Collision(Point headPosition)
        {
            if (headPosition.Equals(_position))
            {
                OnAppleRemove?.Invoke(this, _position);
                CreateApple();
                return true;
            }
            return false;
        }

        public void Init(int countRows, int countColumns)
        {
            _randoTron = new Random();
            this.countRows = countRows;
            this.countColumns = countColumns;
            CreateApple();
        }

        public void CreateApple()
        {
            _position = new Point()
            {
                X = _randoTron.Next(0, countColumns),
                Y = _randoTron.Next(0, countRows)
            };
            OnAppleSpawn?.Invoke(this, _position);
        }
    }
}