using RimWorld;
using Verse;

namespace MoreGraphs;

internal class HistoryAutoRecorderWorker_MoreGraphs_ItemCountCategoryBase(ThingCategoryDef thingCategoryDef)
    : HistoryAutoRecorderWorker
{
    public readonly ThingCategoryDef thingCategory = thingCategoryDef;

    public override float PullRecord()
    {
        var num = 0;
        foreach (var map in Find.Maps)
        {
            if (!map.IsPlayerHome)
            {
                continue;
            }

            var allCountedAmounts = map.resourceCounter.AllCountedAmounts;
            foreach (var key in allCountedAmounts.Keys)
            {
                if (key.IsWithinCategory(thingCategory))
                {
                    num += allCountedAmounts[key];
                }
            }
        }

        return num;
    }
}