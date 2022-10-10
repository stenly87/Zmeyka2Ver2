using System;
using System.Windows.Input;

namespace Zmeyka2
{
    internal class GameControl : IGameControl
    {
        private Direction currentDirection;

        public event EventHandler<Direction> OnDirectionChanged;

        Direction _currentDirection
        {
            get => currentDirection;
            set { 
                currentDirection = value;
                OnDirectionChanged?.Invoke(this, currentDirection);
            }
        }

        public void KeyPress(int key)
        {
            switch ((Key)key)
            {
                case Key.W:
                    if (_currentDirection != Direction.Down)
                        _currentDirection = Direction.Up;
                    break;
                case Key.A:
                    if (_currentDirection != Direction.Right)
                        _currentDirection = Direction.Left;
                    break;
                case Key.S:
                    if (_currentDirection != Direction.Up)
                        _currentDirection = Direction.Down;
                    break;
                case Key.D:
                    if (_currentDirection != Direction.Left)
                        _currentDirection = Direction.Right;
                    break;
            }
        }
    }
}