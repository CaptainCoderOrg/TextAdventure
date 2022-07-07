public class FishingPole : IItem
{
    public string name => "Fishing Pole";
    
    public FishingPole(string Name)
    {
        this.name = name;
    }
    public void ItemEffect()
    {
        Console.WriteLine("You cast out your line!");
    }
    public void AddToInventory(Player player)
    {
        player.Inventory.Add(this);

    }
}