public class Waterfall : ILocation
{
    public static readonly Waterfall Instance = new Waterfall();
    public string Description => "You jump into the ice cold waterfall. The water is crystal clear. Laying on the ground is a shinny golden key.";

    public string Name => "Waterfall";

    public Menu LocationMenu { get; }

    public Waterfall()
    {
        LocationMenu = new Menu();
        MenuItem SwimToSurface = new MenuItem("Swim to surface.", GoSwimToSurface);
        LocationMenu.AddItem(SwimToSurface);
        MenuItem GetKey = new MenuItem("Swim down and get key.", GoGetKey);
        LocationMenu.AddItem(GetKey);
    }

    private void GoSwimToSurface()
    {
        Narrator.WriteLine("You see the key but can't hold your breathe for long enough so you swim back up.");
        GameState.Instance.SetLocation(RightTunnel.Instance);
    }

    private void GoGetKey()
    {
        Narrator.WriteLine("You swim down and grab the key from the bottom.");
        RightTunnel.Instance.TunnelKey.AddToInventory(GameState.Instance.Player);
        Narrator.WriteLine("You climb out of the water and back to the tunnel.");
        Narrator.WriteLine("Holding your breath for that long was deterimental to your health. But you are now stronger because of it.");
        GameState.Instance.Player.Hp--;
        GameState.Instance.Player.Level++;
        GameState.Instance.SetLocation(RightTunnel.Instance);
    }
}