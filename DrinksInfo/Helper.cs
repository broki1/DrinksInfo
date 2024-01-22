using ConsoleTableExt;

namespace DrinksInfo;

internal class Helper
{

    internal static void PrintTable<T>(List<T> list) where T : class
    {
        ConsoleTableBuilder.From(list).WithFormat(ConsoleTableBuilderFormat.Alternative).ExportAndWriteLine();
    }

    internal static string FormatStringForAPI(string str)
    {
        return str.Trim().ToLower().Replace(" ", "_");
    }
}
