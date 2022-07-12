public class TunnelEntrance : ILocation
{
    public static readonly TunnelEntrance Instance = new TunnelEntrance();
    public string Description => "You crawl down in a large tunnel. There's a fork in the tunnel.";

    public string Name => "Tunnel";
    public Menu LocationMenu { get; }


    public TunnelEntrance()
    {
        LocationMenu = new Menu();
        MenuItem TurnAround = new MenuItem("Turn Around", GoTurnAround);
        LocationMenu.AddItem(TurnAround);
        MenuItem RightTunnel = new MenuItem("Right Tunnel", GoRightTunnel);
        LocationMenu.AddItem(RightTunnel);
        MenuItem LeftTunnel = new MenuItem("Left Tunnel", GoLeftTunnel);
        LocationMenu.AddItem(LeftTunnel);
    }

    private void GoTurnAround() {
        Narrator.WriteLine("You turn around and head back.");
        GameState.Instance.SetLocation(Forest.Instance);
    }

    private void GoRightTunnel() {
        Narrator.WriteLine("You head down the right tunnel.");
        GameState.Instance.SetLocation(LeftTunnel.Instance);
    }

    private void GoLeftTunnel() {
        Narrator.WriteLine("You head down the left tunnel.");
        // TODO: Add set location for left tunnel when we make one
    }
}

