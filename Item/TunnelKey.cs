public class TunnelKey : IItem
{
    public string Name => "Tunnel Key";

    public void AddToInventory(Player player)
    {
        player.playerInventory.AddToInventory(this);
    }
}