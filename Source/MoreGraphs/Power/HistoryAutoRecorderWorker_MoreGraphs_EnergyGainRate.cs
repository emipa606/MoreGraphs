using RimWorld;
using Verse;

namespace MoreGraphs.Power
{
    public class HistoryAutoRecorderWorker_MoreGraphs_EnergyGainRate : HistoryAutoRecorderWorker
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
                    num += item.CurrentEnergyGainRate() / CompPower.WattsToWattDaysPerTick;
                }
            }

            return num;
        }
    }
}