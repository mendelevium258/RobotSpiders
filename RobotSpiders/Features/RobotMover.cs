using System;
using RobotSpiders.Exceptions;
using RobotSpiders.Interfaces;

namespace RobotSpiders.Features
{
    public class RobotMover
    {
        private void Execute(IWallExplorer wallExplorer, IWall wall, char command)
        {
            switch (command)
            {
                case 'L':
                case 'l':
                    wallExplorer.RotateLeft();
                    break;
                case 'R':
                case 'r':
                    wallExplorer.RotateRight();
                    break;
                case 'F':
                case 'f':
                    wallExplorer.MoveForward();
                    if (!wall.IsOnWall(wallExplorer.GetPosition()))
                    {
                        throw new FallenOffWallException();
                    }
                    break;
                default:
                    throw new InvalidCharacterException();
            }
        }

        public void Execute(IWallExplorer wallExplorer, IWall wall, string commands)
        {
            foreach (var command in commands)
            {
                Execute(wallExplorer, wall, command);
            }
        }
    }
}
