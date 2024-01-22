using DrinksInfo.Model;
using System.Configuration;
using System.Text.Json;

namespace DrinksInfo;

internal class DrinkService
{
    internal static async Task<List<Category>> GetCategories()
    {
        // create HttpClient object, clear Accept headers, set Accept to json format
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        // store DrinkInfo categories API in string var
        var drinkCategoriesAPI = ConfigurationManager.AppSettings.Get("DrinkCategories");

        // capture API response in string var
        var json = await client.GetStringAsync(drinkCategoriesAPI);

        // deserialize json into CategoryMenu object
        var categories = JsonSerializer.Deserialize<CategoryMenu>(json).Categories;

        TableVisualizerEngine.DisplayTable(categories, "Category Menu");

        return categories;
    }

    internal static async Task<List<Drink>> GetDrinks(string category)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        var drinksAPI = ConfigurationManager.AppSettings.Get("GetDrinks") + category;

        var json = await client.GetStringAsync(drinksAPI);

        var drinks = JsonSerializer.Deserialize<DrinkMenu>(json);

        TableVisualizerEngine.DisplayTable(drinks.Drinks, "Drink Menu (ID)");

        return drinks.Drinks;
    }

    internal static async Task GetDrink(string drink)
    {

    }

}
