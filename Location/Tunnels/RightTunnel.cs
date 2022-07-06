public class RightTunnel : ILocation
{
    public static readonly RightTunnel Instance = new RightTunnel();
    public string Description => "You take a sharp right turn down the tunnel and walk for 2 miles.";

    public string Name => "Right Tunnel";
    private List<string> options;

    public RightTunnel()
    {
        options = new List<string>();
        options.Add("Turn around.");
        options.Add("Jump in the waterfall.");
        options.Add("Open the secret door.");
    }

    public List<string> GetOptions()
    {
        return options;
    }

    public void HandleInput(int option, GameState gs)
    {
        switch (option)
        {
            case 1:
                Narrator.WriteLine("You turn around.");
                gs.SetLocation(new TunnelEntrance());
                break;
            case 2:
                Narrator.WriteLine("You jump in the waterfall.");
                //TODO: Create waterfall room
                break;
            case 3:
                Narrator.WriteLine("You open the secret door.");
                // TODO: Create secret door room
                break;
            default:
                break;

        }
    }
}