
public class Cottage : ILocation
{
    public string Description => GetDescription();

    public string Name => "Cottage";
    private bool hasTakenFishingPole = false;
    private bool discoveredFishingPole = false;

    private ILocation _garden = new GardenPath();
    private List<string> options;

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
        options.Add("Exit Cottage");
        options.Add("Examine Room");
        if (discoveredFishingPole && !hasTakenFishingPole)
        {
            options.Add("Take Fishing Pole");
        }
        else if (hasTakenFishingPole)
        {
            options.Add("Put fishing pole on wall.");
        }
        return options;
    }

    public void HandleInput(int option, GameState gs)
    {
        string choice = options[option-1];
        switch (choice)
        {
            case "Exit Cottage":
                Exit(gs);
                break;
            case "Examine Room":
                ExamineRoom();
                break;
            case "Put fishing pole on wall.":
            case "Take Fishing Pole":
                FishingPole();
                break;
            default:
                break;
        }
    }

    private void Exit(GameState gs)
    {
        Narrator.WriteLine("You exit the cottage.");
        gs.SetLocation(_garden);
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