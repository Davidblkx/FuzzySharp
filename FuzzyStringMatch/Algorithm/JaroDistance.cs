using System;

namespace FuzzyStringMatch.Algorithm
{
    /// <summary>
    /// See https://en.wikipedia.org/wiki/Jaro%E2%80%93Winkler_distance
    /// </summary>
    public class JaroDistance : IFuzzyAlgorithm
    {
        public FuzzyAlgorithmType Algorithm
        {
            get
            {
                return FuzzyAlgorithmType.JaroDistance;
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
            //Check arguments for null
            if (source == null || target == null)
                throw new ArgumentNullException();

            int sourceLength = source.Length;
            int targetLength = target.Length;

            char[] sourceArray = source.ToCharArray();
            char[] targetArray = target.ToCharArray();

            //If  both are empty return 1 orwise return if only one is empty return 0
            if (sourceLength == 0)
                return targetLength == 0 ? 1 : 0;

            if (targetLength == 0)
                return sourceLength == 0 ? 1 : 0;

            //Max accepted value for a letter to be considered as match
            int maxMatchDistance = Math.Max(0, (Math.Max(sourceLength, targetLength) / 2) - 1);

            //Booleans to check if char in position has match
            bool[] sourceMatches = new bool[sourceLength];
            bool[] targetMatches = new bool[targetLength];

            //Number of matches
            //A double var is used to prevent the use of a cast in the final equation
            double numMatches = 0;

            //Check each char for a match in target string
            for (int i = 0; i < sourceLength; i++)
            {
                //Where to start searching for matches
                int start = Math.Max(0, i - maxMatchDistance);

                //Where to stop searching for matches
                int end = Math.Min(targetLength - 1, i + maxMatchDistance);

                //check each char in target for a match
                for (int k = start; k <= end; k++)
                {
                    //If already found a match in position k, continue
                    if (targetMatches[k]) continue;

                    //If chars are no match continue
                    if (sourceArray[i] != targetArray[k]) continue;

                    //Set positions as match
                    sourceMatches[i] = true;
                    targetMatches[k] = true;

                    //Increment match count
                    numMatches++;

                    //Stop looking for match
                    break;
                }
            }

            if (numMatches == 0) return 0;

            //Number of transpositions
            double numTransp = 0;

            int t_position = 0; // Store target check position

            //Count transpositions
            for (int i = 0; i < sourceLength; i++)
            {
                //If it isn't a match, continue
                if (!sourceMatches[i]) continue;

                //Interate through target to find match
                for (; t_position < targetLength && !targetMatches[t_position];) t_position++;
                if (t_position >= targetLength) break;

                //If chars differ, a transposition as occur
                if (sourceArray[i] != targetArray[t_position]) numTransp++;

                t_position++;
            }

            //According to jaro algorithm, the number to use is (transpositions / 2)
            numTransp /= 2.0;

            /*
             * j = Jaro algorithm result
             * m = number of matches
             * t = number of transpositions
             * s1 = length of string 1 (source)
             * s2 = length of string 2 (target)
             * j =(m/s1 + m/s2 + (m-t)/m) * 1/3
             */
            double jaro = 
                ((numMatches / sourceLength) + 
                (numMatches / targetLength) + 
                ((numMatches - numTransp) / numMatches)) 
                / 3.0;

            return jaro;
        }
    }
}
