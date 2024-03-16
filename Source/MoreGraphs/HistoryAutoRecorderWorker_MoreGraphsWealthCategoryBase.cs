using RimWorld;
using Verse;

namespace MoreGraphs;

internal class HistoryAutoRecorderWorker_MoreGraphsWealthCategoryBase(WealthCategory wealthCategory)
    : HistoryAutoRecorderWorker
{
    public override float PullRecord()
    {
        var num = 0f;
        foreach (var map in Find.Maps)
        {
            if (!map.IsPlayerHome)
            {
                continue;
            }

            var itemWealthByCategory = map.GetComponent<ItemWealthTrackerMapComponent>().ItemWealthByCategory;
            num += itemWealthByCategory[wealthCategory];
        }

        return num;
    }
}