using System.Configuration;
using System.Net.Http;

namespace DrinksInfo;

internal class Program
{
    static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();

        client.DefaultRequestHeaders.Accept.Clear();

        await GetDrinkCategories(client);
    }

    static async Task GetDrinkCategories(HttpClient client)
    {
        var drinkCategoriesAPI = ConfigurationManager.AppSettings.Get("DrinkCategories");

        var drinkCategories = await client.GetStringAsync(drinkCategoriesAPI);

        Console.WriteLine(drinkCategories);
    }
}
