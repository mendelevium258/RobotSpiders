namespace RobotSpiders.Interfaces
{
    public interface IPosition
    {
        int X { get; set; }
        int Y { get; set; }

        void Set(int x, int y);
        void Move(int incrementX, int incrementY);
    }
}
