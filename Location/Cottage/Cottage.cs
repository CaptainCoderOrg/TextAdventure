
public class Cottage : ILocation
{
    public readonly static Cottage Instance = new Cottage();
    public string Description => GetDescription();

    public string Name => "Cottage";
    private bool hasTakenFishingPole = false;
    private bool discoveredFishingPole = false;
    private readonly MenuItem _getPole, _takePole;

    public Menu LocationMenu { get; }

    public Cottage()
    {
        LocationMenu = new Menu();
        MenuItem exit = new ("Exit Cottage", Exit);
        MenuItem examine = new ("Examine room", ExamineRoom);
        _getPole = new MenuItem("Take fishing pole", FishingPole);
        _takePole = new MenuItem("Put fishing pole on wall", FishingPole);
        _getPole.IsEnabled = false;
        _takePole.IsEnabled = false;
        LocationMenu.AddItem(exit);
        LocationMenu.AddItem(examine);
        LocationMenu.AddItem(_getPole);
        LocationMenu.AddItem(_takePole);
    }

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

    private void Exit()
    {
        Narrator.WriteLine("You exit the cottage.");
        GameState.Instance.SetLocation(Forest.Instance);
    }

    private void ExamineRoom()
    {
        Narrator.Write("This is your home, a small cottage.");
        if (!hasTakenFishingPole)
        {
            Narrator.Write(" On the wall is your fishing pole.");
            _getPole.IsEnabled = true;
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
            _getPole.IsEnabled = false;
            _takePole.IsEnabled = true;
        }
        else
        {
            Narrator.WriteLine("You take the fishing pole from your pocket and hang it on the wall.");
            hasTakenFishingPole = false;
            _getPole.IsEnabled = true;
            _takePole.IsEnabled = false;
        }

    }
}