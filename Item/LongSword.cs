public class LongSword : IItem
{
    public string Name => "Long Sword";
    
    public void ItemEffect()
    {
        Console.WriteLine("You slowly swing the Long Sword");
    }
    public void AddToInventory(Player player)
    {
        player.playerInventory.AddToInventory(this);

    }
}