using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EdwardWilliams.ExampleApps.Libraries.Tests.FlipAnImageTests
{
    [TestClass]
    public class ArrayExtensionTests
    {
        [TestMethod]
        public void Matches_NullArraysMatch()
        {
            Assert.IsTrue(((int[][])null).Matches(null));
        }

        [TestMethod]
        public void Matches_NullArrayDoesntMatchNonNullArray()
        {
            Assert.IsFalse(((int[][])null).Matches(new[] { new[] { 1, 2 }, new[] { 3, 4 }}));
        }

        [TestMethod]
        public void Matches_TwoLikeArraysMatch()
        {
            var array1 = new[] { new[] { 1, 2 }, new[] { 3, 4 }};
            var array2 = (int[][]) array1.Clone();

            Assert.IsTrue(array1.Matches(array2));
        }

        [TestMethod]
        public void Matches_TwoUnlikeArraysDontMatch()
        {
            var array1 = new[] { new[] { 1, 2 }, new[] { 3, 4 } };
            var array2 = new[] { new[] { 1, 2 }, new[] { 3, 5 } };

            Assert.IsFalse(array1.Matches(array2));
        }

        [TestMethod]
        public void Matches_TwoUnlikeArraysDontMatchIfDifferenceAtStart()
        {
            var array1 = new[] { new[] { 0, 2 }, new[] { 3, 4 } };
            var array2 = new[] { new[] { 1, 2 }, new[] { 3, 4 } };

            Assert.IsFalse(array1.Matches(array2));
        }

        [TestMethod]
        public void Matches_SimilarJaggedArraysDontMatch()
        {
            var array1 = new[] { new[] { 1, 2 }, new[] { 3, 4 } };
            var array2 = new[] { new[] { 1, 2 }, new[] { 3, 4, 5 } };

            Assert.IsFalse(array1.Matches(array2));
        }

        [TestMethod]
        public void Matches_JaggedArraysMatch()
        {
            var array1 = new[] { new[] { 0, 2 }, new[] { 3, 4, 5 } };
            var array2 = new[] { new[] { 0, 2 }, new[] { 3, 4, 5 } };

            Assert.IsTrue(array1.Matches(array2));
        }

        [TestMethod]
        public void Matches_NullComparingToArrayFailsDoesNotThrow()
        {
            var array1 = new[] { new[] { 0, 2 }, new[] { 3, 4 } };
            int[][] array2 = null;

            Assert.IsFalse(array1.Matches(array2));
        }

        [TestMethod]
        public void Matches_NullComparingArrayFailsDoesNotThrow()
        {
            int[][] array1 = null;
            var array2 = new[] { new[] { 0, 2 }, new[] { 3, 4 } };

            Assert.IsFalse(array1.Matches(array2));
        }
    }
}