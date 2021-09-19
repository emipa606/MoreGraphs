using Verse;

namespace MoreGraphs.Nutrition
{
    internal class
        HistoryAutoRecorderWorker_MoreGraphs_NutritionAnimalProd :
            HistoryAutoRecorderWorker_MoreGraphs_NutritionCountBase
    {
        public HistoryAutoRecorderWorker_MoreGraphs_NutritionAnimalProd()
            : base(ThingCategoryDef.Named("AnimalProductRaw"))
        {
        }
    }
}