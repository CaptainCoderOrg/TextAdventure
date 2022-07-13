public class ShortSword : IItem
{
    // TODO: Create a class called weapon that is a subclass of item where you can implement damage
    public string Name => "Short Sword";
    
    public void ItemEffect()
    {
        Console.WriteLine("You quickly attack with the short sword");
    }
    public void AddToInventory(Player player)
    {
        player.playerInventory.AddToInventory(this);

    }
}