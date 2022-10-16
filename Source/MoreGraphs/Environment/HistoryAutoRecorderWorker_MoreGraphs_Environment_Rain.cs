using System.Linq;
using RimWorld;
using Verse;

namespace MoreGraphs.Environment;

internal class
    HistoryAutoRecorderWorker_MoreGraphs_Environment_Rain : HistoryAutoRecorderWorker
{
    public override float PullRecord()
    {
        var homeMap = Find.Maps.Where(map => map.IsPlayerHome)
            .OrderByDescending(map => map.wealthWatcher.WealthTotal)
            .FirstOrDefault();

        if (homeMap == null)
        {
            return 0;
        }

        return homeMap.weatherManager.SnowRate > 0 ? 0 : homeMap.weatherManager.RainRate * 50;
    }
}