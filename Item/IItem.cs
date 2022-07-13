public interface IItem
{	
    public string Name { get; }
    public void ItemEffect(){}
    public void AddToInventory(Player player);
    public bool IsConsumable()
    {
      return false;
    }
}