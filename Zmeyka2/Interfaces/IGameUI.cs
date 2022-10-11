using System;

namespace Zmeyka2
{
    internal interface IGameUI
    {
        void Init();

        event EventHandler OnGameFieldReady;
        event EventHandler<int> OnKeyPressed;

        void ViewMessage(string v);
        
        void Clear();
        void RemoveGameElement(Point e);
        void DrawApple(Point e);
        void DrawSnakeHead(Point headPosition);
    }
}