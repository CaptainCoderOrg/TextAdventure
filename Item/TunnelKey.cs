public class TunnelKey : IItem
{
    public string Name => "Tunnel Key";

    public void AddToInventory(Player player)
    {
        player.Inventory.Add(this);
    }
}