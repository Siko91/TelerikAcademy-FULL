using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixTraversing.Tests
{
    [TestClass]
    public class MatrixTraversingTest
    {
        static int size = 7;
        static int[,] matrix = MatrixTraversing.MatrixTraversing.InitializeMatrix(size);
        static int[,] smallExpectedMatrix = 
            {
                {1, 7, 8},
                {6, 2, 9},
                {5, 4, 3}
            };

        [TestMethod]
        public void ThereShouldntBeTwoSameElementsInMatrix()
        {
            CollectionAssert.AllItemsAreUnique(matrix);
        }

        [TestMethod]
        public void TheDiagonalLineShouldConsistOfIncreasingNumbers()
        {
            for (int i = 0; i < size; i++)
            {
                Assert.AreEqual(i + 1, matrix[i, i]);
            }
        }

        [TestMethod]
        public void SmallMatrixShouldBeCorrect()
        {
            int[,] smallMatrix = MatrixTraversing.MatrixTraversing.InitializeMatrix(3);
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Assert.AreEqual(
                        smallExpectedMatrix[r, c],
                        smallMatrix[r, c]
                        );
                }
            }

        }
    }
}
