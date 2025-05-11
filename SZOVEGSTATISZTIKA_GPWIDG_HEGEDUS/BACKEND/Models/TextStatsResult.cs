using System;

using System.Collections.Generic;

namespace SZOVEGSTATISZTIKA_GPWIDG_HEGEDUS.BACKEND.Models
{
    public class TextStatsResult
    {
        public int WordCount { get; set; }
        public int CharacterCount { get; set; }
        public Dictionary<string, int> MostCommonWords { get; set; }
        public double AverageSentenceLength { get; set; }
        public double AverageWordLength { get; set; }
    }
}