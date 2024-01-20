using System.Text.Json.Serialization;

namespace DrinksInfo.Model
{
    internal record class DrinksJsonObject([property: JsonPropertyName("drinks")] List<DrinkCategory> DrinkCategories);
}
