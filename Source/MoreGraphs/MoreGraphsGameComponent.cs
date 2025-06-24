using System.Linq;
using Verse;

namespace MoreGraphs;

public class MoreGraphsGameComponent : GameComponent
{
    public MoreGraphsGameComponent(Game game)
    {
    }

    public override void LoadedGame()
    {
        base.LoadedGame();
        fixHistoryRecorderGroups();
    }

    private static void fixHistoryRecorderGroups()
    {
        var num = 0;
        foreach (var item in Find.History.Groups())
        {
            foreach (var recorder in item.recorders)
            {
                var num2 = recorder.records.Count * recorder.def.recordTicksFrequency;
                if (num2 > num)
                {
                    num = num2;
                }
            }
        }

        foreach (var item2 in Find.History.Groups())
        {
            foreach (var recorder2 in item2.recorders)
            {
                var num3 = recorder2.records.Count * recorder2.def.recordTicksFrequency;
                var num4 = num - num3;
                var count = num4 / recorder2.def.recordTicksFrequency;
                var collection = recorder2.records.ListFullCopy();
                recorder2.records.Clear();
                recorder2.records.AddRange(Enumerable.Repeat(0f, count));
                recorder2.records.AddRange(collection);
            }
        }
    }
}