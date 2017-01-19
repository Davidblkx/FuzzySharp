using System;

namespace FuzzyStringMatch.Algorithm
{
    /// <summary>
    /// See https://en.wikipedia.org/wiki/Hamming_distance
    /// </summary>
    public class HammingDistance : IFuzzyAlgorithm
    {
        public FuzzyAlgorithmType Algorithm
        {
            get
            {
                return FuzzyAlgorithmType.HammingDistance;
            }
        }

        public double Calculate(string source, string target)
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

        public double CalcRelativeDistance(string source, string target)
        {
            double hammingDistance = Calculate(source, target);

            //the string length is the max possible result for the hamming distance algorithm
            int stringLength = source.Length;

            //Calculates the relative difference
            double relativeDistance = hammingDistance / stringLength;
            return relativeDistance;
        }

        public double CalcRelativeSimilarity(string source, string target)
        {
            return 1 - CalcRelativeDistance(source, target);
        }
    }
}
