using DrinksInfo.Model;
using System.Configuration;
using System.Text.Json;

namespace DrinksInfo;

internal class APIController
{
    internal HttpClient client;

    // internal string API { get; init; }

    public APIController()
    {
        this.client = new HttpClient();
    }

    internal async Task<List<CategoryMenuItem>> GetDrinkCategories()
    {
        // retrieve DrinkCategories API from App.config
        var drinkCategoriesAPI = ConfigurationManager.AppSettings.Get("DrinkCategories");

        // make GET request to API, captures response body as stream
        await using var stream = await this.client.GetStreamAsync(drinkCategoriesAPI);

        // deserializes Json response stream into categoryMenu instance variable, which contains List of Category Menu Item objects
        var categoryMenu = await JsonSerializer.DeserializeAsync<CategoryMenu>(stream);

        return categoryMenu.CategoryMenuItems;
    }

    internal async Task<List<Drink>> GetDrinksByCategory(string category)
    {
        // retrieve DrinksByCategory API from App.config, appends category to end of API string
        var drinksByCategoryAPI = ConfigurationManager.AppSettings.Get("DrinksByCategory") + category;

        await using var stream = await this.client.GetStreamAsync(drinksByCategoryAPI);

        var drinkMenu = await JsonSerializer.DeserializeAsync<DrinkMenu>(stream);

        return drinkMenu.Drinks;
    }

}
