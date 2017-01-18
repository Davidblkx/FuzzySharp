

namespace FuzzyStringMatch.StringExtensions
{
    public static class Extensions
    {
        /// <summary>
        /// Calculates the diference between 2 strings using the HammingDistance algorithm
        /// Both strings must have the same length
        /// </summary>
        /// <param name="source">Source string to compare</param>
        /// <param name="target">Target string to compare</param>
        /// <returns>The number of differences between both strings</returns>
        public static int HammingDistanceCalculate(this string source, string target)
        {
            return HammingDistance.Calculate(source, target);
        }

        /// <summary>
        /// Calculates the equality between 2 strings using the HammingDistance algorithm
        /// Both strings must have the same length
        /// </summary>
        /// <param name="source">Source string to compare</param>
        /// <param name="target">Target string to compare</param>
        /// <returns>A value between 0 and 100 to represent the relative 
        /// equality between both strings, 0 - totally different, 100 exactly equal </returns>
        public static double HammingDistanceRelative(this string source, string target)
        {
            return HammingDistance.RelativeCalculate(source, target);
        }
    }
}
