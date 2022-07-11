//To do: max hitpoints, math clamp hitpoints


public class Player : LivingEntity
{
    public Menu inventoryMenu = new Menu();
	public Player(int hp, int level) : base(hp, level)
    {
    }


    public void DisplayStatus()
    {
        Narrator.WriteLine($"Level: {this.Level} | HP: {this.Hp} / {this.MaxHp}");
    }

    public void DisplayInventory()
    {
        foreach(IItem item in Inventory)
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
