//To do: max hitpoints, math clamp hitpoints


public class Player : LivingEntity
{
    public Menu inventoryMenu = new Menu();
    public readonly Inventory playerInventory = new Inventory();
    public Player(int hp, int level, Inventory playerInventory) : base(hp, level) { }

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
        if (this._didHpDecrease)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        Narrator.Write($"{this.Hp}");
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void DisplayLevel()
    {
        // TODO: Implement color changing ability
        Narrator.Write($"{this.Level}");
    }
}
