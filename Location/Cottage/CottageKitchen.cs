public class CottageKitchen : ILocation
{
    public static readonly CottageKitchen Instance = new ();
    public string Name => "";
    private readonly Menu _menu = new ();
    public Menu LocationMenu => GetMenu();
    public string Description => GetDescription();

    private CottageKitchen()
    {
        MenuItem toEntrance = new ("Return to Entrance", ToEntrance);
        _menu.AddItem(toEntrance);
    }

    private Menu GetMenu()
    {
        return _menu;
    }

    private string GetDescription() {
        DisplayLocation();
        return "";
    }
    private void DisplayLocation()
    {
        ConsoleColor orig = Console.ForegroundColor;
        Narrator.WriteLine("-----------");
        Narrator.Write("| ");
        Console.ForegroundColor = ConsoleColor.Green;
        Narrator.Write("Kitchen");
        Console.ForegroundColor = orig;
        Narrator.WriteLine(" |");
        Narrator.WriteLine("-----------\n");
        Narrator.Write("You in a cozy ");
        Console.ForegroundColor = ConsoleColor.Green;
        Narrator.Write("kitchen");
        Console.ForegroundColor = orig;
        Narrator.Write(". ");
        
        Narrator.WriteLine("");
    }

    private void ToEntrance()
    {
        GameState.Instance.SetLocation(Cottage.Instance);
    }

    
}