using RobotSpiders.Attributes;

namespace RobotSpiders.Interfaces
{
    public enum Direction
    {
        [Movement(X = -1)]
        Left,
        [Movement(Y = 1)]
        Up,
        [Movement(X = 1)]
        Right,
        [Movement(Y = -1)]
        Down
    };
    public interface IWallExplorer
    {
        IPosition GetPosition();
        Direction GetFacing();
        void RotateLeft();
        void RotateRight();
        void MoveForward();
    }
}
