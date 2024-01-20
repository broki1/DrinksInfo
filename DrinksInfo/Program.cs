using DrinksInfo.Model;

namespace DrinksInfo;

internal class Program
{
    static APIController apiController = new APIController();

    static async Task Main(string[] args)
    {
        await StartApplication();
    }

    static async Task StartApplication()
    {
        var endApplication = false;

        var drinkCategories = await Program.apiController.GetDrinkCategories();

        Helper.PrintTable(drinkCategories);

        Console.ReadLine();

        var drinks = await Program.apiController.GetDrinksByCategory("beer");

        Helper.PrintTable(drinks);

        Console.ReadLine();

    }
}
