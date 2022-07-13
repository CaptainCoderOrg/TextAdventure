	public class Apple : IItem
	{
		public string Name => "Apple";
    public bool IsConsumable() => true;

		public void ItemEffect(Player player)
		{
			player.Hp += 5;
			player.playerInventory.RemoveFromInventory(this);
		}
		
		public void AddToInventory(Player player)
		{
			player.playerInventory.AddToInventory(this);

		}
	}
