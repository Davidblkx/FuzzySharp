using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyStringMatch.Algorithm
{
    /// <summary>
    /// See https://en.wikipedia.org/wiki/Jaro%E2%80%93Winkler_distance
    /// </summary>
    public class JaroWinklerDistance : IFuzzyAlgorithm
    {
        public FuzzyAlgorithmType Algorithm
        {
            get
            {
                return FuzzyAlgorithmType.JaroWinklerDistance;
            }
        }

        public double CalcRelativeDistance(string source, string target)
        {
            return 1 - Calculate(source, target);
        }

        public double CalcRelativeSimilarity(string source, string target)
        {
            return Calculate(source, target);
        }

        public double Calculate(string source, string target)
        {
            //Default scaling factor
            double scalingFactor = 0.1;

            //Prefix to consider, max 4
            int prefix = source.Length / 2;
            if (prefix > 4) prefix = 4;

            return Calculate(source, target, prefix, scalingFactor);
        }

        public double Calculate(string source, string target, int prefix, double scalingFactor)
        {
            var jaro = new JaroDistance();
            double jaroDistance = jaro.Calculate(source, target);

            /* 
             * jw = JaroWinkler algorithm result
             * j = JaroDistance
             * l = length of common prefix
             * p = scaling factor
             * 
             * jw = j - (l*p*(1-j))
             * 
             */
            return jaroDistance + ((prefix * scalingFactor) * (1 - jaroDistance));
        }
    }
}
