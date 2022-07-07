public class TunnelEntrance : ILocation
{
    public static readonly TunnelEntrance Instance = new TunnelEntrance();
    public string Description => "You crawl down in a large tunnel. There's a fork in the tunnel.";

    public string Name => "Tunnel";
    // private List<string> options;
    private Menu menu;


    public TunnelEntrance()
    {
        menu = new Menu();
        MenuItem turnAround = new MenuItem("Turn Around", TurnAround);
        menu.AddItem(turnAround);
        MenuItem rightTunnel = new MenuItem("Turn Around", RightTunnel);
        menu.AddItem(rightTunnel);
        MenuItem leftTunnel= new MenuItem("Turn Around", LeftTunnel);
        menu.AddItem(leftTunnel);
        // options = new List<string>();
        
        // options.Add("Continue down the right tunnel");
        // options.Add("Continue down the left tunnel");
    }

    // public List<string> GetOptions()
    // {
    //     return options;
    // }

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


private void TurnAround()
    Narrator.WriteLine($"")
}

