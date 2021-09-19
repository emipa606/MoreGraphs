using RimWorld;

namespace MoreGraphs.Nutrition
{
    internal class
        HistoryAutoRecorderWorker_MoreGraphs_NutritionVeg : HistoryAutoRecorderWorker_MoreGraphs_NutritionCountBase
    {
        public HistoryAutoRecorderWorker_MoreGraphs_NutritionVeg()
            : base(ThingCategoryDefOf.PlantFoodRaw)
        {
        }
    }
}