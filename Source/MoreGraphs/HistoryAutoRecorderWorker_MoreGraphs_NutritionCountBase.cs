using RimWorld;
using Verse;

namespace MoreGraphs;

internal class HistoryAutoRecorderWorker_MoreGraphs_NutritionCountBase(ThingCategoryDef thingCategoryDef)
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

            var allCountedAmounts = map.resourceCounter.AllCountedAmounts;
            foreach (var item in allCountedAmounts)
            {
                if (!item.Key.IsWithinCategory(thingCategoryDef))
                {
                    continue;
                }

                var statValueAbstract = item.Key.GetStatValueAbstract(StatDefOf.Nutrition);
                num += statValueAbstract * item.Value;
            }
        }

        return num;
    }
}