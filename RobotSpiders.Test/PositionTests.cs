using NUnit.Framework;
using RobotSpiders.Domain;

namespace Tests
{
    public class PositionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1, 1)]
        [TestCase(5, 1)]
        [TestCase(1, 5)]
        [TestCase(-2, -2)]
        [Test]
        public void Set(int x, int y)
        {
            //Arrange
            Position pos = new Position(0, 0);

            //Act
            pos.Set(x, y);

            //Assert
            Assert.AreEqual(x, pos.X);
            Assert.AreEqual(y, pos.Y);
        }

        [TestCase(1, 1)]
        [TestCase(5, 1)]
        [TestCase(1, 5)]
        [TestCase(-2, -2)]
        [Test]
        public void Constructor(int x, int y)
        {
            //Arrange

            //Act
            Position pos = new Position(x, y);

            //Assert
            Assert.AreEqual(x, pos.X);
            Assert.AreEqual(y, pos.Y);
        }

        [TestCase(1, 1, 0, 1, 1, 2)]
        [TestCase(5, 1, 1, 0, 6, 1)]
        [TestCase(1, 5, 1, 1, 2, 6)]
        [TestCase(-2, 2, -1, -2, -3, 0)]
        [Test]
        public void Move(int startX, int startY, int incrementX, int incrementY, int finishX, int finishY)
        {
            //Arrange
            Position pos = new Position(startX, startY);

            //Act
            pos.Move(incrementX, incrementY);

            //Assert
            Assert.AreEqual(finishX, pos.X);
            Assert.AreEqual(finishY, pos.Y);
        }
    }
}