using System;

namespace Zmeyka2
{
    internal interface ISnakeController
    {
        void Init(int countRows, int countColumns);
        void ChangeDirection(Direction newDirection);
        Point MoveSnake();
        void Increase();

        event EventHandler<Point> OnCleanCell;
        event EventHandler<Point> OnAddCell;
        event EventHandler OnCollision;
    }
}