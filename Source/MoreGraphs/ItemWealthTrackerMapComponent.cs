using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreGraphs;

public class ItemWealthTrackerMapComponent : MapComponent
{
    private const int cacheTickInterval = 5000;
    private readonly Dictionary<string, WealthCategory> thingCategoryMap;

    private int lastUpdatedTick = -100000;

    private Dictionary<WealthCategory, float> latestItemWealthByCategory;

    public ItemWealthTrackerMapComponent(Map map)
        : base(map)
    {
        thingCategoryMap = GetThingCategoyMap();
    }

    public Dictionary<WealthCategory, float> ItemWealthByCategory
    {
        get
        {
            if (Find.TickManager.TicksGame - lastUpdatedTick <= 5000)
            {
                return latestItemWealthByCategory;
            }

            lastUpdatedTick = Find.TickManager.TicksGame;
            latestItemWealthByCategory = GetWealthByCategory();

            return latestItemWealthByCategory;
        }
    }

    private Dictionary<WealthCategory, float> GetWealthByCategory()
    {
        var dictionary = new Dictionary<WealthCategory, float>();
        foreach (WealthCategory value in Enum.GetValues(typeof(WealthCategory)))
        {
            dictionary[value] = 0f;
        }

        var list = new List<Thing>();
        ThingOwnerUtility.GetAllThingsRecursively(map, ThingRequest.ForGroup(ThingRequestGroup.HaulableEver), list,
            false, delegate(IThingHolder thingHolder)
            {
                var result = true;
                if (thingHolder is PassingShip)
                {
                    result = false;
                }
                else
                {
                    if (thingHolder is Pawn pawn && pawn.Faction != Faction.OfPlayer)
                    {
                        result = false;
                    }
                }

                return result;
            });
        foreach (var item in list)
        {
            if (item.SpawnedOrAnyParentSpawned && !item.PositionHeld.Fogged(map))
            {
                dictionary[GetWealthCategory(item.def.FirstThingCategory)] += item.MarketValue * item.stackCount;
            }
        }

        return dictionary;
    }

    private WealthCategory GetWealthCategory(ThingCategoryDef thingCategoryDef)
    {
        while (thingCategoryDef != null)
        {
            if (thingCategoryMap.ContainsKey(thingCategoryDef.defName))
            {
                return thingCategoryMap[thingCategoryDef.defName];
            }

            thingCategoryDef = thingCategoryDef.parent;
        }

        return WealthCategory.Other;
    }

    private Dictionary<string, WealthCategory> GetThingCategoyMap()
    {
        return new Dictionary<string, WealthCategory>
        {
            ["Foods"] = WealthCategory.Food,
            ["Apparel"] = WealthCategory.Clothing_Armor,
            ["BodyParts"] = WealthCategory.Medical_Drugs,
            ["Medicine"] = WealthCategory.Medical_Drugs,
            ["Drugs"] = WealthCategory.Medical_Drugs,
            ["ResourcesRaw"] = WealthCategory.Materials,
            ["Textiles"] = WealthCategory.Materials,
            ["Corpses"] = WealthCategory.Materials,
            ["Weapons"] = WealthCategory.Weapons,
            ["Manufactured"] = WealthCategory.Manufactured,
            ["Buildings"] = WealthCategory.Manufactured,
            ["Items"] = WealthCategory.Manufactured
        };
    }
}