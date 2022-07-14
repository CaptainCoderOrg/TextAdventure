// TODO: I would like to have a generic "inventory" or "pocket" command that lets
//       the player view their inventory. Our Menu system needs to have some kind
//       of "default" options available.

// TODO: I would like to have aliases for the commands you can type. Right now
//       the player needs to type the full text of a menu item out to execute it.
//       A work around right now is to create "hidden" menu items with the aliases.
//       For example, 

// TODO: Narrator writes super long lines that break poorly in my console. It would be nice to have a
//       max width that we could use to break lines nicely not in the middle of a word.
public class Cottage : ILocation
{
    public readonly static Cottage Instance = new();

    // TODO: I would like to be able to add color to the description
    //       I propose changing this from a field to a void method DisplayLocation()
    public string Description => GetDescription();

    public string Name => "";
    private readonly IItem _fishingPole = new FishingPole();
    private bool _hasExaminedRoom = false;
    private bool HasPole => GameState.Instance.Player.playerInventory.ItemsInInventory.ContainsKey(_fishingPole.Name);
    private readonly MenuItem _getPole, _putPole, _pole, _door;

    private readonly Menu _locationMenu;
    public Menu LocationMenu { get => GetMenu(); }

    public Cottage()
    {
        Narrator.AddKeyWords(ConsoleColor.Green, "cottage");
        Narrator.AddKeyWords(ConsoleColor.Yellow, "pole");
        _locationMenu = new Menu();
        MenuItem exit = new("Exit Cottage", Exit);
        MenuItem examine = new("Examine room", ExamineRoom);
        MenuItem cottage = new("cottage", ExamineRoom);
        _door = new("Go through Doorway", () => GameState.Instance.SetLocation(CottageKitchen.Instance))
        {
            IsEnabled = false
        };
        cottage.IsHidden = true;
        _getPole = new("Take fishing pole", FishingPole)
        {
            IsEnabled = false
        };
        _pole = new("pole", FishingPole)
        {
            IsEnabled = false,
            IsHidden = true
        };

        _putPole = new MenuItem("Put fishing pole on wall", FishingPole)
        {
            IsEnabled = false
        };
        // TODO: I keep forgetting to add the item to the list after making it. Maybe a nice
        //       way to ensure this doesn't happen?
        LocationMenu.AddItem(_door);
        LocationMenu.AddItem(exit);
        LocationMenu.AddItem(examine);
        LocationMenu.AddItem(_getPole);
        LocationMenu.AddItem(_putPole);
        LocationMenu.AddItem(_pole);
        LocationMenu.AddItem(cottage);
    }

    private Menu GetMenu()
    {
        // TODO: I think it might make sense to make IsEnabled an Action<bool> so we 
        //       can make it a delegated function.
        _getPole.IsEnabled = _hasExaminedRoom && !HasPole;
        _putPole.IsEnabled = _hasExaminedRoom && HasPole;
        _pole.IsEnabled = _hasExaminedRoom;
        _door.IsEnabled = _hasExaminedRoom;
        
        return _locationMenu;
    }

    private void DisplayLocation()
    {
        ConsoleColor orig = Console.ForegroundColor;
        Narrator.WriteLine("-----------");
        Narrator.WriteLine("| Cottage |");
        Narrator.WriteLine("-----------\n");
        Narrator.Write("You are standing in a small cottage.");
        if (HasPole)
        {
            Narrator.Write(" There is a spot on the wall to hang a fishing pole.");
        }
        else if (_hasExaminedRoom && !HasPole)
        {
            Narrator.Write(" There is a fishing pole hanging on the wall.");
        }
        Narrator.WriteLine("");
    }

    private string GetDescription()
    {
        // TODO: Hack to make colors work for now.
        DisplayLocation();
        return "";
    }

    private void Exit()
    {
        Narrator.Write("You exit the cottage.");
        GameState.Instance.SetLocation(Forest.Instance);
    }

    private void ExamineRoom()
    {
        Narrator.Write("This is your home, a small cottage.");
        if (!HasPole)
        {
            Narrator.Write(" On the wall is your fishing pole.");
            _getPole.IsEnabled = true;
        }
        Narrator.WriteLine(" There is a doorway leading further into the cottage and an exit leading out of the cottage.");
        _hasExaminedRoom = true;
    }

    private void FishingPole()
    {
        if (!GameState.Instance.Player.playerInventory.ItemsInInventory.ContainsKey(_fishingPole.Name))
        {
            Narrator.WriteLine("You take the fishing pole off the wall and jam it into your pocket.");
            _fishingPole.AddToInventory(GameState.Instance.Player);
            _getPole.IsEnabled = false;
            _putPole.IsEnabled = true;
        }
        else
        {
            Narrator.WriteLine("You take the fishing pole from your pocket and hang it on the wall.");
            GameState.Instance.Player.playerInventory.RemoveFromInventory(_fishingPole);
            _getPole.IsEnabled = true;
            _putPole.IsEnabled = false;
        }

    }
}