using RimWorld;

namespace MoreGraphs.Nutrition;

internal class
    HistoryAutoRecorderWorker_MoreGraphs_NutritionTotal : HistoryAutoRecorderWorker_MoreGraphs_NutritionCountBase
{
    public HistoryAutoRecorderWorker_MoreGraphs_NutritionTotal()
        : base(ThingCategoryDefOf.Foods)
    {
    }
}