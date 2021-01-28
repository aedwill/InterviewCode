using System.Linq;

namespace EdwardWilliams.ExampleApps.Libraries.Tests.FlipAnImageTests
{
    public static class ArrayExtensions
    {
        public static bool Matches(this int[][] source, int[][] other)
        {
            if (source != null && other != null)
            {
                // Could do this with a couple foreach loops, easier to read. 
                return source.Length == other.Length
                    && Enumerable.Range(0, source.Length).All(
                        dimension1 => 
                            source[dimension1].Length == other[dimension1].Length
                            && Enumerable.Range(0, source[dimension1].Length).All(
                                dimension2 =>
                                    source[dimension1][dimension2] == other[dimension1][dimension2]
                                )
                        )
                ;
            }

            return source == other;
        }
    }
}
