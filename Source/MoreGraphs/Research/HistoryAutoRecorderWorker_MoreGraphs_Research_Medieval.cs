using System.Linq;
using RimWorld;
using Verse;

namespace MoreGraphs.Research;

public class HistoryAutoRecorderWorker_MoreGraphs_Research_Medieval : HistoryAutoRecorderWorker
{
    public override float PullRecord()
    {
        return DefDatabase<ResearchProjectDef>.AllDefsListForReading
            .Where(def => def.techLevel == TechLevel.Medieval).Select(def => def.ProgressReal).Sum();
    }
}