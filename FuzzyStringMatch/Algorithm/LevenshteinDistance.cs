using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyStringMatch.Algorithm
{
    /// <summary>
    /// See https://en.wikipedia.org/wiki/Levenshtein_distance
    /// </summary>
    class LevenshteinDistance : IFuzzyAlgorithm
    {
        public FuzzyAlgorithmType Algorithm
        {
            get
            {
                return FuzzyAlgorithmType.LevenshteinDistance;
            }
        }

        public double CalcRelativeDistance(string source, string target)
        {
            //Max distance possible is equal to the value of the biggest string length
            double maxDistance = Math.Max(source.Length, target.Length);
            double distance = Calculate(source, target);

            return distance / maxDistance;
        }

        public double CalcRelativeSimilarity(string source, string target)
        {
            return 1 - CalcRelativeDistance(source, target);
        }

        public double Calculate(string source, string target)
        {
            var sourceLength = source.Length;
            var targetLength = target.Length;

            var matrix = new int[sourceLength + 1, targetLength + 1];

            // If one entry is empty, return the other entry full length
            if (sourceLength == 0)
                return targetLength;

            if (targetLength == 0)
                return sourceLength;


            // Initialization of matrix with rows size source length and columns size target length
            for (var i = 0; i <= sourceLength; matrix[i, 0] = i++) { }
            for (var j = 0; j <= targetLength; matrix[0, j] = j++) { }

            // Calculate rows and columns distances
            for (var i = 1; i <= sourceLength; i++)
            {
                for (var j = 1; j <= targetLength; j++)
                {
                    var cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    matrix[i, j] = Math.Min(
                        Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                        matrix[i - 1, j - 1] + cost);
                }
            }
            // return result
            return matrix[sourceLength, targetLength];
        }
    }
}
