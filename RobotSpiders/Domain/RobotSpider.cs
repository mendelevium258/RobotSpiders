using RobotSpiders.Interfaces;
using RobotSpiders.Attributes;
using System;
using System.Reflection;
using System.Linq;

namespace RobotSpiders.Domain
{
    public class RobotSpider : IWallExplorer
    {
        public IPosition Position { get; set; }

        public IPosition GetPosition()
        {
            return Position;
        }

        private Direction Facing { get; set; }

        public Direction GetFacing()
        {
            return Facing;
        }

        public RobotSpider(IPosition position, string startFacing)
        {
            this.Position = position;
            this.Facing = ((Direction)Enum.Parse(typeof(Direction), startFacing));
        }

        public void MoveForward()
        {
            var attributes = typeof(Direction).GetMember(Facing.ToString()).First().GetCustomAttributes(false);
            foreach (var attribute in attributes)
            {
                if (attribute.GetType() == typeof(MovementAttribute))
                {
                    Position.Move(((MovementAttribute)attribute).X, ((MovementAttribute)attribute).Y);
                }
            }
        }

        public void RotateLeft()
        {
            if (Facing == Direction.Left)
            {
                Facing = Direction.Down;
            }
            else
            {
                Facing--;
            }
        }

        public void RotateRight()
        {
            if (Facing == Direction.Down)
            {
                Facing = Direction.Left;
            }
            else
            {
                Facing++;
            }
        }
    }
}
