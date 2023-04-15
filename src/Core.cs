using NutritionConfig.Configuration;
using Vintagestory.API.Common;

[assembly: ModInfo("Nutrition Config",
    Authors = new[] { "Craluminum2413" })]

namespace NutritionConfig;

class Core : ModSystem
{
    public override bool ShouldLoad(EnumAppSide forSide) => forSide == EnumAppSide.Server;

    public override void AssetsFinalize(ICoreAPI api)
    {
        // Reading it twice because it creates empty dictionary on first load
        ModConfig.ReadConfig(api);
        ModConfig.ReadConfig(api);
        api.World.Logger.Event("started 'Nutrition Config' mod");
    }
}