using System;

namespace Zmeyka2
{
    internal interface IGameControl
    {
        void KeyPress(int e);
        event EventHandler<Direction> OnDirectionChanged;
    }
}