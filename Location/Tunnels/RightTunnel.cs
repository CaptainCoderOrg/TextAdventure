public class RightTunnel : ILocation
{
    public static readonly RightTunnel Instance = new RightTunnel();
    public string Description => "You take a sharp right turn down the tunnel and walk for 2 miles.";

    public IItem TunnelKey { get; } = new TunnelKey();

    public string Name => "Right Tunnel";
    public bool hasHiddenKey => GameState.Instance.Player.Inventory.Contains(TunnelKey);

    public Menu LocationMenu { get; }

    public RightTunnel()
    {
        LocationMenu = new Menu();
        MenuItem TurnAround = new MenuItem("Turn Around", GoTurnAround);
        LocationMenu.AddItem(TurnAround);
        MenuItem WaterFall = new MenuItem("Jump in the waterfall.", GoWaterFall);
        LocationMenu.AddItem(WaterFall);
        MenuItem SecretDoor = new MenuItem("Open the secret door.", GoSecretDoor);
        LocationMenu.AddItem(SecretDoor);
    }

    private void GoTurnAround()
    {
        Narrator.WriteLine("You turn around and head back.");
        GameState.Instance.SetLocation(TunnelEntrance.Instance);
    }

    private void GoWaterFall()
    {
        Narrator.WriteLine("You jump in the waterfall.");
        GameState.Instance.SetLocation(Waterfall.Instance);

    }

    private void GoSecretDoor()
    {
        Narrator.WriteLine("You try and open the secret door.");
        if (hasHiddenKey)
        {
            Narrator.WriteLine("You use your key to open the secret door.");
            // TODO: Set next location
        }
        else
        {
            Narrator.WriteLine("The door is locked!!! You must go find the key.");
            Narrator.WriteLine("Hint: The key is submerged deep underwater.");
            GameState.Instance.SetLocation(RightTunnel.Instance);
        }
    }
}