using System;

using SZOVEGSTATISZTIKA_GPWIDG_HEGEDUS.BACKEND.Models;

namespace SZOVEGSTATISZTIKA_GPWIDG_HEGEDUS.Data

{
    public interface ITextStatsService
    {
        TextStatsResult Analyze(TextStatsInput input);
    }
}
