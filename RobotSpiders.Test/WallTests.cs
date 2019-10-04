using NUnit.Framework;
using RobotSpiders.Domain;
using RobotSpiders.Exceptions;

namespace Tests
{
    public class WallTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1, 1)]
        [TestCase(5, 1)]
        [TestCase(1, 5)]
        [Test]
        public void Constructor(int width, int height)
        {
            //Arrange

            //Act
            Wall wall = new Wall(width, height);

            //Assert
            Assert.AreEqual(width, wall.Width);
            Assert.AreEqual(height, wall.Height);
        }

        [TestCase(-2, -2)]
        [TestCase(0, 0)]
        [TestCase(2, -2)]
        [TestCase(-2, 2)]
        [Test]
        public void Constructor_Error(int x, int y)
        {
            //Arrange

            //Act
            void testDelegate() => new Wall(x, y);

            //Assert
            Assert.That(testDelegate, Throws.TypeOf<InvalidDimensionException>());
        }

        [TestCase(1, 1, 0, 0, true)]
        [TestCase(1, 1, 1, 1, false)]
        [TestCase(1, 1, 1, 0, false)]
        [TestCase(1, 1, 0, 1, false)]
        [TestCase(4, 5, 3, 4, true)]
        [TestCase(2, 2, -1, 0, false)]
        [TestCase(2, 2, 0, -1, false)]
        [Test]
        public void IsOnWall(int wallWidth, int wallHeight, int positionX, int positionY, bool expectedResult)
        {
            //Arrange
            Wall wall = new Wall(wallWidth, wallHeight);
            Position pos = new Position(positionX, positionY);

            //Act
            bool actualResult = wall.IsOnWall(pos);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}