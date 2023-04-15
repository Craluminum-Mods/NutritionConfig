using System.Collections.Generic;
using System.Linq;
using Vintagestory.API.Common;
using static System.Enum;

namespace NutritionConfig.Configuration
{
    public class Config
    {
        public readonly Dictionary<int, string> FoodCategories = GetValues(typeof(EnumFoodCategory))
            .Cast<EnumFoodCategory>()
            .ToDictionary(t => (int)t, t => t.ToString());

        public Dictionary<string, ShortFoodNutritionProperties> NutritionProps = new() { };

        public Config() { }
        public Config(Config previousConfig)
        {
            FoodCategories = previousConfig.FoodCategories;

            foreach (var val in previousConfig.NutritionProps)
            {
                if (NutritionProps.ContainsKey(val.Key)) continue;
                NutritionProps.Add(val.Key, val.Value);
            }
        }
    }
}
