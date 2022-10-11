namespace Zmeyka2
{
    internal class GameField : IGameField
    {
        public double GameWidth { get; private set; }
        public double GameHeight { get; private set; }
        public int CountRows { get; private set; }
        public int CountColumns { get; private set; }

        public bool CheckCollisionBorders(Point headPosition)
        {
            return headPosition.X > GameWidth - 1 ||
                headPosition.X  < 0 ||
                headPosition.Y  < 0 ||
                headPosition.Y  > GameHeight - 1;
        }

        public void Init(double actualWidth, double actualHeight)
        {
            GameWidth = actualWidth;
            GameHeight = actualHeight;
            CountColumns = (int)GameWidth;
            CountRows = (int)GameHeight ;
        }
    }
}