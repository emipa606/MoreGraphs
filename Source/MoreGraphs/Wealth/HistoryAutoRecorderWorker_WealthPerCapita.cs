using System;
using System.Linq;
using RimWorld;
using Verse;

namespace MoreGraphs;

public class HistoryAutoRecorderWorker_WealthPerCapita : HistoryAutoRecorderWorker
{
    public override float PullRecord()
    {
        var total = 0f;
        var maps = Find.Maps;
        foreach (var map in maps)
        {
            if (map.IsPlayerHome)
            {
                total += map.wealthWatcher.WealthTotal;
            }
        }

        var colonistCount =
            Math.Max(PawnsFinder.AllMapsCaravansAndTravelingTransportPods_Alive_FreeColonists_NoLodgers.Count(), 1);

        return total / colonistCount;
    }
}