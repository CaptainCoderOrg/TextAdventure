	public class Key : IItem
	{
		public string Name => "Apple";
    public bool IsConsumable() => true;


		public void ItemEffect(Player player)
		{
		
		}
		
		public void AddToInventory(Player player)
		{
			player.playerInventory.AddToInventory(this);

		}
	}
