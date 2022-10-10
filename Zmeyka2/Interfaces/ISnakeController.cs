using System;

namespace Zmeyka2
{
    internal interface ISnakeController
    {
        void ChangeDirection(Direction newDirection);
        void Init(int countRows, int countColumns);
        Point MoveSnake();
        void Increase();

        event EventHandler<Point> OnCleanCell;
        event EventHandler<Point> OnAddCell;
        event EventHandler OnCollision;
    }
}