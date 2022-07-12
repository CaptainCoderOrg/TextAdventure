public class Pathway : ILocation
{
    public readonly static Pathway Instance = new Pathway();
    public string Description => GetDescription();

    public string Name => "Pathway";
    private readonly IItem _LongSword = new LongSword();
    private readonly IItem _ShortSword = new ShortSword();

    private bool hasTakenLongSword => GameState.Instance.Player.Inventory.Contains(_LongSword);
    private bool hasTakenShortSword => GameState.Instance.Player.Inventory.Contains(_ShortSword);
    private bool discoveredLongSword = false;
    private bool discoveredShortSword = false;
    private readonly MenuItem _getLongSword, _getShortSword;

    public Menu LocationMenu { get; }

    public Pathway()
    {
        LocationMenu = new Menu();
        MenuItem exit = new ("Leave Pathway", Exit);
        MenuItem examine = new ("Examine", ExamineRoom);
        _getLongSword = new MenuItem("Take the LongSword", LongSword);
        _getLongSword.IsEnabled = false;
        _getShortSword = new MenuItem("take the ShortSword", ShortSword);
        _getShortSword.IsEnabled = false;
        LocationMenu.AddItem(exit);
        LocationMenu.AddItem(examine);
        LocationMenu.AddItem(_getLongSword);
        LocationMenu.AddItem(_getShortSword);
    }
    // Want to be able to update the characters stats. Have other stats besides the health 
    private string GetDescription()
    {
        string desc = "You are in a narrow pathway.";
        if (discoveredLongSword && !hasTakenLongSword)
        {
            desc += " A shiny LongSword stands in the pathway. It could be helpful.";
        }
        else if (hasTakenLongSword)
        {
            desc += " You can place the LongSword back. It is heavy.";
        }
        else if (discoveredShortSword && !hasTakenShortSword)
        {
            desc += " A shiny ShortSword stands in the pathway. Could be easy to use.";
        }
        else if (hasTakenShortSword)
        {
            desc += "You can place the ShortSword back.";
        }
        return desc;
    }

    private void Exit()
    {
        Narrator.WriteLine("You exit the pathway.");
        GameState.Instance.SetLocation(Dungeon.Instance);
    }

    private void ExamineRoom()
    {
        Narrator.Write("A long pathway stands in front of you. ");
        if (!hasTakenLongSword)
        {
            Narrator.WriteLine("A Long and Short Sword, weapons of destruction used to protect yourself are in the path.");
            _getLongSword.IsEnabled = true;
            _getShortSword.IsEnabled = true;
        }
        Narrator.WriteLine("");
        discoveredLongSword = true;
        discoveredShortSword = true;
    }

    private void LongSword()
    {
        if (!hasTakenLongSword)
        {
            Narrator.WriteLine("You take the Long Sword and firmly grasp it in your hand.");
        //    hasTakenLongSword = true;
            _getLongSword.IsEnabled = false;        }
        else
        {
            Narrator.WriteLine("You place the Long Sword back, afraid it does not fit your fighting style.");
            // hasTakenLongSword = false;
            _getLongSword.IsEnabled = true;
        }

    }
        private void ShortSword()
    {
        if (!hasTakenShortSword)
        {
            Narrator.WriteLine("You take the Short Sword and firmly grasp it in your hand.");

            _getShortSword.IsEnabled = false;        }
        else
        {
            Narrator.WriteLine("You place the Long Sword back, afraid it does not fit your fighting style.");
            // hasTakenLongSword = false;
            _getLongSword.IsEnabled = true;
        }

    }
}