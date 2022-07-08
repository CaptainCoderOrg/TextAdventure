public class TunnelEntrance : ILocation
{
    public static readonly TunnelEntrance Instance = new TunnelEntrance();
    public string Description => "You crawl down in a large tunnel. There's a fork in the tunnel.";

    public string Name => "Tunnel";
    // private List<string> options;
    public Menu LocationMenu { get; }


    public TunnelEntrance()
    {
        LocationMenu = new Menu();
        MenuItem TurnAround = new MenuItem("Turn Around", GoTurnAround);
        LocationMenu.AddItem(TurnAround);
        MenuItem RightTunnel = new MenuItem("Turn Around", GoRightTunnel);
        LocationMenu.AddItem(RightTunnel);
        MenuItem LeftTunnel = new MenuItem("Turn Around", GoLeftTunnel);
        LocationMenu.AddItem(LeftTunnel);
    }

    public void HandleInput(int option, GameState gs)
    {
        switch (option)
        {
            case 1:
                Narrator.WriteLine("You turn around.");
                gs.SetLocation(Forest.Instance);
                break;
            case 2:
                Narrator.WriteLine("You go down the right tunnel.");
                gs.SetLocation(RightTunnel.Instance);
                break;
            case 3:
                Narrator.WriteLine("You go down the left tunnel.");
                // TODO: Create Left tunnel room
                gs.SetLocation(Dungeon.Instance);
                break;
            default:
                break;
        }
    }


    private void GoTurnAround() {
        Narrator.WriteLine("You turn around and head back.");
        GameState.Instance.SetLocation(Forest.Instance);
    }

    private void GoRightTunnel() {
        Narrator.WriteLine("You head down the right tunnel.");
        GameState.Instance.SetLocation(RightTunnel.Instance);
    }

    private void GoLeftTunnel() {
        Narrator.WriteLine("You head down the left tunnel.");
        // TODO: Add set location for left tunnel when we make one
    }
    
}

