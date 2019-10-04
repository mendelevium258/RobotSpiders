using Moq;
using NUnit.Framework;
using RobotSpiders.Domain;
using RobotSpiders.Interfaces;
using System;

namespace Tests
{
    public class RobotSpiderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1, 1, "Left", Direction.Left)]
        [TestCase(5, 1, "Right", Direction.Right)]
        [TestCase(1, 5, "Up", Direction.Up)]
        [TestCase(-2, -2, "Down", Direction.Down)]
        [Test]
        public void Constructor(int x, int y, string facing, Direction expectedFacing)
        {
            //Arrange
            var pos = new Position(x, y);

            //Act
            var spider = new RobotSpider(pos, facing);

            //Assert
            Assert.AreEqual(x, spider.GetPosition().X);
            Assert.AreEqual(y, spider.GetPosition().Y);
            Assert.AreEqual(expectedFacing, spider.GetFacing());
        }

        [TestCase("InvalidValue")]
        [Test]
        public void Constructor_Error(string facing)
        {
            //Arrange
            var pos = new Mock<IPosition>();

            //Act
            void testDelegate() => new RobotSpider(pos.Object, facing);

            //Assert
            Assert.That(testDelegate, Throws.TypeOf<ArgumentException>());
        }

        [TestCase(3, 1, "Left", 2, 1)]
        [TestCase(3, 1, "Right", 4, 1)]
        [TestCase(3, 1, "Up", 3, 2)]
        [TestCase(3, 1, "Down", 3, 0)]
        [Test]
        public void MoveForward(int startX, int startY, string facing, int finishX, int finishY)
        {
            //Arrange
            Position pos = new Position(startX, startY);
            RobotSpider spider = new RobotSpider(pos, facing);

            //Act
            spider.MoveForward();

            //Assert
            Assert.AreEqual(finishX, spider.GetPosition().X);
            Assert.AreEqual(finishY, spider.GetPosition().Y);
        }

        [TestCase(3, 1, "Left", Direction.Down)]
        [TestCase(3, 1, "Right", Direction.Up)]
        [TestCase(3, 1, "Up", Direction.Left)]
        [TestCase(3, 1, "Down", Direction.Right)]
        [Test]
        public void RotateLeft(int startX, int startY, string facing, Direction expectedFacing)
        {
            //Arrange
            Position pos = new Position(startX, startY);
            RobotSpider spider = new RobotSpider(pos, facing);

            //Act
            spider.RotateLeft();

            //Assert
            Assert.AreEqual(expectedFacing, spider.GetFacing());
        }

        [TestCase(3, 1, "Left", Direction.Up)]
        [TestCase(3, 1, "Right", Direction.Down)]
        [TestCase(3, 1, "Up", Direction.Right)]
        [TestCase(3, 1, "Down", Direction.Left)]
        [Test]
        public void RotateRight(int startX, int startY, string facing, Direction expectedFacing)
        {
            //Arrange
            Position pos = new Position(startX, startY);
            RobotSpider spider = new RobotSpider(pos, facing);

            //Act
            spider.RotateRight();

            //Assert
            Assert.AreEqual(expectedFacing, spider.GetFacing());
        }
    }
}