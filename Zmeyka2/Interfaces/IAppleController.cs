using System;

namespace Zmeyka2
{
    internal interface IAppleController
    {
        event EventHandler<Point> OnAppleRemove;
        event EventHandler<Point> OnAppleSpawn;
        void Init(int countRows, int countColumns);
        bool Collision(Point headPosition);
    }
}