using System;

namespace FuzzyStringMatch
{
    public static class HammingDistance
    {
        /// <summary>
        /// Calculates the diference between 2 strings using the HammingDistance algorithm
        /// Both strings must have the same length
        /// </summary>
        /// <param name="source">Source string to compare</param>
        /// <param name="target">Target string to compare</param>
        /// <returns>The number of differences between both strings</returns>
        public static int Calculate(string source, string target)
        {
            //Checks for null arguments
            if (source == null || target == null)
                throw new ArgumentNullException();

            //Check if both strings length match
            if (source.Length != target.Length)
                throw new Exception("Arguments length don't match");

            //Var to store the difference count between both strings
            int distance = 0;

            //Checks letter by letter and increments count
            for (int i = 0; i < source.Length; i++)
                if (source[i] != target[i])
                    distance++;

            //Returns the calculated difference
            return distance;
        }

        /// <summary>
        /// Calculates the equality between 2 strings using the HammingDistance algorithm
        /// Both strings must have the same length
        /// </summary>
        /// <param name="source">Source string to compare</param>
        /// <param name="target">Target string to compare</param>
        /// <returns>A value between 0 and 100 to represent the relative 
        /// equality between both strings, 0 - totally different, 100 exactly equal </returns>
        public static double RelativeCalculate(string source, string target)
        {
            int hammingDistance = Calculate(source, target);
            int stringLength = source.Length;

            //Calculates the relative difference
            double relativeDistance = (hammingDistance * 100.0) / stringLength;

            //Subtract to 100 to get the relative equality 
            return 100 - relativeDistance;
        }
    }
}
