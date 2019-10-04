using Moq;
using NUnit.Framework;
using RobotSpiders.Domain;
using RobotSpiders.Exceptions;
using RobotSpiders.Features;
using RobotSpiders.Interfaces;
using System;

namespace Tests
{
    public class RobotMoverTests
    {
        private Mock<IWallExplorer> wallExplorer;
        private Mock<IWall> wall;
        
        [SetUp]
        public void Setup()
        {
            wallExplorer = new Mock<IWallExplorer>();
            wall = new Mock<IWall>();
        }

        [TestCase("L", 1)]
        [TestCase("LL", 2)]
        [TestCase("LRF", 1)]
        [TestCase("RRRLFRRLF", 2)]
        [Test]
        public void TurnLeft(string movement, int numLeftTurns)
        {
            //Arrange
            var robotMover = new RobotMover();
            wall.Setup(x => x.IsOnWall(It.IsAny<IPosition>())).Returns(true);

            //Act
            robotMover.Execute(wallExplorer.Object, wall.Object, movement);

            //Assert
            wallExplorer.Verify(x => x.RotateLeft(), Times.Exactly(numLeftTurns));
        }

        [TestCase("R", 1)]
        [TestCase("RR", 2)]
        [TestCase("LRF", 1)]
        [TestCase("LLLRFLLRF", 2)]
        [Test]
        public void TurnRight(string movement, int numRightTurns)
        {
            //Arrange
            var robotMover = new RobotMover();
            wall.Setup(x => x.IsOnWall(It.IsAny<IPosition>())).Returns(true);

            //Act
            robotMover.Execute(wallExplorer.Object, wall.Object, movement);

            //Assert
            wallExplorer.Verify(x => x.RotateRight(), Times.Exactly(numRightTurns));
        }

        [TestCase("F", 1)]
        [TestCase("FF", 2)]
        [TestCase("LRF", 1)]
        [TestCase("LLLRFLLRF", 2)]
        [Test]
        public void MoveForward(string movement, int numForwardMoves)
        {
            //Arrange
            var robotMover = new RobotMover();
            wall.Setup(x => x.IsOnWall(It.IsAny<IPosition>())).Returns(true);

            //Act
            robotMover.Execute(wallExplorer.Object, wall.Object, movement);

            //Assert
            wallExplorer.Verify(x => x.MoveForward(), Times.Exactly(numForwardMoves));
            wall.Verify(x => x.IsOnWall(It.IsAny<IPosition>()), Times.Exactly(numForwardMoves));
        }

        [TestCase("F")]
        [TestCase("FF")]
        [TestCase("LRF")]
        [TestCase("LLLRFLLRF")]
        [Test]
        public void MoveForward_Error(string movement)
        {
            //Arrange
            var robotMover = new RobotMover();
            wall.Setup(x => x.IsOnWall(It.IsAny<IPosition>())).Returns(false);

            //Act
            void testDelegate() => robotMover.Execute(wallExplorer.Object, wall.Object, movement);

            //Assert
            Assert.That(testDelegate, Throws.TypeOf<FallenOffWallException>());
        }

        [TestCase("L")]
        [TestCase("LR")]
        [TestCase("LRLLR")]
        [Test]
        public void RotateLeftRight_OffWall(string movement)
        {
            //Arrange
            var robotMover = new RobotMover();
            wall.Setup(x => x.IsOnWall(It.IsAny<IPosition>())).Returns(false);

            //Act
            robotMover.Execute(wallExplorer.Object, wall.Object, movement);

            //Assert
            wallExplorer.Verify(x => x.MoveForward(), Times.Never);
            wall.Verify(x => x.IsOnWall(It.IsAny<IPosition>()), Times.Never);
        }

        [TestCase("m", 0, 0, 0)]
        [TestCase("LRS", 1, 1, 0)]
        [TestCase("LFRFSLLR", 1, 1, 2)]
        [Test]
        public void InvalidInput(string movement, int numLeftTurns, int numRightTurns, int numForwards)
        {
            //Arrange
            var robotMover = new RobotMover();
            wall.Setup(x => x.IsOnWall(It.IsAny<IPosition>())).Returns(true);

            //Act
            void testDelegate() => robotMover.Execute(wallExplorer.Object, wall.Object, movement);

            //Assert
            Assert.That(testDelegate, Throws.TypeOf<InvalidCharacterException>());
            wallExplorer.Verify(x => x.MoveForward(), Times.Exactly(numForwards));
            wallExplorer.Verify(x => x.RotateLeft(), Times.Exactly(numLeftTurns));
            wallExplorer.Verify(x => x.RotateRight(), Times.Exactly(numRightTurns));
        }
    }
}