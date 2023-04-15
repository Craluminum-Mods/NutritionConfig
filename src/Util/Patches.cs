using System.Collections.Generic;
using NutritionConfig.Configuration;
using Vintagestory.API.Common;

namespace NutritionConfig;

public static class Patches
{
    public static void ApplyPatches(this ICoreAPI api, Config config)
    {
        if (config.NutritionProps?.Count == 0) return;

        foreach (var val in config.NutritionProps)
        {
            var obj = api.GetCollectible(val);
            if (obj != null) obj.NutritionProps = new ShortFoodNutritionProperties().Convert(val.Value);
        }
    }

    public static Config FillConfig(this ICoreAPI api, Config config)
    {
        if (config.NutritionProps == null) return config;

        foreach (var obj in api.World.Collectibles)
        {
            if (obj.Code == null) continue;
            if (obj.NutritionProps == null) continue;
            if (config.NutritionProps.ContainsKey(obj.Code.ToString())) continue;

            config.NutritionProps.Add(obj.Code.ToString(), new ShortFoodNutritionProperties().Convert(obj.NutritionProps));
        }

        return config;
    }

    public static CollectibleObject GetCollectible<T>(this ICoreAPI api, KeyValuePair<string, T> val)
    {
        return api.World.GetItem(new AssetLocation(val.Key)) as CollectibleObject ?? api.World.GetBlock(new AssetLocation(val.Key));
    }
}