using System;
using System.Collections.Generic;
using System.Text;

namespace RobotSpiders.Interfaces
{
    public interface IWall
    {
        bool IsOnWall(IPosition position);
    }
}
