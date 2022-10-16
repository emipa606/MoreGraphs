using RimWorld;
using Verse;

namespace MoreGraphs.Power;

public class HistoryAutoRecorderWorker_MoreGraphs_StoredEnergy : HistoryAutoRecorderWorker
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

            foreach (var item in map.powerNetManager.AllNetsListForReading)
            {
                num += item.CurrentStoredEnergy();
            }
        }

        return num;
    }
}