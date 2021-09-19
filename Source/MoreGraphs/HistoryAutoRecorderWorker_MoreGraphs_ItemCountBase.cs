using RimWorld;
using Verse;

namespace MoreGraphs
{
    internal class HistoryAutoRecorderWorker_MoreGraphs_ItemCountBase : HistoryAutoRecorderWorker
    {
        private readonly ThingDef thingDef;

        public HistoryAutoRecorderWorker_MoreGraphs_ItemCountBase(ThingDef thingDef)
        {
            this.thingDef = thingDef;
        }

        public override float PullRecord()
        {
            var num = 0;
            foreach (var map in Find.Maps)
            {
                if (!map.IsPlayerHome)
                {
                    continue;
                }

                var allCountedAmounts = map.resourceCounter.AllCountedAmounts;
                num += allCountedAmounts[thingDef];
            }

            return num;
        }
    }
}