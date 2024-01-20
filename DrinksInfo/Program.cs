using System.Configuration;

namespace DrinksInfo;

internal class Program
{
    static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();

        var drinksInfoAPI = ConfigurationManager.AppSettings.Get("DrinkCategories");

        APIController apiController = new APIController(drinksInfoAPI);

        var drinkCategories = await apiController.GetDrinkCategories(client);
    }
}
