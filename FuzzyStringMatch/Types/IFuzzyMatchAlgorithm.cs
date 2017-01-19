using System;
using System.Collections.Generic;
using System.Linq;
namespace FuzzyStringMatch
{
    /// <summary>
    /// Interface for a Fuzzy string algorithm, similarity
    /// </summary>
    public interface IFuzzyAlgorithm
    {
        /// <summary>
        /// The algorithm type
        /// </summary>
        FuzzyAlgorithmType Algorithm { get; }
        /// <summary>
        /// Basic calculation, returns the default algorithm value
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        double Calculate(string source, string target);
        /// <summary>
        /// Returns a value between 0 and 1, where 0 represents a equal string pair
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        double CalcRelativeDistance(string source, string target);
        /// <summary>
        /// Returns a value between 0 and 1, where 1 represents a equal string pair
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        double CalcRelativeSimilarity(string source, string target);
    }
}
