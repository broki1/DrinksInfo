namespace DrinksInfo;

internal class Program
{
    static async Task Main(string[] args)
    {
        var category = await UserInput.GetCategoryInput();

        var drink = await UserInput.GetDrinkInput(category);

        DrinkService.GetDrink(drink);
    }
}
