public class Inventory
{
	Dictionary<string, IItem> ItemsInInventory = new Dictionary<string, IItem>();
	
	
	public void AddToInventory(IItem item)
	{
		ItemsInInventory.Add(item.Name, item);
	}

  	public void RemoveFromInventory(IItem item)
	{
		ItemsInInventory.Remove(item.Name);
	}
	
	public void DisplayInventory()
	{
		foreach(KeyValuePair <string, IItem> items in this.ItemsInInventory)
		{
			Console.WriteLine($"Item: {items.Key}");	
		}
	}
	
	public void UseItem(string item)
	{
		if(ItemsInInventory.ContainsKey(item))
		{
			IItem x = ItemsInInventory[item];
			x.ItemEffect();
		}
		else
		{
			Console.WriteLine("I don't think I have that item");
		}
	}
}
