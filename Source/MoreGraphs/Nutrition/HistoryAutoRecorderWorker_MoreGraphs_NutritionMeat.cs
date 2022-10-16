using RimWorld;

namespace MoreGraphs.Nutrition;

internal class
    HistoryAutoRecorderWorker_MoreGraphs_NutritionMeat : HistoryAutoRecorderWorker_MoreGraphs_NutritionCountBase
{
    public HistoryAutoRecorderWorker_MoreGraphs_NutritionMeat()
        : base(ThingCategoryDefOf.MeatRaw)
    {
    }
}