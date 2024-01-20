using DrinksInfo.Model;
using System.Text.Json;

namespace DrinksInfo;

internal class APIController
{
    internal string API { get; init; }

    public APIController(string API)
    {
        this.API = API;
    }

    internal async Task<List<DrinkCategory>> GetDrinkCategories(HttpClient client)
    {
        // captures response body as stream
        await using var stream = await client.GetStreamAsync(this.API);

        // deserializes Json into drinksJsonObject instance variable, which contains List of Drink Category objects
        var drinksJsonObject = await JsonSerializer.DeserializeAsync<DrinksJsonObject>(stream);

        return drinksJsonObject.DrinkCategories;
    }

}
