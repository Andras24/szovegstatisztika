using System.Linq;

public class TextAnalysisRepository : ITextAnalysisRepository
{
    public TextAnalysisResult Analyze(string text)
    {
        var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var wordCount = words.Length;
        var characterCount = text.Length;

        var wordFrequency = words.GroupBy(w => w.ToLower())
                                 .OrderByDescending(g => g.Count())
                                 .Take(5)
                                 .ToDictionary(g => g.Key, g => g.Count());

        double averageSentenceLength = text.Split('.', StringSplitOptions.RemoveEmptyEntries)
                                           .Average(s => s.Split(' ').Length);
        double readabilityIndex = averageSentenceLength / wordCount;

        return new TextAnalysisResult
        {
            WordCount = wordCount,
            CharacterCount = characterCount,
            MostCommonWords = wordFrequency,
            ReadabilityIndex = readabilityIndex
        };
    }
}
