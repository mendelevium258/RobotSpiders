using NUnit.Framework;
using RobotSpiders;
using RobotSpiders.Domain;
using System;
using System.IO;

namespace Tests
{
    public class ProgramTests
    {
        StringWriter stringWriter;
        [SetUp]
        public void Setup()
        {
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
        }

        [TestCase("7", "15", "2", "4", "Left", "FLFLFRFFLF", 3, 1, "Right")]
        [TestCase("7", "6", "2", "4", "Up", "LLLFLRFFFLF", 6, 5, "Up")]
        [TestCase("4", "6", "2", "4", "Down", "LLFLRRLRFL", 3, 5, "Up")]
        [TestCase("5", "5", "2", "4", "Down", "FLRLFFLRLRR", 4, 3, "Down")]
        [TestCase("5", "6", "2", "4", "Left", "LLFFRLRLLFR", 4, 5, "Right")]
        [TestCase("4", "5", "2", "4", "Left", "RRFLLRLLFR", 3, 3, "Left")]
        [Test]
        public void Main_Arguments(string wallX, string wallY, string startX, string startY, string facing, string movement, int expectedX, int expectedY, string expectedFacing)
        {
            //Arrange
            var args = new string[] { wallX, wallY, startX, startY, facing, movement };
            var expectedText = $"{expectedX} {expectedY} {expectedFacing}\r\n";

            //Act
            Program.Main(args);

            //Assert
            Assert.AreEqual(expectedText, stringWriter.ToString());
        }

        [TestCase("11", "2", "9", "1", "Down", "LRFLFFLLFRFFL", "The spider fell off the wall\r\n")]
        [TestCase("5", "2", "4", "0", "Right", "FLRRFRLRFRFFRL", "The spider fell off the wall\r\n")]
        [TestCase("10", "10", "5", "5", "Right", "FLRRFSLRFRFFRL", "The command should contain only F, L and R characters\r\n")]
        [TestCase("-1", "2", "4", "0", "Right", "FLRRFRLRFRFFRL", "A Wall can only have dimensions > 0, you attempted to enter -1 x 2\r\n")]
        [TestCase("5", "-1", "4", "0", "Right", "FLRRFRLRFRFFRL", "A Wall can only have dimensions > 0, you attempted to enter 5 x -1\r\n")]
        [Test]
        public void Main_Error(string wallX, string wallY, string startX, string startY, string facing, string movement, string expectedText)
        {
            //Arrange
            var args = new string[] { wallX, wallY, startX, startY, facing, movement };

            //Act
            Program.Main(args);

            //Assert
            Assert.AreEqual(expectedText, stringWriter.ToString());
        }
        [TestCase("../../../TestMainFilePath.txt", 3,1,"Right")]
        [Test]
        public void Main_FilePath(string filePath, int expectedX, int expectedY, string expectedFacing)
        {
            //Arrange
            var args = new string[] { filePath };
            var expectedText = $"{expectedX} {expectedY} {expectedFacing}\r\n";

            //Act
            Program.Main(args);

            //Assert
            Assert.AreEqual(expectedText, stringWriter.ToString());
        }
    }
}