using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EdwardWilliams.ExampleApps.Libraries.ImageHandling;

namespace EdwardWilliams.ExampleApps.Libraries.Tests.FlipAnImageTests
{
    [TestClass]
    public class RotationTests
    {
        private Rotation Handler;

        [TestInitialize]
        public void Initialize()
        {
            Handler = new Rotation();
        }

        [TestMethod]
        public void InvertAndFlip_CanInvertSimpleImage()
        {
            var source = new[]
            {
                new [] { 1, 1, 0},
                new [] { 1, 0, 1},
                new [] { 0, 0, 0}
            };


            var expected = new[]
            {
                new [] { 1, 0, 0},
                new [] { 0, 1, 0},
                new [] { 1, 1, 1}
            };

            var actual = Handler.InvertAndFlip(source);

            Assert.IsTrue(expected.Matches(actual));
        }

        [TestMethod]
        public void InvertAndFlip_CanInvertSimpleImageWithDifferingXDimensions()
        {
            var source = new[]
            {
                new [] { 1, 1, 1, 0},
                new [] { 0, 0, 1, 1},
                new [] { 1, 0, 1, 0}
            };

            var expected = new[]
            {
                new [] { 1, 0, 0, 0},
                new [] { 0, 0, 1, 1},
                new [] { 1, 0, 1, 0}
            };

            var actual = Handler.InvertAndFlip(source);

            Assert.IsTrue(expected.Matches(actual));
        }

        [TestMethod]
        public void InvertAndFlip_CanInvertSimpleImageWithDifferingYDimensions()
        {
            var source = new[]
            {
                new [] { 1, 1, 1},
                new [] { 1, 1, 0},
                new [] { 1, 0, 1},
                new [] { 1, 0, 0},
                new [] { 0, 1, 1},
                new [] { 0, 1, 0},
                new [] { 0, 0, 1},
                new [] { 0, 0, 0}
            };

            var expected = new[]
            {
                new [] { 0, 0, 0},
                new [] { 1, 0, 0},
                new [] { 0, 1, 0},
                new [] { 1, 1, 0},
                new [] { 0, 0, 1},
                new [] { 1, 0, 1},
                new [] { 0, 1, 1},
                new [] { 1, 1, 1}
            };

            var actual = Handler.InvertAndFlip(source);

            Assert.IsTrue(expected.Matches(actual));
        }

        [TestMethod]
        public void InvertAndFlip_CanInvertSimpleImageWithEvenHorizontalSize()
        {
            var source = new[]
            {
                new [] { 1, 1, 1, 0},
                new [] { 0, 0, 1, 1},
                new [] { 1, 0, 1, 0}
            };

            var expected = new[]
            {
                new [] { 1, 0, 0, 0},
                new [] { 0, 0, 1, 1},
                new [] { 1, 0, 1, 0}
            };

            var actual = Handler.InvertAndFlip(source);

            Assert.IsTrue(expected.Matches(actual));
        }

        [TestMethod]
        public void InvertAndFlip_JaggedArrayThrows()
        {
            var source = new[]
            {
                new [] { 1, 1, 1, 0},
                new [] { 0, 1, 1},
                new [] { 1, 0, 1, 0}
            };

            try
            {
                _ = Handler.InvertAndFlip(source);
                Assert.Fail("Should have thrown an IndexOutOfRangeException");
            }
            catch(IndexOutOfRangeException)
            {

            }
        }

        [TestMethod]
        public void InvertAndFlip_CanInvertSinglePixelImage()
        {
            var source = new[]
            {
                new [] { 1 }
            };

            var expected = new[]
            {
                new [] { 0 }
            };

            var actual = Handler.InvertAndFlip(source);

            Assert.IsTrue(expected.Matches(actual));
        }

        [TestMethod]
        public void InvertAndFlip_CanInvertEmptyArray()
        {
            var source = new[]
            {
                new int[] { }
            };

            var expected = new[]
            {
                new int[] {  }
            };

            var actual = Handler.InvertAndFlip(source);

            Assert.IsTrue(expected.Matches(actual));
        }

        [TestMethod]
        public void InvertAndFlip_CanInvertNullArray()
        {
            int[][] source = null;
            int[][] expected = null;

            var actual = Handler.InvertAndFlip(source);

            Assert.IsNull(actual);
            Assert.IsTrue(expected.Matches(actual));
        }
    }
}
