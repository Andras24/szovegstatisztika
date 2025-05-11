using System;

public class TextAnalysisResult
{
    public int WordCount { get; set; }
    public int CharacterCount { get; set; }
    public Dictionary<string, int> MostCommonWords { get; set; }
    public double ReadabilityIndex { get; set; }
}

