public class DownStairs : ILocation
{
    public string Description => "You are downstairs in your cottage.";

    public string Name => "Downstairs";

    private List<string> options;
    public DownStairs()
    {
        options = new List<string>();
        options.Add("Exit Cottage");
        options.Add("Go Down Stairs");
        options.Add("Examine Room");
    }

    public List<string> GetOptions()
    {
        return options;
    }

    public void HandleInput(int option, GameState gs)
    {
        throw new NotImplementedException();
    }
}