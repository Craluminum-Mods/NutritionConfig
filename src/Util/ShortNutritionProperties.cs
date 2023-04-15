using Vintagestory.API.Common;

namespace NutritionConfig;

public class ShortFoodNutritionProperties
{
    public EnumFoodCategory FoodCategory;
    public float Satiety;
    public float SaturationLossDelay;
    public float Health;
    public float Intoxication { get; set; }

    public FoodNutritionProperties Convert(ShortFoodNutritionProperties from)
    {
        if (from == null) return null;
        return new()
        {
            FoodCategory = from.FoodCategory,
            Satiety = from.Satiety,
            SaturationLossDelay = from.SaturationLossDelay,
            Health = from.Health,
            Intoxication = from.Intoxication,
        };
    }

    public ShortFoodNutritionProperties Convert(FoodNutritionProperties from)
    {
        if (from == null) return null;
        return new()
        {
            FoodCategory = from.FoodCategory,
            Satiety = from.Satiety,
            SaturationLossDelay = from.SaturationLossDelay,
            Health = from.Health,
            Intoxication = from.Intoxication,
        };
    }
}