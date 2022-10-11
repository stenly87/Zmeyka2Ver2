using System;

namespace Zmeyka2
{
    internal interface IGameControl
    {
        void KeyPress(int key);
        event EventHandler<Direction> OnDirectionChanged;
    }
}