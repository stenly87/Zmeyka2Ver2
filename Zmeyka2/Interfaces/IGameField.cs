namespace Zmeyka2
{
    internal interface IGameField
    {
        double GameWidth { get; }
        double GameHeight { get; }
        int CountRows { get; }
        int CountColumns { get; }
        bool CheckCollisionBorders(Point headPosition);
        void Init(double actualWidth, double actualHeight);
    }
}