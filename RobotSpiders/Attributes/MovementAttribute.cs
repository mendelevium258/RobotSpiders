using System;

namespace RobotSpiders.Attributes
{
    internal class MovementAttribute : Attribute
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}