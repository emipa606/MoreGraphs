using RimWorld;
using Verse;

namespace MoreGraphs.Manufactured;

internal class
    HistoryAutoRecorderWorker_MoreGraphs_Manufactured_Drugs_Hard() :
    HistoryAutoRecorderWorker_MoreGraphs_ItemCountCategoryBase(ThingCategoryDefOf.Drugs)
{
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
                if (key.IsWithinCategory(thingCategory) && key.IsIngestible &&
                    key.ingestible?.drugCategory == DrugCategory.Hard)
                {
                    num += allCountedAmounts[key];
                }
            }
        }

        return num;
    }
}