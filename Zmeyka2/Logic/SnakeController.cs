using System;
using System.Collections.Generic;

namespace Zmeyka2
{
    internal class SnakeController : ISnakeController
    {
        public event EventHandler<Point> OnCleanCell;
        public event EventHandler<Point> OnAddCell;
        public event EventHandler OnCollision;
        List<Point> _snake;
        Point _tailBackup;
        Direction _currentDirection;
        public SnakeController()
        {
            _snake = new List<Point>();
            _currentDirection = Direction.Right;
        }

        public void ChangeDirection(Direction newDirection)
        {
            _currentDirection = newDirection;
        }

        public void Increase()
        {
            _snake.Add(new Point() { X = _tailBackup.X, Y = _tailBackup.Y });
        }

        public void Init(int countRows, int countColumns)
        {
            _snake.Add(new Point()
            {
                X = countColumns / 2,
                Y = countRows / 2
            });
            OnAddCell?.Invoke(this, _snake[0]);
        }

        public Point MoveSnake()
        {
            Point head = _snake[0];
            Point tail = _snake[_snake.Count - 1];
            _tailBackup = tail;
            _tailBackup = new Point()
            {
                X = tail.X,
                Y = tail.Y
            };

            tail.X = head.X;
            tail.Y = head.Y;
            switch (_currentDirection)
            {
                case Direction.Right:
                    tail.X += 1;
                    break;
                case Direction.Left:
                    tail.X -= 1;
                    break;
                case Direction.Up:
                    tail.Y -= 1;
                    break;
                case Direction.Down:
                    tail.Y += 1;
                    break;
                default:
                    break;
            }

            _snake.RemoveAt(_snake.Count - 1);
            OnCleanCell?.Invoke(this, _tailBackup);
            _snake.Insert(0, tail);
            CheckCollision();

            return tail;
        }

        private void CheckCollision()
        {
            Point head = _snake[0];
            for (int i = 1; i < _snake.Count; i++)
                if (head.Equals(_snake[i]))
                {
                    OnCollision?.Invoke(this, new EventArgs());
                    return;
                }
        }
    }
}