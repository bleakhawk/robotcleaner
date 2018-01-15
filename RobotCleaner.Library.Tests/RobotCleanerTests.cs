using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleaner.Library.Tests
{
    [TestFixture]
    public class RobotCleanerTests
    {
        [Test]
        public void CheckAlreadyExists_WhenExists_DoesNotAdd()
        {
            List<KeyValuePair<int, int>> currentUniquePositions = new List<KeyValuePair<int, int>>();
            currentUniquePositions.Add(new KeyValuePair<int, int>(10, 22));
            currentUniquePositions.Add(new KeyValuePair<int, int>(11, 22));
            currentUniquePositions.Add(new KeyValuePair<int, int>(12, 22));
            currentUniquePositions.Add(new KeyValuePair<int, int>(13, 22));

            var output = RobotProcessor.CheckUniqueAndAddPosition(10, 22, currentUniquePositions);

            Assert.AreEqual(4, output.Count);
        }

        [Test]
        public void CheckAlreadyExists_WhenNotExists_AddsPosition()
        {
            List<KeyValuePair<int, int>> currentUniquePositions = new List<KeyValuePair<int, int>>();
            currentUniquePositions.Add(new KeyValuePair<int, int>(10, 22));
            currentUniquePositions.Add(new KeyValuePair<int, int>(11, 22));
            currentUniquePositions.Add(new KeyValuePair<int, int>(12, 22));
            currentUniquePositions.Add(new KeyValuePair<int, int>(13, 22));

            var output = RobotProcessor.CheckUniqueAndAddPosition(10, 222, currentUniquePositions);

            Assert.AreEqual(5, output.Count);
        }

        [Test]
        public void Clean_When1Direction_ReturnsPlus1(
           [Values(1, 2, 3, 4, 5)] int steps)
        {

            var directions = new List<KeyValuePair<char, int>>();
            directions.Add(new KeyValuePair<char, int>('E', steps));

            int output = RobotProcessor.Clean(10, 22, directions);

            Assert.AreEqual(steps + 1, output);
        }

        [Test]
        public void Clean_When2DifferentDirections_ReturnsSumPlus1(
            [Values(2)] int stepsDir1,
            [Values(2)] int stepsDir2)
        {

            var directions = new List<KeyValuePair<char, int>>();
            directions.Add(new KeyValuePair<char, int>('E', stepsDir1));
            directions.Add(new KeyValuePair<char, int>('N', stepsDir2));

            int output = RobotProcessor.Clean(10, 22, directions);

            Assert.AreEqual(stepsDir1 + stepsDir2 + 1, output);
        }

        [Test]
        public void Clean_When2OppositeDirections_SkipsCommonPlaces(
            [Values(1,2,3,4)] int stepsDir1,
            [Values(2,2,3)] int stepsDir2)
        {

            var directions = new List<KeyValuePair<char, int>>();
            directions.Add(new KeyValuePair<char, int>('E', stepsDir1));
            directions.Add(new KeyValuePair<char, int>('W', stepsDir2));

            int output = RobotProcessor.Clean(10, 22, directions);

            Assert.AreEqual(Math.Max(stepsDir1, stepsDir2) + 1, output);
        }

        [Test]
        public void Clean_When4Directions_SkipsCommonPlaces()
        {

            var directions = new List<KeyValuePair<char, int>>();
            directions.Add(new KeyValuePair<char, int>('E', 4));
            directions.Add(new KeyValuePair<char, int>('N', 4));
            directions.Add(new KeyValuePair<char, int>('W', 4));
            directions.Add(new KeyValuePair<char, int>('S', 4));

            int output = RobotProcessor.Clean(10, 22, directions);

            Assert.AreEqual(16, output);
        }

        [Test]
        public void Clean_When4Directions2_SkipsCommonPlaces()
        {

            var directions = new List<KeyValuePair<char, int>>();
            directions.Add(new KeyValuePair<char, int>('E', 4));
            directions.Add(new KeyValuePair<char, int>('N', 1));
            directions.Add(new KeyValuePair<char, int>('W', 3));
            directions.Add(new KeyValuePair<char, int>('S', 2));

            int output = RobotProcessor.Clean(10, 22, directions);

            Assert.AreEqual(10, output);
        }

        [Test]
        public void Clean_When4DirectionsNegative_SkipsCommonPlaces()
        {

            var directions = new List<KeyValuePair<char, int>>();
            directions.Add(new KeyValuePair<char, int>('E', 4));
            directions.Add(new KeyValuePair<char, int>('N', 1));
            directions.Add(new KeyValuePair<char, int>('W', 3));
            directions.Add(new KeyValuePair<char, int>('S', 2));

            int output = RobotProcessor.Clean(-10, -22, directions);

            Assert.AreEqual(10, output);
        }

    }
}
