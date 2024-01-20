using System.Text.Json.Serialization;

namespace DrinksInfo.Model;

internal record class Drink([property: JsonPropertyName("strDrink")] string DrinkName);