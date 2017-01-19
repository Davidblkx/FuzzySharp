using System;
using System.Linq;

namespace FuzzyStringMatch.Algorithm
{
    /// <summary>
    /// See https://en.wikipedia.org/wiki/Jaccard_index#Generalized_Jaccard_similarity_and_distance
    /// </summary>
    public class JaccardIndex : IFuzzyAlgorithm
    {
        public FuzzyAlgorithmType Algorithm
        {
            get
            {
                return FuzzyAlgorithmType.JaccardIndex;
            }
        }

        public double Calculate(string source, string target)
        {
            //Check for null arguments
            if (source == null || target == null)
                throw new ArgumentNullException();

            //Calculates the intersection (and operation) between source and target strings
            double andResult = source.ToCharArray().Intersect(target.ToCharArray()).Count();

            //Calculates the union (or operation) between source and target strings
            double orResult = source.ToCharArray().Union(target.ToCharArray()).Count();

            //(source & target) / (source | target)
            return andResult / orResult;
        }

        public double CalcRelativeDistance(string source, string target)
        {
            return 1 - Calculate(source, target);
        }

        public double CalcRelativeSimilarity(string source, string target)
        {
            return Calculate(source, target);
        }
    }
}
