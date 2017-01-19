using System;

namespace FuzzyStringMatch
{
    [Flags]
    public enum FuzzyAlgorithmType
    {
        HammingDistance = 1,
        JaccardIndex = 2,
        JaroDistance = 4,
        JaroWinklerDistance = 8,
        LevenshteinDistance = 16
    }
}
