using System;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/text-analysis")]
public class TextAnalysisController : ControllerBase
{
    private readonly ITextAnalysisRepository repo;

    public TextAnalysisController(ITextAnalysisRepository repo)
    {
        this.repo = repo;
    }

    [HttpPost]
    public ActionResult<TextAnalysisResult> AnalyzeText([FromBody] string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return BadRequest("A szöveg nem lehet üres!");

        var analysis = repo.Analyze(text);
        return Ok(analysis);
    }
}

