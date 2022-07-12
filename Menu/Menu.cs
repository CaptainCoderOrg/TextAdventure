
public class Menu
{
    private readonly Dictionary<string, MenuItem> options;

    public Menu()
    {
        this.options = new Dictionary<string, MenuItem>();
    }

    public void AddItem(MenuItem toAdd)
    {
        this.options[toAdd.Name.ToLower().Trim()] = toAdd;
    }

    public void DisplayMenu()
    {
        int ix = 1;
        List<MenuItem> numberedItems = new List<MenuItem>();
        foreach (MenuItem menuItem in options.Values)
        {
            if (menuItem.IsHidden || !menuItem.IsEnabled) continue;
            numberedItems.Add(menuItem);
            Narrator.WriteLine($"{ix}. {menuItem.Name}");
            ix++;
        }
        Narrator.Write("> ");
        string userChoice = Console.ReadLine()!;
        HandleChoice(userChoice, numberedItems);
    }

    public bool HandleChoice(string userInput, List<MenuItem> numberedItems)
    {
        userInput = userInput.ToLower().Trim();
        if (options.TryGetValue(userInput, out MenuItem? menuItem))
        {
            return HandleStringChoice(menuItem, userInput);
        }
        else if (int.TryParse(userInput, out int choice))
        {
            return HandleNumberedChoice(choice, userInput, numberedItems);
        }

        Narrator.WriteLine($"I don't know how to '{userInput}'.");
        return false;
    }

    private static bool HandleNumberedChoice(int choice, string userInput, List<MenuItem> numberedItems)
    {
        if (choice < 1 || choice > numberedItems.Count)
        {
            Narrator.WriteLine($"Invalid option '{userInput}'.");
            return false;
        }
        numberedItems[choice - 1].Effect.Invoke();
        return true;
    }

    private static bool HandleStringChoice(MenuItem menuItem, string userInput)
    {
        if (menuItem == null) throw new NullReferenceException($"Something terrible has happened. The key: '{userInput}' was valid but returned a null MenuItem.");
        if (!menuItem.IsEnabled)
        {
            Narrator.WriteLine($"That option is not available.");
            return false;
        }
        menuItem.Effect.Invoke();
        return true;
    }

}

public class MenuItem
{

    public string Name { get; }
    public Action Effect { get; }
    public bool IsHidden { get; set; } = false;
    public bool IsEnabled { get; set; } = true;

    public MenuItem(String name, Action effect)
    {
        this.Name = name;
        this.Effect = effect;
    }

}