public class TunnelEntrance : ILocation
{

    public string Description => "You crawl down in a large tunnel. There's a fork in the tunnel.";

    public string Name => "Tunnel";
    private List<string> options;

    public TunnelEntrance()
    {
        options = new List<string>();
        options.Add("Turn Around");
        options.Add("Continue down the right tunnel");
        options.Add("Continue down the left tunnel");
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
                gs.SetLocation(new DownStairs());
                break;
            case 2:
                Narrator.WriteLine("You go down the right tunnel.");
                gs.SetLocation(new RightTunnel());
                break;
            case 3:
                Narrator.WriteLine("You go down the left tunnel.");
                // TODO: Create Left tunnel room
                break;
            default:
                break;
        }
    }
}