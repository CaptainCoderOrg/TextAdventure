
public class Cottage : ILocation
{
    public string Description => "You are standing in a small cottage.";

    public string Name => "Cottage";
    private List<string> options;

    public Cottage()
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
        switch (option) {
            case 1:
                Console.WriteLine("You exit the cottage.");
                // TODO: Create OutsideCottage room
                break;
            case 2:
                Console.WriteLine("You go down stairs.");
                gs.SetLocation(new DownStairs());
                break;
            case 3:
                Console.WriteLine("You examine the room");
                break;
            default:
                break;
        }
    }
}