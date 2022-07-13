//To do: max hitpoints, math clamp hitpoints


public class Player : LivingEntity
{
    public Menu inventoryMenu = new Menu();
    public Player(int hp, int level) : base(hp, level)
    {
        this.hpState = StateOfChange.Same;
        this.levelState = StateOfChange.Same;
    }

    public void DisplayStatus()
    {
        Narrator.Write("Level: ");
        DisplayLevel();
        Narrator.Write(" | HP: ");
        DisplayHp();
        Narrator.WriteLine($" / {this.MaxHp}");

    }

    private void DisplayHp()
    {
        switch (this.hpState)
        {
            case StateOfChange.Decreased:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case StateOfChange.Increased:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case StateOfChange.Same:
                Console.ForegroundColor = ConsoleColor.White;
                break;
            default:
                break;
        }
        this.hpState = StateOfChange.Same;
        Narrator.Write($"{this.Hp}");
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void DisplayLevel()
    {
        switch (this.levelState)
        {
            case StateOfChange.Decreased:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case StateOfChange.Increased:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case StateOfChange.Same:
                Console.ForegroundColor = ConsoleColor.White;
                break;
            default:
                break;
        }
        this.levelState = StateOfChange.Same;
        Narrator.Write($"{this.Level}");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void DisplayInventory()
    {
        foreach (IItem item in Inventory)
        {
            Narrator.WriteLine($"{item}");
            // MenuItem item = new MenuItem($"{item}", UseItem(item));
            // inventoryMenu.AddItem();
        }

    }

    // private void UseItem(IItem item)
    // {
    //     item.ItemEffect();
    // }
}
