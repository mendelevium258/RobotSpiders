using RobotSpiders.Interfaces;

namespace RobotSpiders.Domain
{
    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            Set(x, y);
        }

        public void Set(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(int incrementX, int incrementY)
        {
            X += incrementX;
            Y += incrementY;
        }
    }
}
