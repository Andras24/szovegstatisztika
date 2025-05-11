using System;
using SZOVEGSTATISZTIKA_GPWIDG_HEGEDUS.Models;
using System.Text.RegularExpressions;
using System.Linq;

namespace SZOVEGSTATISZTIKA_GPWIDG_HEGEDUS.BACKEND.Data
{
    public class TextStatsService : ITextStatsService
    {
        public TextStatsResult Analyze(TextStatsInput input)
        {
            var text = input.Text ?? "";
            var words = Regex.Split(text, @"\W+").Where(w => !string.IsNullOrWhiteSpace(w)).ToList();
            var sentences = Regex.Split(text, @"[.!?]").Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

            var wordCount = words.Count;
            var charCount = text.Count(c => !char.IsWhiteSpace(c));
            var mostCommon = words.GroupBy(w => w.ToLower())
                                  .OrderByDescending(g => g.Count())
                                  .Take(5)
                                  .ToDictionary(g => g.Key, g => g.Count());
            var avgSentenceLen = sentences.Count > 0 ? (double)wordCount / sentences.Count : wordCount;
            var avgWordLen = wordCount > 0 ? words.Average(w => w.Length) : 0;

            return new TextStatsResult
            {
                WordCount = wordCount,
                CharacterCount = charCount,
                MostCommonWords = mostCommon,
                AverageSentenceLength = avgSentenceLen,
                AverageWordLength = avgWordLen
            };
        }
    }
}
