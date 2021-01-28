namespace EdwardWilliams.ExampleApps.Libraries.ImageHandling
{
    public interface IRotation
    {
        /// <summary>
        /// Given a binary matrix A, we want to flip the image horizontally, then invert it, and return the resulting image.
        ///
        /// To flip an image horizontally means that each row of the image is reversed.For example, flipping[1, 1, 0] horizontally results in [0, 1, 1].
        /// To invert an image means that each 0 is replaced by 1, and each 1 is replaced by 0. For example, inverting[0, 1, 1] results in [1, 0, 0].
        /// 
        /// This implementation assumes a jagged array is NOT possible and if detected an ArgumentException is thrown.
        /// </summary>
        /// <param name="imageMatrix">The incoming binary matrix.  Note this image will be modified.  Need a deep cloning version to assure non-destructive functionality.</param>
        /// <returns>The matrix flipped horizontally and inverted.</returns>
        int[][] InvertAndFlip(int[][] imageMatrix);
    }
}