using System;
using System.Collections.Generic;
using System.Windows.Shapes;

namespace Zmeyka2
{
    internal class RectangleContainer
    {
        Stack<Rectangle> _stack = new Stack<Rectangle>();

        internal Rectangle GetFreeRectangle(int _elementSize)
        {
            if(_stack.Count > 0)
                return _stack.Pop();
            return new Rectangle { Width = _elementSize, Height = _elementSize };
        }

        internal void Store(Rectangle rectangle)
        {
            _stack.Push(rectangle);
        }

        internal void Clear()
        {
            _stack.Clear();
        }
    }
}