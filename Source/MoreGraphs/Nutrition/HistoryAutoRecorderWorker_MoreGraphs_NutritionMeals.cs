using RimWorld;

namespace MoreGraphs.Nutrition;

internal class
    HistoryAutoRecorderWorker_MoreGraphs_NutritionMeals : HistoryAutoRecorderWorker_MoreGraphs_NutritionCountBase
{
    public HistoryAutoRecorderWorker_MoreGraphs_NutritionMeals()
        : base(ThingCategoryDefOf.FoodMeals)
    {
    }
}