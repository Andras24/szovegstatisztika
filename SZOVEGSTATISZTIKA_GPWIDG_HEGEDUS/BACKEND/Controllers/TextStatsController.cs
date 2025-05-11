using System;
using Microsoft.AspNetCore.Mvc;
using SZOVEGSTATISZTIKA_GPWIDG_HEGEDUS.Data;
using SZOVEGSTATISZTIKA_GPWIDG_HEGEDUS.BACKEND.Models;

namespace SZOVEGSTATISZTIKA_GPWIDG_HEGEDUS.BACKEND.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextStatsController : ControllerBase
    {
        private readonly ITextStatsService service;

        public TextStatsController(ITextStatsService service)
        {
            this.service = service;
        }

        [HttpPost]
        public ActionResult<TextStatsResult> Analyze([FromBody] TextStatsInput input)
        {
            var result = service.Analyze(input);
            return Ok(result);
        }
    }
}
