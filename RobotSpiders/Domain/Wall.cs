using RobotSpiders.Exceptions;
using RobotSpiders.Interfaces;

namespace RobotSpiders.Domain
{
    public class Wall : IWall
    {
        public int Width { get; }
        public int Height { get; }

        public Wall(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new InvalidDimensionException($"A Wall can only have dimensions > 0, you attempted to enter {width} x {height}");
            }
            Width = width;
            Height = height;
        }

        public bool IsOnWall(IPosition position)
        {
            return position.X >= 0 && 
                position.X < Width &&
                position.Y >= 0 && 
                position.Y < Height;
        }
    }
}
