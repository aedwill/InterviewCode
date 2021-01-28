using System;

namespace EdwardWilliams.ExampleApps.Libraries.ImageHandling
{
    public class Rotation : IRotation
    {
        /// <summary>
        /// Given a binary matrix A, we want to flip the image horizontally, then invert it, and return the resulting image.
        ///
        /// To flip an image horizontally means that each row of the image is reversed.For example, flipping[1, 1, 0] horizontally results in [0, 1, 1].
        /// To invert an image means that each 0 is replaced by 1, and each 1 is replaced by 0. For example, inverting[0, 1, 1] results in [1, 0, 0].
        /// 
        /// This implementation assumes a jagged array is NOT possible and if detected an OutOfRange exception is thrown.  Trading error checking for performance.
        /// </summary>
        /// <param name="imageMatrix">The incoming binary matrix.  Note this image will be modified.  Need a deep cloning version to assure non-destructive functionality.</param>
        /// <returns>The matrix flipped horizontally and inverted.</returns>
        public int[][] InvertAndFlip(int[][] imageMatrix)
        {
            if (imageMatrix == null)
            {
                return null;
            }

            int arrayLength = imageMatrix[0].Length;

            foreach (var row in imageMatrix)
            {
                for (int col = 0; col < (arrayLength + 1) / 2; ++col)
                {
                    int tmp = row[col] ^ 1;
                    row[col] = row[arrayLength - 1 - col] ^ 1;
                    row[arrayLength - 1 - col] = tmp;
                }
            }

            return imageMatrix;
        }
    }
}
