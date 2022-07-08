	public class Apple : IItem
	{
		public string Name => "Apple";
		
		public void ItemEffect(Player player)
		{
			player.Hp += 5;
			player.Inventory.Remove(this);
		}
		
		public void AddToInventory(Player player)
		{
			player.Inventory.Add(this);

		}
	}
