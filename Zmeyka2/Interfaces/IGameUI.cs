using System;

namespace Zmeyka2
{
    internal interface IGameUI
    {
        double GameWidth { get; }
        double GameHeight { get;}
        int CountRows { get; }
        int CountColumns { get; }
        void Init();

        event EventHandler OnGameFieldReady;
        event EventHandler<int> OnKeyPressed;

        void ViewMessage(string v);
        bool CheckCollisionBorders(Point headPosition);
        void Clear();
        void RemoveGameElement(Point e);
        void DrawApple(Point e);
        void DrawSnakeHead(Point headPosition);
    }
}