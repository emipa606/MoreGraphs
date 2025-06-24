using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreGraphs;

public class ItemWealthTrackerMapComponent(Map map) : MapComponent(map)
{
    private const int CacheTickInterval = 5000;
    private readonly Dictionary<string, WealthCategory> thingCategoryMap = getThingCategoryMap();

    private int lastUpdatedTick = -100000;

    private Dictionary<WealthCategory, float> latestItemWealthByCategory;

    public Dictionary<WealthCategory, float> ItemWealthByCategory
    {
        get
        {
            if (Find.TickManager.TicksGame - lastUpdatedTick <= CacheTickInterval)
            {
                return latestItemWealthByCategory;
            }

            lastUpdatedTick = Find.TickManager.TicksGame;
            latestItemWealthByCategory = getWealthByCategory();

            return latestItemWealthByCategory;
        }
    }

    private Dictionary<WealthCategory, float> getWealthByCategory()
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
                var result = !(thingHolder is PassingShip ||
                               thingHolder is Pawn pawn && pawn.Faction != Faction.OfPlayer);

                return result;
            });
        foreach (var item in list)
        {
            if (item.SpawnedOrAnyParentSpawned && !item.PositionHeld.Fogged(map))
            {
                dictionary[getWealthCategory(item.def.FirstThingCategory)] += item.MarketValue * item.stackCount;
            }
        }

        return dictionary;
    }

    private WealthCategory getWealthCategory(ThingCategoryDef thingCategoryDef)
    {
        while (thingCategoryDef != null)
        {
            if (thingCategoryMap.TryGetValue(thingCategoryDef.defName, out var category))
            {
                return category;
            }

            thingCategoryDef = thingCategoryDef.parent;
        }

        return WealthCategory.Other;
    }

    private static Dictionary<string, WealthCategory> getThingCategoryMap()
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