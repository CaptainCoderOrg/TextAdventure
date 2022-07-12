public class LeftTunnel : ILocation
{
    public static readonly LeftTunnel Instance = new LeftTunnel();
    public string Description => "You take a sharp right turn down the tunnel and walk for 2 miles.";

    public string Name => "Right Tunnel";

    public Menu LocationMenu { get; }

    public LeftTunnel()
    {
        LocationMenu = new Menu();
        MenuItem TurnAround = new MenuItem("Turn Around", GoTurnAround);
        LocationMenu.AddItem(TurnAround);
        MenuItem DigNew = new MenuItem("Dig New", DigNewTunnel);
        LocationMenu.AddItem(DigNew);
    }

    private void GoTurnAround()
    {
        Narrator.WriteLine("You turn around and head back.");
        GameState.Instance.SetLocation(TunnelEntrance.Instance);
    }

    private void DigNewTunnel()
    {
        Narrator.WriteLine("You start to dig your own tunnel but it colapses and you die.");
    }

}