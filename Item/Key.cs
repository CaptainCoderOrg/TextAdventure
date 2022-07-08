	public class Key : IItem
	{
		public string Name => "Apple";
		
		public void ItemEffect(Player player)
		{
		
		}
		
		public void AddToInventory(Player player)
		{
			player.Inventory.Add(this);

		}
	}
