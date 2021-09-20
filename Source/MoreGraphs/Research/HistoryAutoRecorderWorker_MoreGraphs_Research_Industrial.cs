using System.Linq;
using RimWorld;
using Verse;

namespace MoreGraphs.Power
{
    public class HistoryAutoRecorderWorker_MoreGraphs_Research_Industrial : HistoryAutoRecorderWorker
    {
        public override float PullRecord()
        {
            return DefDatabase<ResearchProjectDef>.AllDefsListForReading
                .Where(def => def.techLevel == TechLevel.Industrial).Select(def => def.ProgressReal).Sum();
        }
    }
}