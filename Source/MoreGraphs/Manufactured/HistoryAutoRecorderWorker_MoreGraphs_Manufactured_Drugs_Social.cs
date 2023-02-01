using RimWorld;
using Verse;

namespace MoreGraphs.Manufactured;

internal class
    HistoryAutoRecorderWorker_MoreGraphs_Manufactured_Drugs_Social :
        HistoryAutoRecorderWorker_MoreGraphs_ItemCountCategoryBase
{
    public HistoryAutoRecorderWorker_MoreGraphs_Manufactured_Drugs_Social()
        : base(ThingCategoryDefOf.Drugs)
    {
    }

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
                if (key.IsWithinCategory(thingCategory) && key.ingestible.drugCategory == DrugCategory.Social)
                {
                    num += allCountedAmounts[key];
                }
            }
        }

        return num;
    }
}