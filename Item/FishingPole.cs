public class FishingPole : IItem
{
    public string Name => "Fishing Pole";
    
    public void ItemEffect()
    {
        Console.WriteLine("You cast out your line!");
    }
    public void AddToInventory(Player player)
    {
        player.Inventory.Add(this);

    }
}