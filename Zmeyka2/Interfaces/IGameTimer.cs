using System;

namespace Zmeyka2
{
    internal interface IGameTimer
    {
        void Init(Action action);
        void Stop();
        void IncreaseSpeed();
    }
}