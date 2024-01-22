using System.Text.Json.Serialization;

namespace DrinksInfo.Model
{
    internal record class Drink([property: JsonPropertyName("strDrink")] string Name, [property: JsonPropertyName("idDrink")] string Id);
}
