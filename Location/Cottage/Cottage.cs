
public class Cottage : ILocation
{
    public readonly static Cottage Instance = new Cottage();
    public string Description => GetDescription();

    public string Name => "Cottage";
    private bool hasTakenFishingPole = false;
    private bool discoveredFishingPole = false;

    private List<string> options;
    private List<Action<GameState>> optionResults;

    private string GetDescription()
    {
        string desc = "You are standing in a small cottage.";
        if (discoveredFishingPole && !hasTakenFishingPole)
        {
            desc += " There is a fishing pole on the wall.";
        }
        else if (hasTakenFishingPole)
        {
            desc += " There is a spot on the wall to hang a fishing pole.";
        }
        return desc;
    }

    public List<string> GetOptions()
    {
        options = new List<string>();
        optionResults = new List<Action<GameState>>();
        options.Add("Exit Cottage");
        optionResults.Add((gs) => Exit(gs));

        options.Add("Examine Room");
        optionResults.Add((gs) => ExamineRoom());

        if (discoveredFishingPole && !hasTakenFishingPole)
        {
            options.Add("Take Fishing Pole");
            optionResults.Add((gs) => FishingPole());
        }
        else if (hasTakenFishingPole)
        {
            options.Add("Put fishing pole on wall.");
            optionResults.Add((gs) => FishingPole());
        }
        return options;
    }

    public void HandleInput(int option, GameState gs)
    {
        Action<GameState> action = optionResults[option-1];
        action.Invoke(gs);
    }

    private void Exit(GameState gs)
    {
        Narrator.WriteLine("You exit the cottage.");
        gs.SetLocation(Forest.Instance);
    }

    private void ExamineRoom()
    {
        Narrator.Write("This is your home, a small cottage.");
        if (!hasTakenFishingPole)
        {
            Narrator.Write(" On the wall is your fishing pole.");
        }
        Narrator.WriteLine("");
        discoveredFishingPole = true;
    }

    private void FishingPole()
    {
        if (!hasTakenFishingPole)
        {
            Narrator.WriteLine("You take the fishing pole off the wall and jam it into your pocket.");
            hasTakenFishingPole = true;
        }
        else
        {
            Narrator.WriteLine("You take the fishing pole from your pocket and hang it on the wall.");
            hasTakenFishingPole = false;
        }

    }
}